using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nn.modules
{
    public interface INeuralNetwork
    {
        event Action<Matrix> ForwardCompleted;

        Layer[] Structure { get; }

        Matrix Forward(Matrix input);

        void LoadWeights(string filePath);

    }
}
