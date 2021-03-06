﻿namespace KryptoSystem
{
    partial class EncDecForm
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
			this.buttonEncryptFile = new System.Windows.Forms.Button();
			this.buttonDecryptFile = new System.Windows.Forms.Button();
			this.buttonCreateAsmKeys = new System.Windows.Forms.Button();
			this.buttonExportPublicKey = new System.Windows.Forms.Button();
			this.buttonImportPublicKey = new System.Windows.Forms.Button();
			this.buttonGetPrivateKey = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// buttonEncryptFile
			// 
			this.buttonEncryptFile.Location = new System.Drawing.Point(21, 382);
			this.buttonEncryptFile.Name = "buttonEncryptFile";
			this.buttonEncryptFile.Size = new System.Drawing.Size(124, 40);
			this.buttonEncryptFile.TabIndex = 0;
			this.buttonEncryptFile.Text = "Шифрование файла";
			this.buttonEncryptFile.UseVisualStyleBackColor = true;
			this.buttonEncryptFile.Click += new System.EventHandler(this.buttonEncryptFile_Click);
			// 
			// buttonDecryptFile
			// 
			this.buttonDecryptFile.Location = new System.Drawing.Point(655, 382);
			this.buttonDecryptFile.Name = "buttonDecryptFile";
			this.buttonDecryptFile.Size = new System.Drawing.Size(124, 40);
			this.buttonDecryptFile.TabIndex = 1;
			this.buttonDecryptFile.Text = "Расшифровка файла";
			this.buttonDecryptFile.UseVisualStyleBackColor = true;
			this.buttonDecryptFile.Click += new System.EventHandler(this.buttonDecryptFile_Click);
			// 
			// buttonCreateAsmKeys
			// 
			this.buttonCreateAsmKeys.Location = new System.Drawing.Point(184, 382);
			this.buttonCreateAsmKeys.Name = "buttonCreateAsmKeys";
			this.buttonCreateAsmKeys.Size = new System.Drawing.Size(124, 40);
			this.buttonCreateAsmKeys.TabIndex = 2;
			this.buttonCreateAsmKeys.Text = "Создание ключей";
			this.buttonCreateAsmKeys.UseVisualStyleBackColor = true;
			this.buttonCreateAsmKeys.Click += new System.EventHandler(this.buttonCreateAsmKeys_Click);
			// 
			// buttonExportPublicKey
			// 
			this.buttonExportPublicKey.Location = new System.Drawing.Point(655, 12);
			this.buttonExportPublicKey.Name = "buttonExportPublicKey";
			this.buttonExportPublicKey.Size = new System.Drawing.Size(124, 40);
			this.buttonExportPublicKey.TabIndex = 3;
			this.buttonExportPublicKey.Text = "Экспорт открытого ключа";
			this.buttonExportPublicKey.UseVisualStyleBackColor = true;
			this.buttonExportPublicKey.Click += new System.EventHandler(this.buttonExportPublicKey_Click);
			// 
			// buttonImportPublicKey
			// 
			this.buttonImportPublicKey.Location = new System.Drawing.Point(655, 74);
			this.buttonImportPublicKey.Name = "buttonImportPublicKey";
			this.buttonImportPublicKey.Size = new System.Drawing.Size(124, 40);
			this.buttonImportPublicKey.TabIndex = 4;
			this.buttonImportPublicKey.Text = "Импорт открытого ключа";
			this.buttonImportPublicKey.UseVisualStyleBackColor = true;
			this.buttonImportPublicKey.Click += new System.EventHandler(this.buttonImportPublicKey_Click);
			// 
			// buttonGetPrivateKey
			// 
			this.buttonGetPrivateKey.Location = new System.Drawing.Point(655, 141);
			this.buttonGetPrivateKey.Name = "buttonGetPrivateKey";
			this.buttonGetPrivateKey.Size = new System.Drawing.Size(124, 40);
			this.buttonGetPrivateKey.TabIndex = 5;
			this.buttonGetPrivateKey.Text = "Получение закрытого ключа";
			this.buttonGetPrivateKey.UseVisualStyleBackColor = true;
			this.buttonGetPrivateKey.Click += new System.EventHandler(this.buttonGetPrivateKey_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 6;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.FileName = "openFileDialog2";
			// 
			// EncDecForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonGetPrivateKey);
			this.Controls.Add(this.buttonImportPublicKey);
			this.Controls.Add(this.buttonExportPublicKey);
			this.Controls.Add(this.buttonCreateAsmKeys);
			this.Controls.Add(this.buttonDecryptFile);
			this.Controls.Add(this.buttonEncryptFile);
			this.Name = "EncDecForm";
			this.Text = "EncDecForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEncryptFile;
        private System.Windows.Forms.Button buttonDecryptFile;
        private System.Windows.Forms.Button buttonCreateAsmKeys;
        private System.Windows.Forms.Button buttonExportPublicKey;
        private System.Windows.Forms.Button buttonImportPublicKey;
        private System.Windows.Forms.Button buttonGetPrivateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}