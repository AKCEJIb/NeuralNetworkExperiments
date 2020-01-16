using NeuralNetworkExperiments.ImageHelper;
using NeuroModule.Neuro;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkExperiments
{
    public partial class TrainForm : Form
    {
        PrivateFontCollection font = new PrivateFontCollection();
        Font newFont;
        private readonly Random _rand = new Random();
        private NeuralNetwork nn;
        private int _dataPackSize;
        public string NeuroName = "";
        public TrainForm()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            this.AutoScaleMode = AutoScaleMode.Font;
            InitializeComponent();
            font.AddFontFile("Fonts/pixelfonta.ttf");
            newFont = new Font(font.Families[0], 16);

            nn = new NeuralNetwork(32 * 32, new int[] { 200 }, 10);
            nn.NeuroName = @"";
            nn.EpochDone += Nn_EpochDone;
        }

        private void Nn_EpochDone(object sender, EpochDoneEventArgs e)
        {
            if (_epochLbl.InvokeRequired)
            {
                _epochLbl.Invoke(new Action(() => _epochLbl.Text = $"Epoch: {e.Epoch}"));
                _errorLbl.Invoke(new Action(() => _errorLbl.Text = $"Error: {e.Error}%"));
                _plot.Invoke(new Action(() => _plot.AddPoint(e)));
            }
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            foreach (Control theControl in (SpecialMethods.GetAllControls(this)))
            {
                theControl.Font = newFont;
            }
        }

        private void TrainBtn_Click(object sender, EventArgs e)
        {
            if (_dataPackSize == 0)
            {
                MessageBox.Show("Выберите обучающую выборку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nn.NeuroName = _neuroNameTxtBx.Text;
            if (Directory.GetFiles("Weights/").Any(x => x.Contains(_neuroNameTxtBx.Text)))
            {
                if(MessageBox.Show("Веса с таким названием уже существуют, перезаписать?", "Дубликат весов", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            var maxEpoches = 200;
            var epochSize = _dataPackSize;
            _epochSzLbl.Text = $"Epoch size: {epochSize}";
            _plot.MaxEpoches = maxEpoches;
            _plot.StartRefresh();
            nn.TrainStop = false;
            Task.Factory.StartNew(() => nn.Train(epochSize, maxEpoches, 0.05, 10));
            this.Text = $"Обучение {nn.NeuroName}. Идёт...";
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_dataPackSize != 0)
            {
                nn.SaveWeightsToFile($"Weights/{nn.NeuroName}.{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}.CLOSED WINDOW.weights");
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            nn.TrainStop = true;
            this.Text = $"Обучение не запущено";
        }

        private void LoadWeights(object sender, EventArgs e)
        {
            if (!nn.TrainStop)
            {
                using (var fd = new OpenFileDialog())
                {
                    fd.Filter = "Weights files (*.weights)|*.weights|All files (*.*)|*.*";
                    fd.FilterIndex = 1;
                    fd.RestoreDirectory = true;

                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        nn.LoadWeightsFromFile(fd.FileName);
                    }
                }
            }
        }

        private void DataSetPick_Click(object sender, EventArgs e)
        {
            using (var fd = new FolderBrowserDialog())
            {
                fd.ShowNewFolderButton = false;
                fd.Description = "Выберите папку в которой есть обучающая выборка";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var dataPack = ImgBinaryConverter.UnpackDataFiles(fd.SelectedPath);
                        _dataPackSize = dataPack.Count;
                        nn.SetDataPack(dataPack);
                        if (_dataPackSize != 0)
                        {
                            MessageBox.Show($"Обучающая выборка загружена\nФайлов: {_dataPackSize}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Не найдено не одного файла для обучающей выборки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось загрузить выборку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
