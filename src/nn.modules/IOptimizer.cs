using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nn.modules
{
    interface IOptimizer
    {
        void Backward(Matrix expected);
        void Step();
    }
}
