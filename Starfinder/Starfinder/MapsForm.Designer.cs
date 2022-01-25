
namespace Starfinder
{
    partial class MapsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapsForm));
            this.buttonLoadEarsMap = new System.Windows.Forms.Button();
            this.button_enemies = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button_heroes = new System.Windows.Forms.Button();
            this.buttonClearE = new System.Windows.Forms.Button();
            this.buttonClearH = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoadEarsMap
            // 
            this.buttonLoadEarsMap.Location = new System.Drawing.Point(3, 3);
            this.buttonLoadEarsMap.Name = "buttonLoadEarsMap";
            this.buttonLoadEarsMap.Size = new System.Drawing.Size(75, 22);
            this.buttonLoadEarsMap.TabIndex = 1;
            this.buttonLoadEarsMap.Text = "Карта Земля";
            this.buttonLoadEarsMap.UseVisualStyleBackColor = true;
            this.buttonLoadEarsMap.Click += new System.EventHandler(this.buttonLoadEarsMap_Click);
            // 
            // button_enemies
            // 
            this.button_enemies.Location = new System.Drawing.Point(12, 115);
            this.button_enemies.Name = "button_enemies";
            this.button_enemies.Size = new System.Drawing.Size(56, 23);
            this.button_enemies.TabIndex = 2;
            this.button_enemies.Text = "Enemies";
            this.button_enemies.UseVisualStyleBackColor = true;
            this.button_enemies.Click += new System.EventHandler(this.EnemiesCreate_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(74, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Фон(черный).png");
            this.imageList1.Images.SetKeyName(1, "Фон(серый).png");
            // 
            // button_heroes
            // 
            this.button_heroes.Location = new System.Drawing.Point(12, 62);
            this.button_heroes.Name = "button_heroes";
            this.button_heroes.Size = new System.Drawing.Size(56, 23);
            this.button_heroes.TabIndex = 2;
            this.button_heroes.Text = "Heroes";
            this.button_heroes.UseVisualStyleBackColor = true;
            this.button_heroes.Click += new System.EventHandler(this.HeroesCreate_Click);
            // 
            // buttonClearE
            // 
            this.buttonClearE.Location = new System.Drawing.Point(12, 135);
            this.buttonClearE.Name = "buttonClearE";
            this.buttonClearE.Size = new System.Drawing.Size(56, 23);
            this.buttonClearE.TabIndex = 4;
            this.buttonClearE.Text = "Clear";
            this.buttonClearE.UseVisualStyleBackColor = true;
            this.buttonClearE.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonClearH
            // 
            this.buttonClearH.Location = new System.Drawing.Point(12, 81);
            this.buttonClearH.Name = "buttonClearH";
            this.buttonClearH.Size = new System.Drawing.Size(56, 23);
            this.buttonClearH.TabIndex = 5;
            this.buttonClearH.Text = "Clear";
            this.buttonClearH.UseVisualStyleBackColor = true;
            this.buttonClearH.Click += new System.EventHandler(this.buttonClearH_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonLoadEarsMap, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 56);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // MapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonClearH);
            this.Controls.Add(this.buttonClearE);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_heroes);
            this.Controls.Add(this.button_enemies);
            this.Name = "MapsForm";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapsForm_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLoadEarsMap;
        public System.Windows.Forms.Button button_enemies;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Button button_heroes;
        private System.Windows.Forms.Button buttonClearE;
        private System.Windows.Forms.Button buttonClearH;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}