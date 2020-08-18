using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroModule.Neuro
{
    public class Neuron
    {
        public Neuron()
        {
            Weight = 0;
            Error = 0;
        }
        public Neuron(double weight)
        {
            Weight = weight;
            Error = 0;
        }

        public void SetWeight(double weight)
        {
            Weight = weight;
        }

        public void SetError(double error)
        {
            Error = error;
        }

        public double Weight { get; private set; }
        public double Error { get; private set; }
    }
}
