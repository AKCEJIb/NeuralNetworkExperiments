namespace NeuralNetworkExperiments
{ 
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._fileMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this._openMenubtn = new System.Windows.Forms.ToolStripMenuItem();
            this._opnTrainFormMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this._numberPicBox = new System.Windows.Forms.PictureBox();
            this._getResultBtn = new System.Windows.Forms.Button();
            this._errorForChkBox = new System.Windows.Forms.CheckBox();
            this._numOnImg = new System.Windows.Forms.NumericUpDown();
            this._weightsPickMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numberPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numOnImg)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileMenuBtn,
            this._opnTrainFormMenuBtn,
            this._weightsPickMenuBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(328, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _fileMenuBtn
            // 
            this._fileMenuBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openMenubtn});
            this._fileMenuBtn.Name = "_fileMenuBtn";
            this._fileMenuBtn.Size = new System.Drawing.Size(48, 20);
            this._fileMenuBtn.Text = "Файл";
            // 
            // _openMenubtn
            // 
            this._openMenubtn.Name = "_openMenubtn";
            this._openMenubtn.Size = new System.Drawing.Size(180, 22);
            this._openMenubtn.Text = "Открыть";
            this._openMenubtn.Click += new System.EventHandler(this.OpenMenubtn_Click);
            // 
            // _opnTrainFormMenuBtn
            // 
            this._opnTrainFormMenuBtn.Name = "_opnTrainFormMenuBtn";
            this._opnTrainFormMenuBtn.Size = new System.Drawing.Size(74, 20);
            this._opnTrainFormMenuBtn.Text = "Обучение";
            this._opnTrainFormMenuBtn.Click += new System.EventHandler(this.OpnTrainFormMenuBtn_Click);
            // 
            // _numberPicBox
            // 
            this._numberPicBox.Location = new System.Drawing.Point(90, 60);
            this._numberPicBox.Name = "_numberPicBox";
            this._numberPicBox.Size = new System.Drawing.Size(128, 128);
            this._numberPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._numberPicBox.TabIndex = 1;
            this._numberPicBox.TabStop = false;
            // 
            // _getResultBtn
            // 
            this._getResultBtn.Enabled = false;
            this._getResultBtn.Location = new System.Drawing.Point(90, 194);
            this._getResultBtn.Name = "_getResultBtn";
            this._getResultBtn.Size = new System.Drawing.Size(128, 23);
            this._getResultBtn.TabIndex = 2;
            this._getResultBtn.Text = "Распознать";
            this._getResultBtn.UseVisualStyleBackColor = true;
            this._getResultBtn.Click += new System.EventHandler(this.GetResultBtn_Click);
            // 
            // _errorForChkBox
            // 
            this._errorForChkBox.AutoSize = true;
            this._errorForChkBox.Location = new System.Drawing.Point(90, 223);
            this._errorForChkBox.Name = "_errorForChkBox";
            this._errorForChkBox.Size = new System.Drawing.Size(87, 17);
            this._errorForChkBox.TabIndex = 3;
            this._errorForChkBox.Text = "Ошибка для";
            this._errorForChkBox.UseVisualStyleBackColor = true;
            this._errorForChkBox.CheckedChanged += new System.EventHandler(this.ErrorForChkBox_CheckedChanged);
            // 
            // _numOnImg
            // 
            this._numOnImg.Location = new System.Drawing.Point(174, 222);
            this._numOnImg.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._numOnImg.Name = "_numOnImg";
            this._numOnImg.Size = new System.Drawing.Size(44, 20);
            this._numOnImg.TabIndex = 4;
            // 
            // _weightsPickMenuBtn
            // 
            this._weightsPickMenuBtn.Name = "_weightsPickMenuBtn";
            this._weightsPickMenuBtn.Size = new System.Drawing.Size(44, 20);
            this._weightsPickMenuBtn.Text = "Веса";
            this._weightsPickMenuBtn.Click += new System.EventHandler(this.WeightsPickMenuBtn_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 273);
            this.Controls.Add(this._numOnImg);
            this.Controls.Add(this._errorForChkBox);
            this.Controls.Add(this._getResultBtn);
            this.Controls.Add(this._numberPicBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Распознавание цифр";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numberPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numOnImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _fileMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem _openMenubtn;
        private System.Windows.Forms.PictureBox _numberPicBox;
        private System.Windows.Forms.Button _getResultBtn;
        private System.Windows.Forms.CheckBox _errorForChkBox;
        private System.Windows.Forms.NumericUpDown _numOnImg;
        private System.Windows.Forms.ToolStripMenuItem _opnTrainFormMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem _weightsPickMenuBtn;
    }
}