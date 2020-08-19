//using NeuroModule.MatrixClass;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;

//namespace NeuroModule.Neuro
//{
//    public class NeuralNetwork
//    {
//        public event EventHandler<EpochDoneEventArgs> EpochDone;
//        private static Random _rand = new Random();
//        private List<Tuple<int, double[,]>> _dataPack = new List<Tuple<int, double[,]>>();
//        private List<Tuple<Matrix, Matrix>> GenerateRandomSet(int batchSize, int layerInSize, int layerOutSize)
//        {
//            var result = new List<Tuple<Matrix, Matrix>>();
//            // Формируем пакет
//            for(int i = 0; i < batchSize; i++)
//            {
//                var itemId = _rand.Next(_dataPack.Count);
//                var question = new Matrix(1, layerInSize, _dataPack[itemId].Item2);
//                var answer = new Matrix(1, layerOutSize);
//                answer[0, _dataPack[itemId].Item1] = 1;
//                result.Add(new Tuple<Matrix, Matrix>(answer, question));
//            }
//            return result;
//        }

//        private List<Tuple<Matrix, Matrix>> GenerateRandomSet(int layerInSize, int layerOutSize)
//        {
//            var result = new List<Tuple<Matrix, Matrix>>();
//            // Формируем пакет
//            for (int i = 0; i < _dataPack.Count; i++)
//            {
//                var question = new Matrix(1, layerInSize, _dataPack[i].Item2);
//                var answer = new Matrix(1, layerOutSize);
//                answer[0, _dataPack[i].Item1] = 1;
//                result.Add(new Tuple<Matrix, Matrix>(answer, question));
//            }
//            return result;
//        }

//        public void SetDataPack(List<Tuple<int, double[,]>> dataPack)
//        {
//            _dataPack = dataPack;
//        }
//        #region .Ctor
//        /// <summary>
//        /// Создаёт экземпляр класса <see cref="NeuralNetwork"/>.
//        /// </summary>
//        public NeuralNetwork()
//        {
//            Epoch = 0;
//            NeuroName = "noname";
//            Layers = new List<Layer>();
//            Weights = new List<Matrix>();
//        }

//        /// <summary>
//        /// Создаёт экземпляр класса <see cref="NeuralNetwork"/>. С типом сети: Прямое распространение.
//        /// С случайно инциализированными весами.
//        /// </summary>
//        /// <param name="countInputNeurons">Количество входных нейронов.</param>
//        /// <param name="hiddenLayerSettings">Количество нейронов на скрытых слоях. Наример, <c> new int[] {4, 3} </c></param>
//        /// <param name="countOutputNeurons">Количество выходных нейронов.</param>
//        /// <example>
//        /// Создание экземпляра класса <see cref="NeuralNetwork"/> с 5 нейронами на входе.
//        /// Двумя скрытыми слоями по 4 и 3 нейрона соотвественно.
//        /// И двумя выходными нейронами.
//        /// <code>
//        /// var nn = new NeuralNetwork(5, new int[] {4, 3}, 2};
//        /// </code>
//        /// </example>
//        public NeuralNetwork(int countInputNeurons, int[] hiddenLayerSettings, int countOutputNeurons)
//        {
//            Epoch = 0;
//            NeuroName = "noname";
//            Layers = new List<Layer>();
//            Weights = new List<Matrix>();

//            // Создаём слой входных нейронов
//            Layers.Add(new Layer(countInputNeurons, hiddenLayerSettings[0]));
//            // Создаём конфигурацию скрытых слоёв
//            for (int i = 0; i < hiddenLayerSettings.Length; i++)
//            {
//                Layers.Add(new Layer(hiddenLayerSettings[i], (i < hiddenLayerSettings.Length - 1 ? hiddenLayerSettings[i + 1] : countOutputNeurons)));
//            }
//            // Создаём слой выходных нейронов
//            Layers.Add(new Layer(countOutputNeurons));

//            // Генерируем рандомные веса
//            for (int i = 0; i < Layers.Count; i++)
//            {
//                if (Layers[i].Equals(OutputLayer))
//                {
//                    break;
//                }

//                var curLayerLenght = Layers[i].Neurons.Cols;
//                var nextLayerLenght = Layers[i + 1].Neurons.Cols;

