using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using Neodynamic.SDK.ZPLPrinter;
using SkiaSharp;

namespace ZPLPrinterWinFormsSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Create an instance of ZPLPrinter class
        ZPLPrinter zplPrinter = new ZPLPrinter("LICENSE_OWNER_HERE", "LICENSE_KEY_HERE");

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load supported output rendering formats and rotation options
            cboOutputFormat.DataSource = Enum.GetNames(typeof(RenderOutputFormat));
            cboOutputRotation.DataSource = Enum.GetNames(typeof(RenderOutputRotation));

            //Select default DPI printer
            this.cboDpi.SelectedIndex = 1; //203 dpi

            //set default label size
            this.nudLabelWidth.Value = 4;
            this.nudLabelHeight.Value = 6;

        }

       
        private void btnPreviewZpl_Click(object sender, EventArgs e)
        {
            //Prepare ZPLPrinter
            this.PrepareZPLPrinter();

            try
            {
                //Let ZPLPrinter to process the specified ZPL commands
                //and display rendering output if any...
                DisplayRenderOutput(zplPrinter.ProcessCommands(this.txtZPLCommands.Text));
            }
            catch (Exception ex)
            {
                this.imgViewer.Clear();
                MessageBox.Show(ex.Message);
            }

        }

        private void btnOpenZplFile_Click(object sender, EventArgs e)
        {
            //Open file containing ZPL commands...
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Prepare ZPLPrinter
                this.PrepareZPLPrinter();

                try
                {
                    //display commands from file
                    this.txtZPLCommands.Text = System.IO.File.ReadAllText(ofd.FileName);

                    //Let ZPLPrinter to process the specified file containing ZPL commands
                    //and display rendering output if any...
                    DisplayRenderOutput(zplPrinter.ProcessCommandsFromFile(ofd.FileName));
                }
                catch (Exception ex)
                {
                    this.imgViewer.Clear();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DisplayRenderOutput(List<byte[]> buffer)
        {
            // the buffer param contains the binary output of the ZPL rendering result
            // The format of this buffer depends on the RenderOutputFormat property setting
            if (buffer != null && buffer.Count > 0)
            {
                if (zplPrinter.RenderOutputFormat == RenderOutputFormat.PNG ||
                    zplPrinter.RenderOutputFormat == RenderOutputFormat.JPG)
                {
                    //temp folder for holding thermal label images
                    this.imgViewer.Clear();
                    string myDir = Directory.GetCurrentDirectory() + @"\temp\";
                    if (Directory.Exists(myDir) == false) Directory.CreateDirectory(myDir);
                    DirectoryInfo di = new DirectoryInfo(myDir);
                    foreach (FileInfo file in di.GetFiles()) file.Delete();

                    try
                    {
                        //save images on disk 
                        for(int i = 0; i < buffer.Count; i++)
                        {
                            File.WriteAllBytes(myDir + "Image" + i.ToString().PadLeft(buffer.Count, '0') + "." + zplPrinter.RenderOutputFormat.ToString(), buffer[i]);
                        }
                        //preview them
                        this.imgViewer.LoadImages(myDir, zplPrinter.RenderOutputFormat.ToString());
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    

                }
                else if (zplPrinter.RenderOutputFormat == RenderOutputFormat.PDF)
                {
                    var sd = new SaveFileDialog();
                    sd.Filter = "Portable Document Format (*.pdf)|*.pdf";
                    sd.DefaultExt = "pdf";
                    sd.AddExtension = true;
                    if (sd.ShowDialog() == DialogResult.OK)
                        System.IO.File.WriteAllBytes(sd.FileName, buffer[0]);
                }
                else if (zplPrinter.RenderOutputFormat == RenderOutputFormat.PCX)
                {
                    var sd = new SaveFileDialog();
                    sd.Filter = "PiCture eXchange (*.pcx)|*.pcx";
                    sd.DefaultExt = "pcx";
                    sd.AddExtension = true;
                    if (sd.ShowDialog() == DialogResult.OK)
                        System.IO.File.WriteAllBytes(sd.FileName, buffer[0]);
                }
            }
        }


        private void PrepareZPLPrinter()
        {
            //ZPLPrinter acts as a virtual printer...
            //Some ZPL commands could upload labels, graphics, fonts 
            //and /or modify global printer settings
            //that can be used by other commands...
            //So, by Resetting the printer before processing ZPL commands
            //will make the printer to clear settings and any resources uploaded by previous commands
            if (this.chkResetPrinter.Checked)
                zplPrinter.PowerOnReset();

            //Set printer DPI
            //The DPI value to be set must match the value for which 
            //the ZPL commands to be processed were created!!!
            zplPrinter.Dpi = float.Parse(cboDpi.SelectedItem.ToString().Substring(0, 3));

            //set label size
            zplPrinter.LabelWidth = (float)this.nudLabelWidth.Value * zplPrinter.Dpi;
            zplPrinter.LabelHeight = (float)this.nudLabelHeight.Value * zplPrinter.Dpi;
            
            //Apply antialiasing?
            zplPrinter.AntiAlias = this.chkAntiAlias.Checked;
            
            //Set image or doc format for output rendering 
            zplPrinter.RenderOutputFormat = (RenderOutputFormat)Enum.Parse(typeof(RenderOutputFormat), cboOutputFormat.SelectedValue.ToString());

            //Set rotation for output rendering
            zplPrinter.RenderOutputRotation = (RenderOutputRotation)Enum.Parse(typeof(RenderOutputRotation), cboOutputRotation.SelectedValue.ToString());

            //Set Ribbon Color
            zplPrinter.RibbonColor = ColorToHex(this.btnRibbonColor.BackColor);

            //Set Label BackColor
            zplPrinter.LabelBackColor = ColorToHex(this.btnLabelBackColor.BackColor);

        }

        private string ColorToHex(Color c)
        {
            return string.Format("{0}{1}{2}{3}",
                Convert.ToString(c.A, 16).PadLeft(2, '0'),
                Convert.ToString(c.R, 16).PadLeft(2, '0'),
                Convert.ToString(c.G, 16).PadLeft(2, '0'),
                Convert.ToString(c.B, 16).PadLeft(2, '0'));
        }

        
        private void btnRibbonColor_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            cd.Color = this.btnRibbonColor.BackColor;
            if(cd.ShowDialog() == DialogResult.OK)
            {
                this.btnRibbonColor.BackColor = cd.Color;
            }
        }

        private void btnLabelBackColor_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            cd.Color = this.btnLabelBackColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                this.btnLabelBackColor.BackColor = cd.Color;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {   
            zplPrinter.Dispose();
        }
    }
}
