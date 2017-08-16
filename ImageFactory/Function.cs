using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image">待保存图片</param>
        /// <param name="path">路径</param>
        private void SaveImage(Image image, string path)
        {
            image.Save(path);
        }

        /// <summary>
        /// 获取真彩色或假彩色图片
        /// </summary>
        /// <param name="channel1">通道1</param>
        /// <param name="channel2">通道2</param>
        /// <param name="channel3">通道3</param>
        /// <param name="threeChannel">合成之后的图片</param>
        /// <returns>是否成功</returns>
        private Bitmap GetThreeChannelImage(Bitmap channel1, Bitmap channel2, Bitmap channel3)
        {
            int width = channel1.Width;
            int height = channel1.Height;

            Bitmap threeChannel = new Bitmap(width, height);

            Rectangle rect = new Rectangle(0, 0, width, height);

            //将Bitmap锁定到系统内存中,获得BitmapData
            BitmapData imgBmData1 = channel1.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmData2 = channel2.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmData3 = channel3.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmDatathreeChannel = threeChannel.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
            System.IntPtr imgPtr1 = imgBmData1.Scan0;
            System.IntPtr imgPtr2 = imgBmData2.Scan0;
            System.IntPtr imgPtr3 = imgBmData3.Scan0;
            System.IntPtr imgPtrthreeChannel = imgBmDatathreeChannel.Scan0;

            int img_bytes = imgBmData1.Stride * height;

            byte[] imgValues1 = new byte[img_bytes];
            byte[] imgValues2 = new byte[img_bytes];
            byte[] imgValues3 = new byte[img_bytes];
            byte[] imgValuesthreeChannel = new byte[img_bytes];

            //复制GRB信息到byte数组
            System.Runtime.InteropServices.Marshal.Copy(imgPtr1, imgValues1, 0, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtr2, imgValues2, 0, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtr3, imgValues3, 0, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtrthreeChannel, imgValuesthreeChannel, 0, img_bytes);

            //操作
            int stride = imgBmData1.Stride;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < 3 * width; j += 3)
                {
                    imgValuesthreeChannel[i * stride + j] = imgValues3[i * stride + j];
                    imgValuesthreeChannel[i * stride + j + 1] = imgValues2[i * stride + j + 1];
                    imgValuesthreeChannel[i * stride + j + 2] = imgValues1[i * stride + j + 2];
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(imgValues1, 0, imgPtr1, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValues2, 0, imgPtr2, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValues3, 0, imgPtr3, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValuesthreeChannel, 0, imgPtrthreeChannel, img_bytes);

            //解锁位图
            channel1.UnlockBits(imgBmData1);
            channel2.UnlockBits(imgBmData2);
            channel3.UnlockBits(imgBmData3);
            threeChannel.UnlockBits(imgBmDatathreeChannel);

            return threeChannel;
        }

        /// <summary>
        /// 合成灰度图
        /// </summary>
        /// <param name="input">输入图片</param>
        /// <returns>输出图片</returns>
        private Bitmap GetGrayImage(Bitmap input)
        {
            int width = input.Width;
            int height = input.Height;

            Bitmap output = new Bitmap(width, height);

            Rectangle rect = new Rectangle(0, 0, width, height);

            //将Bitmap锁定到系统内存中,获得BitmapData
            BitmapData imgBmData1 = input.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmDataoutput = output.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
            System.IntPtr imgPtr1 = imgBmData1.Scan0;
            System.IntPtr imgPtroutput = imgBmDataoutput.Scan0;

            int img_bytes = imgBmData1.Stride * height;

            byte[] imgValues1 = new byte[img_bytes];
            byte[] imgValuesoutput = new byte[img_bytes];

            //复制GRB信息到byte数组
            System.Runtime.InteropServices.Marshal.Copy(imgPtr1, imgValues1, 0, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtroutput, imgValuesoutput, 0, img_bytes);

            //操作
            int stride = imgBmData1.Stride;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < 3 * width; j += 3)
                {
                    imgValuesoutput[i * stride + j] = (byte)(imgValues1[i * stride + j] * 0.114 + imgValues1[i * stride + j + 1] * 0.587 + imgValues1[i * stride + j + 2] * 0.299);
                    imgValuesoutput[i * stride + j + 1] = imgValuesoutput[i * stride + j];
                    imgValuesoutput[i * stride + j + 2] = imgValuesoutput[i * stride + j];
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(imgValues1, 0, imgPtr1, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValuesoutput, 0, imgPtroutput, img_bytes);

            //解锁位图
            input.UnlockBits(imgBmData1);
            output.UnlockBits(imgBmDataoutput);

            return output;
        }

        /// <summary>
        /// 3*3滤波器
        /// </summary>
        /// <param name="input">输入图片</param>
        /// <param name="filterValue">滤波算子</param>
        /// <returns>结果图</returns>
        private Bitmap ImageFilter33(Bitmap input, double[,] filterValue)
        {
            int width = input.Width;
            int height = input.Height;

            Bitmap output = new Bitmap(width, height);

            Rectangle rect = new Rectangle(0, 0, width, height);

            //将Bitmap锁定到系统内存中,获得BitmapData
            BitmapData imgBmData1 = input.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmDataoutput = output.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
            System.IntPtr imgPtr1 = imgBmData1.Scan0;
            System.IntPtr imgPtroutput = imgBmDataoutput.Scan0;

            int img_bytes = imgBmData1.Stride * height;

            byte[] imgValues1 = new byte[img_bytes];
            byte[] imgValuesoutput = new byte[img_bytes];

            //复制GRB信息到byte数组
            System.Runtime.InteropServices.Marshal.Copy(imgPtr1, imgValues1, 0, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtroutput, imgValuesoutput, 0, img_bytes);

            //操作
            int stride = imgBmData1.Stride;
            for (int i = 0; i < height; i++)
            {
                imgValuesoutput[i * stride + 0] = imgValues1[i * stride + 0];
                imgValuesoutput[i * stride + 1 + 0] = imgValues1[i * stride + 1 + 0];
                imgValuesoutput[i * stride + 2 + 0] = imgValues1[i * stride + 0 + 2];
                imgValuesoutput[i * stride + 3 * (width - 1)] = imgValues1[i * stride + 3 * (width - 1)];
                imgValuesoutput[i * stride + 3 * (width - 1) + 1] = imgValues1[i * stride + 3 * (width - 1) + 1];
                imgValuesoutput[i * stride + 3 * (width - 1) + 2] = imgValues1[i * stride + 3 * (width - 1) + 2];
            }
            for (int j = 0; j < 3 * width; j += 3)
            {
                imgValuesoutput[0 * stride + j] = imgValues1[0 * stride + j];
                imgValuesoutput[0 * stride + j + 1] = imgValues1[0 * stride + j + 1];
                imgValuesoutput[0 * stride + j + 2] = imgValues1[0 * stride + j + 2];
                imgValuesoutput[(height - 1) * stride + j] = imgValues1[(height - 1) * stride + j];
                imgValuesoutput[(height - 1) * stride + j + 1] = imgValues1[(height - 1) * stride + j + 1];
                imgValuesoutput[(height - 1) * stride + j + 2] = imgValues1[(height - 1) * stride + j + 2];
            }
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 3; j < 3 * (width - 1); j += 3)
                {
                    double temp1 = 0;
                    double temp2 = 0;
                    double temp3 = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        for (int kk = 0; kk < 3; kk++)
                        {
                            temp1 += imgValues1[(i - 1 + kk) * stride + (j - 3 + k * 3)] * filterValue[kk, k];
                            temp2 += imgValues1[(i - 1 + kk) * stride + (j - 3 + k * 3) + 1] * filterValue[kk, k];
                            temp3 += imgValues1[(i - 1 + kk) * stride + (j - 3 + k * 3) + 2] * filterValue[kk, k];
                        }
                    }
                    imgValuesoutput[i * stride + j] = Get0To255((int)temp1);
                    imgValuesoutput[i * stride + j + 1] = Get0To255((int)temp2);
                    imgValuesoutput[i * stride + j + 2] = Get0To255((int)temp3);
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(imgValues1, 0, imgPtr1, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValuesoutput, 0, imgPtroutput, img_bytes);

            //解锁位图
            input.UnlockBits(imgBmData1);
            output.UnlockBits(imgBmDataoutput);

            return output;
        }

        /// <summary>
        /// 高斯模糊
        /// </summary>
        /// <param name="input">输入图片</param>
        /// <param name="delta">高斯模糊尺度</param>
        /// <returns>结果图</returns>
        private Bitmap GuassBlur(Bitmap input, double delta)
        {
            double[,] filter = new double[5, 5];
            double sum = 0;
            for(int i=0;i<5;i++)
            {
                for(int j=0;j<5;j++)
                {
                    filter[i, j] = Guass(j - 2, i - 2, delta);
                    sum += filter[i, j];
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    filter[i, j] = filter[i, j] / sum;
                }
            }

            int width = input.Width;
            int height = input.Height;

            Bitmap output = new Bitmap(width, height);

            Rectangle rect = new Rectangle(0, 0, width, height);

            //将Bitmap锁定到系统内存中,获得BitmapData
            BitmapData imgBmData1 = input.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmDataoutput = output.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
            System.IntPtr imgPtr1 = imgBmData1.Scan0;
            System.IntPtr imgPtroutput = imgBmDataoutput.Scan0;

            int img_bytes = imgBmData1.Stride * height;

            byte[] imgValues1 = new byte[img_bytes];
            byte[] imgValuesoutput = new byte[img_bytes];

            //复制GRB信息到byte数组
            System.Runtime.InteropServices.Marshal.Copy(imgPtr1, imgValues1, 0, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtroutput, imgValuesoutput, 0, img_bytes);

            //操作
            int stride = imgBmData1.Stride;
            double tsum = filter[2, 2] + filter[2, 3] + filter[2, 4];
            for (int i = 0; i < height; i++)
            {
                imgValuesoutput[i * stride + 0 + 0] = Get0To255((int)(imgValues1[i * stride + 0 + 0] * filter[2,2] / tsum + imgValues1[i * stride + 0 + 3] * filter[2, 3] / tsum + imgValues1[i * stride + 0 + 6] * filter[2, 4] / tsum));
                imgValuesoutput[i * stride + 0 + 1] = Get0To255((int)(imgValues1[i * stride + 1 + 0] * filter[2, 2] / tsum + imgValues1[i * stride + 1 + 3] * filter[2, 3] / tsum + imgValues1[i * stride + 1 + 6] * filter[2, 4] / tsum));
                imgValuesoutput[i * stride + 0 + 2] = Get0To255((int)(imgValues1[i * stride + 2 + 0] * filter[2, 2] / tsum + imgValues1[i * stride + 2 + 3] * filter[2, 3] / tsum + imgValues1[i * stride + 2 + 6] * filter[2, 4] / tsum));

                imgValuesoutput[i * stride + 3 + 0] = Get0To255((int)(imgValues1[i * stride + 0 + 3] * filter[2, 2] / tsum + imgValues1[i * stride + 0 + 6] * filter[2, 3] / tsum + imgValues1[i * stride + 0 + 9] * filter[2, 4] / tsum));
                imgValuesoutput[i * stride + 3 + 1] = Get0To255((int)(imgValues1[i * stride + 1 + 3] * filter[2, 2] / tsum + imgValues1[i * stride + 1 + 6] * filter[2, 3] / tsum + imgValues1[i * stride + 1 + 9] * filter[2, 4] / tsum));
                imgValuesoutput[i * stride + 3 + 2] = Get0To255((int)(imgValues1[i * stride + 2 + 3] * filter[2, 2] / tsum + imgValues1[i * stride + 2 + 6] * filter[2, 3] / tsum + imgValues1[i * stride + 2 + 9] * filter[2, 4] / tsum));

                imgValuesoutput[i * stride + 3 * (width - 2) + 0] = Get0To255((int)(imgValues1[i * stride + 3 * (width - 2) + 0] * filter[2, 2] / tsum + imgValues1[i * stride + 3 * (width - 3) + 0] * filter[2, 3] / tsum + imgValues1[i * stride + 3 * (width - 4) + 0] * filter[2, 4] / tsum));
                imgValuesoutput[i * stride + 3 * (width - 2) + 1] = Get0To255((int)(imgValues1[i * stride + 3 * (width - 2) + 1] * filter[2, 2] / tsum + imgValues1[i * stride + 3 * (width - 3) + 1] * filter[2, 3] / tsum + imgValues1[i * stride + 3 * (width - 4) + 1] * filter[2, 4] / tsum));
                imgValuesoutput[i * stride + 3 * (width - 2) + 2] = Get0To255((int)(imgValues1[i * stride + 3 * (width - 2) + 2] * filter[2, 2] / tsum + imgValues1[i * stride + 3 * (width - 3) + 2] * filter[2, 3] / tsum + imgValues1[i * stride + 3 * (width - 4) + 2] * filter[2, 4] / tsum));

                imgValuesoutput[i * stride + 3 * (width - 1) + 0] = Get0To255((int)(imgValues1[i * stride + 3 * (width - 1) + 0] * filter[2, 2] / tsum + imgValues1[i * stride + 3 * (width - 2) + 0] * filter[2, 3] / tsum + imgValues1[i * stride + 3 * (width - 3) + 0] * filter[2, 4] / tsum));
                imgValuesoutput[i * stride + 3 * (width - 1) + 1] = Get0To255((int)(imgValues1[i * stride + 3 * (width - 1) + 1] * filter[2, 2] / tsum + imgValues1[i * stride + 3 * (width - 2) + 1] * filter[2, 3] / tsum + imgValues1[i * stride + 3 * (width - 3) + 1] * filter[2, 4] / tsum));
                imgValuesoutput[i * stride + 3 * (width - 1) + 2] = Get0To255((int)(imgValues1[i * stride + 3 * (width - 1) + 2] * filter[2, 2] / tsum + imgValues1[i * stride + 3 * (width - 2) + 2] * filter[2, 3] / tsum + imgValues1[i * stride + 3 * (width - 3) + 2] * filter[2, 4] / tsum));
            }
            
            for (int j = 0; j < 3 * width; j += 3)
            {
                imgValuesoutput[0 * stride + j + 0] = Get0To255((int)(imgValues1[0 * stride + j + 0] * filter[2, 2] / tsum + imgValues1[1 * stride + j + 0] * filter[2, 3] / tsum + imgValues1[2 * stride + j + 0] * filter[2, 4] / tsum));
                imgValuesoutput[0 * stride + j + 1] = Get0To255((int)(imgValues1[0 * stride + j + 1] * filter[2, 2] / tsum + imgValues1[1 * stride + j + 1] * filter[2, 3] / tsum + imgValues1[2 * stride + j + 1] * filter[2, 4] / tsum));
                imgValuesoutput[0 * stride + j + 2] = Get0To255((int)(imgValues1[0 * stride + j + 2] * filter[2, 2] / tsum + imgValues1[1 * stride + j + 2] * filter[2, 3] / tsum + imgValues1[2 * stride + j + 2] * filter[2, 4] / tsum));

                imgValuesoutput[1 * stride + j + 0] = Get0To255((int)(imgValues1[1 * stride + j + 0] * filter[2, 2] / tsum + imgValues1[2 * stride + j + 0] * filter[2, 3] / tsum + imgValues1[3 * stride + j + 0] * filter[2, 4] / tsum));
                imgValuesoutput[1 * stride + j + 1] = Get0To255((int)(imgValues1[1 * stride + j + 1] * filter[2, 2] / tsum + imgValues1[2 * stride + j + 1] * filter[2, 3] / tsum + imgValues1[3 * stride + j + 1] * filter[2, 4] / tsum));
                imgValuesoutput[1 * stride + j + 2] = Get0To255((int)(imgValues1[1 * stride + j + 2] * filter[2, 2] / tsum + imgValues1[2 * stride + j + 2] * filter[2, 3] / tsum + imgValues1[3 * stride + j + 2] * filter[2, 4] / tsum));

                imgValuesoutput[(height - 2) * stride + j + 0] = Get0To255((int)(imgValues1[(height - 2) * stride + j + 0] * filter[2, 2] / tsum + imgValues1[(height - 3) * stride + j + 0] * filter[2, 3] / tsum + imgValues1[(height - 4) * stride + j + 0] * filter[2, 4] / tsum));
                imgValuesoutput[(height - 2) * stride + j + 1] = Get0To255((int)(imgValues1[(height - 2) * stride + j + 1] * filter[2, 2] / tsum + imgValues1[(height - 3) * stride + j + 1] * filter[2, 3] / tsum + imgValues1[(height - 4) * stride + j + 1] * filter[2, 4] / tsum));
                imgValuesoutput[(height - 2) * stride + j + 2] = Get0To255((int)(imgValues1[(height - 2) * stride + j + 2] * filter[2, 2] / tsum + imgValues1[(height - 3) * stride + j + 2] * filter[2, 3] / tsum + imgValues1[(height - 4) * stride + j + 2] * filter[2, 4] / tsum));

                imgValuesoutput[(height - 1) * stride + j + 0] = Get0To255((int)(imgValues1[(height - 1) * stride + j + 0] * filter[2, 2] / tsum + imgValues1[(height - 2) * stride + j + 0] * filter[2, 3] / tsum + imgValues1[(height - 3) * stride + j + 0] * filter[2, 4] / tsum));
                imgValuesoutput[(height - 1) * stride + j + 1] = Get0To255((int)(imgValues1[(height - 1) * stride + j + 1] * filter[2, 2] / tsum + imgValues1[(height - 2) * stride + j + 1] * filter[2, 3] / tsum + imgValues1[(height - 3) * stride + j + 1] * filter[2, 4] / tsum));
                imgValuesoutput[(height - 1) * stride + j + 2] = Get0To255((int)(imgValues1[(height - 1) * stride + j + 2] * filter[2, 2] / tsum + imgValues1[(height - 2) * stride + j + 2] * filter[2, 3] / tsum + imgValues1[(height - 3) * stride + j + 2] * filter[2, 4] / tsum));
            }
            for (int i = 2; i < height - 2; i++)
            {
                for (int j = 6; j < 3 * (width - 2); j += 3)
                {
                    double temp1 = 0;
                    double temp2 = 0;
                    double temp3 = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        for (int kk = 0; kk < 5; kk++)
                        {
                            temp1 += imgValues1[(i - 2 + kk) * stride + (j - 6 + k * 3)] * filter[kk, k];
                            temp2 += imgValues1[(i - 2 + kk) * stride + (j - 6 + k * 3) + 1] * filter[kk, k];
                            temp3 += imgValues1[(i - 2 + kk) * stride + (j - 6 + k * 3) + 2] * filter[kk, k];
                        }
                    }
                    imgValuesoutput[i * stride + j] = Get0To255((int)temp1);
                    imgValuesoutput[i * stride + j + 1] = Get0To255((int)temp2);
                    imgValuesoutput[i * stride + j + 2] = Get0To255((int)temp3);
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(imgValues1, 0, imgPtr1, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValuesoutput, 0, imgPtroutput, img_bytes);

            //解锁位图
            input.UnlockBits(imgBmData1);
            output.UnlockBits(imgBmDataoutput);

            return output;
        }

        /// <summary>
        /// 高斯模糊
        /// </summary>
        /// <param name="input">输入图片</param>
        /// <param name="delta">高斯模糊尺度</param>
        /// <returns>结果图</returns>
        private CDOG GuassBlur1(Bitmap input, double delta)
        {
            double[,] filter = new double[5, 5];
            double sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    filter[i, j] = Guass(j - 2, i - 2, delta);
                    sum += filter[i, j];
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    filter[i, j] = filter[i, j] / sum;
                }
            }

            int width = input.Width;
            int height = input.Height;

            CDOG output = new CDOG(width, height);

            Rectangle rect = new Rectangle(0, 0, width, height);

            //将Bitmap锁定到系统内存中,获得BitmapData
            BitmapData imgBmData1 = input.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //BitmapData imgBmDataoutput = output.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
            System.IntPtr imgPtr1 = imgBmData1.Scan0;
            //System.IntPtr imgPtroutput = imgBmDataoutput.Scan0;

            int img_bytes = imgBmData1.Stride * height;

            byte[] imgValues1 = new byte[img_bytes];
            //byte[] imgValuesoutput = new byte[img_bytes];

            //复制GRB信息到byte数组
            System.Runtime.InteropServices.Marshal.Copy(imgPtr1, imgValues1, 0, img_bytes);
            //System.Runtime.InteropServices.Marshal.Copy(imgPtroutput, imgValuesoutput, 0, img_bytes);

            //操作
            int stride = imgBmData1.Stride;
            double tsum = filter[2, 2] + filter[2, 3] + filter[2, 4];
            for (int i = 0; i < height; i++)
            {
                output.SetPixel(0, i, (imgValues1[i * stride + 0 + 0] * filter[2, 2] / tsum + imgValues1[i * stride + 0 + 3] * filter[2, 3] / tsum + imgValues1[i * stride + 0 + 6] * filter[2, 4] / tsum));
                output.SetPixel(1, i, (imgValues1[i * stride + 0 + 3] * filter[2, 2] / tsum + imgValues1[i * stride + 0 + 6] * filter[2, 3] / tsum + imgValues1[i * stride + 0 + 9] * filter[2, 4] / tsum));
                output.SetPixel((width - 2), i, (imgValues1[i * stride + 3 * (width - 2) + 0] * filter[2, 2] / tsum + imgValues1[i * stride + 3 * (width - 3) + 0] * filter[2, 3] / tsum + imgValues1[i * stride + 3 * (width - 4) + 0] * filter[2, 4] / tsum));
                output.SetPixel((width - 1), i, (imgValues1[i * stride + 3 * (width - 1) + 0] * filter[2, 2] / tsum + imgValues1[i * stride + 3 * (width - 2) + 0] * filter[2, 3] / tsum + imgValues1[i * stride + 3 * (width - 3) + 0] * filter[2, 4] / tsum));
            }

            for (int j = 0; j < 3 * width; j+=3)
            {
                output.SetPixel(j / 3, 0, (imgValues1[0 * stride + j + 0] * filter[2, 2] / tsum + imgValues1[1 * stride + j + 0] * filter[2, 3] / tsum + imgValues1[2 * stride + j + 0] * filter[2, 4] / tsum));
                output.SetPixel(j / 3, 1, (imgValues1[1 * stride + j + 0] * filter[2, 2] / tsum + imgValues1[2 * stride + j + 0] * filter[2, 3] / tsum + imgValues1[3 * stride + j + 0] * filter[2, 4] / tsum));
                output.SetPixel(j / 3, (height - 2), (imgValues1[(height - 2) * stride + j + 0] * filter[2, 2] / tsum + imgValues1[(height - 3) * stride + j + 0] * filter[2, 3] / tsum + imgValues1[(height - 4) * stride + j + 0] * filter[2, 4] / tsum));
                output.SetPixel(j / 3, (height - 1), (imgValues1[(height - 1) * stride + j + 0] * filter[2, 2] / tsum + imgValues1[(height - 2) * stride + j + 0] * filter[2, 3] / tsum + imgValues1[(height - 3) * stride + j + 0] * filter[2, 4] / tsum));
            }
            for (int i = 2; i < height - 2; i++)
            {
                for (int j = 6; j < (width - 2)*3; j+=3)
                {
                    double temp1 = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        for (int kk = 0; kk < 5; kk++)
                        {
                            temp1 += imgValues1[(i - 2 + kk) * stride + (j - 6 +3* k)] * filter[kk, k];
                        }
                    }
                    output.SetPixel(j/3, i, temp1);
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(imgValues1, 0, imgPtr1, img_bytes);
            //System.Runtime.InteropServices.Marshal.Copy(imgValuesoutput, 0, imgPtroutput, img_bytes);

            //解锁位图
            input.UnlockBits(imgBmData1);
            //output.UnlockBits(imgBmDataoutput);

            return output;
        }

        /// <summary>
        /// 高斯模糊
        /// </summary>
        /// <param name="input">输入图片</param>
        /// <param name="delta">高斯模糊尺度</param>
        /// <returns>结果图</returns>
        private CDOG GuassBlur1(CDOG input, double delta)
        {
            double[,] filter = new double[5, 5];
            double sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    filter[i, j] = Guass(j - 2, i - 2, delta);
                    sum += filter[i, j];
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    filter[i, j] = filter[i, j] / sum;
                }
            }

            int width = input.GetWidth();
            int height = input.GetHeight();

            CDOG output = new CDOG(width, height);
            
            double tsum = filter[2, 2] + filter[2, 3] + filter[2, 4];
            for (int i = 0; i < height; i++)
            {
                output.SetPixel(0, i, (input.GetPixel(0,i) * filter[2, 2] / tsum + input.GetPixel(1, i) * filter[2, 3] / tsum + input.GetPixel(2, i) * filter[2, 4] / tsum));
                output.SetPixel(1, i, (input.GetPixel(1, i) * filter[2, 2] / tsum + input.GetPixel(2, i) * filter[2, 3] / tsum + input.GetPixel(3, i) * filter[2, 4] / tsum));
                output.SetPixel((width - 2), i, (input.GetPixel((width - 2), i) * filter[2, 2] / tsum + input.GetPixel((width - 3), i) * filter[2, 3] / tsum + input.GetPixel((width - 4), i) * filter[2, 4] / tsum));
                output.SetPixel((width - 1), i, (input.GetPixel((width - 1), i) * filter[2, 2] / tsum + input.GetPixel((width - 2), i) * filter[2, 3] / tsum + input.GetPixel((width - 3), i) * filter[2, 4] / tsum));
            }

            for (int j = 0; j < width; j++)
            {
                output.SetPixel(j, 0, (input.GetPixel(j, 0) * filter[2, 2] / tsum + input.GetPixel(j, 1) * filter[2, 3] / tsum + input.GetPixel(j, 2) * filter[2, 4] / tsum));
                output.SetPixel(j, 1, (input.GetPixel(j, 1) * filter[2, 2] / tsum + input.GetPixel(j, 2) * filter[2, 3] / tsum + input.GetPixel(j, 3) * filter[2, 4] / tsum));
                output.SetPixel(j, (height - 2), (input.GetPixel(j, (height - 2)) * filter[2, 2] / tsum + input.GetPixel(j, (height - 3)) * filter[2, 3] / tsum + input.GetPixel(j, (height - 4)) * filter[2, 4] / tsum));
                output.SetPixel(j, (height - 1), (input.GetPixel(j, (height - 1)) * filter[2, 2] / tsum + input.GetPixel(j, (height - 2)) * filter[2, 3] / tsum + input.GetPixel(j, (height - 3)) * filter[2, 4] / tsum));
            }
            for (int i = 2; i < height - 2; i++)
            {
                for (int j = 2; j < (width - 2); j++)
                {
                    double temp1 = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        for (int kk = 0; kk < 5; kk++)
                        {
                            temp1 += input.GetPixel((j - 2 + k), (i - 2 + kk)) * filter[kk, k];
                        }
                    }
                    output.SetPixel(j, i, temp1);
                }
            }

            return output;
        }

        /// <summary>
        /// 高斯函数
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">坐标</param>
        /// <param name="delta">标准差</param>
        /// <returns>函数值</returns>
        private double Guass(int x,int y,double delta)
        {
            double value = (1.0 / (2 * Math.PI * delta * delta)) * Math.Exp(-(x * x + y * y) / (2 * delta * delta));
            return value;
        }

        /// <summary>
        /// 得到0-255之间的数，防止图片像素溢出
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private byte Get0To255(int input)
        {
            int output = input > 255 ? 255 : (input < 0 ? 0 : input);
            return (byte)output;
        }

        /// <summary>
        /// 获取时间间隔
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private string GetTimeInterval(DateTime begin, DateTime end)
        {
            string time = "";
            int Second = (end.Hour - begin.Hour) * 3600 + (end.Minute - begin.Minute) * 60 + (end.Second - begin.Second);
            int h, min, s;
            h = (int)(Second / 3600.0);
            min = (Second - h * 3600) / 60;
            s = Second - h * 3600 - min * 60;
            if (h != 0)
                time += h + "小时";
            time += min + "分";
            time += s + "秒";
            return time;
        }

        /// <summary>
        /// 图片裁剪
        /// </summary>
        /// <param name="inputBitmap">输入图片</param>
        /// <param name="X1">左上角横坐标</param>
        /// <param name="Y1">左上角纵坐标</param>
        /// <param name="X2">右下角横坐标</param>
        /// <param name="Y2">右下角纵坐标</param>
        /// <returns>结果图</returns>
        private Bitmap CutImage(Bitmap inputBitmap, int X1, int Y1, int X2, int Y2)
        {
            int inputWidth = inputBitmap.Width;
            int inputHeight = inputBitmap.Height;

            int outputWidth = X2 - X1;
            int outputHeight = Y2 - Y1;

            Bitmap outputBitmap = new Bitmap(outputWidth, outputHeight);

            //将Bitmap锁定到系统内存中,获得BitmapData
            BitmapData inputBitmapData = inputBitmap.LockBits(new Rectangle(0, 0, inputWidth, inputHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData outputBitmapData = outputBitmap.LockBits(new Rectangle(0, 0, outputWidth, outputHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
            System.IntPtr inputPtr = inputBitmapData.Scan0;
            System.IntPtr outputPtr = outputBitmapData.Scan0;

            int input_bytes = inputBitmapData.Stride * inputHeight;
            int output_bytes = outputBitmapData.Stride * outputHeight;

            byte[] inputValues = new byte[input_bytes];
            byte[] outputValues = new byte[output_bytes];

            //复制GRB信息到byte数组
            System.Runtime.InteropServices.Marshal.Copy(inputPtr, inputValues, 0, input_bytes);
            System.Runtime.InteropServices.Marshal.Copy(outputPtr, outputValues, 0, output_bytes);

            //操作
            int inputStride = inputBitmapData.Stride;
            int outputStride = outputBitmapData.Stride;
            for (int i = 0; i < outputHeight; i++)
            {
                for (int j = 0; j < 3 * outputWidth; j += 3)
                {
                    outputValues[i * outputStride + j] = inputValues[(i + Y1) * inputStride + j + X1*3];
                    outputValues[i * outputStride + j + 1] = inputValues[(i+Y1) * inputStride + j + 1 + X1*3];
                    outputValues[i * outputStride + j + 2] = inputValues[(i+Y1) * inputStride + j + 2 + X1*3];
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(inputValues, 0, inputPtr, input_bytes);
            System.Runtime.InteropServices.Marshal.Copy(outputValues, 0, outputPtr, output_bytes);

            //解锁位图
            inputBitmap.UnlockBits(inputBitmapData);
            outputBitmap.UnlockBits(outputBitmapData);

            return outputBitmap;
        }

        /// <summary>
        /// 边缘检测
        /// </summary>
        /// <param name="input">输入图片</param>
        /// <param name="threshold">阈值</param>
        /// <returns>结果图</returns>
        public Bitmap EdgeSense(Bitmap input,int threshold)
        {
            int[,] Angle0 = { { -5, 3, 3 }, { -5, 0, 3 }, { -5, 3, 3 } };
            int[,] Angle90 = { { -5, -5, -5 }, { 3, 0, 3 }, { 3, 3, 3 } };
            int[,] Angle45 = { { -5, -5, 3 }, { -5, 0, 3 }, { 3, 3, 3 } };
            int[,] Angle135 = { { 3, -5, -5 }, { 3, 0, -5 }, { 3, 3, 3 } };
            int[,] Angle180 = { { 3, 3, -5 }, { 3, 0, -5 }, { 3, 3, -5 } };
            int[,] Angle225 = { { 3, 3, 3 }, { 3, 0, -5 }, { 3, -5, -5 } };
            int[,] Angle270 = { { 3, 3, 3 }, { 3, 0, 3 }, { -5, -5, -5 } };
            int[,] Angle315 = { { 3, 3, 3 }, { -5, 0, 3 }, { -5, -5, 3 } };

            int width = input.Width;
            int height = input.Height;

            Bitmap output = new Bitmap(width, height);

            Rectangle rect = new Rectangle(0, 0, width, height);

            //将Bitmap锁定到系统内存中,获得BitmapData
            BitmapData imgBmData1 = input.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmDataoutput = output.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
            System.IntPtr imgPtr1 = imgBmData1.Scan0;
            System.IntPtr imgPtroutput = imgBmDataoutput.Scan0;

            int img_bytes = imgBmData1.Stride * height;

            byte[] imgValues1 = new byte[img_bytes];
            byte[] imgValuesoutput = new byte[img_bytes];

            //复制GRB信息到byte数组
            System.Runtime.InteropServices.Marshal.Copy(imgPtr1, imgValues1, 0, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtroutput, imgValuesoutput, 0, img_bytes);

            //操作
            int stride = imgBmData1.Stride;
            for (int i = 0; i < height; i++)
            {
                imgValuesoutput[i * stride + 0] = (byte)(imgValues1[i * stride + 0] * 0.144 + imgValues1[i * stride + 1 + 0] * 0.587 + imgValues1[i * stride + 0 + 2] * 0.299);
                imgValuesoutput[i * stride + 1 + 0] = imgValuesoutput[i * stride + 0];
                imgValuesoutput[i * stride + 2 + 0] = imgValuesoutput[i * stride + 0];
                imgValuesoutput[i * stride + 3 * (width - 1)] = (byte)(imgValues1[i * stride + 3 * (width - 1)] * 0.144 + imgValues1[i * stride + 3 * (width - 1) + 1] * 0.587 + imgValues1[i * stride + 3 * (width - 1) + 2] * 0.299);
                imgValuesoutput[i * stride + 3 * (width - 1) + 1] = imgValuesoutput[i * stride + 3 * (width - 1)];
                imgValuesoutput[i * stride + 3 * (width - 1) + 2] = imgValuesoutput[i * stride + 3 * (width - 1)];
            }
            for (int j = 0; j < 3 * width; j += 3)
            {
                imgValuesoutput[0 * stride + j] = (byte)(imgValues1[0 * stride + j] * 0.144 + imgValues1[0 * stride + j + 1] * 0.587 + imgValues1[0 * stride + j + 2] * 0.299);
                imgValuesoutput[0 * stride + j + 1] = imgValuesoutput[0 * stride + j];
                imgValuesoutput[0 * stride + j + 2] = imgValuesoutput[0 * stride + j];
                imgValuesoutput[(height - 1) * stride + j] = (byte)(imgValues1[(height - 1) * stride + j]*0.144 + imgValues1[(height - 1) * stride + j + 1] * 0.587 + imgValues1[(height - 1) * stride + j + 2] * 0.299);
                imgValuesoutput[(height - 1) * stride + j + 1] = imgValuesoutput[(height - 1) * stride + j];
                imgValuesoutput[(height - 1) * stride + j + 2] = imgValuesoutput[(height - 1) * stride + j];
            }
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 3; j < 3 * (width - 1); j += 3)
                {
                    int temp0 = 0;
                    int temp90 = 0;
                    int temp45 = 0;
                    int temp135 = 0;
                    int temp180 = 0;
                    int temp225 = 0;
                    int temp270 = 0;
                    int temp315 = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int kk = -1; kk < 2; kk++)
                        {
                            for(int kkk=0;kkk<3;kkk++)
                            {
                                int gray = (byte)(imgValues1[(i + k) * stride + j + (3 * kk)] * 0.114 + imgValues1[(i + k) * stride + j + (3 * kk) + 1] * 0.587 + imgValues1[(i + k) * stride + j + (3 * kk) + 2] * 0.299);
                                temp0 += gray * Angle0[kk + 1, k + 1];
                                temp90 += gray * Angle90[kk + 1, k + 1];
                                temp45 += gray * Angle45[kk + 1, k + 1];
                                temp135 += gray * Angle135[kk + 1, k + 1];
                                temp180 += gray * Angle180[kk + 1, k + 1];
                                temp225 += gray * Angle225[kk + 1, k + 1];
                                temp270 += gray * Angle270[kk + 1, k + 1];
                                temp315 += gray * Angle315[kk + 1, k + 1];
                            }
                        }
                    }
                    int temp = GetMaxValue(new int[] { temp0, temp90, temp45, temp135, temp180, temp225, temp270, temp315 });
                    if(temp > threshold)
                    {
                        imgValuesoutput[i * stride + j] = 255;
                        imgValuesoutput[i * stride + j + 1] = 255;
                        imgValuesoutput[i * stride + j + 2] = 255;
                    }
                    else
                    {
                        imgValuesoutput[i * stride + j] = 0;
                        imgValuesoutput[i * stride + j + 1] = 0;
                        imgValuesoutput[i * stride + j + 2] = 0;
                    }
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(imgValues1, 0, imgPtr1, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValuesoutput, 0, imgPtroutput, img_bytes);

            //解锁位图
            input.UnlockBits(imgBmData1);
            output.UnlockBits(imgBmDataoutput);

            return output;
        }
        
        /// <summary>
        /// 返回最大值
        /// </summary>
        /// <param name="array">数组</param>
        /// <returns>最大值</returns>
        private int GetMaxValue(int[] array)
        {
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }
            return maxValue;
        }

        /// <summary>
        /// 图片拼接
        /// </summary>
        /// <param name="images">输入图片集</param>
        /// <returns></returns>
        private Bitmap ImageStitch(Bitmap[] images)
        {
            


            return new Bitmap("");
        }

        /// <summary>
        /// 获取Sift特征点
        /// </summary>
        /// <param name="input">输入图片</param>
        /// <returns>特征点集</returns>
        private unsafe List<CFeaturePoint>[,] GetFeaturePoints(Bitmap input)
        {
            int s = 3;
            int n = 4;
            double k = Math.Pow(2, 1.0 / s);
            double delta = 1.6;
            double delta0 = 0.5;
            double deltai = Math.Sqrt(delta * delta - delta0 * delta0);
            double delta1 = deltai;
            List<CFeaturePoint>[,] featurePoints = new List<CFeaturePoint>[n, s + 2];

            //1.建立高斯尺度空间
            Bitmap doubleImage = DoubleImage(GetGrayImage(input));
            CDOG[,] GuassSpace = new CDOG[n, s+3];
            GuassSpace[0, 0] = GuassBlur1(doubleImage, deltai);
            for (int i=0;i<n; i++)
            {
                for(int j=0;j<s+3;j++)
                {
                    if(i == 0 && j == 0)
                    {
                        continue;
                    }
                    if(j == 0)
                    {
                        GuassSpace[i, j] = HalfImage(GuassSpace[i - 1, s]);
                        deltai = delta1;
                    }
                    else
                    {
                        deltai *= k;
                        GuassSpace[i, j] = GuassBlur1(GuassSpace[i, 0], deltai);
                    }
                }
            }
            /*
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < s + 3; j++)
                {
                    CreateTabPage("第" + i + "组,第" + j + "层", GuassSpace[i, j]);
                }
            }*/

            //2.建立高斯差分空间
            CDOG[,] DOG = new CDOG[n, s + 2];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < s + 2; j++)
                {
                    featurePoints[i, j] = new List<CFeaturePoint>();
                    DOG[i, j] = GetDifferentImage(GuassSpace[i, j + 1], GuassSpace[i, j], ref featurePoints[i,j]);
                }
            }
            /*  
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < s + 2; j++)
                {
                    CreateTabPage("第" + i + "组,第" + j + "层", DOG[i, j]);
                }
            }*/
            double max = 0;
            double min = 0;
            //3.获得未求精的特征点
            for (int i = 0; i < n; i++)
            {
                for(int j=1;j<s+1;j++)
                {
                    int count = featurePoints[i, j].Count;
                    for (int index = 0; index < count; index++)
                    {
                        int x = featurePoints[i, j][index].x;
                        int y = featurePoints[i, j][index].y;
                        double[,,] nearstPixels = new double[3, 3, 3];
                        for (int ii = 0; ii < 3; ii++)
                        {//层数
                            for (int jj = 0; jj < 3; jj++)
                            {//横坐标
                                for (int kk = 0; kk < 3; kk++)
                                {//纵坐标
                                    nearstPixels[ii, jj, kk] = DOG[i, j + ii - 1].values[x + jj - 1, y + kk - 1];
                                }
                            }
                        }
                        if (max < DOG[i, j].GetPixel(featurePoints[i, j][index].x, featurePoints[i, j][index].y))
                            max = DOG[i, j].GetPixel(featurePoints[i, j][index].x, featurePoints[i, j][index].y);

                        if (min > DOG[i, j].GetPixel(featurePoints[i, j][index].x, featurePoints[i, j][index].y))
                            min = DOG[i, j].GetPixel(featurePoints[i, j][index].x, featurePoints[i, j][index].y);

                        if (!IsMinOrMax(nearstPixels[1, 1, 1], nearstPixels))
                        {
                            featurePoints[i, j].RemoveAt(index);
                            index--;
                            count--;
                        }

                    }
                }
            }
            MessageBox.Show("DOG:max = " + max + ",min = " + min);
            max = 0;
            min = 0;


            //for (int i = 0; i < n; i++)
            {
                int i = 0;
                int j = 1;
                //for (int j = 1; j < s + 1; j++)
                //{
                Bitmap t = new Bitmap(GuassSpace[i, 0].ToBitmap());
                Graphics g = Graphics.FromImage(t);
                for (int index = 0; index < featurePoints[i, j].Count; index++)
                {
                    if (max < DOG[i, j].GetPixel(featurePoints[i, j][index].x, featurePoints[i, j][index].y))
                        max = DOG[i, j].GetPixel(featurePoints[i, j][index].x, featurePoints[i, j][index].y);

                    if (min > DOG[i, j].GetPixel(featurePoints[i, j][index].x, featurePoints[i, j][index].y))
                        min = DOG[i, j].GetPixel(featurePoints[i, j][index].x, featurePoints[i, j][index].y);
                    
                    g.FillEllipse(new SolidBrush(Color.FromArgb(255, 0, 0)), new Rectangle(featurePoints[i, j][index].x, featurePoints[i, j][index].y, 10, 10));
                }
                //t.SetPixel(, Color.FromArgb(255, 0, 0));
                CreateTabPage("粗特征点", t);
                //}
            }
            MessageBox.Show("DOG特征:max = " + max + ",min = " + min);
            max = 0;
            min = 0;

            //4.特征点求精
            for (int i = 0; i < n; i++)
            {
                for (int ii = 1; ii < s + 1; ii++)
                {
                    int count = featurePoints[i, ii].Count;
                    for (int rindex = 0; rindex < count; rindex++)
                    {
                        double[,] g = new double[3,1];
                        double[,] H = new double[3, 3];
                        double[,] H_ = new double[3, 3];
                        double[,] deltaX = new double[3, 1];
                        
                        int MAX_INTERP_STEP = 5;
                        int j = ii;
                        int index = rindex;
                        double x = featurePoints[i, j][index].x;
                        double y = featurePoints[i, j][index].y;
                        bool isChangelevel = false;
                        for (int m = 0; m < MAX_INTERP_STEP + 1; m++)
                        {
                            if (m == MAX_INTERP_STEP)
                            {
                                featurePoints[i, j].RemoveAt(index);
                                index--;
                                if (!isChangelevel)
                                {
                                    rindex--;
                                    count--;
                                }
                                break;
                            }

                            g[0, 0] = (D(DOG, i, j, (int)x + 1, (int)y) - D(DOG, i, j, (int)x - 1, (int)y)) / 2.0;
                            g[1, 0] = (D(DOG, i, j, (int)x, (int)y + 1) - D(DOG, i, j, (int)x, (int)y - 1)) / 2.0;
                            g[2, 0] = (D(DOG, i, j + 1, (int)x, (int)y) - D(DOG, i, j - 1, (int)x, (int)y)) / 2.0;

                            H[0, 0] = D(DOG, i, j, (int)x + 1, (int)y) + D(DOG, i, j, (int)x - 1, (int)y) - 2 * D(DOG, i, j, (int)x, (int)y);
                            H[1, 1] = D(DOG, i, j, (int)x, (int)y + 1) + D(DOG, i, j, (int)x, (int)y - 1) - 2 * D(DOG, i, j, (int)x, (int)y);
                            H[2, 2] = D(DOG, i, j + 1, (int)x, (int)y) + D(DOG, i, j - 1, (int)x, (int)y) - 2 * D(DOG, i, j, (int)x, (int)y);
                            H[0, 1] = (D(DOG, i, j, (int)x + 1, (int)y + 1) + D(DOG, i, j, (int)x - 1, (int)y + 1) - D(DOG, i, j, (int)x + 1, (int)y - 1) - D(DOG, i, j, (int)x - 1, (int)y - 1)) / 4.0;
                            H[1, 0] = H[0, 1];
                            H[0, 2] = (D(DOG, i, j + 1, (int)x + 1, (int)y) + D(DOG, i, j + 1, (int)x - 1, (int)y) - D(DOG, i, j - 1, (int)x + 1, (int)y) - D(DOG, i, j - 1, (int)x - 1, (int)y)) / 4.0;
                            H[2, 0] = H[0, 2];
                            H[1, 2] = (D(DOG, i, j + 1, (int)x, (int)y + 1) + D(DOG, i, j + 1, (int)x, (int)y - 1) - D(DOG, i, j - 1, (int)x, (int)y + 1) - D(DOG, i, j - 1, (int)x, (int)y - 1)) / 4.0;
                            H[2, 1] = H[1, 2];

                            if (!CMatrix.MatrixOpp(H, ref H_))
                            {
                                deltaX[0, 0] = 0;
                                deltaX[1, 0] = 0;
                                deltaX[2, 0] = 0;
                            }
                            else
                            {
                                CMatrix.MatrixMultiply(H_, g, ref deltaX);
                                deltaX[0, 0] *= -1;
                                deltaX[1, 0] *= -1;
                                deltaX[2, 0] *= -1;
                            }
                            if (Math.Abs(deltaX[0, 0]) < 0.5 && Math.Abs(deltaX[1, 0]) < 0.5 && Math.Abs(deltaX[2, 0]) < 0.5)
                            {
                                double[,] g_deltaX = new double[1, 1];
                                double[,] gt = new double[1, 3];
                                gt[0, 0] = g[0, 0];
                                gt[0, 1] = g[1, 0];
                                gt[0, 2] = g[2, 0];
                                CMatrix.MatrixMultiply(gt, deltaX, ref g_deltaX);
                                double deltaD = g_deltaX[0, 0] / 2.0;
                                double newD = D(DOG, i, j, (int)x, (int)y) + deltaD;
                                if (newD > max)
                                    max = newD;
                                if (newD < min)
                                    min = newD;
                                if (Math.Abs(newD) < 7.68 * 0.5 / j)
                                {
                                    featurePoints[i, j].RemoveAt(index);
                                    index--;
                                    if (!isChangelevel)
                                    {
                                        rindex--;
                                        count--;
                                    }
                                }
                                break;
                            }
                            else
                            {
                                featurePoints[i, j][index].x = (int)Math.Round(x + deltaX[0, 0]);
                                featurePoints[i, j][index].y = (int)Math.Round(y + deltaX[1, 0]);
                                if (deltaX[2, 0] >= 0.5)
                                {
                                    int tx = featurePoints[i, j][index].x;
                                    int ty = featurePoints[i, j][index].y;
                                    featurePoints[i, j].RemoveAt(index);
                                    index--;
                                    if (!isChangelevel)
                                    {
                                        rindex--;
                                        count--;
                                    }
                                    j++;
                                    if (j < 1 || j > s)
                                        break;
                                    featurePoints[i, j].Add(new CFeaturePoint(tx, ty));
                                    index = featurePoints[i, j].Count - 1;
                                    isChangelevel = true;
                                }
                            }
                        }
                    }
                }
            }
            //for (int i = 0; i < n; i++)
            {
                int i = 0;
                int j = 1;
                //for (int j = 1; j < s + 1; j++)
                //{
                Bitmap t = new Bitmap(GuassSpace[i, 0].ToBitmap());
                Graphics g = Graphics.FromImage(t);
                for (int index = 0; index < featurePoints[i, j].Count; index++)
                    g.FillEllipse(new SolidBrush(Color.FromArgb(255, 0, 0)), new Rectangle(featurePoints[i, j][index].x, featurePoints[i, j][index].y, 10, 10));
                //t.SetPixel(, Color.FromArgb(255, 0, 0));
                CreateTabPage("求精", t);
                //}
            }
            MessageBox.Show("D+0D:max = " + max + ",min = " + min);

            //5.去除边缘响应
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < s + 1; j++)
                {
                    int count = featurePoints[i, j].Count;
                    for (int index = 0; index < count; index++)
                    {
                        double x = featurePoints[i, j][index].x;
                        double y = featurePoints[i, j][index].y;
                        double[,] H = new double[3, 3];
                        H[0, 0] = D(DOG, i, j, (int)x + 1, (int)y) + D(DOG, i, j, (int)x - 1, (int)y) - 2 * D(DOG, i, j, (int)x, (int)y);
                        H[1, 1] = D(DOG, i, j, (int)x, (int)y + 1) + D(DOG, i, j, (int)x, (int)y - 1) - 2 * D(DOG, i, j, (int)x, (int)y);
                        H[0, 1] = (D(DOG, i, j, (int)x + 1, (int)y + 1) + D(DOG, i, j, (int)x - 1, (int)y + 1) - D(DOG, i, j, (int)x + 1, (int)y - 1) - D(DOG, i, j, (int)x - 1, (int)y - 1)) / 4.0;
                        H[1, 0] = H[0, 1];

                        double r_max = 10;
                        double Tr_H = H[0, 0] + H[1, 1];
                        double Det_H = H[0, 0] * H[0, 0] - H[1, 0] * H[0, 1];
                        if ((Tr_H * Tr_H / Det_H) >= ((r_max + 1) * (r_max + 1) / r_max))
                        {
                            featurePoints[i, j].RemoveAt(index);
                            index--;
                            count--;
                        }

                    }
                }
            }

            //for (int i = 0; i < n; i++)
            {
                int i = 0;
                int j = 1;
                //for (int j = 1; j < s + 1; j++)
                //{
                Bitmap t = new Bitmap(GuassSpace[i, 0].ToBitmap());
                Graphics g = Graphics.FromImage(t);
                for (int index = 0; index < featurePoints[i, j].Count; index++)
                    g.FillEllipse(new SolidBrush(Color.FromArgb(255, 0, 0)), new Rectangle(featurePoints[i, j][index].x, featurePoints[i, j][index].y, 10, 10));
                //t.SetPixel(, Color.FromArgb(255, 0, 0));
                CreateTabPage("去边缘", t);
                //}
            }

            return featurePoints;
        }

        /// <summary>
        /// 获取D值，用于极值点索引
        /// </summary>
        /// <param name="DOG">高斯差分空间</param>
        /// <param name="i">组号</param>
        /// <param name="j">层号</param>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <returns></returns>
        private double D(CDOG[,] DOG,int i, int j, int x, int y)
        {
            return DOG[i, j].GetPixel(x, y);
        }

        /// <summary>
        /// 是否为最小值或最大值，用于确定DOG极值点
        /// </summary>
        /// <param name="pixel">中心点</param>
        /// <param name="nearstPixels">周围像素，包括中心</param>
        /// <returns>是否为极值点</returns>
        private bool IsMinOrMax(double pixel, double[,,] nearstPixels)
        {
            double max = nearstPixels[0, 0, 0];
            double min = nearstPixels[0, 0, 0];
            for (int ii = 0; ii < 3; ii++)
            {//层数
                for (int jj = 0; jj < 3; jj++)
                {//横坐标
                    for (int kk = 0; kk < 3; kk++)
                    {//纵坐标
                        if (ii == 1 && jj == 1 && kk == 1)
                            continue;
                        if(min > nearstPixels[ii,jj,kk])
                        {
                            min = nearstPixels[ii, jj, kk];
                        }
                        if (max < nearstPixels[ii, jj, kk])
                        {
                            max = nearstPixels[ii, jj, kk];
                        }
                    }
                }
            }
            return pixel > max || pixel < min;
        }

        /// <summary>
        /// 获得两个图片的差值
        /// </summary>
        /// <param name="image1">被减数图片</param>
        /// <param name="image2">减数图片</param>
        /// <param name="featurePoints">sift特征点</param>
        /// <returns>差值图片</returns>
        private CDOG GetDifferentImage(CDOG image1, CDOG image2, ref List<CFeaturePoint> featurePoints)
        {
            int width = image1.GetWidth();
            int height = image1.GetHeight();

            CDOG output = new CDOG(width, height);
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output.SetPixel(j, i, image1.GetPixel(j,i) - image2.GetPixel(j, i));
                    if (i > 3 && i < height - 3 && j > 3 && j < width - 3/* && ((int)image1.GetPixel(j, i) - (int)image2.GetPixel(j, i)) != 0*/)
                    {
                        featurePoints.Add(new CFeaturePoint(j, i));
                        //imgValuesoutput[i * stride + j + 0] = 255;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// 双线性插值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private Bitmap DoubleImage(Bitmap input)
        {
            int inputWidth = input.Width;
            int inputHeight = input.Height;
            int outputWidth = input.Width * 2;
            int outputHeight = input.Height * 2;

            Bitmap output = new Bitmap(outputWidth, outputHeight);

            Rectangle inputRect = new Rectangle(0, 0, inputWidth, inputHeight);
            Rectangle outputRect = new Rectangle(0, 0, outputWidth, outputHeight);

            //将Bitmap锁定到系统内存中,获得BitmapData
            BitmapData imgBmData1 = input.LockBits(inputRect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmDataoutput = output.LockBits(outputRect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
            System.IntPtr imgPtr1 = imgBmData1.Scan0;
            System.IntPtr imgPtroutput = imgBmDataoutput.Scan0;

            int inputImg_bytes = imgBmData1.Stride * inputHeight;
            int outputImg_bytes = imgBmDataoutput.Stride * outputHeight;

            byte[] imgValues1 = new byte[inputImg_bytes];
            byte[] imgValuesoutput = new byte[outputImg_bytes];

            //复制GRB信息到byte数组
            System.Runtime.InteropServices.Marshal.Copy(imgPtr1, imgValues1, 0, inputImg_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtroutput, imgValuesoutput, 0, outputImg_bytes);

            //操作
            int inputStride = imgBmData1.Stride;
            int outputStride = imgBmDataoutput.Stride;
            for(int i=0;i < outputHeight;i++)
            {
                double temp1 = 0;
                double temp2 = 0;
                double temp3 = 0;

                int j = 3 * outputWidth - 6;

                temp1 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3];
                temp2 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3 + 1];
                temp3 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3 + 2];

                imgValuesoutput[i * outputStride + j] = Get0To255((int)temp1);
                imgValuesoutput[i * outputStride + j + 1] = Get0To255((int)temp2);
                imgValuesoutput[i * outputStride + j + 2] = Get0To255((int)temp3);

                j = 3 * outputWidth - 3;

                temp1 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3];
                temp2 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3 + 1];
                temp3 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3 + 2];

                imgValuesoutput[i * outputStride + j] = Get0To255((int)temp1);
                imgValuesoutput[i * outputStride + j + 1] = Get0To255((int)temp2);
                imgValuesoutput[i * outputStride + j + 2] = Get0To255((int)temp3);
            }
            for(int j=0;j < 3 * outputWidth; j+=3)
            {
                double temp1 = 0;
                double temp2 = 0;
                double temp3 = 0;

                int i = outputHeight - 2;

                temp1 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3];
                temp2 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3 + 1];
                temp3 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3 + 2];

                imgValuesoutput[i * outputStride + j] = Get0To255((int)temp1);
                imgValuesoutput[i * outputStride + j + 1] = Get0To255((int)temp2);
                imgValuesoutput[i * outputStride + j + 2] = Get0To255((int)temp3);
                
                i = outputHeight - 1;

                temp1 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3];
                temp2 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3 + 1];
                temp3 = imgValues1[i / 2 * inputStride + j / 3 / 2 * 3 + 2];

                imgValuesoutput[i * outputStride + j] = Get0To255((int)temp1);
                imgValuesoutput[i * outputStride + j + 1] = Get0To255((int)temp2);
                imgValuesoutput[i * outputStride + j + 2] = Get0To255((int)temp3);

            }
            for (int i = 0; i < outputHeight - 2; i++)
            {
                for (int j = 0; j < 3 * outputWidth - 6; j += 3)
                {
                    double temp1 = 0;
                    double temp2 = 0;
                    double temp3 = 0;

                    double u = i / 2.0 - i / 2;
                    double v = j / 3 / 2.0 - j / 3 / 2;

                    int i00 = i / 2;
                    int j00 = (j / 3 / 2) * 3;

                    int i01 = i / 2;
                    int j01 = (j / 3 / 2 + 1) * 3;

                    int i10 = i / 2 + 1;
                    int j10 = (j / 3 / 2) * 3;

                    int i11 = i / 2 + 1;
                    int j11 = (j / 3 / 2 + 1) * 3;

                    temp1 = imgValues1[i00 * inputStride + j00] * (1 - u) * (1 - v) + imgValues1[i01 * inputStride + j01] * (1 - u) * v + imgValues1[i10 * inputStride + j10] * u * (1 - v) + imgValues1[i11 * inputStride + j11] * u * v;
                    temp2 = imgValues1[i00 * inputStride + j00 + 1] * (1 - u) * (1 - v) + imgValues1[i01 * inputStride + j01 + 1] * (1 - u) * v + imgValues1[i10 * inputStride + j10 + 1] * u * (1 - v) + imgValues1[i11 * inputStride + j11 + 1] * u * v;
                    temp3 = imgValues1[i00 * inputStride + j00 + 2] * (1 - u) * (1 - v) + imgValues1[i01 * inputStride + j01 + 2] * (1 - u) * v + imgValues1[i10 * inputStride + j10 + 2] * u * (1 - v) + imgValues1[i11 * inputStride + j11 + 2] * u * v;

                    imgValuesoutput[i * outputStride + j] = Get0To255((int)temp1);
                    imgValuesoutput[i * outputStride + j + 1] = Get0To255((int)temp2);
                    imgValuesoutput[i * outputStride + j + 2] = Get0To255((int)temp3);
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(imgValues1, 0, imgPtr1, inputImg_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValuesoutput, 0, imgPtroutput, outputImg_bytes);

            //解锁位图
            input.UnlockBits(imgBmData1);
            output.UnlockBits(imgBmDataoutput);

            return output;
        }

        private CDOG HalfImage(CDOG input)
        {
            int inputWidth = input.GetWidth();
            int inputHeight = input.GetHeight();
            int outputWidth = inputWidth / 2;
            int outputHeight = inputHeight / 2;

            CDOG output = new CDOG(outputWidth, outputHeight);
            
            for (int i = 0; i < outputHeight; i++)
            {
                for (int j = 0; j < outputWidth; j++)
                {
                    output.SetPixel(j, i, input.GetPixel(j * 2, i * 2));
                }
            }

            return output;
        }
    }
}