//                Weights.Add(Matrix.CreateRandom(curLayerLenght, nextLayerLenght) * 2 - 1);
//            }
//        }
//        /// <summary>
//        /// Создаёт экземпляр класса <see cref="NeuralNetwork"/>.
//        /// С типом сети: Прямое распространение.
//        /// И заранее загруженными весами.
//        /// </summary>
//        /// <param name="countInputNeurons">Количество входных нейронов.</param>
//        /// <param name="hiddenLayerSettings">Количество нейронов на скрытых слоях. Наример, <c> new int[] {4, 3} </c></param>
//        /// <param name="countOutputNeurons">Количество выходных нейронов.</param>
//        /// <param name="weights">Путь до файла весов.</param>
//        public NeuralNetwork(int countInputNeurons, int[] hiddenLayerSettings, int countOutputNeurons, string weights)
//        {
//            Epoch = 0;
//            NeuroName = "noname";
//            Layers = new List<Layer>();
//            Weights = new List<Matrix>();

//            // Создаём слой входных нейронов
//            Layers.Add(new Layer(countInputNeurons, hiddenLayerSettings[0]));
//            // Создаём конфигурацию скрытых слоёв
//            for (int i = 0; i < hiddenLayerSettings.Length; i++)
//            {
//                Layers.Add(new Layer(hiddenLayerSettings[i], (i < hiddenLayerSettings.Length - 1 ? hiddenLayerSettings[i + 1] : countOutputNeurons)));
//            }
//            // Создаём слой выходных нейронов
//            Layers.Add(new Layer(countOutputNeurons));

//            // Загружаем веса
//            LoadWeightsFromFile(weights);
//        }

//        /// <summary>
//        /// Создаёт экземпляр класса <see cref="NeuralNetwork"/>. С типом сети: Прецептрон.
//        /// С случайно инциализированными весами.
//        /// </summary>
//        /// <param name="countInputNeurons">Количество нейронов на входном слое.</param>
//        /// <remarks>
//        /// Выходной слой всегда будет иметь 1 нейрон.
//        /// </remarks>
//        public NeuralNetwork(int countInputNeurons)
//        {
//            Epoch = 0;
//            NeuroName = "noname";
//            Layers = new List<Layer>();
//            Weights = new List<Matrix>();

//            // Создаём слой входных нейронов
//            Layers.Add(new Layer(countInputNeurons, 1));
//            // Создаём слой выходных нейронов
//            Layers.Add(new Layer(1));

//            // Генерируем рандомные веса
//            Weights.Add(Matrix.CreateRandom(countInputNeurons, 1) * 2 - 1);
//        }

//        #endregion
//        /// <summary>
//        /// Метод прямого распространения входного сигнала по сети.
//        /// </summary>
//        private void Forward()
//        {
//            for (int i = 0; i < Layers.Count - 1; i++)
//            {
//                var sigmoidDot = (Layers[i].Neurons * Weights[i]);
//                sigmoidDot.Action((j, k) => sigmoidDot[j, k] = Sigmoid(sigmoidDot[j, k] + Layers[i].Bias[j, k]));
//                Layers[i + 1].SetNeurons(sigmoidDot);
//            }
//        }
//        /// <summary>
//        /// Метод обратного распространения ошибки по сети.
//        /// </summary>
//        /// <param name="expected">Ожидаемый выход.</param>
//        /// <param name="learningRate">Скорость обучения.</param>
//        /// <returns>Ошибка для текущей итерации.</returns>
//        private double Backpropagation(Matrix expected, double learningRate)
//        {
//            Forward(); // Проходимся вперед
//            // Считаем ошибку для последнего слоя.
//            var errorLast = expected - OutputLayer.Neurons;
//            OutputLayer.SetErrors(errorLast);
//            // Распространяем ошибку по всем слоям.
//            for (int i = Layers.Count - 2; i >= 0; i--)
//            {
//                var inpLayer = Layers[i].Neurons;
//                var outLayer = Layers[i + 1].Neurons;
//                var error = Layers[i + 1].Errors;
//                // Формируем массив выходных нейронов пропущенных через производную.
//                var oneMinusOutput = new Matrix(outLayer);
//                oneMinusOutput.Action((j, k) => oneMinusOutput[j, k] = DerivativeSigmoid(oneMinusOutput[j, k]));

//                // Считаем градиент, на который нам нужно будет сдвинуть веса.
//                var adjust = inpLayer.T * (Matrix.ByElementMul(oneMinusOutput, error) * learningRate);
//                Weights[i] = Weights[i] + adjust; // Сдвигаем веса.
//                Layers[i].AddBias(Matrix.ByElementMul(oneMinusOutput, error) * learningRate); // Сдвигаем добавочные веса.
//            }

