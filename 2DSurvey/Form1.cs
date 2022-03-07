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

namespace _2DSurvey
{
    //像平面坐标
    public struct ImagePoint
    {
        public int x;
        public int y;
        public ImagePoint(int a,int b)
        {
            x = a;
            y = b;
        }
    }
    //物方空间坐标
    struct ObjectPoint
    {
        public double x;
        public double y;
        public ObjectPoint(double a,double b)
        {
            x = a;
            y = b;
        }
    }
    public partial class Form1 : Form
    {
        string Path;//根路径
        string ImagePath;//图像存储路径
        string MarkPath;//标志存储路径
        
        int ImageHeight;//图像H
        int ImageWidth;//图像W

        Histogram h;//当前图像直方图

        Bitmap[] ImageStack;//图像栈
        int StackDepth;//栈深
        int CurrentImage;//栈顶图像

        Bitmap TheMark;//当前标志图像
        int MarkType;//0 无标志 1 矩形 2 圆形
        int MarkHeight;//标志图像H
        int MarkWidth;//标志图像W
        int PointCount;//控制点数
        double[] GeometryFeatures;//几何信息
        string Unit;//单位
        ImagePoint[] ControlPoints;//图像控制点
        ObjectPoint[] UnknownPoints;//待测特征点
        double result;//结果线段长度
        
        Pen BlackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
        Pen RedPen = new Pen(Color.FromArgb(220, 20, 60),5);
        //double[] L;//DLT变换参数
        //int count;//迭代次数
        //int max;//最大迭代次数
        //private static bool drawing = false;

