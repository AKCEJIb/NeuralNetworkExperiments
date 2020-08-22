using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nn.modules
{
    public interface ILearningError
    {
        Matrix Forward(Matrix input, Matrix target);
        //Matrix Backward();
    }
}
