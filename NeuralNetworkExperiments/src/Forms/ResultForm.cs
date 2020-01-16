using NeuralNetworkExperiments.ImageHelper;
using NeuroModule.MatrixClass;
using NeuroModule.Neuro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkExperiments
{
    public partial class ResultForm : Form
    {
        private NeuralNetwork nn;
        private Matrix inputLayer;
        public ResultForm()
        {
            InitializeComponent();

            // Нейронная сеть 1024 входных нейрона, 200 скрытых нейронов, 10 выходных нейронов
            nn = new NeuralNetwork(32 * 32, new int[] { 200 } , 10, "Weights/CourseWorkNumbers.11-01-2020_23-44-36.LAST.weights");
            //nn = new NeuralNetwork(32 * 32, new int[] { 300 } , 10, "Weights/CourseWorkNumbers300HU_2.12-01-2020_21-18-29.LAST.weights");
        }

        private void OpenMenubtn_Click(object sender, EventArgs e)
        {
            using(var fd = new OpenFileDialog())
            {
                //fd.InitialDirectory = Application.StartupPath;
                fd.Filter = "Image files (*.bmp)|*.bmp|All files (*.*)|*.*";
                fd.FilterIndex = 1;
                fd.RestoreDirectory = true;

                if(fd.ShowDialog() == DialogResult.OK)
                {
                    var image = Image.FromFile(fd.FileName);

                    _numberPicBox.Image = image;

                   inputLayer = new Matrix(1, 32 * 32, ImgBinaryConverter.ConvertTo1D(fd.FileName));

                    _getResultBtn.Enabled = true;
                
                }
            }
        }

        private void GetResultBtn_Click(object sender, EventArgs e)
        {
            var sw = Stopwatch.StartNew();

            var expected = new Matrix(1, 10);
            expected[0, (int)_numOnImg.Value] = 1;
            sw.Restart();
            var result = nn.GetResultWithError(inputLayer, expected);
            var elapsedTime = sw.ElapsedMilliseconds;
            sw.Stop();
            var output = ((Layer)result[0]).Neurons;
            var error = (double)result[1];
            var max = output.Max();
            var maxid = Matrix.IndexOf(output, max);
            var q = $"Max is: {max}\n";
            q += $"This Id: {maxid.Item2}";
            Console.WriteLine(output);
            Console.WriteLine(q);

            var q2 = "";
            for(int i = 0; i < 10; i++)
            {
                q2 += $"{i} - {Math.Round(output[0, i] * 100, 3)}%\n";
            }
            q2 += $"На распознавание затрачено: {elapsedTime} мс\n";
            if (_errorForChkBox.Checked)
            {
                q2 += $"СКО составляет: {Math.Round(error, 3)} ";
            }
            MessageBox.Show($"На изображении цифра с вероятностью:\n{q2}\nВероятно это цифра: {maxid.Item2}", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ErrorForChkBox_CheckedChanged(object sender, EventArgs e)
        {
            _numberPicBox.Enabled = _errorForChkBox.Checked;
        }

        private void OpnTrainFormMenuBtn_Click(object sender, EventArgs e)
        {
            using(var trainForm = new TrainForm())
            {
                trainForm.ShowDialog();
            }
        }

        private void WeightsPickMenuBtn_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog())
            {
                fd.Filter = "Weights files (*.weights)|*.bmp|All files (*.*)|*.*";
                fd.FilterIndex = 1;
                fd.RestoreDirectory = true;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    nn.LoadWeightsFromFile(fd.FileName);
                }
            }
        }
    }
}
