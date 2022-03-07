using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DSurvey
{
    static class Matching
    {
        //平均绝对差
        static public ImagePoint MAD(Bitmap Mark,Bitmap b)
        {
            ImagePoint result = new ImagePoint(0, 0);
            double DMin = 100000;
            double D_R, D_G, D_B;
            int w = Mark.Width;
            int h = Mark.Height;
            int W = b.Width;
            int H = b.Height;
            //遍历图像中每一个模板大小的子图
            for (int i = 0; i < W - w; i++)
            {
                for (int j = 0; j < H - h; j++)
                {
                    D_R = 0;
                    D_G = 0;
                    D_B = 0;
                    //计算子图与模板相似度
                    for (int m = 0; m < w; m++)
                        for (int n = 0; n < h; n++)
                        {
                            //R波段
                            D_R += Math.Abs(Mark.GetPixel(m, n).R - b.GetPixel(i + m, j + n).R);
                            //G波段
                            D_G += Math.Abs(Mark.GetPixel(m, n).G - b.GetPixel(i + m, j + n).G);
                            //B波段
                            D_B += Math.Abs(Mark.GetPixel(m, n).B - b.GetPixel(i + m, j + n).B);
                        }
                    //比较相似度
                    if (((D_R + D_G + D_B) / (w * h)) < DMin)
                    {
                        DMin = (D_R + D_G + D_B) / (w * h);
                        result.x = i;
                        result.y = j;
                    }
                }
            }
            return result;
        }
        //绝对误差和
        static public ImagePoint SAD(Bitmap Mark, Bitmap b)
        {
            ImagePoint result = new ImagePoint(0, 0);
            int DMin = 0;
            int D_R, D_G, D_B;
            int w = Mark.Width;
            int h = Mark.Height;
            int W = b.Width;
            int H = b.Height;
            //遍历图像中每一个模板大小的子图
            for (int i = 0; i < W - w; i++)
            {
                for (int j = 0; j < H - h; j++)
                {
                    D_R = 0;
                    D_G = 0;
                    D_B = 0;
                    //计算子图与模板相似度
                    for (int m = 0; m < w; m++)
                        for (int n = 0; n < h; n++)
                        {
                            //R波段
                            D_R += Math.Abs(Mark.GetPixel(m, n).R - b.GetPixel(i + m, j + n).R);
                            //G波段
                            D_G += Math.Abs(Mark.GetPixel(m, n).G - b.GetPixel(i + m, j + n).G);
                            //B波段
                            D_B += Math.Abs(Mark.GetPixel(m, n).B - b.GetPixel(i + m, j + n).B);
                        }
                    //比较相似度
                    if (i == 0)
                        DMin = D_R + D_G + D_B;
                    else
                    {
                        if ((D_R + D_G + D_B) < DMin)
                        {
                            DMin = (D_R + D_G + D_B);
                            result.x = i;
                            result.y = j;
                        }
                    }
                }
            }
            return result;
        }
        //误差平方和
        static public ImagePoint SSD(Bitmap Mark, Bitmap b)
        {
            ImagePoint result = new ImagePoint(0, 0);
            int DMin = 0;
            int D_R, D_G, D_B;
            int w = Mark.Width;
            int h = Mark.Height;
            int W = b.Width;
            int H = b.Height;
            //遍历图像中每一个模板大小的子图
            for (int i = 0; i < W - w; i++)
                for (int j = 0; j < H - h; j++)
                {
                    D_R = 0;
                    D_G = 0;
                    D_B = 0;
                    //计算子图与模板相似度
                    for (int m = 0; m < w; m++)
                        for (int n = 0; n < h; n++)
                        {
                            //R波段
                            D_R += (int)Math.Pow(Math.Abs(Mark.GetPixel(m, n).R - b.GetPixel(i + m, j + n).R), 2);
                            //G波段
                            D_G += (int)Math.Pow(Math.Abs(Mark.GetPixel(m, n).G - b.GetPixel(i + m, j + n).G), 2);
                            //B波段
                            D_B += (int)Math.Pow(Math.Abs(Mark.GetPixel(m, n).B - b.GetPixel(i + m, j + n).B), 2);
                        }
                    //比较相似度
                    if (i == 0)
                        DMin = D_R + D_G + D_B;
                    else
                    {
                        if ((D_R + D_G + D_B) < DMin)
                        {
                            DMin = (D_R + D_G + D_B);
                            result.x = i;
                            result.y = j;
                        }
                    }
                }
            return result;
        }
    }
}
