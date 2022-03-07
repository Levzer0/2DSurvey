using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DSurvey
{
    static class Tools
    {
        //求中值
        static public int Get_Median(int a, int b, int c)
        {
            int temp;
            //排序
            if (a > b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            if (b > c)
            {
                temp = b;
                b = c;
                c = temp;
            }
            if (a > b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            return b;
        }
        //卷积
        static public Bitmap Convolution(Bitmap b,int[] Template)
        {
            int H = b.Height;
            int W = b.Width;
            int[,] b_R = new int[W, H];
            int[,] b_G = new int[W, H];
            int[,] b_B = new int[W, H];
            int[,] r_R = new int[W, H];
            int[,] r_G = new int[W, H];
            int[,] r_B = new int[W, H];
            Bitmap result = new Bitmap(W, H);
            Color temp;
            //像素值读入矩阵
            for(int i=0;i<W;i++)
                for(int j=0;j<H;j++)
                {
                    b_R[i, j] = b.GetPixel(i, j).R;
                    b_G[i, j] = b.GetPixel(i, j).G;
                    b_B[i, j] = b.GetPixel(i, j).B;
                    r_R[i, j] = b.GetPixel(i, j).R;
                    r_G[i, j] = b.GetPixel(i, j).G;
                    r_B[i, j] = b.GetPixel(i, j).B;
                }
            //卷积计算
            int R_max = 0;
            int R_min = 255;
            int G_max = 0;
            int G_min = 255;
            int B_max = 0;
            int B_min = 255;

            for(int i=1;i<W-1;i++)
                for(int j=1;j<H-1;j++)
                {
                    //R通道卷积
                    r_R[i, j] = b_R[i - 1, j - 1] * Template[0] + b_R[i, j - 1] * Template[1] + b_R[i + 1, j - 1] * Template[2];
                    r_R[i, j] += b_R[i - 1, j] * Template[3] + b_R[i, j] * Template[4] + b_R[i + 1, j] * Template[5];
                    r_R[i, j] += b_R[i - 1, j + 1] * Template[6] + b_R[i, j + 1] * Template[7] + b_R[i + 1, j + 1] * Template[8];
                    if (r_R[i, j] > R_max)
                        R_max = r_R[i, j];
                    if (r_R[i, j] < R_min)
                        R_min = r_R[i, j];
                    //G通道卷积
                    r_G[i, j] = b_G[i - 1, j - 1] * Template[0] + b_G[i, j - 1] * Template[1] + b_G[i + 1, j - 1] * Template[2];
                    r_G[i, j] += b_G[i - 1, j] * Template[3] + b_G[i, j] * Template[4] + b_G[i + 1, j] * Template[5];
                    r_G[i, j] += b_G[i - 1, j + 1] * Template[6] + b_G[i, j + 1] * Template[7] + b_G[i + 1, j + 1] * Template[8];
                    if (r_G[i, j] > G_max)
                        G_max = r_G[i, j];
                    if (r_G[i, j] < G_min)
                        G_min = r_G[i, j];
                    //B通道卷积
                    r_B[i, j] = b_B[i - 1, j - 1] * Template[0] + b_B[i, j - 1] * Template[1] + b_B[i + 1, j - 1] * Template[2];
                    r_B[i, j] += b_B[i - 1, j] * Template[3] + b_B[i, j] * Template[4] + b_B[i + 1, j] * Template[5];
                    r_B[i, j] += b_B[i - 1, j + 1] * Template[6] + b_B[i, j + 1] * Template[7] + b_B[i + 1, j + 1] * Template[8];
                    if (r_B[i, j] > B_max)
                        B_max = r_B[i, j];
                    if (r_B[i, j] < B_min)
                        B_min = r_B[i, j];
                }
            //灰度变化为0-255并转为图像
            for (int i = 1; i < W - 1; i++)
                for (int j = 1; j < H - 1; j++)
                {
                    r_R[i, j] = 255 * (r_R[i, j] - R_min) / (R_max - R_min);
                    r_G[i, j] = 255 * (r_G[i, j] - G_min) / (G_max - G_min);
                    r_B[i, j] = 255 * (r_B[i, j] - B_min) / (R_max - B_min);
                    temp = Color.FromArgb(r_R[i, j], r_G[i, j], r_B[i, j]);
                    result.SetPixel(i, j, temp);
                }

             return result;
        }
        //计算DLT方程系数
        static public double[] DLT_Equations(double[] factor)
        {
            return factor;
        }
        //图像相加
        static public Bitmap plusBitmap(Bitmap a,Bitmap b)
        {
            int H = a.Height;
            int W = a.Width;
            Bitmap c = new Bitmap(a.Width, a.Height);
            
            for(int i=0;i<W;i++)
                for(int j=0;j<H;j++)
                {
                    int R = a.GetPixel(i, j).R + b.GetPixel(i, j).R;
                    int G = a.GetPixel(i, j).G + b.GetPixel(i, j).G;
                    int B = a.GetPixel(i, j).B + b.GetPixel(i, j).B;
                    c.SetPixel(i, j, Color.FromArgb(R / 2, G / 2, B / 2));
                }
            
            return c;
        }
    }
}
