using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DSurvey
{
    class Histogram
    {
        //频数直方图
        public int[] R_Histogram;
        public int[] G_Histogram;
        public int[] B_Histogram;
        //累积直方图
        public int[] R_Cumulative_Histogram;
        public int[] G_Cumulative_Histogram;
        public int[] B_Cumulative_Histogram;
        //构造函数
        public Histogram(Bitmap b)
        {
            //初始化直方图
            R_Histogram = new int[256];
            G_Histogram = new int[256];
            B_Histogram = new int[256];
            R_Cumulative_Histogram = new int[256];
            G_Cumulative_Histogram = new int[256];
            B_Cumulative_Histogram = new int[256];

            for(int i=0;i<256;i++)
            {
                R_Histogram[i] = 0;
                G_Histogram[i] = 0;
                B_Histogram[i] = 0;
                R_Cumulative_Histogram[i] = 0;
                G_Cumulative_Histogram[i] = 0;
                B_Cumulative_Histogram[i] = 0;
            }
            //计算频数直方图
            for(int i=0;i<b.Width;i++)
                for(int j=0;j<b.Height;j++)
                {
                    int sign = b.GetPixel(i, j).R;
                    R_Histogram[sign]++;

                    sign = b.GetPixel(i, j).G;
                    G_Histogram[sign]++;

                    sign = b.GetPixel(i, j).B;
                    B_Histogram[sign]++;
                }
            //计算累积直方图
            for(int i=0;i<256;i++)
            {
                if(i==0)
                {
                    R_Cumulative_Histogram[i] = R_Histogram[i];
                    G_Cumulative_Histogram[i] = G_Histogram[i];
                    B_Cumulative_Histogram[i] = B_Histogram[i];
                }
                else
                {
                    R_Cumulative_Histogram[i] = R_Cumulative_Histogram[i - 1] + R_Histogram[i];
                    G_Cumulative_Histogram[i] = G_Cumulative_Histogram[i - 1] + G_Histogram[i];
                    B_Cumulative_Histogram[i] = B_Cumulative_Histogram[i - 1] + B_Histogram[i];
                }
            }
            
        }
    }
}
