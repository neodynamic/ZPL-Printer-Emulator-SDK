using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Neodynamic.SDK.ZPLPrinter;

namespace ZPLPrinterWinFormsSample
{
    public partial class ImageViewer : UserControl
    {
        ZPLPrinter _zplPrinter = null;

        int iCurrPage = 1, iPages = 1;

        public ImageViewer()
        {
            InitializeComponent();
        }

        string[] imgFiles = null;
        public void LoadImages(string folder, ref ZPLPrinter zplPrinter)
        {
            _zplPrinter = zplPrinter;

            picLabel.Image = null;

            if (Directory.Exists(folder))
            {
                imgFiles = Directory.GetFiles(folder, "*." + _zplPrinter.RenderOutputFormat.ToString());


                //currentImage = Image.FromStream(imgStream);
                iCurrPage = 1;
                this.RefreshImage();
            }
        }

        public void RefreshImage()
        {
            iPages = imgFiles.Length;
            btnNext.Visible = btnPrev.Visible = cmdNext.Visible = cmdPrev.Visible = (iPages > 1);
            lblNumOfLabels.Text = "Label " + iCurrPage.ToString() + " of " + iPages.ToString();
            using (FileStream fs = new FileStream(imgFiles[iCurrPage - 1], FileMode.Open, FileAccess.Read))
                picLabel.Image = Image.FromStream(fs);
            this.SetImageLocation();

            // display rendered elements if any
            this.lstZPLElements.Items.Clear();
            if(_zplPrinter != null && _zplPrinter.RenderedElements != null && _zplPrinter.RenderedElements.Count> 0)
            {
                foreach(var zplElem in _zplPrinter.RenderedElements[iCurrPage - 1])
                {
                    this.lstZPLElements.Items.Add(string.IsNullOrEmpty(zplElem.Content) ? "^" + zplElem.Name : string.Format("^{0}: `{1}`", zplElem.Name, zplElem.Content));
                }
            }

        }

        public void Clear() { 
            if (picLabel.Image != null) picLabel.Image.Dispose();

            this.lstZPLElements.Items.Clear();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (iCurrPage > 1)
            {
                iCurrPage--;
                this.RefreshImage();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (iCurrPage < iPages)
            {
                iCurrPage++;
                this.RefreshImage();
            }
        }

        private void SetImageLocation()
        {
            int x = 0;
            int y = 0;

            if (picLabel.Width > pnlContainer.ClientRectangle.Width)
            {
                x = 0;
            }
            else
            {
                x = (pnlContainer.ClientRectangle.Width - picLabel.Width) / 2;
            }

            if (picLabel.Height > pnlContainer.ClientRectangle.Height)
            {
                y = 0;
            }
            else
            {
                y = (pnlContainer.ClientRectangle.Height - picLabel.Height) / 2;
            }

            picLabel.Location = new Point(x, y);
        }

        private void lstZPLElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZPLElement zplElem = null;
            if(this.lstZPLElements.SelectedIndex >= 0)
            {
                zplElem = _zplPrinter.RenderedElements[iCurrPage - 1][this.lstZPLElements.SelectedIndex];
            }
            HighlightZplElem(zplElem);
        }

        private void HighlightZplElem(ZPLElement zplElem)
        {
            using (FileStream fs = new FileStream(imgFiles[iCurrPage - 1], FileMode.Open, FileAccess.Read))
            {
                var imgLabel = Image.FromStream(fs);

                if (zplElem != null)
                {
                    using (var gfx = Graphics.FromImage(imgLabel))
                    {
                        using (var brush = new SolidBrush(Color.FromArgb(128, Color.DeepSkyBlue)))
                        {
                            gfx.FillRectangle(brush, new Rectangle(zplElem.X, zplElem.Y, zplElem.Width, zplElem.Height));
                        }
                    }
                }
                picLabel.Image = imgLabel;
                this.SetImageLocation();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.SetImageLocation();
        }

    }
}
