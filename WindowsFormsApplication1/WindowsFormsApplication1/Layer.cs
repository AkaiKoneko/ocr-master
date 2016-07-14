using System.Collections.Generic;

namespace ocr
{
    class Layer
    {
        public List<Neuron> Neurons { get; set; }

        public Layer(int nNeurons, int nInputs)
        {
            Neurons = new List<Neuron>();

            for (int i = 0; i < nNeurons; i++)
                Neurons.Add(new Neuron(nInputs));
        }
    }
}
