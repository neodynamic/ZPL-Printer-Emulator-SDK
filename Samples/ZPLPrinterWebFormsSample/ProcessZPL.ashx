<%@ WebHandler Language="C#" Class="ProcessZPL" %>

using System;
using System.Web;
using System.Text;
using System.IO;
using System.IO.Compression;
using Neodynamic.SDK.ZPLPrinter;

public class ProcessZPL : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //Get data for rendering process...
        string lstPrinterDpi = context.Request["lstPrinterDpi"];
        string txtLabelWidth = context.Request["txtLabelWidth"];
        string txtLabelHeight = context.Request["txtLabelHeight"];
        string cpRibbonColor = context.Request["cpRibbonColor"];
        string cpBackColor = context.Request["cpBackColor"];
        string lstOutputFormat = context.Request["lstOutputFormat"];
        string lstOutputRotate = context.Request["lstOutputRotate"];
        string zplCommands = context.Request["zplCommands"];

        var json = new StringBuilder();
        json.Append("{");

        try
        {

            if (string.IsNullOrEmpty(zplCommands)) throw new ArgumentException("Please specify some ZPL commands.");

            //Create an instance of ZPLPrinter class
            using (var zplPrinter = new ZPLPrinter("LICENSE OWNER", "LICENSE KEY"))
            {
                //Set printer DPI
                //The DPI value to be set must match the value for which 
                //the ZPL commands to be processed were created!!!
                zplPrinter.Dpi = float.Parse(lstPrinterDpi.Substring(0, 3));
                //Apply antialiasing?
                zplPrinter.AntiAlias = (context.Request["chkAntialias"] != null);
                //set label size
                zplPrinter.LabelWidth = float.Parse(txtLabelWidth) * zplPrinter.Dpi;
                if (zplPrinter.LabelWidth <= 0) zplPrinter.LabelWidth = 4;
                zplPrinter.ForceLabelWidth = (context.Request["chkForceLabelWidth"] != null);
                zplPrinter.LabelHeight = float.Parse(txtLabelHeight) * zplPrinter.Dpi;
                if (zplPrinter.LabelHeight <= 0) zplPrinter.LabelHeight = 6;
                zplPrinter.ForceLabelHeight = (context.Request["chkForceLabelHeight"] != null);
                //Set Label BackColor
                zplPrinter.LabelBackColor = cpBackColor;
                //Set Ribbon Color
                zplPrinter.RibbonColor = cpRibbonColor;
                //Set image or doc format for output rendering 
                zplPrinter.RenderOutputFormat = (RenderOutputFormat)Enum.Parse(typeof(RenderOutputFormat), lstOutputFormat);
                //Set rotation for output rendering
                zplPrinter.RenderOutputRotation = (RenderOutputRotation)Enum.Parse(typeof(RenderOutputRotation), lstOutputRotate);
                //Set text encoding
                Encoding enc = (context.Request["chkUTF8"] != null ? Encoding.UTF8 : Encoding.GetEncoding(850));

                var buffer = zplPrinter.ProcessCommands(zplCommands, enc, true);

                // the buffer variable contains the binary output of the ZPL rendering result
                // The format of this buffer depends on the RenderOutputFormat property setting
                if (buffer != null && buffer.Count > 0)
                {
                    if (zplPrinter.RenderOutputFormat == RenderOutputFormat.PNG ||
                        zplPrinter.RenderOutputFormat == RenderOutputFormat.JPG)
                    {
                        json.Append("\"labelImages\":[");

                        for (int i = 0; i < buffer.Count; i++)
                        {

                            json.Append($"\"data:image/{zplPrinter.RenderOutputFormat.ToString().ToLower()};base64,{Convert.ToBase64String(buffer[i])}\"");
                            if (i < buffer.Count - 1) json.Append(",");
                        }

                        json.Append("]");
                    }
                    else if (zplPrinter.RenderOutputFormat == RenderOutputFormat.PDF)
                    {
                        json.Append($"\"labelPDF\":\"data:application/pdf;base64,{Convert.ToBase64String(buffer[0])}\"");
                    }
                    else
                    {
                        string fileExt = zplPrinter.RenderOutputFormat.ToString().ToLower();
                        //If there're more than one file, then zip them...
                        if (buffer.Count > 1)
                        {
                            using (var outStream = new MemoryStream())
                            {
                                using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
                                {
                                    for (int i = 0; i < buffer.Count; i++)
                                    {
                                        var fileInArchive = archive.CreateEntry($"Label{i.ToString()}.{fileExt}", CompressionLevel.Optimal);
                                        using (var entryStream = fileInArchive.Open())
                                        using (var fileToCompressStream = new MemoryStream(buffer[i]))
                                        {
                                            fileToCompressStream.CopyTo(entryStream);
                                        }
                                    }
                                }
                                json.Append($"\"labelBinaries\":\"data:application/zip;base64,{Convert.ToBase64String(outStream.ToArray())}\"");
                            }
                        }
                        else
                        {
                            json.Append($"\"labelBinaries\":\"data:application/octet-stream;base64,{Convert.ToBase64String(buffer[0])}\"");
                        }
                    }

                    json.Append($",\"renderedElements\":" + zplPrinter.RenderedElementsAsJson);

                }
                else
                    throw new ArgumentException("No output available for the specified ZPL commands.");
            }
        }
        catch (Exception ex)
        {
            json.Append("\"error\":");
            json.Append($"\"{HttpUtility.JavaScriptStringEncode(ex.Message)}\"");
        }

        json.Append("}");

        HttpContext.Current.Response.ContentType = "application/json";
        HttpContext.Current.Response.Write(json.ToString());
        HttpContext.Current.Response.End();
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
