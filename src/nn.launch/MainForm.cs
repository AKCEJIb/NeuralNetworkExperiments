using nn.modules;
using nn.modules.Layers;
using nn.modules.LearningErrors;
using nn.modules.Networks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nn
{
    public partial class MainForm : Form
    {
        private delegate Matrix Gradient<in T1, in T2>(T1 arg1, T2 arg2);
        public MainForm()
        {
            InitializeComponent();

            Matrix.SetRandomSeed(1488);

            var ln = new LinearNetwork();

            var ans = ln.Forward(new Matrix(32 * 32, 1, 0.5d));


            var loss = new MSE();

            var val1 = new double[,] {
                {1, 1, 1}
            };

            var val2 = new double[,] {
                {0, 1, 0}
            };

            var m1 = new Matrix(1, 3, val1);
            var m2 = new Matrix(1, 3, val2);

            Console.WriteLine(loss.Forward(m1, m2));


            //CalculateGradient(loss.Forward, ans, new Matrix(10, 1, 0.2));

        }

        private Matrix CalculateGradient(Gradient<Matrix, Matrix> func, Matrix answer, Matrix expected)
        {
            var ans = func?.Invoke(answer, expected);

            throw new NotImplementedException();
        }
    }
}
