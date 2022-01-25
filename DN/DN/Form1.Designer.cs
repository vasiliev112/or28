
namespace DN
{
    partial class DN
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pole1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pole2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pole3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pole4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.file2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(487, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(344, 17);
            this.listBox1.TabIndex = 1;
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(12, 52);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(344, 95);
            this.listBox2.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.file2ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pole1ToolStripMenuItem,
            this.pole2ToolStripMenuItem,
            this.pole3ToolStripMenuItem,
            this.pole4ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // pole1ToolStripMenuItem
            // 
            this.pole1ToolStripMenuItem.Name = "pole1ToolStripMenuItem";
            this.pole1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pole1ToolStripMenuItem.Text = "Pole1";
            this.pole1ToolStripMenuItem.Click += new System.EventHandler(this.pole1ToolStripMenuItem_Click);
            // 
            // pole2ToolStripMenuItem
            // 
            this.pole2ToolStripMenuItem.Name = "pole2ToolStripMenuItem";
            this.pole2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pole2ToolStripMenuItem.Text = "Pole2";
            // 
            // pole3ToolStripMenuItem
            // 
            this.pole3ToolStripMenuItem.Name = "pole3ToolStripMenuItem";
            this.pole3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pole3ToolStripMenuItem.Text = "Pole3";
            // 
            // pole4ToolStripMenuItem
            // 
            this.pole4ToolStripMenuItem.Name = "pole4ToolStripMenuItem";
            this.pole4ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pole4ToolStripMenuItem.Text = "Pole4";
            // 
            // file2ToolStripMenuItem
            // 
            this.file2ToolStripMenuItem.Name = "file2ToolStripMenuItem";
            this.file2ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.file2ToolStripMenuItem.Text = "File2";
            // 
            // DN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 441);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DN";
            this.Text = "DN";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pole1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pole2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pole3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pole4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem file2ToolStripMenuItem;
    }
}