//            // Считаем ошибку для текущей итерации.
//            var returnError = 0d;
//            for (int i = 0; i < errorLast.Cols; i++)
//            {
//                returnError += Math.Pow(errorLast[0, i], 2);
//            }
//            return returnError;
//        }
//        /// <summary>
//        /// Запускает тренировку нейронной сети на заданных пользователем данных.
//        /// </summary>
//        /// <param name="epoches">Количество эпох.</param>
//        /// <param name="learningRate">Скорость обучения.</param>
//        /// <param name="eachEpochWeightsSave">Через сколько эпох делать сохранение.</param>
//        public void Train(int epochSize, int epoches, double learningRate, int eachEpochWeightsSave)
//        {
//            Console.WriteLine("==TRAIN STARTED==");
//            for (/*It's ok!*/; Epoch < epoches; Epoch++)
//            {
//                if (TrainStop)
//                    break;
//                var epochError = 0d;

//                //var dPack = GenerateRandomSet(epochSize, 32 * 32, 10);
//                var dPack = GenerateRandomSet(32 * 32, 10);
//                for (int j = 0; j < dPack.Count; j++)
//                {
//                    InputLayer.SetNeurons(dPack[j].Item2);
//                    epochError += Backpropagation(dPack[j].Item1, learningRate);
//                }
//                if ((Epoch + 1) % eachEpochWeightsSave == 0) // Каждые eachEpochWeights эпох сохраняем веса.
//                {
//                    SaveWeightsToFile($"Weights/{NeuroName}.{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}.{Epoch + 1}.{Math.Round((epochError / (OutputLayer.Neurons.Cols * dPack.Count)) * 100, 3)}.weights");
//                }
//                EpochDone?.Invoke(this, new EpochDoneEventArgs(Math.Round((epochError / (OutputLayer.Neurons.Cols * dPack.Count)) * 100, 3), this.Epoch));
//                //Console.WriteLine($"Epoch {i} Error: {Math.Round((epochError / (OutputLayer.Neurons.Cols * inputData.Count)) * 100, 3)}%");
//            }
//            SaveWeightsToFile($"Weights/{NeuroName}.{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}.LAST.weights"); // Сохраняем последние веса.
//            Console.WriteLine("==TRAIN DONE==");
//        }
//        /// <summary>
//        /// Однократный запуск нейронной сети, для получения ответа на входные данные.
//        /// </summary>
//        /// <param name="input">Входные данные.</param>
//        /// <returns>Слой с выходными нейронами сети.</returns>
//        public Layer GetResult(Matrix input)
//        {
//            InputLayer.SetNeurons(input);
//            Forward();
//            return OutputLayer;
//        }
//        /// <summary>
//        /// Получить текущую квадратичную ошибку между выходными нейронами и ождаемым выходом.
//        /// </summary>
//        /// <param name="expected">Ожидаемые выходные данные.</param>
//        /// <returns>Квадратичная ошибка.</returns>
//        public double GetError(Matrix expected)
//        {
//            var result = 0d;
//            var err = expected - OutputLayer.Neurons;
//            for (int i = 0; i < err.Cols; i++)
//            {
//                result += Math.Pow(err[0, i], 2);
//            }
//            return result;
//        }
//        /// <summary>
//        /// Однократный запуск нейронной сети, для получения ответа на входные данные.
//        /// А также получает квадратичную ошибку между выходными нейронами и ожидаемым выходом.
//        /// </summary>
//        /// <param name="input">Входные данные.</param>
//        /// <param name="expected">Ожидаемые выходные данные.</param>
//        /// <returns>Результат и квадратичная ошибка в списке <see cref="List{T}"/>.</returns>
//        public List<object> GetResultWithError(Matrix input, Matrix expected)
//        {
//            var list = new List<object>();
//            list.Add(GetResult(input));
//            list.Add(GetError(expected));

//            return list;
//        }

//        /// <summary>
//        /// Сохраняет веса в файл.
//        /// </summary>
//        /// <param name="path">Путь и нзвание файла весов.
//        /// По умолчанию будет сохранено в папку с исполняемым файлом с именем в виде текущей даты и времени.</param>
//        public void SaveWeightsToFile(string path = null)
//        {
//            if (path == null)
//            {
//                path = $"Weights/{NeuroName}.{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}.weights";
//            }

