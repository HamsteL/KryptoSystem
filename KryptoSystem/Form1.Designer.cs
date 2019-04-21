namespace KryptoSystem
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
            this.encDecBtn = new System.Windows.Forms.Button();
            this.sigBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // encDecBtn
            // 
            this.encDecBtn.Location = new System.Drawing.Point(12, 12);
            this.encDecBtn.Name = "encDecBtn";
            this.encDecBtn.Size = new System.Drawing.Size(246, 46);
            this.encDecBtn.TabIndex = 0;
            this.encDecBtn.Text = "Encode/Decode";
            this.encDecBtn.UseVisualStyleBackColor = true;
            this.encDecBtn.Click += new System.EventHandler(this.encDecBtn_Click);
            // 
            // sigBtn
            // 
            this.sigBtn.Location = new System.Drawing.Point(12, 83);
            this.sigBtn.Name = "sigBtn";
            this.sigBtn.Size = new System.Drawing.Size(246, 46);
            this.sigBtn.TabIndex = 1;
            this.sigBtn.Text = "Signature";
            this.sigBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 157);
            this.Controls.Add(this.sigBtn);
            this.Controls.Add(this.encDecBtn);
            this.Name = "Form1";
            this.Text = "System";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button encDecBtn;
        private System.Windows.Forms.Button sigBtn;
    }
}

