namespace KryptoSystem
{
	partial class Signature
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
			this.button1 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.Location = new System.Drawing.Point(36, 300);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Создать подпись";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.сreateSignature_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(287, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(36, 29);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 62);
			this.button2.TabIndex = 2;
			this.button2.Text = "Сгенерировать новую пару ключей";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.buttonGenerateNewKeys_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(88, 97);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(104, 44);
			this.button3.TabIndex = 3;
			this.button3.Text = "Экспортировать открытый ключ";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.buttonExportPublicKey_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(146, 29);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(104, 62);
			this.button4.TabIndex = 4;
			this.button4.Text = "Востановить пару по открытому ключу";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.buttonRecoverKeys_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(457, 300);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 23);
			this.button5.TabIndex = 5;
			this.button5.Text = "Проверить ";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.buttonVerificationsSig_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(457, 79);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 39);
			this.button6.TabIndex = 6;
			this.button6.Text = "Загрузить Сообщение";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.buttonDownloadMessage_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(457, 123);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(104, 40);
			this.button7.TabIndex = 7;
			this.button7.Text = "Загрузить подпись";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.buttonDownloadSig_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(457, 29);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(104, 44);
			this.button8.TabIndex = 8;
			this.button8.Text = "Импортировать открытый ключ";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.buttonImportPublicKey_Click);
			// 
			// Signature
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "Signature";
			this.Text = "Signature";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
	}
}