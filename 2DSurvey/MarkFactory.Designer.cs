
namespace _2DSurvey
{
    partial class MarkFactory
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.打开图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标志类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开图像ToolStripMenuItem,
            this.标志类型ToolStripMenuItem,
            this.保存结果ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 打开图像ToolStripMenuItem
            // 
            this.打开图像ToolStripMenuItem.Name = "打开图像ToolStripMenuItem";
            this.打开图像ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.打开图像ToolStripMenuItem.Text = "打开图像";
            // 
            // 标志类型ToolStripMenuItem
            // 
            this.标志类型ToolStripMenuItem.Name = "标志类型ToolStripMenuItem";
            this.标志类型ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.标志类型ToolStripMenuItem.Text = "标志类型";
            // 
            // 保存结果ToolStripMenuItem
            // 
            this.保存结果ToolStripMenuItem.Name = "保存结果ToolStripMenuItem";
            this.保存结果ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.保存结果ToolStripMenuItem.Text = "保存结果";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(258, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(542, 419);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 31);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(252, 419);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // MarkFactory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MarkFactory";
            this.Text = "MarkFactory";
            this.Load += new System.EventHandler(this.MarkFactory_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标志类型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存结果ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}