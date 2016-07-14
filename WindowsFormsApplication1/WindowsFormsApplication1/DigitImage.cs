using System;
using System.Drawing;
using System.Globalization;

namespace ocr
{
    class DigitImage

    {
        public byte[][] Pixels { get; set; }
        public byte Label { get; set; }


        public DigitImage(int w, int h,Bitmap bitmap)
        {

            Pixels = new byte[h][];

            for (int i = 0; i < h; ++i)
                Pixels[i] = new byte[w];

            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                 
                    

                    if (bitmap.GetPixel(j, i) != Color.FromArgb(255,255,255,255)) { 
                    Console.WriteLine(bitmap.GetPixel(j, i));
                    Pixels[i][j] = 1;
                }
                    else
                            Pixels[i][j] = 0;


                }
            }

        }

        public DigitImage(int w, int h, byte[][] pixels, byte label)
        {
            Pixels = new byte[h][];

            for (int i = 0; i < h; ++i)
                Pixels[i] = new byte[w];

            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    switch (pixels[i][j])
                    {
                        case 0:
                            Pixels[i][j] = 0;
                            break;
                        default:
                            Pixels[i][j] = 1;
                            break;
                    }
                }
            }

            Label = label;
        }

        public override string ToString()
        {
            string s = "";

            foreach (var hPixel in Pixels)
            {
                foreach (double wPixel in hPixel)
                {
                    switch (wPixel.ToString())
                    {
                        case "0":
                            s += " ";
                            break;
                        default:
                            s += ".";
                            break;
                    }
                }

                s += "\n";
            }

            s += "\n\n";
            s += Label.ToString(CultureInfo.InvariantCulture);

            return s;
        }
    }
}
