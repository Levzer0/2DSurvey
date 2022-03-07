using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DSurvey
{
    static class Image
    {
        //均值滤波
        static public Bitmap Mean_Filter(Bitmap b)
        {
            int H = b.Height;
            int W = b.Width;
            Bitmap result = new Bitmap(W, H);
            int[,] R_Matrix = new int[W, H];
            int[,] G_Matrix = new int[W, H];
            int[,] B_Matrix = new int[W, H];
            Color temp;
            //像素值读入矩阵
            for(int i=0;i<W;i++)
                for(int j=0;j<H;j++)
                {
                    R_Matrix[i, j] = b.GetPixel(i, j).R;
                    G_Matrix[i, j] = b.GetPixel(i, j).G;
                    B_Matrix[i, j] = b.GetPixel(i, j).B;
                }
            //均值滤波
            for (int i = 1; i < W-1; i++)
                for (int j = 1; j < H-1; j++)
                {
                    R_Matrix[i, j] = (R_Matrix[i - 1, j - 1] + R_Matrix[i, j - 1] + R_Matrix[i + 1, j - 1] + R_Matrix[i - 1, j] + R_Matrix[i + 1, j] + R_Matrix[i - 1, j + 1] + R_Matrix[i, j + 1] + R_Matrix[i + 1, j + 1]) / 8;
                    G_Matrix[i, j] = (G_Matrix[i - 1, j - 1] + G_Matrix[i, j - 1] + G_Matrix[i + 1, j - 1] + G_Matrix[i - 1, j] + G_Matrix[i + 1, j] + G_Matrix[i - 1, j + 1] + G_Matrix[i, j + 1] + G_Matrix[i + 1, j + 1]) / 8;
                    B_Matrix[i, j] = (B_Matrix[i - 1, j - 1] + B_Matrix[i, j - 1] + B_Matrix[i + 1, j - 1] + B_Matrix[i - 1, j] + B_Matrix[i + 1, j] + B_Matrix[i - 1, j + 1] + B_Matrix[i, j + 1] + B_Matrix[i + 1, j + 1]) / 8;
                }
            //矩阵值返回图像
            for (int i = 0; i < W; i++)
                for (int j = 0; j < H; j++)
                {
                    temp = Color.FromArgb(R_Matrix[i, j], G_Matrix[i, j], B_Matrix[i, j]);
                    result.SetPixel(i, j, temp);
                }
            return result;
        }
        //中值滤波
        static public Bitmap Median_Filter(Bitmap b)
        {
            int H = b.Height;
            int W = b.Width;
            Bitmap result = new Bitmap(W, H);
            int[,] R_Matrix = new int[W, H];
            int[,] G_Matrix = new int[W, H];
            int[,] B_Matrix = new int[W, H];
            Color temp;
            //像素值读入矩阵
            for (int i = 0; i < W; i++)
                for (int j = 0; j < H; j++)
                {
                    R_Matrix[i, j] = b.GetPixel(i, j).R;
                    G_Matrix[i, j] = b.GetPixel(i, j).G;
                    B_Matrix[i, j] = b.GetPixel(i, j).B;
                }
            //中值滤波
            for (int i = 1; i < W-1; i++)
                for (int j = 1; j < H-1; j++)
                {
                    R_Matrix[i, j] = Tools.Get_Median(R_Matrix[i - 1, j], R_Matrix[i, j], R_Matrix[i + 1, j]);
                    G_Matrix[i, j] = Tools.Get_Median(G_Matrix[i - 1, j], G_Matrix[i, j], G_Matrix[i + 1, j]);
                    B_Matrix[i, j] = Tools.Get_Median(B_Matrix[i - 1, j], B_Matrix[i, j], B_Matrix[i + 1, j]);
                }
            //矩阵值返回图像
            for (int i = 0; i < W; i++)
                for (int j = 0; j < H; j++)
                {
                    temp = Color.FromArgb(R_Matrix[i, j], G_Matrix[i, j], B_Matrix[i, j]);
                    result.SetPixel(i, j, temp);
                }
            return result;
        }
        //梯度倒数加权
        static public Bitmap Gradient_Inverse_Weight(Bitmap b)
        {
            int H = b.Height;
            int W = b.Width;
            Bitmap r = new Bitmap(W, H);
            int[,] R_Matrix = new int[W, H];
            int[,] G_Matrix = new int[W, H];
            int[,] B_Matrix = new int[W, H];
            Color temp;
            //像素值读入矩阵
            for (int i = 0; i < W; i++)
                for (int j = 0; j < H; j++)
                {
                    R_Matrix[i, j] = b.GetPixel(i, j).R;
                    G_Matrix[i, j] = b.GetPixel(i, j).G;
                    B_Matrix[i, j] = b.GetPixel(i, j).B;
                }
            //梯度倒数加权
            //R通道
            for (int i = 1; i < W-1; i++)
                for (int j = 1; j < H-1; j++)
                {
                    //计算梯度倒数
                    double w1 = Math.Abs(R_Matrix[i - 1, j - 1] - R_Matrix[i, j]);
                    double w2 = Math.Abs(R_Matrix[i, j - 1] - R_Matrix[i, j]);
                    double w3 = Math.Abs(R_Matrix[i + 1, j - 1] - R_Matrix[i, j]);
                    double w4 = Math.Abs(R_Matrix[i - 1, j] - R_Matrix[i, j]);
                    double w5 = Math.Abs(R_Matrix[i + 1, j] - R_Matrix[i, j]);
                    double w6 = Math.Abs(R_Matrix[i - 1, j + 1] - R_Matrix[i, j]);
                    double w7 = Math.Abs(R_Matrix[i, j + 1] - R_Matrix[i, j]);
                    double w8 = Math.Abs(R_Matrix[i + 1, j + 1] - R_Matrix[i, j]);
                    //系数归一化
                    double sum = w1 + w2 + w3 + w4 + w5 + w6 + w7 + w8;

                    if (sum == 0)
                        continue;
                    w1 = w1 / sum / 2;
                    w2 = w2 / sum / 2;
                    w3 = w3 / sum / 2;
                    w4 = w4 / sum / 2;
                    w5 = w5 / sum / 2;
                    w6 = w6 / sum / 2;
                    w7 = w7 / sum / 2;
                    w8 = w8 / sum / 2;
                    //计算
                    double result = w1 * R_Matrix[i - 1, j - 1] + w2 * R_Matrix[i, j - 1] + w3 * R_Matrix[i + 1, j - 1] + w4 * R_Matrix[i - 1, j];
                    result += R_Matrix[i, j] / 2 + w5 * R_Matrix[i + 1, j] + w6 * R_Matrix[i - 1, j + 1] + w7 * R_Matrix[i, j + 1] + w8 * R_Matrix[i + 1, j + 1];

                    R_Matrix[i, j] = (int)result;
                }
            //G通道
            for (int i = 1; i < W-1; i++)
                for (int j = 1; j < H-1; j++)
                {
                    //计算梯度倒数
                    double w1 = Math.Abs(G_Matrix[i - 1, j - 1] - G_Matrix[i, j]);
                    double w2 = Math.Abs(G_Matrix[i, j - 1] - G_Matrix[i, j]);
                    double w3 = Math.Abs(G_Matrix[i + 1, j - 1] - G_Matrix[i, j]);
                    double w4 = Math.Abs(G_Matrix[i - 1, j] - G_Matrix[i, j]);
                    double w5 = Math.Abs(G_Matrix[i + 1, j] - G_Matrix[i, j]);
                    double w6 = Math.Abs(G_Matrix[i - 1, j + 1] - G_Matrix[i, j]);
                    double w7 = Math.Abs(G_Matrix[i, j + 1] - G_Matrix[i, j]);
                    double w8 = Math.Abs(G_Matrix[i + 1, j + 1] - G_Matrix[i, j]);
                    //系数归一化
                    double sum = w1 + w2 + w3 + w4 + w5 + w6 + w7 + w8;

                    if (sum == 0)
                        continue;
                    w1 = w1 / sum / 2;
                    w2 = w2 / sum / 2;
                    w3 = w3 / sum / 2;
                    w4 = w4 / sum / 2;
                    w5 = w5 / sum / 2;
                    w6 = w6 / sum / 2;
                    w7 = w7 / sum / 2;
                    w8 = w8 / sum / 2;
                    //计算
                    double result = w1 * G_Matrix[i - 1, j - 1] + w2 * G_Matrix[i, j - 1] + w3 * G_Matrix[i + 1, j - 1] + w4 * G_Matrix[i - 1, j];
                    result += G_Matrix[i, j] / 2 + w5 * G_Matrix[i + 1, j] + w6 * G_Matrix[i - 1, j + 1] + w7 * G_Matrix[i, j + 1] + w8 * G_Matrix[i + 1, j + 1];

                    G_Matrix[i, j] = (int)result;
                }
            //B通道
            for (int i = 1; i < W-1; i++)
                for (int j = 1; j < H-1; j++)
                {
                    //计算梯度倒数
                    double w1 = Math.Abs(B_Matrix[i - 1, j - 1] - B_Matrix[i, j]);
                    double w2 = Math.Abs(B_Matrix[i, j - 1] - B_Matrix[i, j]);
                    double w3 = Math.Abs(B_Matrix[i + 1, j - 1] - B_Matrix[i, j]);
                    double w4 = Math.Abs(B_Matrix[i - 1, j] - B_Matrix[i, j]);
                    double w5 = Math.Abs(B_Matrix[i + 1, j] - B_Matrix[i, j]);
                    double w6 = Math.Abs(B_Matrix[i - 1, j + 1] - B_Matrix[i, j]);
                    double w7 = Math.Abs(B_Matrix[i, j + 1] - B_Matrix[i, j]);
                    double w8 = Math.Abs(B_Matrix[i + 1, j + 1] - B_Matrix[i, j]);
                    //系数归一化
                    double sum = w1 + w2 + w3 + w4 + w5 + w6 + w7 + w8;

                    if (sum == 0)
                        continue;
                    w1 = w1 / sum / 2;
                    w2 = w2 / sum / 2;
                    w3 = w3 / sum / 2;
                    w4 = w4 / sum / 2;
                    w5 = w5 / sum / 2;
                    w6 = w6 / sum / 2;
                    w7 = w7 / sum / 2;
                    w8 = w8 / sum / 2;
                    //计算
                    double result = w1 * B_Matrix[i - 1, j - 1] + w2 * B_Matrix[i, j - 1] + w3 * B_Matrix[i + 1, j - 1] + w4 * B_Matrix[i - 1, j];
                    result += B_Matrix[i, j] / 2 + w5 * B_Matrix[i + 1, j] + w6 * B_Matrix[i - 1, j + 1] + w7 * B_Matrix[i, j + 1] + w8 * B_Matrix[i + 1, j + 1];

                    B_Matrix[i, j] = (int)result;
                }
            //矩阵值返回图像
            for (int i = 0; i < W; i++)
                for (int j = 0; j < H; j++)
                {
                    temp = Color.FromArgb(R_Matrix[i, j], G_Matrix[i, j], B_Matrix[i, j]);
                    r.SetPixel(i, j, temp);
                }

            return r;
        }
        //梯度法锐化
        static public Bitmap Gradient_Sharpening(Bitmap b)
        {
            int H = b.Height;
            int W = b.Width;
            Bitmap result = new Bitmap(W, H);
            Color temp;
            //各波段X Y方向特征矩阵
            int[,] R_MatrixX = new int[W, H];
            int[,] R_MatrixY = new int[W, H];
            int[,] G_MatrixX = new int[W, H];
            int[,] G_MatrixY = new int[W, H];
            int[,] B_MatrixX = new int[W, H];
            int[,] B_MatrixY = new int[W, H];
            //各波段特征图像范围
            int Rmax = 0;
            int Rmin = 255;
            int Gmax = 0;
            int Gmin = 255;
            int Bmax = 0;
            int Bmin = 255;
            //像素值读入矩阵
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    R_MatrixX[i, j] = b.GetPixel(i, j).R;
                    G_MatrixX[i, j] = b.GetPixel(i, j).G;
                    B_MatrixX[i, j] = b.GetPixel(i, j).B;
                }
            }
            R_MatrixY = R_MatrixX;
            G_MatrixY = G_MatrixX;
            B_MatrixY = B_MatrixX;
            //计算特征矩阵
            //X方向
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    R_MatrixX[i, j] = R_MatrixX[i, j] - R_MatrixX[i + 1, j];
                    G_MatrixX[i, j] = G_MatrixX[i, j] - G_MatrixX[i + 1, j];
                    B_MatrixX[i, j] = B_MatrixX[i, j] - B_MatrixX[i + 1, j];
                }
            }
            //Y方向
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    R_MatrixY[i, j] = R_MatrixY[i, j] - R_MatrixY[i, j + 1];
                    G_MatrixY[i, j] = G_MatrixY[i, j] - G_MatrixY[i, j + 1];
                    B_MatrixY[i, j] = B_MatrixY[i, j] - B_MatrixY[i, j + 1];
                }
            }
            //相加得到梯度图像矩阵
            Rmax = R_MatrixX[0, 0] + R_MatrixY[0, 0];
            Rmin = Rmax;
            Gmax = G_MatrixX[0, 0] + G_MatrixY[0, 0];
            Gmin = Gmax;
            Bmax = B_MatrixX[0, 0] + B_MatrixY[0, 0];
            Bmin = Bmax;

            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    //R
                    R_MatrixX[i, j] = R_MatrixX[i, j] + R_MatrixY[i, j];
                    if (R_MatrixX[i, j] > Rmax)
                        Rmax = R_MatrixX[i, j];
                    if (R_MatrixX[i, j] < Rmin)
                        Rmin = R_MatrixX[i, j];
                    //G
                    G_MatrixX[i, j] = G_MatrixX[i, j] + G_MatrixY[i, j];
                    if (G_MatrixX[i, j] > Gmax)
                        Gmax = G_MatrixX[i, j];
                    if (G_MatrixX[i, j] < Gmin)
                        Gmin = G_MatrixX[i, j];
                    //B
                    B_MatrixX[i, j] = B_MatrixX[i, j] + B_MatrixY[i, j];
                    if (B_MatrixX[i, j] > Bmax)
                        Bmax = B_MatrixX[i, j];
                    if (B_MatrixX[i, j] < Bmin)
                        Bmin = B_MatrixX[i, j];
                }
            }
            //灰度变换到正值
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    R_MatrixX[i, j] = 255 * (R_MatrixX[i, j] - Rmin) / (Rmax - Rmin);
                    G_MatrixX[i, j] = 255 * (G_MatrixX[i, j] - Gmin) / (Gmax - Gmin);
                    B_MatrixX[i, j] = 255 * (B_MatrixX[i, j] - Bmin) / (Bmax - Bmin);
                }
            }
            //矩阵返回图像
            for(int i=0;i<W;i++)
                for(int j=0;j<H;j++)
                {
                    temp = Color.FromArgb(R_MatrixX[i, j], G_MatrixX[i, j], B_MatrixX[i, j]);
                    result.SetPixel(i, j, temp);
                }
            return Tools.plusBitmap(result, b);
        }
        //直方图均衡化
        static public Bitmap Histogram_Equilibrium(Bitmap b)
        {
            int H = b.Height;
            int W = b.Width;
            Histogram histogram = new Histogram(b);
            Bitmap result = new Bitmap(W, H);
            //累积频率直方图
            double[] R_CumulativeFrequency_Histogram = new double[256];
            double[] G_CumulativeFrequency_Histogram = new double[256];
            double[] B_CumulativeFrequency_Histogram = new double[256];
            //理论累积频率直方图
            double[] Theoretical_CumulativeFrequency_Histogram = new double[256];
            //计算累积频率
            for(int i=0;i<256;i++)
            {
                R_CumulativeFrequency_Histogram[i] = (double)histogram.R_Cumulative_Histogram[i] / ((double)H * (double)W);
                G_CumulativeFrequency_Histogram[i] = (double)histogram.G_Cumulative_Histogram[i] / ((double)H * (double)W);
                B_CumulativeFrequency_Histogram[i] = (double)histogram.B_Cumulative_Histogram[i] / ((double)H * (double)W);
            }
            //计算理论累积频率
            for (int i = 0; i < 256; i++)
                Theoretical_CumulativeFrequency_Histogram[i] = (i + 1) / 256;
            //直方图均衡化
            for(int i=0;i<W;i++)
            {
                for(int j=0;j<H;j++)
                {
                    //累积频率
                    double R_CF = R_CumulativeFrequency_Histogram[b.GetPixel(i, j).R];
                    double G_CF = G_CumulativeFrequency_Histogram[b.GetPixel(i, j).G];
                    double B_CF = B_CumulativeFrequency_Histogram[b.GetPixel(i, j).B];
                    //最小频率和理论频率差
                    double R_differ_min = 1;
                    double G_differ_min = 1;
                    double B_differ_min = 1;
                    //新值
                    int R_new_value = 0;
                    int G_new_value = 0;
                    int B_new_value = 0;
                    //匹配
                    for(int k=0;k<256;k++)
                    {
                        //R通道
                        if(Math.Abs(R_CF-Theoretical_CumulativeFrequency_Histogram[k])<R_differ_min)
                        {
                            R_differ_min = R_CF - Theoretical_CumulativeFrequency_Histogram[k];
                            R_new_value = k;
                        }
                        //G通道
                        if (Math.Abs(G_CF - Theoretical_CumulativeFrequency_Histogram[k]) < G_differ_min)
                        {
                            G_differ_min = G_CF - Theoretical_CumulativeFrequency_Histogram[k];
                            G_new_value = k;
                        }
                        //B通道
                        if (Math.Abs(B_CF - Theoretical_CumulativeFrequency_Histogram[k]) < B_differ_min)
                        {
                            B_differ_min = B_CF - Theoretical_CumulativeFrequency_Histogram[k];
                            B_new_value = k;
                        }
                    }
                    //给像素赋新值
                    Color temp = Color.FromArgb(R_new_value, G_new_value, B_new_value);
                    result.SetPixel(i, j, temp);
                }
            }
            return result;
        }
        //单通道参数线性拉伸
        static public Bitmap Linear_Stretching_one(Bitmap b,int min,int max)
        {
            int H = b.Height;
            int W = b.Width;
            Bitmap result = new Bitmap(W, H);
            Histogram histogram = new Histogram(b);
            int R_min = 255;
            int G_min = 255;
            int B_min = 255;
            int R_max = 0;
            int G_max = 0;
            int B_max = 0;
            //求图像灰度范围
            for(int i=0;i<256;i++)
            {
                //R通道
                if(histogram.R_Histogram[i]!=0)
                {
                    if (i < R_min)
                        R_min = i;
                    if (i > R_max)
                        R_max = i;
                }
                //G通道
                if (histogram.G_Histogram[i] != 0)
                {
                    if (i < G_min)
                        G_min = i;
                    if (i > G_max)
                        G_max = i;
                }
                //B通道
                if (histogram.B_Histogram[i] != 0)
                {
                    if (i < B_min)
                        B_min = i;
                    if (i > B_max)
                        B_max = i;
                }
            }
            //遍历求新值
            for(int i=0;i<W;i++)
                for(int j=0;j<H;j++)
                {
                    int R = (max - min) * (b.GetPixel(i, j).R - R_min) / (R_max - R_min) + min;
                    int G = (max - min) * (b.GetPixel(i, j).G - G_min) / (G_max - G_min) + min;
                    int B = (max - min) * (b.GetPixel(i, j).B - B_min) / (B_max - B_min) + min;
                    Color temp = Color.FromArgb(R, G, B);
                    result.SetPixel(i, j, temp);
                }
            return result; 
        }
        //多通道参数线性拉伸
        static public Bitmap Linear_Stretching_Three(Bitmap b,int R_MIN, int R_MAX,int G_MIN,int G_MAX,int B_MIN,int B_MAX)
        {
            int H = b.Height;
            int W = b.Width;
            Bitmap result = new Bitmap(W, H);
            Histogram histogram = new Histogram(b);
            int R_min = 255;
            int G_min = 255;
            int B_min = 255;
            int R_max = 0;
            int G_max = 0;
            int B_max = 0;
            //求图像灰度范围
            for (int i = 0; i < 256; i++)
            {
                //R通道
                if (histogram.R_Histogram[i] != 0)
                {
                    if (i < R_min)
                        R_min = i;
                    if (i > R_max)
                        R_max = i;
                }
                //G通道
                if (histogram.G_Histogram[i] != 0)
                {
                    if (i < G_min)
                        G_min = i;
                    if (i > G_max)
                        G_max = i;
                }
                //B通道
                if (histogram.B_Histogram[i] != 0)
                {
                    if (i < B_min)
                        B_min = i;
                    if (i > B_max)
                        B_max = i;
                }
            }
            //遍历求新值
            for (int i = 0; i < W; i++)
                for (int j = 0; j < H; j++)
                {
                    int R = (R_MAX - R_MIN) * (b.GetPixel(i, j).R - R_min) / (R_max - R_min) + R_MIN;
                    int G = (G_MAX - G_MIN) * (b.GetPixel(i, j).G - G_min) / (G_max - G_min) + G_MIN;
                    int B = (B_MAX - B_MIN) * (b.GetPixel(i, j).B - B_min) / (B_max - B_min) + B_MIN;
                    Color temp = Color.FromArgb(R, G, B);
                    result.SetPixel(i, j, temp);
                }
            return result;
        }
        //2%拉伸
        static public Bitmap Percent2_Stretching(Bitmap b)
        {
            int H = b.Height;
            int W = b.Width;
            Histogram histogram = new Histogram(b);
            //累积频率直方图
            double[] R_CumulativeFrequency_Histogram = new double[256];
            double[] G_CumulativeFrequency_Histogram = new double[256];
            double[] B_CumulativeFrequency_Histogram = new double[256];
            //计算累积频率
            for (int i = 0; i < 256; i++)
            {
                R_CumulativeFrequency_Histogram[i] = (double)histogram.R_Cumulative_Histogram[i] / ((double)H * (double)W);
                G_CumulativeFrequency_Histogram[i] = (double)histogram.G_Cumulative_Histogram[i] / ((double)H * (double)W);
                B_CumulativeFrequency_Histogram[i] = (double)histogram.B_Cumulative_Histogram[i] / ((double)H * (double)W);
            }
            //计算拉伸域
            int R_max = 255;
            int G_max = 255;
            int B_max = 255;
            int R_min = 0;
            int G_min = 0;
            int B_min = 0;
            double R_equal2 = 1;
            double R_equal98 = 1;
            double G_equal2 = 1;
            double G_equal98 = 1;
            double B_equal2 = 1;
            double B_equal98 = 1;

            for(int i=0;i<256;i++)
            {
                //R通道
                if(Math.Abs(R_CumulativeFrequency_Histogram[i]-0.02)<R_equal2)
                {
                    R_equal2 = Math.Abs(R_CumulativeFrequency_Histogram[i] - 0.02);
                    R_min = i;
                }
                if(Math.Abs(R_CumulativeFrequency_Histogram[i]-0.98)<R_equal98)
                {
                    R_equal98 = Math.Abs(R_CumulativeFrequency_Histogram[i] - 0.98);
                    R_max = i;
                }
                //G通道
                if (Math.Abs(G_CumulativeFrequency_Histogram[i] - 0.02) < G_equal2)
                {
                    G_equal2 = Math.Abs(G_CumulativeFrequency_Histogram[i] - 0.02);
                    G_min = i;
                }
                if (Math.Abs(G_CumulativeFrequency_Histogram[i] - 0.98) < G_equal98)
                {
                    G_equal98 = Math.Abs(G_CumulativeFrequency_Histogram[i] - 0.98);
                    G_max = i;
                }
                //B通道
                if (Math.Abs(B_CumulativeFrequency_Histogram[i] - 0.02) < B_equal2)
                {
                    B_equal2 = Math.Abs(B_CumulativeFrequency_Histogram[i] - 0.02);
                    B_min = i;
                }
                if (Math.Abs(B_CumulativeFrequency_Histogram[i] - 0.98) < B_equal98)
                {
                    B_equal98 = Math.Abs(B_CumulativeFrequency_Histogram[i] - 0.98);
                    B_max = i;
                }
            }
            //拉伸
            return Linear_Stretching_Three(b, R_min, R_max, G_min, G_max, B_min, B_max);
        }
        //Laplacian
        static public Bitmap Laplacian(Bitmap b)
        {
            int[] Ltemple = { 0, 1, 0, 1, -4, 1, 0, 1, 0 };
            return Tools.plusBitmap(Tools.Convolution(b, Ltemple), b);
            //return Tools.Convolution(b, Ltemple);
        }
    }
}
