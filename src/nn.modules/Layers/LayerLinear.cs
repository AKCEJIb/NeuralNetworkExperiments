using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nn.modules.Layers
{
    /// <summary>
    /// Класс представляющий из себя линейный слой
    /// </summary>
    public class LayerLinear : Layer
    {
        public LayerLinear(int inFeatures, int outFeatures, bool bias = false)
        {
            _weights = Matrix.CreateRandom(outFeatures, inFeatures);

            if (bias)
                _bias = Matrix.CreateRandom(outFeatures, 1);
        }

        public override Matrix Forward(Matrix input)
        {
            var result = _weights * input;

            if (_bias != null)
                result += _bias;

            return result;
        }
    }
}
