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
    public partial class PrinterStorage : Form
    {
        public PrinterStorage()
        {
            InitializeComponent();
        }

        enum PrinterResourceType
        {
            None,
            Font,
            Graphic
        }

        PrinterResourceType _resourceType = PrinterResourceType.None;

        public ZPLPrinter VirtualPrinter { get; set; }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            picPreview.Image = null;

            int index = listBox1.SelectedIndex;
            if (index != -1 && VirtualPrinter != null)
            {
                nameTxt.Text = listBox1.SelectedItem.ToString();

                if (_resourceType == PrinterResourceType.Graphic)
                {
                    DisplayGraphicPreview();
                }
                
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string selItem = listBox1.SelectedItem.ToString();
            string name = nameTxt.Text;
            if (!string.IsNullOrWhiteSpace(name) && VirtualPrinter != null && name != selItem)
            {
                if (_resourceType == PrinterResourceType.Font)
                {
                    var ofd = new OpenFileDialog();
                    ofd.Filter = "TruType Font file (*.TTF)|*.TTF";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        VirtualPrinter.AddFont(name, ofd.FileName);
                        ListPrinterResource();
                    }
                }
                else if (_resourceType == PrinterResourceType.Graphic)
                {
                    var ofd = new OpenFileDialog();
                    ofd.Filter = "Image Files(*.JPG;*.PNG)|*.JPG;*.PNG";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        VirtualPrinter.AddGraphic(name, ofd.FileName);
                        ListPrinterResource();
                        DisplayGraphicPreview();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid name.");
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string newName = nameTxt.Text;

            if (index != -1 && !string.IsNullOrWhiteSpace(newName) && VirtualPrinter != null)
            {
                string curName = listBox1.SelectedItem.ToString();

                if (_resourceType == PrinterResourceType.Font)
                {
                    VirtualPrinter.RenameFont(curName, newName);
                    ListPrinterResource();
                }
                else if (_resourceType == PrinterResourceType.Graphic)
                {
                    VirtualPrinter.RenameGraphic(curName, newName);
                    ListPrinterResource();
                    DisplayGraphicPreview();
                }

                
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1 && VirtualPrinter != null)
            {
                clearTxt();

                string curName = listBox1.SelectedItem.ToString();

                if (_resourceType == PrinterResourceType.Font)
                {
                    VirtualPrinter.RemoveFont(curName);
                    ListPrinterResource();
                }
                else if (_resourceType == PrinterResourceType.Graphic)
                {
                    VirtualPrinter.RemoveGraphic(curName);
                    ListPrinterResource();
                    DisplayGraphicPreview();
                }

                
            }
        }

        
        private void clearTxt()
        {
            nameTxt.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListPrinterResource();
        }

        private void ListPrinterResource()
        {
            clearTxt();
            listBox1.DataSource = null;
            _resourceType = PrinterResourceType.None;
            picPreview.Image = null;
            lblPreview.Visible = pnlPreview.Visible = false;

            int index = comboBox1.SelectedIndex;
            if (index != -1 && VirtualPrinter != null)
            {
                listBox1.DataSource = index == 0 ? VirtualPrinter.GetFonts() : VirtualPrinter.GetGraphics();
                _resourceType = index == 0 ? PrinterResourceType.Font : PrinterResourceType.Graphic;
                lblPreview.Visible = pnlPreview.Visible = _resourceType == PrinterResourceType.Graphic;
            }
        }

        private void DisplayGraphicPreview()
        {
            if (string.IsNullOrWhiteSpace(nameTxt.Text))
                picPreview.Image = null;
            else
                picPreview.Image = Image.FromStream(new MemoryStream(VirtualPrinter.GetGraphic(nameTxt.Text)));
        }
    }
}
