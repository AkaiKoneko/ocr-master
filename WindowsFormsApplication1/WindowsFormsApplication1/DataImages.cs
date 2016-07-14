using System;
using System.Collections.Generic;
using System.IO;

namespace ocr
{
    class DataImages
    {
        public int W { get; set; }
        public int H { get; set; }
        public List<DigitImage> DigitImages { get; set; }

        public DataImages(string uriImages, string uriLabels, int w, int h, int nImages)
        {
            W = w;
            H = h;

            DigitImages = new List<DigitImage>();

            try
            {
                var images = new FileStream(uriImages, FileMode.Open);
                var labels = new FileStream(uriLabels, FileMode.Open);

                var brImages = new BinaryReader(images);
                var brLabels = new BinaryReader(labels);

                int magic1 = brImages.ReadInt32();
                int numImages = brImages.ReadInt32();
                int numRows = brImages.ReadInt32();
                int numCols = brImages.ReadInt32();

                int magic2 = brLabels.ReadInt32();
                int numLabels = brLabels.ReadInt32();

                var pixels = new byte[h][];

                for (int i = 0; i < h; ++i)
                    pixels[i] = new byte[w];

                for (int di = 0; di < nImages; ++di)
                {
                    for (int i = 0; i < h; ++i)
                    {
                        for (int j = 0; j < w; ++j)
                        {
                            byte b = brImages.ReadByte();
                            pixels[i][j] = b;
                        }
                    }

                    DigitImages.Add(new DigitImage(W, H, pixels, brLabels.ReadByte()));
                }

                images.Close();
                brImages.Close();
                labels.Close();
                brLabels.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("Wyjątek: " + ex.Message);
            }
        }
    }
}