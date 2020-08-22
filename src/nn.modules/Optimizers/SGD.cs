using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace nn.modules.Optimizers
{
    public class SGD : IOptimizer
    {
        private readonly ILearningError _learningError;
        private readonly INeuralNetwork _nn;
        public SGD(ILearningError error, INeuralNetwork nn)
        {
            _learningError = error;
            _nn = nn;

            _nn.ForwardCompleted += Backward;
        }

        public void Backward(Matrix real)
        {
           

            //var err = _learningError.Calculate(expected, ex);


        }

        public void Step()
        {
           

        }
    }
}
