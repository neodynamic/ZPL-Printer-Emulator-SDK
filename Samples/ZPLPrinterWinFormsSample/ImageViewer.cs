using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZPLPrinterWinFormsSample
{
    public partial class ImageViewer : UserControl
    {
        int iCurrPage = 1, iPages = 1;

        public ImageViewer()
        {
            InitializeComponent();
        }



        string[] imgFiles = null;
        public void LoadImages(string folder, string imageExtension)
        {
            picLabel.Image = null;

            if (Directory.Exists(folder))
            {
                imgFiles = Directory.GetFiles(folder, "*." + imageExtension);


                //currentImage = Image.FromStream(imgStream);
                iCurrPage = 1;
                this.RefreshImage();
            }
        }

        public void RefreshImage()
        {
            iPages = imgFiles.Length;
            cmdNext.Visible = cmdPrev.Visible = (iPages > 1);
            lblNumOfLabels.Text = "Label " + iCurrPage.ToString() + " of " + iPages.ToString();
            using (FileStream fs = new FileStream(imgFiles[iCurrPage - 1], FileMode.Open, FileAccess.Read))
                picLabel.Image = Image.FromStream(fs);
            this.SetImageLocation();
        }

        public void Clear() { if (picLabel.Image != null) picLabel.Image.Dispose(); }

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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.SetImageLocation();
        }

    }
}
