namespace _2DSurvey
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入标识ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出结果图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像平滑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.均值滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中值滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.梯度倒数加权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.梯度法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像拉伸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线性拉伸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拉伸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直方图均衡化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.复原ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.显示直方图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标识ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手动选取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矩形标志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.圆形标志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动匹配ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.制作标识ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.几何量测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.夹角ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矩形面积ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MessageBox = new System.Windows.Forms.RichTextBox();
            this.openImage = new System.Windows.Forms.OpenFileDialog();
            this.openMark = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.MarkGeometry = new System.Windows.Forms.RichTextBox();
            this.MarkImage = new System.Windows.Forms.PictureBox();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MarkImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.预处理ToolStripMenuItem,
            this.标识ToolStripMenuItem,
            this.制作标识ToolStripMenuItem,
            this.几何量测ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1581, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开图像ToolStripMenuItem,
            this.导入标识ToolStripMenuItem,
            this.导出结果图ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // 打开图像ToolStripMenuItem
            // 
            this.打开图像ToolStripMenuItem.Name = "打开图像ToolStripMenuItem";
            this.打开图像ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.打开图像ToolStripMenuItem.Text = "打开图像";
            this.打开图像ToolStripMenuItem.Click += new System.EventHandler(this.打开图像ToolStripMenuItem_Click);
            // 
            // 导入标识ToolStripMenuItem
            // 
            this.导入标识ToolStripMenuItem.Name = "导入标识ToolStripMenuItem";
            this.导入标识ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.导入标识ToolStripMenuItem.Text = "导入标志";
            this.导入标识ToolStripMenuItem.Click += new System.EventHandler(this.导入标识ToolStripMenuItem_Click);
            // 
            // 导出结果图ToolStripMenuItem
            // 
            this.导出结果图ToolStripMenuItem.Name = "导出结果图ToolStripMenuItem";
            this.导出结果图ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.导出结果图ToolStripMenuItem.Text = "导出结果";
            this.导出结果图ToolStripMenuItem.Click += new System.EventHandler(this.导出结果图ToolStripMenuItem_Click);
            // 
            // 预处理ToolStripMenuItem
            // 
            this.预处理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图像平滑ToolStripMenuItem,
            this.图像滤波ToolStripMenuItem,
            this.图像拉伸ToolStripMenuItem,
            this.撤销ToolStripMenuItem1,
            this.复原ToolStripMenuItem1,
            this.显示直方图ToolStripMenuItem});
            this.预处理ToolStripMenuItem.Name = "预处理ToolStripMenuItem";
            this.预处理ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.预处理ToolStripMenuItem.Text = "预处理";
            // 
            // 图像平滑ToolStripMenuItem
            // 
            this.图像平滑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.均值滤波ToolStripMenuItem,
            this.中值滤波ToolStripMenuItem,
            this.梯度倒数加权ToolStripMenuItem});
            this.图像平滑ToolStripMenuItem.Name = "图像平滑ToolStripMenuItem";
            this.图像平滑ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.图像平滑ToolStripMenuItem.Text = "图像平滑";
            this.图像平滑ToolStripMenuItem.Click += new System.EventHandler(this.图像平滑ToolStripMenuItem_Click);
            // 
            // 均值滤波ToolStripMenuItem
            // 
            this.均值滤波ToolStripMenuItem.Name = "均值滤波ToolStripMenuItem";
            this.均值滤波ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.均值滤波ToolStripMenuItem.Text = "均值滤波";
            this.均值滤波ToolStripMenuItem.Click += new System.EventHandler(this.均值滤波ToolStripMenuItem_Click);
            // 
            // 中值滤波ToolStripMenuItem
            // 
            this.中值滤波ToolStripMenuItem.Name = "中值滤波ToolStripMenuItem";
            this.中值滤波ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.中值滤波ToolStripMenuItem.Text = "中值滤波";
            this.中值滤波ToolStripMenuItem.Click += new System.EventHandler(this.中值滤波ToolStripMenuItem_Click);
            // 
            // 梯度倒数加权ToolStripMenuItem
            // 
            this.梯度倒数加权ToolStripMenuItem.Name = "梯度倒数加权ToolStripMenuItem";
            this.梯度倒数加权ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.梯度倒数加权ToolStripMenuItem.Text = "梯度倒数加权";
            this.梯度倒数加权ToolStripMenuItem.Click += new System.EventHandler(this.梯度倒数加权ToolStripMenuItem_Click);
            // 
            // 图像滤波ToolStripMenuItem
            // 
            this.图像滤波ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.梯度法ToolStripMenuItem,
            this.laplacianToolStripMenuItem});
            this.图像滤波ToolStripMenuItem.Name = "图像滤波ToolStripMenuItem";
            this.图像滤波ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.图像滤波ToolStripMenuItem.Text = "图像锐化";
            // 
            // 梯度法ToolStripMenuItem
            // 
            this.梯度法ToolStripMenuItem.Name = "梯度法ToolStripMenuItem";
            this.梯度法ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.梯度法ToolStripMenuItem.Text = "梯度法";
            this.梯度法ToolStripMenuItem.Click += new System.EventHandler(this.梯度法ToolStripMenuItem_Click);
            // 
            // laplacianToolStripMenuItem
            // 
            this.laplacianToolStripMenuItem.Name = "laplacianToolStripMenuItem";
            this.laplacianToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.laplacianToolStripMenuItem.Text = "Laplacian";
            this.laplacianToolStripMenuItem.Click += new System.EventHandler(this.laplacianToolStripMenuItem_Click);
            // 
            // 图像拉伸ToolStripMenuItem
            // 
            this.图像拉伸ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.线性拉伸ToolStripMenuItem,
            this.拉伸ToolStripMenuItem,
            this.直方图均衡化ToolStripMenuItem});
            this.图像拉伸ToolStripMenuItem.Name = "图像拉伸ToolStripMenuItem";
            this.图像拉伸ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.图像拉伸ToolStripMenuItem.Text = "图像拉伸";
            this.图像拉伸ToolStripMenuItem.Click += new System.EventHandler(this.图像拉伸ToolStripMenuItem_Click);
            // 
            // 线性拉伸ToolStripMenuItem
            // 
            this.线性拉伸ToolStripMenuItem.Name = "线性拉伸ToolStripMenuItem";
            this.线性拉伸ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.线性拉伸ToolStripMenuItem.Text = "线性拉伸";
            this.线性拉伸ToolStripMenuItem.Click += new System.EventHandler(this.线性拉伸ToolStripMenuItem_Click_1);
            // 
            // 拉伸ToolStripMenuItem
            // 
            this.拉伸ToolStripMenuItem.Name = "拉伸ToolStripMenuItem";
            this.拉伸ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.拉伸ToolStripMenuItem.Text = "2%拉伸";
            this.拉伸ToolStripMenuItem.Click += new System.EventHandler(this.拉伸ToolStripMenuItem_Click);
            // 
            // 直方图均衡化ToolStripMenuItem
            // 
            this.直方图均衡化ToolStripMenuItem.Name = "直方图均衡化ToolStripMenuItem";
            this.直方图均衡化ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.直方图均衡化ToolStripMenuItem.Text = "直方图均衡化";
            this.直方图均衡化ToolStripMenuItem.Click += new System.EventHandler(this.直方图均衡化ToolStripMenuItem_Click);
            // 
            // 撤销ToolStripMenuItem1
            // 
            this.撤销ToolStripMenuItem1.Name = "撤销ToolStripMenuItem1";
            this.撤销ToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.撤销ToolStripMenuItem1.Text = "撤销";
            this.撤销ToolStripMenuItem1.Click += new System.EventHandler(this.撤销ToolStripMenuItem1_Click);
            // 
            // 复原ToolStripMenuItem1
            // 
            this.复原ToolStripMenuItem1.Name = "复原ToolStripMenuItem1";
            this.复原ToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.复原ToolStripMenuItem1.Text = "复原";
            this.复原ToolStripMenuItem1.Click += new System.EventHandler(this.复原ToolStripMenuItem1_Click);
            // 
            // 显示直方图ToolStripMenuItem
            // 
            this.显示直方图ToolStripMenuItem.Name = "显示直方图ToolStripMenuItem";
            this.显示直方图ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.显示直方图ToolStripMenuItem.Text = "显示直方图";
            this.显示直方图ToolStripMenuItem.Click += new System.EventHandler(this.显示直方图ToolStripMenuItem_Click);
            // 
            // 标识ToolStripMenuItem
            // 
            this.标识ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.手动选取ToolStripMenuItem,
            this.自动匹配ToolStripMenuItem});
            this.标识ToolStripMenuItem.Name = "标识ToolStripMenuItem";
            this.标识ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.标识ToolStripMenuItem.Text = "标志匹配";
            // 
            // 手动选取ToolStripMenuItem
            // 
            this.手动选取ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.矩形标志ToolStripMenuItem,
            this.圆形标志ToolStripMenuItem});
            this.手动选取ToolStripMenuItem.Name = "手动选取ToolStripMenuItem";
            this.手动选取ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.手动选取ToolStripMenuItem.Text = "手动选取";
            // 
            // 矩形标志ToolStripMenuItem
            // 
            this.矩形标志ToolStripMenuItem.Name = "矩形标志ToolStripMenuItem";
            this.矩形标志ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.矩形标志ToolStripMenuItem.Text = "矩形标志";
            this.矩形标志ToolStripMenuItem.Click += new System.EventHandler(this.矩形标志ToolStripMenuItem_Click);
            // 
            // 圆形标志ToolStripMenuItem
            // 
            this.圆形标志ToolStripMenuItem.Name = "圆形标志ToolStripMenuItem";
            this.圆形标志ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.圆形标志ToolStripMenuItem.Text = "圆形标志";
            this.圆形标志ToolStripMenuItem.Click += new System.EventHandler(this.圆形标志ToolStripMenuItem_Click);
            // 
            // 自动匹配ToolStripMenuItem
            // 
            this.自动匹配ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mADToolStripMenuItem,
            this.sADToolStripMenuItem,
            this.sSDToolStripMenuItem});
            this.自动匹配ToolStripMenuItem.Name = "自动匹配ToolStripMenuItem";
            this.自动匹配ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.自动匹配ToolStripMenuItem.Text = "自动匹配";
            this.自动匹配ToolStripMenuItem.Click += new System.EventHandler(this.自动匹配ToolStripMenuItem_Click);
            // 
            // mADToolStripMenuItem
            // 
            this.mADToolStripMenuItem.Name = "mADToolStripMenuItem";
            this.mADToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.mADToolStripMenuItem.Text = "MAD";
            this.mADToolStripMenuItem.Click += new System.EventHandler(this.mADToolStripMenuItem_Click);
            // 
            // sADToolStripMenuItem
            // 
            this.sADToolStripMenuItem.Name = "sADToolStripMenuItem";
            this.sADToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.sADToolStripMenuItem.Text = "SAD";
            this.sADToolStripMenuItem.Click += new System.EventHandler(this.sADToolStripMenuItem_Click);
            // 
            // sSDToolStripMenuItem
            // 
            this.sSDToolStripMenuItem.Name = "sSDToolStripMenuItem";
            this.sSDToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.sSDToolStripMenuItem.Text = "SSD";
            this.sSDToolStripMenuItem.Click += new System.EventHandler(this.sSDToolStripMenuItem_Click);
            // 
            // 制作标识ToolStripMenuItem
            // 
            this.制作标识ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.结束ToolStripMenuItem});
            this.制作标识ToolStripMenuItem.Name = "制作标识ToolStripMenuItem";
            this.制作标识ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.制作标识ToolStripMenuItem.Text = "制作标志";
            this.制作标识ToolStripMenuItem.Click += new System.EventHandler(this.制作标识ToolStripMenuItem_Click);
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.开始ToolStripMenuItem.Text = "开始";
            this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // 结束ToolStripMenuItem
            // 
            this.结束ToolStripMenuItem.Name = "结束ToolStripMenuItem";
            this.结束ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.结束ToolStripMenuItem.Text = "结束";
            this.结束ToolStripMenuItem.Click += new System.EventHandler(this.结束ToolStripMenuItem_Click);
            // 
            // 几何量测ToolStripMenuItem
            // 
            this.几何量测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.线ToolStripMenuItem,
            this.夹角ToolStripMenuItem,
            this.矩形面积ToolStripMenuItem});
            this.几何量测ToolStripMenuItem.Name = "几何量测ToolStripMenuItem";
            this.几何量测ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.几何量测ToolStripMenuItem.Text = "几何量测";
            // 
            // 线ToolStripMenuItem
            // 
            this.线ToolStripMenuItem.Name = "线ToolStripMenuItem";
            this.线ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.线ToolStripMenuItem.Text = "线";
            this.线ToolStripMenuItem.Click += new System.EventHandler(this.线ToolStripMenuItem_Click);
            // 
            // 夹角ToolStripMenuItem
            // 
            this.夹角ToolStripMenuItem.Name = "夹角ToolStripMenuItem";
            this.夹角ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.夹角ToolStripMenuItem.Text = "夹角";
            // 
            // 矩形面积ToolStripMenuItem
            // 
            this.矩形面积ToolStripMenuItem.Name = "矩形面积ToolStripMenuItem";
            this.矩形面积ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.矩形面积ToolStripMenuItem.Text = "矩形面积";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iipToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(97, 28);
            // 
            // iipToolStripMenuItem
            // 
            this.iipToolStripMenuItem.Name = "iipToolStripMenuItem";
            this.iipToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.iipToolStripMenuItem.Text = "iip";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.SystemColors.Window;
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MessageBox.Location = new System.Drawing.Point(31, 325);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ReadOnly = true;
            this.MessageBox.Size = new System.Drawing.Size(564, 394);
            this.MessageBox.TabIndex = 5;
            this.MessageBox.Text = "";
            // 
            // openImage
            // 
            this.openImage.FileName = "openFileDialog1";
            // 
            // openMark
            // 
            this.openMark.FileName = "openFileDialog2";
            // 
            // MarkGeometry
            // 
            this.MarkGeometry.Location = new System.Drawing.Point(410, 46);
            this.MarkGeometry.Name = "MarkGeometry";
            this.MarkGeometry.Size = new System.Drawing.Size(185, 249);
            this.MarkGeometry.TabIndex = 6;
            this.MarkGeometry.Text = "";
            // 
            // MarkImage
            // 
            this.MarkImage.BackColor = System.Drawing.SystemColors.Info;
            this.MarkImage.Location = new System.Drawing.Point(31, 46);
            this.MarkImage.Name = "MarkImage";
            this.MarkImage.Size = new System.Drawing.Size(342, 249);
            this.MarkImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MarkImage.TabIndex = 3;
            this.MarkImage.TabStop = false;
            // 
            // ImageBox
            // 
            this.ImageBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ImageBox.Location = new System.Drawing.Point(635, 46);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(934, 673);
            this.ImageBox.TabIndex = 2;
            this.ImageBox.TabStop = false;
            this.ImageBox.Click += new System.EventHandler(this.ImageBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1581, 729);
            this.Controls.Add(this.MarkGeometry);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.MarkImage);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "2DSurvey";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MarkImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iipToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 预处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像平滑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像滤波ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像拉伸ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示直方图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入标识ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出结果图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 均值滤波ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中值滤波ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 梯度倒数加权ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 梯度法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拉伸ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 直方图均衡化ToolStripMenuItem;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.PictureBox MarkImage;
        private System.Windows.Forms.RichTextBox MessageBox;
        private System.Windows.Forms.ToolStripMenuItem 制作标识ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标识ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 手动选取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动匹配ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openImage;
        private System.Windows.Forms.OpenFileDialog openMark;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 撤销ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 复原ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox MarkGeometry;
        private System.Windows.Forms.ToolStripMenuItem 矩形标志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 几何量测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 夹角ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 矩形面积ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 圆形标志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线性拉伸ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束ToolStripMenuItem;
    }
}