        public Form1()
        {
            InitializeComponent();
            //获取当前文件目录
            Path = System.Environment.CurrentDirectory;
            MarkPath = Path + @"\Mark";

            //MessageBox.AppendText("Tips\n");
            //检查Mark文件夹
            if (System.IO.Directory.Exists(MarkPath) == false)
            {
                //新建
                Directory.CreateDirectory(MarkPath);
                MessageBox.AppendText("Folder Mark has been created.\n");
            }
            else
            {
                MessageBox.AppendText("Folder Mark has existed.\n");
            }
                //MarkPath += @"\";
 
            //图像栈初始化
            StackDepth = 10;
            CurrentImage = 0;
            ImageStack = new Bitmap[StackDepth];
            //图像初始化
            ImageStack[0] = new Bitmap(Properties.Resources.DJI);
            ImageBox.Image = ImageStack[0];
            ImageHeight = ImageStack[0].Height;
            ImageWidth = ImageStack[0].Width;

            for (int i = 1; i < StackDepth; i++)
                ImageStack[i] = new Bitmap(ImageWidth, ImageHeight);

            MessageBox.AppendText("Image Stack initialized.\n");
            //标志初始化
            TheMark = new Bitmap(Properties.Resources.Mark2);
            MarkType = 0;
            MarkHeight = TheMark.Height;
            MarkWidth = TheMark.Width;
            PointCount = 0;
            //MarkGeometry.AppendText("path:Resource\nType:rectangle\nPoint1:0,0\nPoint2:13,0\nPoint3:0,13\nPoint4:13,13\nLength:0.05m\nWidth:0.05m");
            MessageBox.AppendText("Mark Initialized.\n");
            MessageBox.AppendText("Lenna say Hello:)\n");
            UpdateMark();
            //计算数据初始化
            ControlPoints = new ImagePoint[4];

            for (int i = 0; i < 4; i++)
                ControlPoints[i] = new ImagePoint(0, 0);

            UnknownPoints = new ObjectPoint[2];

            for (int i = 0; i < 2; i++)
                UnknownPoints[i] = new ObjectPoint(0, 0);

            result = 0;
            //DLT参数数组初始化
            //L = new double[9];
            //for (int i = 0; i < 9; i++)
            //    L[i] = 0;

            //count = 0;
            //max = 10;
        }
        private void UpdateImage(string path)
        {
            //图像更新
            ImageStack[0] = new Bitmap(path);
            ImageHeight = ImageStack[0].Height;
            ImageWidth = ImageStack[0].Width;
            MessageBox.AppendText("Image initialized.\n");
            //图像栈更新
            CurrentImage = 0;

            for (int i = 1; i < StackDepth; i++)
                ImageStack[i] = new Bitmap(ImageWidth, ImageHeight);

            MessageBox.AppendText("Image Stack initialized.\n");
            //显示更新
            ImageBox.Image = ImageStack[CurrentImage];
            MessageBox.AppendText("Load Success.\n");
        }
        //刷新标志信息显示
        private void UpdateMark()
        {
            MarkGeometry.Clear();

            if(MarkType==0)
            {
                //图像更新
                MarkImage.Image = TheMark;
                //信息显示更新
                //MarkGeometry.AppendText(MarkPath + "\n");
                MarkGeometry.AppendText("No data\n");
                return;
            }
            if(MarkType==1)
            {
                //图像更新
                MarkImage.Image = TheMark;
                //信息显示更新
                MarkGeometry.AppendText(MarkPath + "\n");
                MarkGeometry.AppendText("Rectangle\n");
                MarkGeometry.AppendText(PointCount.ToString()+" Control Points\n");
                //MarkGeometry.AppendText("Point A: " + ControlPoints[0].x.ToString() + "," + ControlPoints[0].y.ToString() + "\n");
                //MarkGeometry.AppendText("Point B: " + ControlPoints[1].x.ToString() + "," + ControlPoints[1].y.ToString() + "\n");
                //MarkGeometry.AppendText("Point C: " + ControlPoints[2].x.ToString() + "," + ControlPoints[2].y.ToString() + "\n");
                //MarkGeometry.AppendText("Point D: " + ControlPoints[3].x.ToString() + "," + ControlPoints[3].y.ToString() + "\n");
                MarkGeometry.AppendText("Rectangle Length: " + GeometryFeatures[0].ToString() + "\n");
                MarkGeometry.AppendText("Rectangle Width: " + GeometryFeatures[1].ToString() + "\n");
                MarkGeometry.AppendText("Unit:" + Unit + "\n");
                return;
            }
            if(MarkType==2)
            {
                MarkGeometry.AppendText("还没写完:)\n");
                return;
            }
            else
            {
                MarkGeometry.AppendText("Illegal Input!\n");
                return;
            }
        }
        //计算DLT参数
        //private void DLT(double L1,double L2,double L4,double L5,double L7,double L8)
        //{
        //    double a = GeometryFeatures[0];
        //    double b = GeometryFeatures[1];
        //    int xa = ControlPoints[0].x;
        //    int ya = ControlPoints[0].y;
        //    int xb = ControlPoints[1].x;
        //    int yb = ControlPoints[1].y;
        //    int xc = ControlPoints[2].x;
        //    int yc = ControlPoints[2].y;
        //    int xd = ControlPoints[3].x;
        //    int yd = ControlPoints[3].y;

        //    L[3] = -xa;
        //    L[6] = -ya;

        //    if (count < max)
        //    {
        //        L[1] = (xa - xb - a * xb * L7) / a;
        //        L[2] = (xa - xd - b * xd * L8) / b;
        //        L[4] = (ya - yb - a * yb * L7) / a;
        //        L[5] = (ya - yd - b * yd * L8) / b;
        //        L[7] = (xb + xd - xa - xc - b * (xc - xd) * L8) / (a * (xc - xb));
        //        L[8] = (yb + yd - yc - ya + a * (yb - yc) * L7) / (b * (yc - yd));

        //        count++;

        //        DLT(L[1], L[2], L[4], L[5], L[7], L[8]);
        //    }
        //    else
        //        return;
        //}
        private void 打开图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage.InitialDirectory = Path;
            openImage.Filter = "Image |*.jpg;*.jepg;*.png;*.bmp;*.gif";
            openImage.FilterIndex = 2;
            openImage.RestoreDirectory = true;

