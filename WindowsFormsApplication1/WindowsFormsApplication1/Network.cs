using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ocr
{
    class Network
    {
        public double K { get; set; }// wspolczynnik uczenia sie 
        public List<Layer> Layers { get; set; }
        public double M { get; set; }
        public Network(int nFirstInputs, IEnumerable<int> nLayers)
        {
            Layers = new List<Layer>();
            int nInputs = nFirstInputs;

            foreach (int nNeurons in nLayers)
            {
                Layers.Add(new Layer(nNeurons, nInputs));
                nInputs = nNeurons;
            }

            var rand = new Random();

            foreach (var layer in Layers)
                foreach (var neuron in layer.Neurons)
                {
                    neuron.B = rand.NextDouble() - 0.5;

                    foreach (var input in neuron.Inputs)
                    {
                        input.W = rand.NextDouble() - 0.5;
                        input.WW = input.W;
                    }
                }
        }

        public void RecognitionImage(DigitImage image)
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                if (i == 0)
                {
                    foreach (var neuron in Layers[i].Neurons)
                    {
                        int nInput = 0;

                        foreach (var hPixel in image.Pixels)
                        {
                            foreach (var wPixel in hPixel)
                            {
                                neuron.Inputs[nInput].X = wPixel;

                                nInput++;
                            }
                        }

                        neuron.SetData();
                    }
                }
                else
                {
                    foreach (var neuron in Layers[i].Neurons)
                    {
                        for (var j = 0; j < Layers[i - 1].Neurons.Count; j++)
                            neuron.Inputs[j].X = Layers[i - 1].Neurons[j].Z;

                        neuron.SetData();
                    }
                }
            }
        }

        public void Train(List<DigitImage> trainImages) //algorytm wstecznej propagacji błędu
        {
            Stopwatch stopWatch = new Stopwatch();
            for (int i = 0; i < 1; i++)
            {
                foreach (var trainImage in trainImages)
                {
                    int count = trainImages.Count - trainImages.IndexOf(trainImage);
                    stopWatch.Start();
                    
                    if (i == 0)
                    {
                        switch (trainImages.IndexOf(trainImage))
                        {
                            case 5000:
                                K = 0.4;
                                M = 0.2;
                                break;
                            case 10000:
                                K = 0.3;
                                break;
                            case 15000:
                                K = 0.2;
                                M = 0.1;
                                break;
                            case 25000:
                                K = 0.1;
                                break;
                            case 45000:
                                K = 0.05;
                                M = 0.05;
                                break;
                        }
                    }

                    Console.WriteLine("-- -->>> " + (trainImages.IndexOf(trainImage) + 1) + " -------------------------");
                    Console.WriteLine("-- --> Obliczanie wartości wyjściowych neuronów");

                    RecognitionImage(trainImage);

                    Console.WriteLine("-- <-- Obliczanie wartości wyjściowych neuronów zakończone");
                    Console.WriteLine("-- --> Obliczanie błędów wstecznej propagacji");

                    foreach (var lastNeuron in Layers[Layers.Count - 1].Neurons)
                    {
                        if (Layers[Layers.Count - 1].Neurons.IndexOf(lastNeuron) == trainImage.Label)
                            lastNeuron.Q = (1 - lastNeuron.Z) * lastNeuron.PrimZ;
                        else
                            lastNeuron.Q = (0 - lastNeuron.Z) * lastNeuron.PrimZ;
                    }

                    for (int nLayer = (Layers.Count - 2); nLayer >= 0; nLayer--)
                    {
                        for (int nNeuron = 0; nNeuron < Layers[nLayer].Neurons.Count; nNeuron++)
                        {
                            double q = Layers[nLayer + 1].Neurons.Sum(nextNeuron => nextNeuron.Inputs[nNeuron].W * nextNeuron.Q) * Layers[nLayer].Neurons[nNeuron].PrimZ;

                            Layers[nLayer].Neurons[nNeuron].Q = q;
                        }
                    }

                    Console.WriteLine("-- <-- Obliczanie błędów wstecznej propagacji zakończone");
                    Console.WriteLine("-- --> Korekcja wag");

                    foreach (var layer in Layers)
                        foreach (var neuron in layer.Neurons)
                        {
                            neuron.B += K * neuron.Q;


                            foreach (var input in neuron.Inputs)
                            {
                                var t = input.W;

                                input.W = input.W + K * neuron.Q * input.X + M * (input.W - input.WW);
                                input.WW = t;

                            }
                        }

                    Console.WriteLine("-- <-- Korekcja wag zakończona");


                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    double time = ts.TotalMinutes * count;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                     ts.Hours*count, ts.Minutes, ts.Seconds,
                     ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + time);
                    stopWatch.Reset();
                }
               


            }
        }
    }
}
