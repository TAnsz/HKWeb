using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace DotNet.Utilities
{
    /// <summary>
    /// 驗證碼類（後台）
    /// </summary>
    public class VerificationCode
    {

        private string tempstring = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";


        #region 定義全局變量
        /// <summary>生成的圖片
        /// </summary>
        private Bitmap _CurrentBitmap;

        /// <summary> 驗證碼圖片
        /// </summary>
        public Bitmap CurrentBitmap
        {
            get { return _CurrentBitmap; }
            internal set { _CurrentBitmap = value; }
        }

        /// <summary>生成的驗證碼
        /// </summary>
        private string _Code;

        /// <summary> 驗證碼
        /// </summary>
        public string Code
        {
            get { return _Code; }
            internal set { _Code = value; }
        }
        #endregion


        #region 驗證碼生成前的準備

        /// <summary>需要生成的驗證碼的字符數
        /// </summary>
        private int _CountCode = 4;

        /// <summary>需要生成的驗證碼的字符數量
        /// </summary>
        public int CountCode
        {
            internal get { return _CountCode; }
            set { _CountCode = value; }
        }

        /// <summary>生成驗證碼碼圖片的寬度
        /// </summary>
        private int _ImageWidth = 200;
        /// <summary>生成驗證碼圖片的寬度
        /// </summary>
        public int ImageWidth
        {
            internal get { return _ImageWidth; }
            set { _ImageWidth = value; }
        }

        /// <summary>生成驗證碼圖片的高度
        /// </summary>
        private int _ImageHeight = 30;
        /// <summary>生成驗證碼圖片的高度
        /// 
        /// </summary>
        public int ImageHeight
        {
            internal get { return _ImageHeight; }
            set { _ImageHeight = value; }
        }

        /// <summary>設定圖片的噪點線數量
        /// </summary>
        private int _NoiseLine = 0;
        /// <summary>設定圖片的噪點線數量
        /// </summary>
        public int NoiseLine
        {
            get { return _NoiseLine; }
            set { _NoiseLine = value; }
        }

        /// <summary> 前景干擾點
        /// </summary>
        private int _NoisePoint = 0;

        /// <summary>設定驗證碼圖片的前景干擾點數量
        /// </summary>
        public int NoisePoint
        {
            get { return _NoisePoint; }
            set { _NoisePoint = value; }
        }

        /// <summary>字體大小
        /// </summary>
        private int _FontSize = 12;

        /// <summary>字體大小
        /// </summary>
        public int FontSize
        {
            internal get { return _FontSize; }
            set { _FontSize = value; }
        }



        #endregion

        public void GetCaptcha()
        {
            Code = tempcode();
            CurrentBitmap = tempImage();
        }


        #region 生成驗證碼

        /// <summary>
        /// 生成驗證碼
        /// </summary>
        /// <returns>驗證碼字符串</returns>
        private string tempcode()
        {
            StringBuilder result = new StringBuilder();

            Random random = new Random();
            for (int i = 0; i < CountCode; i++)
            {
                int index = random.Next(0, tempstring.Length);
                result.Append(tempstring[index]);
            }

            return result.ToString();

        }

        #endregion

        #region 生成圖片

        /// <summary>生成驗證碼圖片
        /// </summary>
        /// <returns></returns>
        private Bitmap tempImage()
        {
            //創建驗證碼圖片對像
            Bitmap image = new Bitmap(ImageWidth, ImageHeight);
            //創建繪布對像
            Graphics g = Graphics.FromImage(image);
            try
            {
                Font[] fonts = {
                            new Font(new FontFamily("Impact"), RandomHelper.GetRndNext(FontSize - 2, FontSize), FontStyle.Bold),
                            new Font(new FontFamily("Kokila"), RandomHelper.GetRndNext(FontSize - 3, FontSize), FontStyle.Bold),
                            //new Font(new FontFamily("Bell MT"), RandomHelp.GetRndNext(FontSize - 3, FontSize), FontStyle.Bold),
                            new Font(new FontFamily("MV Boli"), RandomHelper.GetRndNext(FontSize - 3, FontSize), FontStyle.Bold)
                         };

                Color[] bgColors ={
                            Color.Snow,
                            Color.White,
                            Color.Linen,
                            Color.FromArgb(242,251,246),
                            Color.FromArgb(233,240,245),
                            Color.FromArgb(244,244,244),
                            Color.FromArgb(255,228,188)
                        };

                Color[] colors ={
                            Color.FromArgb(24,1,58),
                            Color.Red,
                            Color.DarkRed,
                            Color.Black,
                            Color.RoyalBlue,
                            Color.FromArgb(57,77,14),
                            Color.FromArgb(85,72,64)
                        };

                Color bgcolor = bgColors[RandomHelper.GetRndNext(0, bgColors.Length)];//背景色

                //生成隨機生成器
                Random random = new Random();
                //清空圖片背景色，畫上背景干擾線
                g.Clear(bgcolor);
                for (int i = 0; i < NoiseLine; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.FromArgb(random.Next())), x1, y1, x2, y2);
                }

                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), colors[RandomHelper.GetRndNext(0, colors.Length)], colors[RandomHelper.GetRndNext(0, colors.Length)], 1.2f, true);

                int count = Code.Length;
                for (int i = 0; i < count; i++)
                {
                    int x = i * image.Width / count - i * RandomHelper.GetRndNext(2, 4);
                    g.DrawString(Code.Substring(i, 1), fonts[RandomHelper.GetRndNext(0, fonts.Length)], brush, RandomHelper.GetRndNext(-2, 1) + x, RandomHelper.GetRndNext(-3, -1));
                }


                //int count = Code.Length;
                //for (int i = 0; i < count; i++)
                //{
                //    //字體設定
                //    Font font = new Font("Arial", RandomHelp.GetRndNext(FontSize - 5, FontSize),
                //        (FontStyle.Bold | FontStyle.Italic));

                //    //創建畫筆
                //    LinearGradientBrush brush =
                //        new LinearGradientBrush(
                //            new Rectangle( 1 + i * 10, 0, image.Width,
                //                image.Height),
                //            Color.Blue, Color.DarkRed, 2.8f, true);
                //    g.DrawString(Code.Substring(i, 1), font, brush, 5, 2);
                //}

                //畫圖片的前景干擾點
                for (int i = 0; i < NoisePoint; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //定義干擾線中間點位置
                int midX = RandomHelper.GetRndNext(0, image.Width /2);
                int midX2 = RandomHelper.GetRndNext(midX, image.Width);
                //定義畫筆
                Pen pen = new Pen(colors[RandomHelper.GetRndNext(0, colors.Length)], 2);
                //畫干擾線
                g.DrawLine(pen, 0, random.Next(image.Height), midX, random.Next(image.Height));
                g.DrawLine(pen, midX, random.Next(image.Height), midX2, random.Next(image.Height));
                g.DrawLine(pen, midX2, random.Next(image.Height), image.Width, random.Next(image.Height));

                //畫多一條干擾線
                midX = RandomHelper.GetRndNext(0, image.Width / 2);
                midX2 = RandomHelper.GetRndNext(midX, image.Width);
                //定義畫筆
                pen = new Pen(colors[RandomHelper.GetRndNext(0, colors.Length)], 2);
                //畫干擾線
                g.DrawLine(pen, 0, random.Next(image.Height), midX, random.Next(image.Height));
                g.DrawLine(pen, midX, random.Next(image.Height), midX2, random.Next(image.Height));
                g.DrawLine(pen, midX2, random.Next(image.Height), image.Width, random.Next(image.Height));

                //畫圖片的邊框線
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            }
            catch (Exception)
            {

                return image;
            }

            return image;
        }

        #endregion


        #region 圖片旋轉函數

        /// <summary>
        /// 以逆時針為方向對圖像進行旋轉
        /// </summary>
        /// <param name="b">位圖流</param>
        /// <param name="angle">旋轉角度[0,360](前台給的)</param>
        /// <returns></returns>
        public Image RotateImg(Image b, int angle)
        {

            angle = angle % 360;

            //弧度轉換

            double radian = angle * Math.PI / 180.0;

            double cos = Math.Cos(radian);

            double sin = Math.Sin(radian);

            //原圖的寬和高

            int w = b.Width;

            int h = b.Height;

            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));

            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));

            //目標位圖

            Bitmap dsImage = new Bitmap(W, H);

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //計算偏移量

            Point Offset = new Point((W - w) / 2, (H - h) / 2);

            //構造圖像顯示區域：讓圖像的中心與窗口的中心點一致

            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);

            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);

            g.TranslateTransform(center.X, center.Y);

            g.RotateTransform(360 - angle);

            //恢復圖像在水平和垂直方向的平移

            g.TranslateTransform(-center.X, -center.Y);

            g.DrawImage(b, rect);

            //重至繪圖的所有變換

            g.ResetTransform();

            g.Save();

            g.Dispose();

            //保存旋轉後的圖片

            b.Dispose();

            //dsImage.Save("FocusPoint.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            return dsImage;

        }

        public Image RotateImg(string filename, int angle)
        {

            return RotateImg(GetSourceImg(filename), angle);

        }

        public Image GetSourceImg(string filename)
        {

            Image img;

            img = Bitmap.FromFile(filename);

            return img;

        }

        #endregion 圖片旋轉函數




    }
}
