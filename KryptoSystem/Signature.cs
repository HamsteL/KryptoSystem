using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;



namespace KryptoSystem
{
    public partial class Signature : Form
    {
        CspParameters cspp = new CspParameters();
        RSACryptoServiceProvider rsa;

        Crypto crypto = new Crypto();
        xmlWorker XmlWorker = new xmlWorker();

        const string SigFolder = @"Signature\";
        const string KeyFolder = @"PubKey\";
        const string PubKeyFile = "";
        const string PublicKey = @"PubKey\";

        string keyName = "";

        public Signature()
        {
            InitializeComponent();
            System.IO.Directory.CreateDirectory("Signature");
        }


        //СОЗДАНИЕ ПОДПИСИ

        // импортировать открытый ключ и востановить закрытый ключ из контейнера
        private void buttonRecoverKeys_Click(object sender, EventArgs e)
        {
            string name = "";
            openFileDialog1.InitialDirectory = KeyFolder;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;
                if (fName != null)
                {
                    FileInfo fInfo = new FileInfo(fName);

                    name = fInfo.FullName;
                }
            }

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

                    //String F = PublicKey + "/Key";

                    //System.IO.File.WriteAllText(F, rsa.ToXmlString(false));

                }

            }
            else
            {
                MessageBox.Show("Невозможно импортировать ключ");
            }
        }

        //экспорт моего открытого ключа
        private void buttonExportPublicKey_Click(object sender, EventArgs e)
        {
            if (keyName != "")
            {
                String F = "";
                string name = "";
                saveFileDialog1.InitialDirectory = PubKeyFile;
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

        //создать новую пару ключей
        private void buttonGenerateNewKeys_Click(object sender, EventArgs e)
        {
            keyName = crypto.createKeys();
            MessageBox.Show("Создан контейнер: " + keyName);

            cspp.KeyContainerName = keyName;
            rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;
            label1.Text += "Keys generated \n";
            if (rsa.PublicOnly == true)
                label1.Text += "Key: " + cspp.KeyContainerName + " - Public Only \n";
            else
                label1.Text += "Key: " + cspp.KeyContainerName + " - Full Key Pair \n";
        }



        //создание цифровой поддписи
        private void сreateSignature_Click(object sender, EventArgs e)
        {
            if (rsa == null)
                MessageBox.Show("Key not set.");
            else
            {
                //открытие файла
                openFileDialog1.InitialDirectory = SigFolder;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fName = openFileDialog1.FileName;
                    if (fName != null)
                    {
                        FileInfo fi = new FileInfo(fName);
                        string name = fi.FullName;

                        //создание подписи
                        createSignature(name);
                    }
                }
            }

        }

        private void createSignature(string inFile)
        {
            //проверка на путоту
            FileStream inFs = new FileStream(inFile, FileMode.Open);
            if (inFs.Length == 0) { MessageBox.Show("File is empty"); }
            else
            {
                int startFileName = inFile.LastIndexOf("\\") + 1;
                string outFile = SigFolder + "sig" + inFile.Substring(startFileName, inFile.LastIndexOf(".") - startFileName) + ".txt";

                byte[] originalData = new byte[inFs.Length];
                byte[] signedData;

                using (inFs)
                {
                    inFs.Read(originalData, 0, originalData.Length);
                    inFs.Close();
                }

                signedData = rsa.SignData(originalData, new SHA256CryptoServiceProvider());

                //сохранение подписи
                using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                {
                    outFs.Write(signedData, 0, signedData.Length);
                    outFs.Close();
                }
            }
        }





        //ПРОВЕРКА

        byte[] message;
        byte[] signature;


        //импортировать открытый ключ
        private void buttonImportPublicKey_Click(object sender, EventArgs e)
        {
            String F = "";
            string PubKeyFile = "";
            openFileDialog1.InitialDirectory = KeyFolder;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                F = openFileDialog1.FileName;
                FileInfo fInfo = new FileInfo(F);

                PubKeyFile = fInfo.FullName;
            }

            if (File.Exists(PubKeyFile))
            {
                StreamReader sr = new StreamReader(PubKeyFile);
                cspp.KeyContainerName = PublicKey;
                rsa = new RSACryptoServiceProvider(cspp);
                string keytxt = sr.ReadToEnd();
                rsa.FromXmlString(keytxt);
                rsa.PersistKeyInCsp = true;
                if (rsa.PublicOnly == true)
                    label1.Text += "Key: " + cspp.KeyContainerName + " - Public Only \n";
                else
                    label1.Text += "Key: " + cspp.KeyContainerName + " - Full Key Pair \n";
                sr.Close();
            }
        }

        //Получить содержимае файла в байтах
        private byte[] getFileContentBytes(ref byte[] data)
        {
            openFileDialog1.InitialDirectory = SigFolder;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;
                if (fName != null)
                {
                    FileInfo fi = new FileInfo(fName);
                    string inFile = fi.FullName;

                    FileStream inFs = new FileStream(inFile, FileMode.Open);
                    if (inFs.Length == 0) { MessageBox.Show("File is empty"); }
                    else
                    {
                        using (inFs)
                        {
                            data = new byte[inFs.Length];
                            inFs.Read(data, 0, data.Length);
                            inFs.Close();

                        }

                    }
                }
            }
            return data;
        }

        //загрузка сообщения
        private void buttonDownloadMessage_Click(object sender, EventArgs e)
        {
            getFileContentBytes(ref message);
            if (message.Length < 1)
            {
                MessageBox.Show("Message not loaded");
                return;
            }
            else
                label1.Text += "Message loaded \n";

        }

        //загрузка подписи
        private void buttonDownloadSig_Click(object sender, EventArgs e)
        {
            getFileContentBytes(ref signature);
            if (signature.Length < 1)
            {
                MessageBox.Show("Signature not loaded");
                return;
            }
            else
                label1.Text += "Signature loaded \n";
        }

        //Проверка подлинности сообщения
        private void buttonVerificationsSig_Click(object sender, EventArgs e)
        {
            if (rsa == null)
                MessageBox.Show("Key not set.");
            else
            {
                if (rsa.PublicOnly != true)
                    MessageBox.Show("Key not set.");
                else
                {

                    if (message.Length < 1)
                    {
                        MessageBox.Show("Message not loaded");
                        return;
                    }
                    if (signature.Length < 1)
                    {
                        MessageBox.Show("Signature not loaded");
                        return;
                    }

                    string test = rsa.VerifyData(message, new SHA256CryptoServiceProvider(), signature).ToString();
                    MessageBox.Show(test);
                }
            }
        }

        private void Signature_Load(object sender, EventArgs e)
        {

        }
    }
}
