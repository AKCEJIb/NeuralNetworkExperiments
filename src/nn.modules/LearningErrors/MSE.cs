using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nn.modules.LearningErrors
{
    public class MSE : ILearningError
    {
        public Matrix Forward(Matrix input, Matrix target)
        {
            if (input.Size != target.Size)
                throw new ArgumentException("Размеры матриц должны совпадать!");

            var errSum = 0d;
            var err = (input - target);
            err.Action((i, j) => errSum += err[i, j] * err[i, j]);

            return new Matrix(1, 1, errSum / (err.Rows * err.Cols));
        }
    }
}
