using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using System.IO.Compression;
using Neodynamic.SDK.ZPLPrinter;
using System.Web;

namespace ZPLPrinterAspNetCoreSample.Controllers
{
    public class ProcessZPLController : Controller
    {
        private IHostingEnvironment _env;
        private HttpContext _ctx;

        public ProcessZPLController(IHostingEnvironment env, IHttpContextAccessor ctx)
        {
            _env = env;
            _ctx = ctx.HttpContext;
        }

        public async void ProcessRequest()
        {

            //Get data for rendering process...
            string lstPrinterDpi = _ctx.Request.Form["lstPrinterDpi"];
            string txtLabelWidth = _ctx.Request.Form["txtLabelWidth"];
            string txtLabelHeight = _ctx.Request.Form["txtLabelHeight"];
            string cpRibbonColor = _ctx.Request.Form["cpRibbonColor"];
            string cpBackColor = _ctx.Request.Form["cpBackColor"];
            string lstOutputFormat = _ctx.Request.Form["lstOutputFormat"];
            string lstOutputRotate = _ctx.Request.Form["lstOutputRotate"];
            string zplCommands = _ctx.Request.Form["zplCommands"];

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
                    zplPrinter.AntiAlias = (_ctx.Request.Form["chkAntialias"].Count > 0);
                    //set label size
                    zplPrinter.LabelWidth = float.Parse(txtLabelWidth) * zplPrinter.Dpi;
                    if (zplPrinter.LabelWidth <= 0) zplPrinter.LabelWidth = 4;
                    zplPrinter.ForceLabelWidth = (_ctx.Request.Form["chkForceLabelWidth"].Count > 0);
                    zplPrinter.LabelHeight = float.Parse(txtLabelHeight) * zplPrinter.Dpi;
                    if (zplPrinter.LabelHeight <= 0) zplPrinter.LabelHeight = 6;
                    zplPrinter.ForceLabelHeight = (_ctx.Request.Form["chkForceLabelHeight"].Count > 0);
                    //Set Label BackColor
                    zplPrinter.LabelBackColor = cpBackColor;
                    //Set Ribbon Color
                    zplPrinter.RibbonColor = cpRibbonColor;
                    //Set image or doc format for output rendering 
                    zplPrinter.RenderOutputFormat = (RenderOutputFormat)Enum.Parse(typeof(RenderOutputFormat), lstOutputFormat);
                    //Set rotation for output rendering
                    zplPrinter.RenderOutputRotation = (RenderOutputRotation)Enum.Parse(typeof(RenderOutputRotation), lstOutputRotate);
                    //Set text encoding
                    Encoding enc = (_ctx.Request.Form["chkUTF8"].Count > 0 ? Encoding.UTF8 : Encoding.GetEncoding(850));

                    var buffer = zplPrinter.ProcessCommands(zplCommands, enc);

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
                        else if (zplPrinter.RenderOutputFormat == RenderOutputFormat.PCX)
                        {
                            //If there're more than one file, then zip them...
                            if (buffer.Count > 1)
                            {
                                using (var outStream = new MemoryStream())
                                {
                                    using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
                                    {
                                        for (int i = 0; i < buffer.Count; i++)
                                        {
                                            var fileInArchive = archive.CreateEntry($"Label{i.ToString()}.pcx", CompressionLevel.Optimal);
                                            using (var entryStream = fileInArchive.Open())
                                            using (var fileToCompressStream = new MemoryStream(buffer[i]))
                                            {
                                                fileToCompressStream.CopyTo(entryStream);
                                            }
                                        }
                                    }
                                    json.Append($"\"labelPCX\":\"data:application/zip;base64,{Convert.ToBase64String(outStream.ToArray())}\"");
                                }
                            }
                            else
                            {
                                json.Append($"\"labelPCX\":\"data:image/pcx;base64,{Convert.ToBase64String(buffer[0])}\"");
                            }
                        }
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

            _ctx.Response.ContentType = "application/json";
            await _ctx.Response.WriteAsync(json.ToString());

            
        }
    }
}