            if(openImage.ShowDialog()==DialogResult.OK)
            {
                //读取图像
                ImagePath = openImage.FileName;
                UpdateImage(ImagePath);
                MessageBox.AppendText("Load Image " + ImagePath + "\n");
                ////初始化图像栈
                //ImageStack = new Bitmap[StackDepth];

                //for (int i = 0; i < StackDepth; i++)
                //    ImageStack[i] = new Bitmap(ImageWidth, ImageHeight);

                //ImageStack[CurrentImage] = TheImage.image;

                //MessageBox.AppendText("Image Stack has been initialized.\n");
                ////显示图像
                //ImageBox.Image = ImageStack[CurrentImage];
            }
        }
        //图像栈溢出处理
        private void StackOverflow()
        {
            CurrentImage = 1;
            MessageBox.AppendText("Stack overflow! Stack has been reset.\n");
        }
        private void 导入标识ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openMark.InitialDirectory = MarkPath;
            openMark.Filter= "Mark |*.zy";
            openImage.FilterIndex = 2;
            openImage.RestoreDirectory = true;

            if(openMark.ShowDialog()==DialogResult.OK)
            {
                //读取.zy
                MarkPath = openMark.FileName;
                string[] content = File.ReadAllLines(MarkPath);

                //test
                //for (int i = 0; i < content.Length; i++)
                //    MessageBox.AppendText(content[i] + "\n");

                //打开图像
                if(!File.Exists(content[0]))
                {
                    MessageBox.AppendText("Can't open image of the Mark!Please check the file.\n");
                    return;
                }
                else
                {
                    //更新参数
                    TheMark = new Bitmap(content[0]);
                    MarkHeight = TheMark.Height;
                    MarkWidth = TheMark.Width;
                    MarkType = int.Parse(content[1]);
                    PointCount = int.Parse(content[2]);
                    //更新控制点集
                    ControlPoints = new ImagePoint[PointCount];
                    //根据标志类型导入控制点信息和几何信息
                    switch(MarkType)
                    {
                        //矩形
                        case 1:
                            //string[] temp;

                            //for(int i=0;i<PointCount;i++)
                            //{
                            //    //字符串分割
                            //    temp = content[i + 3].Split(' ');
                            //    //初始化控制点
                            //    ControlPoints[i].x = int.Parse(temp[0]);
                            //    ControlPoints[i].y = int.Parse(temp[1]);
                            //}
                            //导入几何特征信息
                            GeometryFeatures = new double[2];
                            //导入数据 矩形 长 宽
                            GeometryFeatures[0] = double.Parse(content[3]);
                            GeometryFeatures[1] = double.Parse(content[4]);
                            //单位
                            Unit = content[5];
                            break;
                        //圆
                        case 2:
                            MarkGeometry.AppendText("还没写完\n");
                            break;
                        default:
                            MarkGeometry.AppendText("Illegal Input!\n");
                            return;
                            break;
                    }
                    UpdateMark();
                    MessageBox.AppendText("Open Mark Success.\n");
                }

            }

        }

        private void 导出结果图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 均值滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //栈溢出检测
            if (CurrentImage >= StackDepth - 1)
            {
                StackOverflow();
                return;
            }
            else
            {
                //更新图像栈
                ImageStack[CurrentImage + 1] = Image.Mean_Filter(ImageStack[CurrentImage]);
                CurrentImage++;
                //显示更新
                ImageBox.Image = ImageStack[CurrentImage];
                MessageBox.AppendText("Mean Filter accomplished.\n");
            }    
        }

        private void 中值滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //栈溢出检测
            if (CurrentImage >= StackDepth - 1)
            {
                StackOverflow();
                return;
            }
            else
            {
                //更新图像栈
                ImageStack[CurrentImage + 1] = Image.Median_Filter(ImageStack[CurrentImage]);
                CurrentImage++;
                //显示更新
                ImageBox.Image = ImageStack[CurrentImage];
                MessageBox.AppendText("Median Filter accomplished.\n");
            }
        }

        private void 梯度倒数加权ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //栈溢出检测
            if (CurrentImage >= StackDepth - 1)
            {
                StackOverflow();
                return;
            }
            else
            {
                //更新图像栈
                ImageStack[CurrentImage + 1] = Image.Gradient_Inverse_Weight(ImageStack[CurrentImage]);
                CurrentImage++;
                //显示更新
                ImageBox.Image = ImageStack[CurrentImage];
                MessageBox.AppendText("Gradient Inverse Weight accomplished.\n");
            }

        }

        private void 梯度法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //栈溢出检测
            if (CurrentImage >= StackDepth - 1)
            {
                StackOverflow();
                return;
            }
            else
            {
                //更新图像栈
                ImageStack[CurrentImage + 1] = Image.Gradient_Sharpening(ImageStack[CurrentImage]);
                CurrentImage++;
                //显示更新
                ImageBox.Image = ImageStack[CurrentImage];
                MessageBox.AppendText("Gradient Sharpening accomplished.\n");
            }
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //栈溢出检测
            if (CurrentImage >= StackDepth - 1)
            {
                StackOverflow();
                return;
            }
            else
            {
                //更新图像栈
                ImageStack[CurrentImage + 1] = Image.Laplacian(ImageStack[CurrentImage]);
                CurrentImage++;
                //显示更新
                ImageBox.Image = ImageStack[CurrentImage];
            }
        }

        private void 线性拉伸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //栈溢出检测
            if (CurrentImage >= StackDepth - 1)
            {
                StackOverflow();
                return;
            }
            else
            {
                //更新图像栈
                ImageStack[CurrentImage + 1] = Image.Linear_Stretching_one(ImageStack[CurrentImage], 0, 255);
                CurrentImage++;
                //显示更新
                ImageBox.Image = ImageStack[CurrentImage];
            }
        }

        private void 拉伸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //栈溢出检测
            if (CurrentImage >= StackDepth - 1)
            {
                StackOverflow();
                return;
            }
            else
            {
                //更新图像栈
                ImageStack[CurrentImage + 1] = Image.Percent2_Stretching(ImageStack[CurrentImage]);
                CurrentImage++;
                //显示更新
                ImageBox.Image = ImageStack[CurrentImage];
                MessageBox.AppendText("2 Percent Stretch accomplished.\n");
            }
        }

        private void 直方图均衡化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //栈溢出检测
            if (CurrentImage >= StackDepth - 1)
            {
                StackOverflow();
                return;
            }
            else
            {
                //更新图像栈
                ImageStack[CurrentImage + 1] = Image.Histogram_Equilibrium(ImageStack[CurrentImage]);
                CurrentImage++;
                //显示更新
                ImageBox.Image = ImageStack[CurrentImage];
                MessageBox.AppendText("Histogram Equilibrium accomplished.\n");
            }
        }

        private void 撤销ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CurrentImage == 0)
            {
                MessageBox.AppendText("Fail,because it's the raw image.\n");
            }
            else
            {
                CurrentImage--;
                ImageBox.Image = ImageStack[CurrentImage];
                MessageBox.AppendText("Undo current step.\n");
            }
        }

        private void 复原ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrentImage = 0;
            ImageBox.Image = ImageStack[CurrentImage];
            MessageBox.AppendText("Image has been reset.\n");
        }

        private void 显示直方图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //**********************************//
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 矩形标志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //A = new Point(23, 304);
            //B = new Point(427, 304);
            //C = new Point(427, 34);
            //D = new Point(23, 34);

            //ControlPoints[0].x = A.X;
            //ControlPoints[0].y = A.Y;
            //ControlPoints[1].x = B.X;
            //ControlPoints[1].y = B.Y;
            //ControlPoints[2].x = C.X;
            //ControlPoints[2].y = C.Y;
            //ControlPoints[3].x = D.X;
            //ControlPoints[3].y = D.Y;

            ////DLT(1, 1, 1, 1, 1, 1);
            //L[1] = (double)-404 / (double)297;
            //L[2] = 0;
            //L[3] = -23;
            //L[4] = 0;
            //L[5] = (double)9 / (double)7;
            //L[6] = -304;
            //L[7] = 0;
            //L[8] = 0;

            //for (int i = 1; i < 9; i++)
            //    MessageBox.AppendText("L"+i.ToString()+":"+L[i].ToString() + "\n");

            ////a
            //double x1 = 297 * 3 / 404;
            //double y1 = -7 * 151 / 9;
            ////b
            //double x2 = 408 * 297 / 404;
            //double y2 = -7 * 138 / 9;
            ////c
            //double x3 = 297 * 408 / 404;
            //double y3 = -7 * 427 / 9;
            ////d
            //double x4 = 297 * 3 / 404;
            //double y4 = -7 * 427 / 9;
            //MessageBox.AppendText("点1的相对物方空间坐标:" + x1.ToString() + "," + y1.ToString() + "\n");
            //MessageBox.AppendText("点2的相对物方空间坐标:" + x2.ToString() + "," + y2.ToString() + "\n");
            //MessageBox.AppendText("点3的相对物方空间坐标:" + x3.ToString() + "," + y3.ToString() + "\n");
            //MessageBox.AppendText("点4的相对物方空间坐标:" + x4.ToString() + "," + y4.ToString() + "\n");
            //double d1 = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            //double d2 = Math.Sqrt((x2 - x3) * (x2 - x3) + (y2 - y3) * (y2 - y3));
            //double d3 = Math.Sqrt((x3 - x4) * (x3 - x4) + (y3 - y4) * (y3 - y4));
            //double d4 = Math.Sqrt((x1 - x4) * (x1 - x4) + (y1 - y4) * (y1 - y4));
            //MessageBox.AppendText("线段距离为:" + d1.ToString() + "\n");
            //MessageBox.AppendText("线段距离为:" + d2.ToString() + "\n");
            //MessageBox.AppendText("线段距离为:" + d3.ToString() + "\n");
            //MessageBox.AppendText("线段距离为:" + d4.ToString() + "\n");
            //Rectangle r = new Rectangle(23, 24, 404, 270);
            //Graphics g = Graphics.FromImage(TheImage.image);
            //g.DrawRectangle(new Pen(Color.Red, 3), r);
            //A = new Point(696, 712);
            //B = new Point(3243, 712);
            //C = new Point(3243, 2395);
            //D = new Point(696, 2395);

            //ControlPoints[0].x = A.X;
            //ControlPoints[0].y = A.Y;
            //ControlPoints[1].x = B.X;
            //ControlPoints[1].y = B.Y;
            //ControlPoints[2].x = C.X;
            //ControlPoints[2].y = C.Y;
            //ControlPoints[3].x = D.X;
            //ControlPoints[3].y = D.Y;

            //L[1] = (double)-2547 / (double)105;
            //L[2] = 0;
            //L[3] = -696;
            //L[4] = 0;
            //L[5] = (double)1683/ (double)68;
            //L[6] = -2395;
            //L[7] = 0;
            //L[8] = 0;

            //for (int i = 1; i < 9; i++)
            //    MessageBox.AppendText("L" + i.ToString() + ":" + L[i].ToString() + "\n");

            ////a
            //double x1 = 105 * (2806-696) / 2547;
            //double y1 = 68 * (2395-1038) / 1683;
            ////b
            //double x2 = 105 * (3243-696) / 2547;
            //double y2 = 68 * (2395 -1038) / 1683;
            ////c
            //double x3 = 105 * (3243-696) / 2547;
            //double y3 = 68 * (2395 -2043) / 1683;
            ////d
            //double x4 = 105 * (2806-696) / 2547;
            //double y4 = 68 * (2395 -2043) / 1683;
            //MessageBox.AppendText("点1的相对物方空间坐标:" + x1.ToString() + "," + y1.ToString() + "\n");
            //MessageBox.AppendText("点2的相对物方空间坐标:" + x2.ToString() + "," + y2.ToString() + "\n");
            //MessageBox.AppendText("点3的相对物方空间坐标:" + x3.ToString() + "," + y3.ToString() + "\n");
            //MessageBox.AppendText("点4的相对物方空间坐标:" + x4.ToString() + "," + y4.ToString() + "\n");
            //double d1 = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            //double d2 = Math.Sqrt((x2 - x3) * (x2 - x3) + (y2 - y3) * (y2 - y3));
            //double d3 = Math.Sqrt((x3 - x4) * (x3 - x4) + (y3 - y4) * (y3 - y4));
            //double d4 = Math.Sqrt((x1 - x4) * (x1 - x4) + (y1 - y4) * (y1 - y4));
            //MessageBox.AppendText("线段距离为:" + d1.ToString() + "\n");
            //MessageBox.AppendText("线段距离为:" + d2.ToString() + "\n");
            //MessageBox.AppendText("线段距离为:" + d3.ToString() + "\n");
            //MessageBox.AppendText("线段距离为:" + d4.ToString() + "\n");
        }

        private void 线ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //DLT

        }

        private void 制作标识ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 自动匹配ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ImageBox_Click(object sender, EventArgs e)
        {

        }

        private void 圆形标志ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            //Rectangle r = new Rectangle(23, 24, 404, 270);
            //Graphics g = ImageBox.CreateGraphics();
            //g.DrawRectangle(new Pen(Color.Red, 3), r);
        }

        private void 图像平滑ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 线性拉伸ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //栈溢出检测
            if (CurrentImage >= StackDepth - 1)
            {
                StackOverflow();
                return;
            }
            else
            {
                //更新图像栈
                ImageStack[CurrentImage + 1] = Image.Linear_Stretching_one(ImageStack[CurrentImage], 0, 255);
                CurrentImage++;
                //显示更新
                ImageBox.Image = ImageStack[CurrentImage];
            }
        }

        private void ImageBox_Mouseup(object sender, MouseEventArgs e)
        {

        }

        private void ImageBox_Mousemove(object sender, MouseEventArgs e)
        {

        }

        private void Image_Paint(object sender,PaintEventArgs e)
        {
            //Rectangle r = new Rectangle(23, 24, 404, 270);
            //e.Graphics.DrawRectangle(new Pen(Color.Red, 3), r);
        }

        private void 图像拉伸ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 结束ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPoints[0] = Matching.MAD(TheMark, ImageStack[CurrentImage]);
            MessageBox.AppendText(ControlPoints[0].x.ToString() + '\n' + ControlPoints[0].y.ToString());
            ControlPoints[1].x = ControlPoints[0].x + MarkWidth;
            ControlPoints[1].y = ControlPoints[0].y;
            ControlPoints[2].x = ControlPoints[0].x + MarkWidth;
            ControlPoints[2].y = ControlPoints[0].y + MarkHeight;
            ControlPoints[3].x = ControlPoints[0].x;
            ControlPoints[3].y = ControlPoints[0].y + MarkHeight;
            Rectangle r = new Rectangle(ControlPoints[0].x, ControlPoints[0].y, MarkWidth, MarkHeight);
            //绘制矩形
            Graphics g = ImageBox.CreateGraphics();
            g.DrawRectangle(RedPen, r);
        }

        private void sADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPoints[0] = Matching.SAD(TheMark, ImageStack[CurrentImage]);
            ControlPoints[1].x = ControlPoints[0].x + MarkWidth;
            ControlPoints[1].y = ControlPoints[0].y;
            ControlPoints[2].x = ControlPoints[0].x + MarkWidth;
            ControlPoints[2].y = ControlPoints[0].y + MarkHeight;
            ControlPoints[3].x = ControlPoints[0].x;
            ControlPoints[3].y = ControlPoints[0].y + MarkHeight;
            Rectangle r = new Rectangle(ControlPoints[0].x, ControlPoints[0].y, MarkWidth, MarkHeight);
            //绘制矩形
            Graphics g = ImageBox.CreateGraphics();
            g.DrawRectangle(RedPen, r);
        }

        private void sSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPoints[0] = Matching.SSD(TheMark, ImageStack[CurrentImage]);
            ControlPoints[1].x = ControlPoints[0].x + MarkWidth;
            ControlPoints[1].y = ControlPoints[0].y;
            ControlPoints[2].x = ControlPoints[0].x + MarkWidth;
            ControlPoints[2].y = ControlPoints[0].y + MarkHeight;
            ControlPoints[3].x = ControlPoints[0].x;
            ControlPoints[3].y = ControlPoints[0].y + MarkHeight;
            Rectangle r = new Rectangle(ControlPoints[0].x, ControlPoints[0].y, MarkWidth, MarkHeight);
            //绘制矩形
            Graphics g = ImageBox.CreateGraphics();
            g.DrawRectangle(RedPen, r);
        }


    }
}
