
namespace Parser
{
    partial class Form1
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
            this.ListTitles = new System.Windows.Forms.ListBox();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.StartPoint = new System.Windows.Forms.Label();
            this.EndPoint = new System.Windows.Forms.Label();
            this.buttonHabr = new System.Windows.Forms.Button();
            this.buttonFreelansim = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.numericUpDownEnd = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // ListTitles
            // 
            this.ListTitles.FormattingEnabled = true;
            this.ListTitles.Location = new System.Drawing.Point(12, 12);
            this.ListTitles.Name = "ListTitles";
            this.ListTitles.Size = new System.Drawing.Size(600, 537);
            this.ListTitles.TabIndex = 0;
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.Location = new System.Drawing.Point(631, 41);
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStart.TabIndex = 1;
            // 
            // StartPoint
            // 
            this.StartPoint.AutoSize = true;
            this.StartPoint.Location = new System.Drawing.Point(671, 25);
            this.StartPoint.Name = "StartPoint";
            this.StartPoint.Size = new System.Drawing.Size(56, 13);
            this.StartPoint.TabIndex = 2;
            this.StartPoint.Text = "Start Point";
            // 
            // EndPoint
            // 
            this.EndPoint.AutoSize = true;
            this.EndPoint.Location = new System.Drawing.Point(671, 94);
            this.EndPoint.Name = "EndPoint";
            this.EndPoint.Size = new System.Drawing.Size(53, 13);
            this.EndPoint.TabIndex = 3;
            this.EndPoint.Text = "End Point";
            // 
            // buttonHabr
            // 
            this.buttonHabr.Location = new System.Drawing.Point(655, 185);
            this.buttonHabr.Name = "buttonHabr";
            this.buttonHabr.Size = new System.Drawing.Size(75, 23);
            this.buttonHabr.TabIndex = 4;
            this.buttonHabr.Text = "Habr";
            this.buttonHabr.UseVisualStyleBackColor = true;
            // 
            // buttonFreelansim
            // 
            this.buttonFreelansim.Location = new System.Drawing.Point(655, 215);
            this.buttonFreelansim.Name = "buttonFreelansim";
            this.buttonFreelansim.Size = new System.Drawing.Size(75, 23);
            this.buttonFreelansim.TabIndex = 5;
            this.buttonFreelansim.Text = "Freelansim";
            this.buttonFreelansim.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(697, 457);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(697, 487);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Завершить";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // numericUpDownEnd
            // 
            this.numericUpDownEnd.Location = new System.Drawing.Point(631, 110);
            this.numericUpDownEnd.Name = "numericUpDownEnd";
            this.numericUpDownEnd.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownEnd.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.numericUpDownEnd);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonFreelansim);
            this.Controls.Add(this.buttonHabr);
            this.Controls.Add(this.EndPoint);
            this.Controls.Add(this.StartPoint);
            this.Controls.Add(this.numericUpDownStart);
            this.Controls.Add(this.ListTitles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "SuperParser";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListTitles;
        private System.Windows.Forms.NumericUpDown numericUpDownStart;
        private System.Windows.Forms.Label StartPoint;
        private System.Windows.Forms.Label EndPoint;
        private System.Windows.Forms.Button buttonHabr;
        private System.Windows.Forms.Button buttonFreelansim;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.NumericUpDown numericUpDownEnd;
    }
}

