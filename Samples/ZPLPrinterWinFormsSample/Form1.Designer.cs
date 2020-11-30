namespace ZPLPrinterWinFormsSample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPreviewZpl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZPLCommands = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAntiAlias = new System.Windows.Forms.CheckBox();
            this.btnOpenZplFile = new System.Windows.Forms.Button();
            this.chkResetPrinter = new System.Windows.Forms.CheckBox();
            this.cboOutputFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkForceLabelHeight = new System.Windows.Forms.CheckBox();
            this.chkForceLabelWidth = new System.Windows.Forms.CheckBox();
            this.chkTransparent = new System.Windows.Forms.CheckBox();
            this.btnExamine = new System.Windows.Forms.Button();
            this.txtBackgroundImage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboOutputRotation = new System.Windows.Forms.ComboBox();
            this.nudLabelHeight = new System.Windows.Forms.NumericUpDown();
            this.nudLabelWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLabelBackColor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRibbonColor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDpi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrinterStorage = new System.Windows.Forms.Button();
            this.btnExamineWatermark = new System.Windows.Forms.Button();
            this.txtWatermarkImage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.imgViewer = new ZPLPrinterWinFormsSample.ImageViewer();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLabelHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLabelWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPreviewZpl
            // 
            this.btnPreviewZpl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviewZpl.Location = new System.Drawing.Point(377, 298);
            this.btnPreviewZpl.Name = "btnPreviewZpl";
            this.btnPreviewZpl.Size = new System.Drawing.Size(144, 25);
            this.btnPreviewZpl.TabIndex = 4;
            this.btnPreviewZpl.Text = "Preview ZPL >>";
            this.btnPreviewZpl.UseVisualStyleBackColor = true;
            this.btnPreviewZpl.Click += new System.EventHandler(this.btnPreviewZpl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "ZPL Commands";
            // 
            // txtZPLCommands
            // 
            this.txtZPLCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtZPLCommands.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZPLCommands.Location = new System.Drawing.Point(12, 329);
            this.txtZPLCommands.MaxLength = 2147483646;
            this.txtZPLCommands.Multiline = true;
            this.txtZPLCommands.Name = "txtZPLCommands";
            this.txtZPLCommands.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtZPLCommands.Size = new System.Drawing.Size(509, 295);
            this.txtZPLCommands.TabIndex = 5;
            this.txtZPLCommands.Text = resources.GetString("txtZPLCommands.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(532, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "ZPL Rendering Output";
            // 
            // chkAntiAlias
            // 
            this.chkAntiAlias.AutoSize = true;
            this.chkAntiAlias.Checked = true;
            this.chkAntiAlias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAntiAlias.Location = new System.Drawing.Point(329, 112);
            this.chkAntiAlias.Name = "chkAntiAlias";
            this.chkAntiAlias.Size = new System.Drawing.Size(112, 17);
            this.chkAntiAlias.TabIndex = 12;
            this.chkAntiAlias.Text = "Apply Anti-Aliasing";
            this.chkAntiAlias.UseVisualStyleBackColor = true;
            // 
            // btnOpenZplFile
            // 
            this.btnOpenZplFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenZplFile.Location = new System.Drawing.Point(215, 298);
            this.btnOpenZplFile.Name = "btnOpenZplFile";
            this.btnOpenZplFile.Size = new System.Drawing.Size(141, 25);
            this.btnOpenZplFile.TabIndex = 3;
            this.btnOpenZplFile.Text = "Open ZPL File...";
            this.btnOpenZplFile.UseVisualStyleBackColor = true;
            this.btnOpenZplFile.Click += new System.EventHandler(this.btnOpenZplFile_Click);
            // 
            // chkResetPrinter
            // 
            this.chkResetPrinter.AutoSize = true;
            this.chkResetPrinter.Checked = true;
            this.chkResetPrinter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkResetPrinter.Location = new System.Drawing.Point(13, 80);
            this.chkResetPrinter.Name = "chkResetPrinter";
            this.chkResetPrinter.Size = new System.Drawing.Size(87, 17);
            this.chkResetPrinter.TabIndex = 7;
            this.chkResetPrinter.Text = "Reset Printer";
            this.chkResetPrinter.UseVisualStyleBackColor = true;
            // 
            // cboOutputFormat
            // 
            this.cboOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputFormat.FormattingEnabled = true;
            this.cboOutputFormat.Location = new System.Drawing.Point(88, 110);
            this.cboOutputFormat.Name = "cboOutputFormat";
            this.cboOutputFormat.Size = new System.Drawing.Size(64, 21);
            this.cboOutputFormat.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "ZPL Printer Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExamineWatermark);
            this.groupBox1.Controls.Add(this.txtWatermarkImage);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnPrinterStorage);
            this.groupBox1.Controls.Add(this.chkForceLabelHeight);
            this.groupBox1.Controls.Add(this.chkForceLabelWidth);
            this.groupBox1.Controls.Add(this.chkTransparent);
            this.groupBox1.Controls.Add(this.btnExamine);
            this.groupBox1.Controls.Add(this.txtBackgroundImage);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboOutputRotation);
            this.groupBox1.Controls.Add(this.nudLabelHeight);
            this.groupBox1.Controls.Add(this.nudLabelWidth);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnLabelBackColor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnRibbonColor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboDpi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboOutputFormat);
            this.groupBox1.Controls.Add(this.chkAntiAlias);
            this.groupBox1.Controls.Add(this.chkResetPrinter);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 245);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // chkForceLabelHeight
            // 
            this.chkForceLabelHeight.AutoSize = true;
            this.chkForceLabelHeight.Location = new System.Drawing.Point(344, 46);
            this.chkForceLabelHeight.Name = "chkForceLabelHeight";
            this.chkForceLabelHeight.Size = new System.Drawing.Size(116, 17);
            this.chkForceLabelHeight.TabIndex = 6;
            this.chkForceLabelHeight.Text = "Force Label Height";
            this.chkForceLabelHeight.UseVisualStyleBackColor = true;
            // 
            // chkForceLabelWidth
            // 
            this.chkForceLabelWidth.AutoSize = true;
            this.chkForceLabelWidth.Location = new System.Drawing.Point(182, 46);
            this.chkForceLabelWidth.Name = "chkForceLabelWidth";
            this.chkForceLabelWidth.Size = new System.Drawing.Size(113, 17);
            this.chkForceLabelWidth.TabIndex = 5;
            this.chkForceLabelWidth.Text = "Force Label Width";
            this.chkForceLabelWidth.UseVisualStyleBackColor = true;
            // 
            // chkTransparent
            // 
            this.chkTransparent.AutoSize = true;
            this.chkTransparent.Location = new System.Drawing.Point(385, 81);
            this.chkTransparent.Name = "chkTransparent";
            this.chkTransparent.Size = new System.Drawing.Size(83, 17);
            this.chkTransparent.TabIndex = 18;
            this.chkTransparent.Text = "Transparent";
            this.chkTransparent.UseVisualStyleBackColor = true;
            // 
            // btnExamine
            // 
            this.btnExamine.Location = new System.Drawing.Point(430, 142);
            this.btnExamine.Name = "btnExamine";
            this.btnExamine.Size = new System.Drawing.Size(69, 21);
            this.btnExamine.TabIndex = 14;
            this.btnExamine.Text = "Examine...";
            this.btnExamine.UseVisualStyleBackColor = true;
            this.btnExamine.Click += new System.EventHandler(this.btnExamine_Click);
            // 
            // txtBackgroundImage
            // 
            this.txtBackgroundImage.Location = new System.Drawing.Point(112, 143);
            this.txtBackgroundImage.Name = "txtBackgroundImage";
            this.txtBackgroundImage.Size = new System.Drawing.Size(312, 20);
            this.txtBackgroundImage.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Background Image:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(160, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Rotate:";
            // 
            // cboOutputRotation
            // 
            this.cboOutputRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputRotation.FormattingEnabled = true;
            this.cboOutputRotation.Location = new System.Drawing.Point(203, 110);
            this.cboOutputRotation.Name = "cboOutputRotation";
            this.cboOutputRotation.Size = new System.Drawing.Size(102, 21);
            this.cboOutputRotation.TabIndex = 11;
            // 
            // nudLabelHeight
            // 
            this.nudLabelHeight.DecimalPlaces = 2;
            this.nudLabelHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLabelHeight.Location = new System.Drawing.Point(410, 16);
            this.nudLabelHeight.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLabelHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLabelHeight.Name = "nudLabelHeight";
            this.nudLabelHeight.Size = new System.Drawing.Size(71, 20);
            this.nudLabelHeight.TabIndex = 4;
            this.nudLabelHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudLabelWidth
            // 
            this.nudLabelWidth.DecimalPlaces = 2;
            this.nudLabelWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLabelWidth.Location = new System.Drawing.Point(247, 16);
            this.nudLabelWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLabelWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLabelWidth.Name = "nudLabelWidth";
            this.nudLabelWidth.Size = new System.Drawing.Size(68, 20);
            this.nudLabelWidth.TabIndex = 3;
            this.nudLabelWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(179, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(320, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Label Width:                           in    Label Height:                       " +
    "    in";
            // 
            // btnLabelBackColor
            // 
            this.btnLabelBackColor.BackColor = System.Drawing.Color.White;
            this.btnLabelBackColor.Location = new System.Drawing.Point(329, 74);
            this.btnLabelBackColor.Name = "btnLabelBackColor";
            this.btnLabelBackColor.Size = new System.Drawing.Size(41, 27);
            this.btnLabelBackColor.TabIndex = 9;
            this.btnLabelBackColor.UseVisualStyleBackColor = false;
            this.btnLabelBackColor.Click += new System.EventHandler(this.btnLabelBackColor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(239, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Label BackColor:";
            // 
            // btnRibbonColor
            // 
            this.btnRibbonColor.BackColor = System.Drawing.Color.Black;
            this.btnRibbonColor.Location = new System.Drawing.Point(186, 74);
            this.btnRibbonColor.Name = "btnRibbonColor";
            this.btnRibbonColor.Size = new System.Drawing.Size(41, 27);
            this.btnRibbonColor.TabIndex = 8;
            this.btnRibbonColor.UseVisualStyleBackColor = false;
            this.btnRibbonColor.Click += new System.EventHandler(this.btnRibbonColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(115, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ribbon Color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Output Format:";
            // 
            // cboDpi
            // 
            this.cboDpi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDpi.FormattingEnabled = true;
            this.cboDpi.Items.AddRange(new object[] {
            "152 dpi (6 dpmm)",
            "203 dpi (8 dpmm)",
            "300 dpi (12 dpmm)",
            "600 dpi (24 dpmm)"});
            this.cboDpi.Location = new System.Drawing.Point(39, 15);
            this.cboDpi.Name = "cboDpi";
            this.cboDpi.Size = new System.Drawing.Size(126, 21);
            this.cboDpi.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "DPI:";
            // 
            // btnPrinterStorage
            // 
            this.btnPrinterStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinterStorage.Location = new System.Drawing.Point(13, 205);
            this.btnPrinterStorage.Name = "btnPrinterStorage";
            this.btnPrinterStorage.Size = new System.Drawing.Size(486, 25);
            this.btnPrinterStorage.TabIndex = 19;
            this.btnPrinterStorage.Text = "Admin Printer Storage...";
            this.btnPrinterStorage.UseVisualStyleBackColor = true;
            this.btnPrinterStorage.Click += new System.EventHandler(this.btnPrinterStorage_Click);
            // 
            // btnExamineWatermark
            // 
            this.btnExamineWatermark.Location = new System.Drawing.Point(430, 170);
            this.btnExamineWatermark.Name = "btnExamineWatermark";
            this.btnExamineWatermark.Size = new System.Drawing.Size(69, 21);
            this.btnExamineWatermark.TabIndex = 21;
            this.btnExamineWatermark.Text = "Examine...";
            this.btnExamineWatermark.UseVisualStyleBackColor = true;
            this.btnExamineWatermark.Click += new System.EventHandler(this.btnExamineWatermark_Click);
            // 
            // txtWatermarkImage
            // 
            this.txtWatermarkImage.Location = new System.Drawing.Point(112, 171);
            this.txtWatermarkImage.Name = "txtWatermarkImage";
            this.txtWatermarkImage.Size = new System.Drawing.Size(312, 20);
            this.txtWatermarkImage.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Watermark Image:";
            // 
            // imgViewer
            // 
            this.imgViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgViewer.Location = new System.Drawing.Point(537, 43);
            this.imgViewer.Name = "imgViewer";
            this.imgViewer.Size = new System.Drawing.Size(639, 581);
            this.imgViewer.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 636);
            this.Controls.Add(this.imgViewer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOpenZplFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtZPLCommands);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPreviewZpl);
            this.Name = "Form1";
            this.Text = "ZPLPrinter SDK for .NET - Windows Forms Sample";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLabelHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLabelWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreviewZpl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZPLCommands;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAntiAlias;
        private System.Windows.Forms.Button btnOpenZplFile;
        private System.Windows.Forms.CheckBox chkResetPrinter;
        private System.Windows.Forms.ComboBox cboOutputFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLabelBackColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRibbonColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDpi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudLabelHeight;
        private System.Windows.Forms.NumericUpDown nudLabelWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboOutputRotation;
        private ImageViewer imgViewer;
        private System.Windows.Forms.Button btnExamine;
        private System.Windows.Forms.TextBox txtBackgroundImage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkTransparent;
        private System.Windows.Forms.CheckBox chkForceLabelHeight;
        private System.Windows.Forms.CheckBox chkForceLabelWidth;
        private System.Windows.Forms.Button btnPrinterStorage;
        private System.Windows.Forms.Button btnExamineWatermark;
        private System.Windows.Forms.TextBox txtWatermarkImage;
        private System.Windows.Forms.Label label11;
    }
}

