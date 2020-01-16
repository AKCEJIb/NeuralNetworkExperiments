using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroModule.MatrixClass
{
    /// <summary>
    /// Вспомогательный класс для нейронных сетей.
    /// Хранит и обрабатывает данные над двумерными массивами.
    /// </summary>
    public class Matrix
    {

        #region .Ctor
        /// <summary>
        /// Создаёт <see cref="Matrix"/> размером 2 * 2.
        /// </summary>
        public Matrix()
        {
            this._rows = 2;
            this._cols = 2;
            this._data = new double[_rows, _cols];
            // Fill Zeroes
            this.Action((i, j) => this._data[i, j] = 0);
        }
        /// <summary>
        /// Копирующий конструктор.
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix(Matrix matrix)
        {
            this._rows = matrix.Rows;
            this._cols = matrix.Cols;
            this._data = new double[_rows, _cols];
            // Fill Zeroes
            this.Action((i, j) => this._data[i, j] = matrix[i, j]);
        }
        /// <summary>
        /// Создаёт <see cref="Matrix"/> размером rows * cols.
        /// </summary>
        /// <param name="rows">Количество строк.</param>
        /// <param name="cols">Количество столбцов.</param>
        public Matrix(int rows, int cols)
        {
            this._rows = rows;
            this._cols = cols;
            this._data = new double[_rows, _cols];
            // Fill Zeroes
            this.Action((i, j) => this._data[i, j] = 0);
        }
        /// <summary>
        /// Создаёт <see cref="Matrix"/> размером rows * cols и заполняет value.
        /// </summary>
        /// <param name="rows">Количество строк.</param>
        /// <param name="cols">Количество столбцов.</param>
        /// <param name="value">Заполнитель.</param>
        public Matrix(int rows, int cols, double value)
        {
            this._rows = rows;
            this._cols = cols;
            this._data = new double[_rows, _cols];
            // Fill Values
            this.Action((i, j) => this._data[i, j] = value);
        }
        /// <summary>
        /// Создание <see cref="Matrix"/> вручную с помощью инициализации обычным <see cref="Array"/>.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="data"></param>
        public Matrix(int rows, int cols, double[,] data)
        {
            this._rows = rows;
            this._cols = cols;
            this._data = new double[_rows, _cols];
            // Fill Values
            this.Action((i, j) => this._data[i, j] = data[i, j]);
        }

        #endregion

        #region Public Methods
        public double Max()
        {
            return _data.Cast<double>().Max();
        }

        public static Tuple<int, int> IndexOf<T>(Matrix matr, T value)
        {
            var matrix = matr._data;
            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }

        public double[,] GetValuesCopy()
        {
            var result = new double[this.Rows, this.Cols];
            Array.Copy(this._data, result, result.Length);
            return result;
        }
        /// <summary>
        /// Метод действий над <see cref="Matrix"/>.
        /// </summary>
        /// <param name="function">Функция, которая будет работать с матрицей.</param>
        public void Action(Action<int, int> function)
        {
            for(int i = 0; i < this.Rows; i++)
            {
                for(int j = 0; j < this.Cols; j++)
                {
                    function(i, j);
                }
            }
        }
        /// <summary>
        /// Перегруженный метод, для вывода массива на консоль.
        /// </summary>
        public override string ToString()
        {
            string result = $"Matrix({this.Rows}, {this.Cols})" + "{\n";
            for (int i = 0; i < this.Rows; i++)
            {
                result += "[";
                for (int j = 0; j < this.Cols; j++)
                {
                    result += $"{this[i, j]}" + (j < this.Cols - 1 ? ", " : "");
                }
                result += "]" + (i < this.Rows - 1 ? ",\n" : "\n");
            }
            return result + "}";
        }
        /// <summary>
        /// Создаёт единичную матрицу n * n.
        /// </summary>
        /// <param name="n">Размер матрицы.</param>
        /// <returns>Результирующая матрица <see cref="Matrix"/></returns>
        public static Matrix CreateIndentity(int n)
        {
            var mat = new Matrix(n, n);
            for (int i = 0; i < n; i++)
                mat[i, i] = 1;

            return mat;
        }
        /// <summary>
        /// Создаёт <see cref="Matrix"/> размером rows * cols заполненный случайными значениями [0..1].
        /// </summary>
        /// <param name="rows">Количество строк.</param>
        /// <param name="cols">Количество столбцов.</param>
        /// <returns>Результирующая матрица <see cref="Matrix"/></returns>
        public static Matrix CreateRandom(int rows, int cols)
        {
            var result = new Matrix(rows, cols);
            result.Action((i, j) => result[i, j] = _rand.NextDouble());

            return result;
        }
        /// <summary>
        /// Транспонирует текущую матрицу.
        /// </summary>
        /// <returns>Транспонрованная матрица mT.</returns>
        public Matrix Transpose()
        {
            var result = new Matrix(this.Cols, this.Rows);
            result.Action((i, j) => result[i, j] = this[j, i]);
            return result;
        }
        public static Matrix ByElementMul(Matrix matrix, Matrix matrix2)
        {
            if (matrix.Rows != matrix2.Rows || matrix.Cols != matrix2.Cols)
            {
                throw new ArgumentException("matrixes dimensions should be equal");
            }
            var result = new Matrix(matrix.Rows, matrix.Cols);
            result.Action((i, j) =>
                result[i, j] = matrix[i, j] * matrix2[i, j]);
            return result;
        }
        #region Operators
        /// <summary>
        /// Индексатор.
        /// </summary>
        /// <param name="row">Строка.</param>
        /// <param name="col">Столбец.</param>
        /// <returns>Значение <see cref="Matrix"/> в ячейке [<paramref name="row"/>, <paramref name="col"/>]</returns>
        public double this[int row, int col]
        {
            get
            {
                return this._data[row, col];
            }
            set
            {
                this._data[row, col] = value;
            }
        }
        /// <summary>
        /// Умножение на число.
        /// </summary>
        /// <param name="matrix">Исходная матрица <see cref="Matrix"/></param>
        /// <param name="value">Значение на которое умножаем.</param>
        /// <returns>Результирующая матрица <see cref="Matrix"/></returns>
        public static Matrix operator *(Matrix matrix, double value)
        {
            var result = new Matrix(matrix.Rows, matrix.Cols);
            result.Action((i, j) =>
                result[i, j] = matrix[i, j] * value);
            return result;
        }
        /// <summary>
        /// Умножение матриц.
        /// </summary>
        /// <param name="matrix">Исходная матрица <see cref="Matrix"/></param>
        /// <param name="matrix2">Вторая матрица <see cref="Matrix"/></param>
        /// <returns>Результирующая матрица <see cref="Matrix"/></returns>
        public static Matrix operator *(Matrix matrix, Matrix matrix2)
        {
            if (matrix.Cols != matrix2.Rows)
            {
                throw new ArgumentException($"Количество столбцов первой матрицы {matrix} не совпадает с количеством строк второй матрицы {matrix2}.");
            }
            var result = new Matrix(matrix.Rows, matrix2.Cols);
            result.Action((i, j) => {
                for (var k = 0; k < matrix.Cols; k++)
                {
                    result[i, j] += matrix[i, k] * matrix2[k, j];
                }
            });
            return result;
        }
        /// <summary>
        /// Сложение матрицы с числом.
        /// </summary>
        /// <param name="matrix">Исходная матрица <see cref="Matrix"/></param>
        /// <param name="value">Значение на которое умножаем.</param>
        /// <returns>Результирующая матрица <see cref="Matrix"/></returns>
        public static Matrix operator +(Matrix matrix, double value)
        {
            var result = new Matrix(matrix.Rows, matrix.Cols);
            result.Action((i, j) =>
                result[i, j] = matrix[i, j] + value);
            return result;
        }
        /// <summary>
        /// Сложение матриц.
        /// </summary>
        /// <param name="matrix">Исходная матрица <see cref="Matrix"/></param>
        /// <param name="matrix2">Вторая матрица <see cref="Matrix"/></param>
        /// <returns>Результирующая матрица <see cref="Matrix"/></returns>
        public static Matrix operator +(Matrix matrix, Matrix matrix2)
        {
            if (matrix.Rows != matrix2.Rows || matrix.Cols != matrix2.Cols)
            {
                throw new ArgumentException("matrixes dimensions should be equal");
            }
            var result = new Matrix(matrix.Rows, matrix.Cols);
            result.Action((i, j) => result[i, j] = matrix[i, j] + matrix2[i, j]);
            return result;
        }
        /// <summary>
        /// Вычитание матриц.
        /// </summary>
        /// <param name="matrix">Исходная матрица <see cref="Matrix"/></param>
        /// <param name="matrix2">Вторая матрица <see cref="Matrix"/></param>
        /// <returns>Результирующая матрица <see cref="Matrix"/></returns>
        public static Matrix operator -(Matrix matrix, Matrix matrix2)
        {
            return matrix + (matrix2 * -1);
        }
        /// <summary>
        /// Вычитание числа из матрицы.
        /// </summary>
        /// <param name="matrix">Исходная матрица <see cref="Matrix"/></param>
        /// <param name="matrix2">Вторая матрица <see cref="Matrix"/></param>
        /// <returns>Результирующая матрица <see cref="Matrix"/></returns>
        public static Matrix operator -(Matrix matrix, double value)
        {
            return matrix + -value;
        }
        #endregion


        #endregion

        #region Public Feilds And Properties
        /// <summary>
        /// Возвращает количество строк.
        /// </summary>
        public int Rows { get => this._rows; }
        /// <summary>
        /// Возвращает количество столбцов.
        /// </summary>
        public int Cols { get => this._cols; }
        /// <summary>
        /// Возвращает транспонированную матрицу.
        /// </summary>
        public Matrix T { get => this.Transpose(); }
        #endregion

        #region Private Methods

        #endregion

        #region Private Feilds And Properties

        /// <summary>
        /// Хранит информацию матрицы.
        /// </summary>
        private double[,] _data;

        /// <summary>
        /// Количество строк матрицы.
        /// </summary>
        private int _rows;
        /// <summary>
        /// Количество столбцов матрицы.
        /// </summary>
        private int _cols;

        private static Random _rand = new Random();
        #endregion
    }

    
}
