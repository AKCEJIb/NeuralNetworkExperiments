using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace nn.modules
{
    public static class MatrixExtensions
    {
        public static Matrix ReLu(this Matrix mtx)
        {
            var result = new Matrix(mtx.Rows, mtx.Cols);
            result.Action((i, j) => result[i, j] = Math.Max(0, mtx[i, j]));
            return result;
        }

        public static Matrix LeakyReLu(this Matrix mtx)
        {
            var result = new Matrix(mtx.Rows, mtx.Cols);
            result.Action((i, j) => result[i, j] = mtx[i, j] > 0 ? mtx[i, j] : 0.01 * mtx[i, j]);
            return result;
        }

        public static Matrix Sigmoid(this Matrix mtx)
        {
            var result = new Matrix(mtx.Rows, mtx.Cols);
            result.Action((i, j) => result[i, j] = 1 / (1 + Math.Exp(-mtx[i, j])));
            return result;
        }
        public static Matrix DxSigmoid(this Matrix mtx)
        {
            var result = new Matrix(mtx.Rows, mtx.Cols);
            result.Action((i, j) => result[i, j] = (1 - mtx[i, j]) * mtx[i, j]);
            return result;
        }
    }
}
