using nn.modules.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nn.modules.Networks
{
    public sealed class LinearNetwork : INeuralNetwork
    {
        public Layer[] Structure { get; }
        public event Action<Matrix> ForwardCompleted;

        public LinearNetwork()
        {
            Structure = new Layer[]
            {
                new LayerLinear(32 * 32, 200),
                new LayerLinear(200, 10)
            };
        }

        public Matrix Forward(Matrix input)
        {
            var x = Structure[0].Forward(input).Sigmoid();

            for (int i = 1; i < Structure.Length; i++) {
                x = Structure[i].Forward(x).Sigmoid();
            }

            ForwardCompleted?.Invoke(x);

            return x;
        }

        public void LoadWeights(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
