namespace itog
{
    partial class Form3
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Items.AddRange(new object[] {
            "Белые шашки ходят на одну клетку по диагонали вперед.",
            "Черные шашки ходят на одну клетку по диагонали вперед.",
            "Выигрывает тот, кто срубит все шашки противника.",
            "Дойдя до конца, шашка становится дамкой.",
            "Дамка может ходить по диагонали на одну клетку вперед вперед ",
            "и по диагонали на одну клетку назад."});
            this.listBox1.Location = new System.Drawing.Point(96, 141);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(629, 204);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(314, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Правила";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}