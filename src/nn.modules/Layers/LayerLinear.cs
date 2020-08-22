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
        /// <summary>
        /// Создаёт <see cref="LayerLinear"/>.
        /// </summary>
        /// <param name="inFeatures">Количество входных признаков.</param>
        /// <param name="outFeatures">Количество выходных признаков.</param>
        /// <param name="bias">Инициализировать признаки смещения.</param>
        public LayerLinear(int inFeatures, int outFeatures, bool bias = false)
        {

            _weights = Matrix.CreateRandom(
                rows: outFeatures,
                cols: inFeatures,
                min: -1,
                max: 1
                );

            if (bias)
                _bias = Matrix.CreateRandom(
                    rows: outFeatures, 
                    cols: 1, 
                    min: -1,
                    max: 1
                    );
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
