namespace NeuralNetworkExperiments
{
    partial class TrainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._trainBtn = new System.Windows.Forms.Button();
            this._epochLbl = new System.Windows.Forms.Label();
            this._errorLbl = new System.Windows.Forms.Label();
            this._plot = new NeuralNetworkExperiments.src.UserControls.Plot();
            this._stopBtn = new System.Windows.Forms.Button();
            this._epochSzLbl = new System.Windows.Forms.Label();
            this._neuroNameTxtBx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this._dataSetPick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _trainBtn
            // 
            this._trainBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._trainBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._trainBtn.BackColor = System.Drawing.Color.Maroon;
            this._trainBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._trainBtn.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._trainBtn.Location = new System.Drawing.Point(19, 392);
            this._trainBtn.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this._trainBtn.Name = "_trainBtn";
            this._trainBtn.Size = new System.Drawing.Size(156, 36);
            this._trainBtn.TabIndex = 2;
            this._trainBtn.Text = "НАЧАТЬ";
            this._trainBtn.UseVisualStyleBackColor = false;
            this._trainBtn.Click += new System.EventHandler(this.TrainBtn_Click);
            // 
            // _epochLbl
            // 
            this._epochLbl.AutoSize = true;
            this._epochLbl.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._epochLbl.ForeColor = System.Drawing.Color.Yellow;
            this._epochLbl.Location = new System.Drawing.Point(15, 9);
            this._epochLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._epochLbl.Name = "_epochLbl";
            this._epochLbl.Size = new System.Drawing.Size(106, 24);
            this._epochLbl.TabIndex = 3;
            this._epochLbl.Text = "Epoch: 0";
            // 
            // _errorLbl
            // 
            this._errorLbl.AutoSize = true;
            this._errorLbl.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._errorLbl.ForeColor = System.Drawing.Color.Yellow;
            this._errorLbl.Location = new System.Drawing.Point(15, 33);
            this._errorLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._errorLbl.Name = "_errorLbl";
            this._errorLbl.Size = new System.Drawing.Size(142, 24);
            this._errorLbl.TabIndex = 4;
            this._errorLbl.Text = "Error: NONE";
            // 
            // _plot
            // 
            this._plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._plot.Location = new System.Drawing.Point(19, 59);
            this._plot.MaxEpoches = 0F;
            this._plot.Name = "_plot";
            this._plot.Size = new System.Drawing.Size(744, 326);
            this._plot.TabIndex = 5;
            // 
            // _stopBtn
            // 
            this._stopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._stopBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._stopBtn.BackColor = System.Drawing.Color.Maroon;
            this._stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._stopBtn.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._stopBtn.Location = new System.Drawing.Point(187, 392);
            this._stopBtn.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this._stopBtn.Name = "_stopBtn";
            this._stopBtn.Size = new System.Drawing.Size(156, 36);
            this._stopBtn.TabIndex = 2;
            this._stopBtn.Text = "ОСТАНОВИТЬ";
            this._stopBtn.UseVisualStyleBackColor = false;
            this._stopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // _epochSzLbl
            // 
            this._epochSzLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._epochSzLbl.AutoSize = true;
            this._epochSzLbl.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._epochSzLbl.ForeColor = System.Drawing.Color.Yellow;
            this._epochSzLbl.Location = new System.Drawing.Point(585, 9);
            this._epochSzLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._epochSzLbl.Name = "_epochSzLbl";
            this._epochSzLbl.Size = new System.Drawing.Size(166, 24);
            this._epochSzLbl.TabIndex = 3;
            this._epochSzLbl.Text = "Epoch size: 0";
            this._epochSzLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _neuroNameTxtBx
            // 
            this._neuroNameTxtBx.Location = new System.Drawing.Point(352, 396);
            this._neuroNameTxtBx.Name = "_neuroNameTxtBx";
            this._neuroNameTxtBx.Size = new System.Drawing.Size(117, 32);
            this._neuroNameTxtBx.TabIndex = 6;
            this._neuroNameTxtBx.Text = "NeuroName";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(478, 392);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "ВЕСА";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.LoadWeights);
            // 
            // _dataSetPick
            // 
            this._dataSetPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._dataSetPick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._dataSetPick.BackColor = System.Drawing.Color.Maroon;
            this._dataSetPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._dataSetPick.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dataSetPick.Location = new System.Drawing.Point(624, 392);
            this._dataSetPick.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this._dataSetPick.Name = "_dataSetPick";
            this._dataSetPick.Size = new System.Drawing.Size(134, 36);
            this._dataSetPick.TabIndex = 2;
            this._dataSetPick.Text = "ВЫБОРКА";
            this._dataSetPick.UseVisualStyleBackColor = false;
            this._dataSetPick.Click += new System.EventHandler(this.DataSetPick_Click);
            // 
            // TrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(775, 441);
            this.Controls.Add(this._neuroNameTxtBx);
            this.Controls.Add(this._plot);
            this.Controls.Add(this._errorLbl);
            this.Controls.Add(this._epochSzLbl);
            this.Controls.Add(this._epochLbl);
            this.Controls.Add(this._dataSetPick);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._stopBtn);
            this.Controls.Add(this._trainBtn);
            this.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Yellow;
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "TrainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обучение";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _trainBtn;
        private System.Windows.Forms.Label _epochLbl;
        private System.Windows.Forms.Label _errorLbl;
        private src.UserControls.Plot _plot;
        private System.Windows.Forms.Button _stopBtn;
        private System.Windows.Forms.Label _epochSzLbl;
        private System.Windows.Forms.TextBox _neuroNameTxtBx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button _dataSetPick;
    }
}

