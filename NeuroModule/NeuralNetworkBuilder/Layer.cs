using NeuroModule.MatrixClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroModule.Neuro
{
    public class Layer
    {
        private readonly Random _random = new Random();
        /// <summary>
        /// Создаёт новый <see cref="Layer"/>
        /// </summary>
        /// <param name="layerSize">Количество нейронов.</param>
        public Layer(int layerSize, int biasSize)
        {
            _bias = Matrix.CreateRandom(1, biasSize) * 2 - 1;
            _neurons = new Matrix(1, layerSize);
            _errors = new Matrix(1, layerSize);
        }
        public Layer(int layerSize)
        {
            _neurons = new Matrix(1, layerSize);
            _errors = new Matrix(1, layerSize);
        }
        /// <summary>
        /// Копирующий конструктор <see cref="Layer"/>
        /// </summary>
        /// <param name="layer"></param>
        public Layer(Layer layer)
        {
            _bias = layer.Bias;
            _neurons = layer.Neurons;
            _errors = layer.Errors;
        }

        public void SetNeurons(Matrix neurons)
        {
            _neurons = neurons;
        }

        public void SetErrors(Matrix errors)
        {
            _errors = errors;
        }
        public void SetBias(Matrix bias)
        {
            _bias = bias;
        }

        public void AddBias(Matrix bias)
        {
            _bias = _bias + bias;
        }

        public override string ToString()
        {
            return this._neurons.ToString();
        }

        public Matrix Errors { get => _errors; }
        /// <summary>
        /// Возвращает матрицу нейронов. Обычно прдеставляет из себя вектор-строку.
        /// </summary>
        public Matrix Neurons { get => _neurons; }
        /// <summary>
        /// Вовзращает веса со всеми нейронами выходного слоя.
        /// </summary>
        public Matrix Bias { get => _bias; }
        /// <summary>
        /// Хранит матрицу нейронов.
        /// </summary>
        private Matrix _neurons;
        /// <summary>
        /// Хранит значение нейрона смещения (веса связей со следующим слоем).
        /// </summary>
        private Matrix _bias;
        private Matrix _errors;
    }
}
