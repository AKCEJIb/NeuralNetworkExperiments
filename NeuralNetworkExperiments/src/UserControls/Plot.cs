using NeuroModule.Neuro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NeuralNetworkExperiments.src.UserControls
{
    public partial class Plot : UserControl
    {
        private List<EpochDoneEventArgs> points;
        public float MaxEpoches { get; set; }

        private float plotHeight;
        private float plotWidth;
        private Timer updateTimer;
        public Plot()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            points = new List<EpochDoneEventArgs>();
            
            updateTimer = new Timer();
            updateTimer.Interval = 10;
            updateTimer.Tick += UpdateTimer_Tick;

            plotWidth = this.Width - 100;
            plotHeight = this.Height - 100; 
        }

        public void StartRefresh()
        {
            Invalidate();
            updateTimer.Start();
            this.Paint += Plot_Paint;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        public void AddPoint(EpochDoneEventArgs point)
        {
            points.Add(point);
        }

        public void ClearPoints()
        {
            points.Clear();
        }

        private void Plot_Paint(object sender, PaintEventArgs e)
        {
            plotWidth = this.Width - 100;
            plotHeight = this.Height - 100;

            // Рисуем сетку и легенду

            e.Graphics.DrawString("Epoch", new Font("Arial", 8, FontStyle.Bold), Brushes.DarkOrange, this.Width / 2f, 10, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("Error", new Font("Arial", 8, FontStyle.Bold), Brushes.DarkOrange, - this.Height / 2f, 10 , new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
            e.Graphics.ResetTransform();
            for (int x = 0; x <= MaxEpoches; x += ((int) MaxEpoches / 10))
            {
                e.Graphics.DrawString($"{String.Format("{0:0.00}", x / 1000f)}k", new Font("Arial", 8, FontStyle.Bold), Brushes.DarkOrange, 50 + x * (plotWidth / MaxEpoches), 40, new StringFormat { LineAlignment = StringAlignment.Far, Alignment = StringAlignment.Center });
                e.Graphics.DrawString($"{String.Format("{0:0.00}", x / 1000f)}k", new Font("Arial", 8, FontStyle.Bold), Brushes.DarkOrange, 50 + x * (plotWidth / MaxEpoches), plotHeight + 60, new StringFormat { LineAlignment = StringAlignment.Near, Alignment = StringAlignment.Center });
            }
            for (int y = 0; y <= 100; y += 10)
            {
                e.Graphics.DrawLine(Pens.Gray, 50, 50 + y * (plotHeight / 100f), 50 + plotWidth, 50 + y * (plotHeight / 100f));
                e.Graphics.DrawString($"{100-y}%", new Font("Arial", 8, FontStyle.Bold), Brushes.DarkOrange, 40, 50 + y * (plotHeight / 100f), new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Far});
                e.Graphics.DrawString($"{100 - y}%", new Font("Arial", 8, FontStyle.Bold), Brushes.DarkOrange, plotWidth + 60, 50 + y * (plotHeight / 100f), new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                for (int x = 0; x <= MaxEpoches; x += (int)MaxEpoches / 10)
                {
                    e.Graphics.DrawLine(Pens.Gray, 50 + x * (plotWidth / MaxEpoches), 50, 50 + x * (plotWidth / MaxEpoches) , 50 + plotHeight);
                }
            }
            // Рисуем точки
            foreach (var point in points)
            {
                e.Graphics.FillRectangle(Brushes.Red, 50 + point.Epoch * (plotWidth / MaxEpoches), 50 + (100 - (float)point.Error) * (plotHeight / 100f), 2, 2);
            }
        }
    }
}
