namespace BelSekolah_3._5
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelJam = new System.Windows.Forms.Label();
            this.labelTanggal = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pengaturanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loopingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bel1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bel2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelJam, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTanggal, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.78873F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.21127F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(158, 71);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelJam
            // 
            this.labelJam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelJam.AutoSize = true;
            this.labelJam.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.labelJam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelJam.Location = new System.Drawing.Point(3, 3);
            this.labelJam.Name = "labelJam";
            this.labelJam.Size = new System.Drawing.Size(151, 39);
            this.labelJam.TabIndex = 0;
            this.labelJam.Text = "00:00:00";
            // 
            // labelTanggal
            // 
            this.labelTanggal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTanggal.AutoSize = true;
            this.labelTanggal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelTanggal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTanggal.Location = new System.Drawing.Point(56, 50);
            this.labelTanggal.Name = "labelTanggal";
            this.labelTanggal.Size = new System.Drawing.Size(45, 16);
            this.labelTanggal.TabIndex = 1;
            this.labelTanggal.Text = "label2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pengaturanToolStripMenuItem,
            this.loopingToolStripMenuItem,
            this.bel1ToolStripMenuItem,
            this.bel2ToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(136, 114);
            // 
            // pengaturanToolStripMenuItem
            // 
            this.pengaturanToolStripMenuItem.Name = "pengaturanToolStripMenuItem";
            this.pengaturanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pengaturanToolStripMenuItem.Text = "Pengaturan";
            this.pengaturanToolStripMenuItem.Click += new System.EventHandler(this.pengaturanToolStripMenuItem_Click);
            // 
            // loopingToolStripMenuItem
            // 
            this.loopingToolStripMenuItem.Name = "loopingToolStripMenuItem";
            this.loopingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loopingToolStripMenuItem.Text = "Looping";
            this.loopingToolStripMenuItem.Click += new System.EventHandler(this.loopingToolStripMenuItem_Click);
            // 
            // bel1ToolStripMenuItem
            // 
            this.bel1ToolStripMenuItem.Name = "bel1ToolStripMenuItem";
            this.bel1ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.bel1ToolStripMenuItem.Text = "Bel 1";
            // 
            // bel2ToolStripMenuItem
            // 
            this.bel2ToolStripMenuItem.Name = "bel2ToolStripMenuItem";
            this.bel2ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.bel2ToolStripMenuItem.Text = "Bel 2";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(170, 86);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelJam;
        private System.Windows.Forms.Label labelTanggal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pengaturanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loopingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bel1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bel2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}