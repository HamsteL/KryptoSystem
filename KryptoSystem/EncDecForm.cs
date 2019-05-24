using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace KryptoSystem
{
    public partial class EncDecForm : Form
    {
        CspParameters cspp = new CspParameters();
        RSACryptoServiceProvider rsa;

        Crypto crypto = new Crypto();
        xmlWorker XmlWorker = new xmlWorker();

        const string EncrFolder = @"Encrypt\";
        const string DecrFolder = @"Decrypt\";
        const string PubKey = @"PubKey\";

        const string PubKeyFile = "";

        string keyName = "";

        public EncDecForm()
        {
            InitializeComponent();
            System.IO.Directory.CreateDirectory("Encrypt");
            System.IO.Directory.CreateDirectory("Decrypt");
            System.IO.Directory.CreateDirectory("PubKey");

        }

        //Шифрование файла
        private void buttonEncryptFile_Click(object sender, EventArgs e)
        {
            if (rsa == null)
                MessageBox.Show("Key not set.");
            else
            {
                openFileDialog1.InitialDirectory = EncrFolder;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fName = openFileDialog1.FileName;
                    if (fName != null)
                    {
                        FileInfo fInfo = new FileInfo(fName);

                        string name = fInfo.FullName;
                        EncryptFile(name);
                    }
                }
            }
        }

        //Экспорт приватного ключа
        private void buttonExportPublicKey_Click(object sender, EventArgs e)
        {
            if (keyName != "")
            {
                String F = "";
                string name = "";
                saveFileDialog1.InitialDirectory = EncrFolder;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    F = saveFileDialog1.FileName;
                    name = saveFileDialog1.FileName;
                    System.IO.File.WriteAllText(F, rsa.ToXmlString(false));
                }

                if (XmlWorker.writeCsppName(name, keyName) != false)
                    MessageBox.Show("Имя контейнера записано в " + name);

                MessageBox.Show("Публичный ключ успешно экспортирован");

            }
            else
            {
                MessageBox.Show("Сначала создайте ключи.");
            }
        }

        //Импорт публичного ключа
        private void buttonImportPublicKey_Click(object sender, EventArgs e)
        {
            String F = "";
            string PubKeyFile = "";
            openFileDialog1.InitialDirectory = PubKey;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                F = openFileDialog1.FileName;
                FileInfo fInfo = new FileInfo(F);

                PubKeyFile = fInfo.FullName;
            }

            try
            {
                StreamReader sr = new StreamReader(PubKeyFile);
                cspp.KeyContainerName = keyName;
                rsa = new RSACryptoServiceProvider(cspp);
                string keytxt = sr.ReadToEnd();
                rsa.FromXmlString(keytxt);
                rsa.PersistKeyInCsp = true;
                if (rsa.PublicOnly == true)
                    label1.Text += "\n Сompanion Public Key: " + cspp.KeyContainerName + " - Public Only";
                else
                    label1.Text += "\n Сompanion Public Key: " + cspp.KeyContainerName + " - Full Key Pair";
                sr.Close();
            }
            catch (Exception evt)
            {
                MessageBox.Show(evt.ToString());
            }
        }

        //получение пары ключей
        private void buttonGetPrivateKey_Click(object sender, EventArgs e)
        {
            string name = "";
            openFileDialog1.InitialDirectory = PubKey;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;
                if (fName != null)
                {
                    FileInfo fInfo = new FileInfo(fName);

                    name = fInfo.FullName;
                }
            }
            if (name != "")
            {
                //Получение имени контейнера из файла
                keyName = XmlWorker.getCsppName(name);

                if (keyName != "")
                {
                    cspp.KeyContainerName = keyName;

                    rsa = new RSACryptoServiceProvider(cspp);
                    rsa.PersistKeyInCsp = true;

                    if (rsa.PublicOnly == true)
                        label1.Text += "\n Your Key: " + cspp.KeyContainerName + " - Public Only";
                    else
                    {
                        label1.Text += "\n Your Key: " + cspp.KeyContainerName + " - Full Key Pair";

                        String F = PubKey + "/Key";

                        System.IO.File.WriteAllText(F, rsa.ToXmlString(false));

                    }

                }
            }
            else
            {
                MessageBox.Show("Невозможно импортировать ключ");
            }

        }

        //генерация ключей для RSA
        private void buttonCreateAsmKeys_Click(object sender, EventArgs e)
        {
            keyName = crypto.createKeys();
            MessageBox.Show("Создан контейнер: " + keyName);

            cspp.KeyContainerName = keyName;
            rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;
            if (rsa.PublicOnly == true)
                label1.Text = "Key: " + cspp.KeyContainerName + " - Public Only";
            else
                label1.Text = "Key: " + cspp.KeyContainerName + " - Full Key Pair";


        }

        //расшифровать файл
        private void buttonDecryptFile_Click(object sender, EventArgs e)
        {
            if (rsa == null)
                MessageBox.Show("Key not set.");
            else
            {

                openFileDialog2.InitialDirectory = DecrFolder;
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    string fName = openFileDialog2.FileName;
                    if (fName != null)
                    {
                        FileInfo fi = new FileInfo(fName);
                        string name = fi.Name;
                        DecryptFile(name);
                    }
                }
            }
        }

        private void EncryptFile(string inFile)
        {
            RijndaelManaged rjndl = new RijndaelManaged();
            rjndl.KeySize = 256;
            rjndl.BlockSize = 256;
            rjndl.Mode = CipherMode.CBC;
            ICryptoTransform transform = rjndl.CreateEncryptor();

            byte[] keyEncrypted = rsa.Encrypt(rjndl.Key, false);
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            int lKey = keyEncrypted.Length;
            LenK = BitConverter.GetBytes(lKey);
            int lIV = rjndl.IV.Length;
            LenIV = BitConverter.GetBytes(lIV);

            int startFileName = inFile.LastIndexOf("\\") + 1;

            string outFile = EncrFolder + inFile.Substring(startFileName, inFile.LastIndexOf(".") - startFileName) + ".enc";

            using (FileStream outFs = new FileStream(outFile, FileMode.Create))
            {

                outFs.Write(LenK, 0, 4);
                outFs.Write(LenIV, 0, 4);
                outFs.Write(keyEncrypted, 0, lKey);
                outFs.Write(rjndl.IV, 0, lIV);



                using (CryptoStream outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                {
                    int count = 0;
                    int offset = 0;
                    int blockSizeBytes = rjndl.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];
                    int bytesRead = 0;

                    using (FileStream inFs = new FileStream(inFile, FileMode.Open))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamEncrypted.Write(data, 0, count);
                            bytesRead += blockSizeBytes;
                        }
                        while (count > 0);
                        inFs.Close();
                    }
                    outStreamEncrypted.FlushFinalBlock();
                    outStreamEncrypted.Close();
                }
                outFs.Close();
            }

        }

        private void DecryptFile(string inFile)
        {
            RijndaelManaged rjndl = new RijndaelManaged();
            rjndl.KeySize = 256;
            rjndl.BlockSize = 256;
            rjndl.Mode = CipherMode.CBC;

            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            string outFile = DecrFolder + inFile.Substring(0, inFile.LastIndexOf(".")) + ".txt";

            using (FileStream inFs = new FileStream(EncrFolder + inFile, FileMode.Open))
            {
                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Read(LenK, 0, 3);
                inFs.Seek(4, SeekOrigin.Begin);
                inFs.Read(LenIV, 0, 3);

                int lenK = BitConverter.ToInt32(LenK, 0);
                int lenIV = BitConverter.ToInt32(LenIV, 0);
                int startC = lenK + lenIV + 8;
                int lenC = (int)inFs.Length - startC;
                byte[] KeyEncrypted = new byte[lenK];
                byte[] IV = new byte[lenIV];

                inFs.Seek(8, SeekOrigin.Begin);
                inFs.Read(KeyEncrypted, 0, lenK);
                inFs.Seek(8 + lenK, SeekOrigin.Begin);
                inFs.Read(IV, 0, lenIV);
                Directory.CreateDirectory(DecrFolder);

                byte[] KeyDecrypted = rsa.Decrypt(KeyEncrypted, false);

                ICryptoTransform transform = rjndl.CreateDecryptor(KeyDecrypted, IV);

                using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                {
                    int count = 0;
                    int offset = 0;
                    int blockSizeBytes = rjndl.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];

                    inFs.Seek(startC, SeekOrigin.Begin);
                    using (CryptoStream outStreamDecrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamDecrypted.Write(data, 0, count);

                        }
                        while (count > 0);

                        outStreamDecrypted.FlushFinalBlock();
                        outStreamDecrypted.Close();
                    }
                    outFs.Close();
                }
                inFs.Close();
            }

        }
    }
}