//            using (FileStream stream = new FileStream(path, FileMode.Create))
//            {
//                var bf = new BinaryFormatter();
//                bf.Serialize(stream, Epoch);
//                for (int i = 0; i < Layers.Count - 1; i++)
//                {
//                    bf.Serialize(stream, Weights[i].GetValuesCopy());
//                    bf.Serialize(stream, Layers[i].Bias.GetValuesCopy());
//                }
//            }
//        }
//        /// <summary>
//        /// Устанавливает веса для <see cref="Weights"/> из файла.
//        /// </summary>
//        /// <param name="fileName">Путь до файла весов.</param>
//        public void LoadWeightsFromFile(string fileName)
//        {
//            Weights.Clear();

//            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
//            {
//                var bf = new BinaryFormatter();
//                Epoch = (long)bf.Deserialize(stream);
//                for (int i = 0; i < Layers.Count - 1; i++)
//                {
//                    var weights = (double[,])bf.Deserialize(stream);
//                    var bias = (double[,])bf.Deserialize(stream);

//                    var rowsW = weights.GetLength(0);
//                    var colsW = weights.GetLength(1);

//                    var rowsB = bias.GetLength(0);
//                    var colsB = bias.GetLength(1);

//                    Weights.Add(new Matrix(rowsW, colsW, weights));
//                    Layers[i].SetBias(new Matrix(rowsB, colsB, bias));
//                }

//            }
//        }
//        public override string ToString()
//        {
//            var result = "====>SYNAPTIC WEIGHTS:\n";
//            foreach (var w in Weights)
//            {
//                result += w.ToString() + "\n";
//            }

//            result += "====>BIAS:\n";
//            for (int i = 0; i < Layers.Count - 1; i++)
//            {
//                result += Layers[i].Bias + "\n";
//            }

//            result += "====>LAYERS:\n";
//            var indx = 0;
//            foreach (var l in Layers)
//            {
//                result += $"Layer [{ (indx++ == 0 ? "INPUT" : (indx == Layers.Count ? "OUTPUT" : indx.ToString())) }]: "
//                    + l.ToString() + "\n";
//            }

//            return result;
//        }
//        /// <summary>
//        /// Сигмоидальная функция активации.
//        /// </summary>
//        /// <param name="x">Число <see cref="double"/></param>
//        /// <returns><see cref="double"/></returns>
//        private double Sigmoid(double x)
//        {
//            return 1 / (1 + Math.Exp(-x));
//        }
//        /// <summary>
//        /// Производная от сигмодиальной функции активации.
//        /// </summary>
//        /// <param name="x">Число <see cref="double"/></param>
//        /// <returns><see cref="double"/></returns>
//        private double DerivativeSigmoid(double x)
//        {
//            return (1 - x) * x;
//        }
//        /// <summary>
//        /// Позволяет получить копию <see cref="List{T}"/> слоёв,
//        /// элементами которого являются экземпляры класса <see cref="Layer"/>.
//        /// </summary>
//        public List<Layer> GetLayers()
//        {
//            return new List<Layer>(Layers);
//        }
//        /// <summary>
//        /// Позволяет получить копию <see cref="List{T}"/> весов,
//        /// элементами которого являются экземпляры класса <see cref="Matrix"/>.
//        /// </summary>
//        public List<Matrix> GetWeights()
//        {
//            return new List<Matrix>(Weights);
//        }
//        /// <summary>
//        /// Позволяет получить копию входного слоя <see cref="Layer"/>.
//        /// </summary>
//        /// <returns>Копия входного слоя <see cref="Layer"/></returns>
//        public Layer GetInputLayer()
//        {
//            return new Layer(InputLayer);
//        }
//        /// <summary>
//        /// Позволяет получить копию выходного слоя <see cref="Layer"/>.
//        /// </summary>
//        /// <returns>Копия выходного слоя <see cref="Layer"/></returns>
//        public Layer GetOutputLayer()
//        {
//            return new Layer(OutputLayer);
//        }
//        /// <summary>
//        /// Возвращает <see cref="List{}"/> слоёв, элементами которого являются экземпляры класса <see cref="Layer"/>.
//        /// </summary>
//        private List<Layer> Layers { get; }
//        /// <summary>
//        /// Возвращает <see cref="List{}"/> весов, элементами которого являются экземпляры класса <see cref="Matrix"/>.
//        /// </summary>
//        private List<Matrix> Weights { get; }
//        /// <summary>
//        /// Возвращает указатель на входной слой <see cref="Layer"/>.
//        /// </summary>
//        private Layer InputLayer => Layers.First();
//        /// <summary>
//        /// Возвращает указатель на выходной слой  <see cref="Layer"/>.
//        /// </summary>
//        private Layer OutputLayer => Layers.Last();

//        public string NeuroName { get; set; }
//        public long Epoch { get; set; }
//        public bool TrainStop = false;
//    }
//}
