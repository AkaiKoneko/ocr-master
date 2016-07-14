using System;
using System.Collections.Generic;
using System.Linq;

namespace ocr
{
    class Neuron
    {
        public double B { get; set; } // bias
        public double Y { get; set; } // wartosc wyjscia neuronu
        public double Z { get; set; } // wartosc funkcji aktywacji
        public double PrimZ { get; set; } // pochodna funkcji aktywacji
        public double Q { get; set; } // blad propagacji
        public List<Input> Inputs { get; set; } //wejscia neuronu

        public Neuron(int nInputs)
        {
            Inputs = new List<Input>();

            for (int i = 0; i < nInputs; i++)
                Inputs.Add(new Input());
        }

        public void SetData()
        {
            Y = Inputs.Sum(input => input.X * input.W) + B;
            Z = 1.0 / (1.0 + Math.Exp(-Y));
            PrimZ = Z * (1 - Z);
        }
    }
}

