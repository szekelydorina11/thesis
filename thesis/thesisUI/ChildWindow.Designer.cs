namespace thesisUI
{
    partial class ChildWindow
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
            this.pbOriginalImage = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pbHistogram = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbGreen = new System.Windows.Forms.PictureBox();
            this.pbBlue = new System.Windows.Forms.PictureBox();
            this.pbCombined = new System.Windows.Forms.PictureBox();
            this.pbRed = new System.Windows.Forms.PictureBox();
            this.btnInvert = new System.Windows.Forms.Button();
            this.btnCollimate = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHistogram)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCombined)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbOriginalImage
            // 
            this.pbOriginalImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbOriginalImage.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pbOriginalImage.Location = new System.Drawing.Point(0, 0);
            this.pbOriginalImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbOriginalImage.Name = "pbOriginalImage";
            this.pbOriginalImage.Size = new System.Drawing.Size(495, 554);
            this.pbOriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOriginalImage.TabIndex = 0;
            this.pbOriginalImage.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbOriginalImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1182, 554);
            this.splitContainer1.SplitterDistance = 962;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pbHistogram);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Controls.Add(this.btnInvert);
            this.flowLayoutPanel1.Controls.Add(this.btnCollimate);
            this.flowLayoutPanel1.Controls.Add(this.btnRestore);
            this.flowLayoutPanel1.Controls.Add(this.trackBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(215, 554);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pbHistogram
            // 
            this.pbHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHistogram.Location = new System.Drawing.Point(4, 4);
            this.pbHistogram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbHistogram.Name = "pbHistogram";
            this.pbHistogram.Size = new System.Drawing.Size(279, 117);
            this.pbHistogram.TabIndex = 2;
            this.pbHistogram.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pbGreen, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbBlue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbCombined, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbRed, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 129);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(279, 159);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // pbGreen
            // 
            this.pbGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbGreen.Location = new System.Drawing.Point(143, 4);
            this.pbGreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbGreen.Name = "pbGreen";
            this.pbGreen.Size = new System.Drawing.Size(132, 71);
            this.pbGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGreen.TabIndex = 1;
            this.pbGreen.TabStop = false;
            this.pbGreen.BackColorChanged += new System.EventHandler(this.pbRed_Click);
            this.pbGreen.Click += new System.EventHandler(this.pbRed_Click);
            // 
            // pbBlue
            // 
            this.pbBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBlue.Location = new System.Drawing.Point(4, 83);
            this.pbBlue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbBlue.Name = "pbBlue";
            this.pbBlue.Size = new System.Drawing.Size(131, 72);
            this.pbBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBlue.TabIndex = 2;
            this.pbBlue.TabStop = false;
            this.pbBlue.BackColorChanged += new System.EventHandler(this.pbRed_Click);
            this.pbBlue.Click += new System.EventHandler(this.pbRed_Click);
            // 
            // pbCombined
            // 
            this.pbCombined.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCombined.Location = new System.Drawing.Point(143, 83);
            this.pbCombined.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbCombined.Name = "pbCombined";
            this.pbCombined.Size = new System.Drawing.Size(132, 72);
            this.pbCombined.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCombined.TabIndex = 3;
            this.pbCombined.TabStop = false;
            this.pbCombined.BackColorChanged += new System.EventHandler(this.pbRed_Click);
            this.pbCombined.Click += new System.EventHandler(this.pbRed_Click);
            // 
            // pbRed
            // 
            this.pbRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbRed.Location = new System.Drawing.Point(4, 4);
            this.pbRed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbRed.Name = "pbRed";
            this.pbRed.Size = new System.Drawing.Size(131, 71);
            this.pbRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRed.TabIndex = 0;
            this.pbRed.TabStop = false;
            this.pbRed.Click += new System.EventHandler(this.pbRed_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(4, 296);
            this.btnInvert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(279, 28);
            this.btnInvert.TabIndex = 0;
            this.btnInvert.Text = "Invert image";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCollimate
            // 
            this.btnCollimate.Location = new System.Drawing.Point(4, 332);
            this.btnCollimate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCollimate.Name = "btnCollimate";
            this.btnCollimate.Size = new System.Drawing.Size(279, 28);
            this.btnCollimate.TabIndex = 1;
            this.btnCollimate.Text = "Find edges";
            this.btnCollimate.UseVisualStyleBackColor = true;
            this.btnCollimate.Click += new System.EventHandler(this.btnCollimate_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(4, 368);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(279, 28);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restore original";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(4, 404);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(279, 58);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 128;
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // ChildWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 554);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChildWindow";
            this.Text = "ChildWindow";
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalImage)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHistogram)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCombined)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOriginalImage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Button btnCollimate;
        private System.Windows.Forms.PictureBox pbHistogram;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbGreen;
        private System.Windows.Forms.PictureBox pbBlue;
        private System.Windows.Forms.PictureBox pbCombined;
        private System.Windows.Forms.PictureBox pbRed;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}