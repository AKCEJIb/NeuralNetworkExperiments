using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nn.modules
{
    public abstract class Layer
    {
        protected Matrix _weights;
        protected Matrix _bias;

        public abstract Matrix Forward(Matrix input);
        public void SetWeights(double[,] weights)
        {
            var rows = weights.GetLength(0);
            var cols = weights.GetLength(1);

            _weights = new Matrix(rows, cols, weights);
        }
        public void SetBias(double[,] bias)
        {
            var rows = bias.GetLength(0);
            var cols = bias.GetLength(1);

            _bias = new Matrix(rows, cols, bias);
        }
    }
}
