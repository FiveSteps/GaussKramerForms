
namespace GaussKramerProjectForms
{
    partial class Form1
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
            this.gaussBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.kramerBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gaussBtn
            // 
            this.gaussBtn.Location = new System.Drawing.Point(378, 27);
            this.gaussBtn.Name = "gaussBtn";
            this.gaussBtn.Size = new System.Drawing.Size(83, 35);
            this.gaussBtn.TabIndex = 0;
            this.gaussBtn.Text = "Метод Гаусса";
            this.gaussBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.gaussBtn.UseVisualStyleBackColor = true;
            this.gaussBtn.Click += new System.EventHandler(this.gaussBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Гаусс и Крамер";
            // 
            // kramerBtn
            // 
            this.kramerBtn.Location = new System.Drawing.Point(378, 90);
            this.kramerBtn.Name = "kramerBtn";
            this.kramerBtn.Size = new System.Drawing.Size(83, 35);
            this.kramerBtn.TabIndex = 4;
            this.kramerBtn.Text = "Метод Крамера";
            this.kramerBtn.UseVisualStyleBackColor = true;
            this.kramerBtn.Click += new System.EventHandler(this.kramerBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(378, 244);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(83, 35);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "Выход";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(482, 292);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.kramerBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gaussBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gaussBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kramerBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}

