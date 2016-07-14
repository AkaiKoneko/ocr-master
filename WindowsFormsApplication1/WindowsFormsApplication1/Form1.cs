using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ocr
{
    public partial class Form1 : Form
    {

        
        private String path = AppDomain.CurrentDomain.BaseDirectory + @"\Resources\";
        private Bitmap drawBitmap;
        private Graphics drawGraph;

        private const int W = 28;//szerokosc MNIST
        private const int H = 28;//wysokosc MNIST
        private const int NTrain = 60000;//ilosc trenujacych MNIST
        private const int NTests = 10000;//ilosc testujacych  MNIST ???
        
        private Network network;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clearInput();
        }

        private void clearInput()
        {

            drawBitmap = new Bitmap(drawPictureBox.Width,drawPictureBox.Height);
            drawGraph = Graphics.FromImage(drawBitmap);
            drawGraph.Clear(Color.White);
            Pen pen = new Pen(Brushes.Black);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        
           // drawGraph.DrawRectangle(pen, 3, 3, drawPictureBox.Width - 7, drawPictureBox.Height - 7);
            drawPictureBox.Image = drawBitmap;
        }

        private void drawPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Rectangle rectEllipse = new Rectangle();
            rectEllipse.X = e.X - 1;
            rectEllipse.Y = e.Y - 1;
            rectEllipse.Width = 2;
            rectEllipse.Height = 2;
            drawGraph.FillEllipse(new SolidBrush(Color.Black), e.X, e.Y, 20, 20);
            drawPictureBox.Image = drawBitmap;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            clearInput();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("--> Tworzenie sieci");

            const int nFirstInputs = W * H; //liczba wejść do warstwy pierwszej
            network = new Network(nFirstInputs, new[] { nFirstInputs, 100,50,20, 10 }) { K = 0.7, M = 0.3 }; //wartości w poszczególnyh polach tablicy określają liczbę neuronów w poszczególnych warstwach
            //300 ukrytej 10 w koncowej k to wspolczynnik uczenia 

            Console.WriteLine("<-- Sieć została stworzona");


            //TrainNetwork(network);
           // TestNetwork(network);

            Console.ReadLine();
            recognizeButton.Visible = true;
        }

        private void trainNetworkButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("--> Ładowanie danych treningowych");

            string uriTrainImages = path + @"train-images.idx3-ubyte";
            string uriTrainLabels = path + @"train-labels.idx1-ubyte";
            var trainImages = new DataImages(uriTrainImages, uriTrainLabels, W, H, NTrain); //60000

            Console.WriteLine("<-- Dane treningowe zostały załadowane");
            Console.WriteLine("<-- Przykładowe zdjęcie");

            Console.WriteLine(trainImages.DigitImages[7].ToString());

            Console.WriteLine("--> Przykładowe zdjecie zostalo wyświetlone (nacisnij dowolny przycisk aby kontynuować trenowanie)");
           // Console.ReadKey();
            Console.WriteLine("--> Trenowanie sieci");

            network.Train(trainImages.DigitImages);

            Console.WriteLine("<-- Trening sieci zakończony");
            Console.WriteLine("--> Zapis parametrów do bazy");

            using (var file = new System.IO.StreamWriter(path + "weight.txt"))
            {
                foreach (var layer in network.Layers)
                {
                    file.WriteLine("Layer[" + (network.Layers.IndexOf(layer) + 1) + "]");

                    foreach (var neuron in layer.Neurons)
                    {
                        file.WriteLine("Neuron[" + (layer.Neurons.IndexOf(neuron) + 1) + "]");
                        file.WriteLine("Bias = " + neuron.B);

                        foreach (var input in neuron.Inputs)
                        {
                            file.WriteLine("Input[" + (neuron.Inputs.IndexOf(input) + 1) + "] = " + input.W);
                        }
                    }
                }
            }

            Console.WriteLine("<-- Zapis parametrów do bazy zakończony");
        }

        private void recognizeButton_Click_1(object sender, EventArgs e)
        {
            //wczytanie 
            //eksperymentalne/!!!!!!!!!!!!!!!!!!!!!!
            Bitmap source = new Bitmap(28, 28);
            using (Graphics g = Graphics.FromImage((Image)source))
                g.DrawImage(drawPictureBox.Image, 0, 0, 28,28);


            int x1=0, x2=28, y1=0, y2=28;   ///lewo prawo gora dol
            bool hFirst=true, wFirst=true;

            for (int i = 0; i < H; ++i)
            {
                for (int j = 0; j < W; ++j)
                {
                   


                    if (source.GetPixel(j, i) != Color.FromArgb(255, 255, 255, 255))
                    {
                        if (hFirst)
                        {
                            y1 = i;
                            y2 = i;
                            hFirst = false;
                        }
                        if (i > y1) y1 = i+1;
                        if (i < y2) y2 = i-1;
                        if (wFirst)
                        {
                            x1 = j;
                            x2 = j;
                            wFirst = false;
                        }
                        if (j > x1) x1 = j+1;
                        if (j < x2) x2 = j-1;

                    }

                }
            }

           // if (x2-x1>=y2-y1) 
            Rectangle sourceRectangle = new Rectangle(x2, y2, x1-x2, y1-y2);
            Rectangle destRectangle = new Rectangle(4, 4, 20, 20);
            Bitmap result = new Bitmap(28, 28);

            using (Graphics g = Graphics.FromImage(result))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255)))
            {
                g.FillRectangle(brush, 0, 0, 28, 28);
            }

            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(source,destRectangle,sourceRectangle,GraphicsUnit.Pixel);









            //koniec eksperymentu


            drawPictureBox.Image = result;

            Console.WriteLine("--> Ustawianie parametrów z bazy");

            string[] lines = System.IO.File.ReadAllLines(path + "weight.txt");

            int iLayer = 0;
            int iNeuron = 0;

            foreach (string line in lines)
            {
                var temp = line.Replace(" ", string.Empty);
                List<String> ab = temp.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var a = ab[0];
                var b = "";

                if (ab.Count > 1)
                    b = ab[1];

                var xy = new List<string>();

                if (a != "Bias")
                {
                    xy = a.Split(new[] { "[" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    xy[1] = xy[1].Replace("]", string.Empty);
                }
                else
                    xy.Add(a);

                var x = xy[0];
                var y = "";

                if (xy.Count > 1)
                    y = xy[1];

                switch (x)
                {
                    case "Layer":
                        iLayer = Convert.ToInt32(y) - 1;
                        break;
                    case "Neuron":
                        iNeuron = Convert.ToInt32(y) - 1;
                        break;
                    case "Bias":
                        network.Layers[iLayer].Neurons[iNeuron].B = Convert.ToDouble(b);
                        break;
                    case "Input":
                        network.Layers[iLayer].Neurons[iNeuron].Inputs[Convert.ToInt32(y) - 1].W = Convert.ToDouble(b);
                        break;
                }
            }

            Console.WriteLine("<-- Ustawianie parametrów z bazy zakończone");






          
            // czy ja wiem co to ?!?!?!
            DigitImage testImage = new DigitImage(28, 28, result);
            Console.WriteLine(testImage.ToString());

            network.RecognitionImage(testImage);

            var t = network.Layers[network.Layers.Count - 1].Neurons;
            var d = t.Max(y => y.Z);


            int k = t.IndexOf(t.First(n => Equals(n.Z, d)));
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Jest to liczba : " + i + " . Wartosc neuronu wyjsciowego : " + String.Format("{0:N2}", t[i].Z));
            }
            label1.Visible = true;
            label2.Visible = true;
   
            label2.Text = k.ToString();
            Console.WriteLine("Chyba to jest ->> " + k);
            number0Bar.Value = (int)(t[0].Z*100);
            number1Bar.Value = (int)(t[1].Z * 100);
            number2Bar.Value = (int)(t[2].Z * 100);
            number3Bar.Value = (int)(t[3].Z * 100);
            number4Bar.Value = (int)(t[4].Z * 100);
            number5Bar.Value = (int)(t[5].Z * 100);
            number6Bar.Value = (int)(t[6].Z * 100);
            number7Bar.Value = (int)(t[7].Z * 100);
            number8Bar.Value = (int)(t[8].Z * 100);
            number9Bar.Value = (int)(t[9].Z * 100);





        }
    }
}
