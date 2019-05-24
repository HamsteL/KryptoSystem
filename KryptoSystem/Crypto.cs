using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace KryptoSystem
{
    class Crypto
    {
        CspParameters cspp = new CspParameters();
        RSACryptoServiceProvider rsa;

        const string EncrFolder = @"Encrypt\";
        const string DecrFolder = @"Decrypt\";
        const string PubKey = @"PubKey\";

        private string createAsmKeys()
        {
            string keyName = "";
            keyName = String.Format(@"{0}", System.Guid.NewGuid());

            cspp.KeyContainerName = keyName;
            rsa = new RSACryptoServiceProvider(cspp);
            return keyName;
        }

        public string createKeys()
        {
            return createAsmKeys();
        }

        //шифрование выбранного файла
        private bool EncryptFile(string inFile, string csppName)
        {
            cspp.KeyContainerName = csppName;
            rsa = new RSACryptoServiceProvider(cspp);
            try
            {
                FileStream inFs = new FileStream(inFile, FileMode.Open);
                if (inFs.Length == 0) { MessageBox.Show("File is empty"); }
                else
                {
                    RijndaelManaged rjndl = new RijndaelManaged();
                    rjndl.KeySize = 256;
                    rjndl.BlockSize = 128;
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


                            using (inFs)
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
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void ecnFile(string inFile, string csppName)
        {
            bool encFiles = EncryptFile(inFile, csppName);

            if (encFiles == true)
            {
                MessageBox.Show("Файл успешно зашифрован");
            }
            else
            {
                MessageBox.Show("Ошибка при шифровке");
            }
        }

        private bool DecryptFile(string inFile, string csppName)
        {
            cspp.KeyContainerName = csppName;
            rsa = new RSACryptoServiceProvider(cspp);
            try
            {
                string infile2 = inFile;
                inFile = EncrFolder + inFile;
                FileStream inFs = new FileStream(inFile, FileMode.Open);
                inFile = infile2;

                if (inFs.Length == 0) { MessageBox.Show("File is empty"); }
                else
                {
                    RijndaelManaged rjndl = new RijndaelManaged();
                    rjndl.KeySize = 256;
                    rjndl.BlockSize = 128;
                    rjndl.Mode = CipherMode.CBC;

                    byte[] LenK = new byte[4];
                    byte[] LenIV = new byte[4];

                    string outFile = DecrFolder + inFile.Substring(0, inFile.LastIndexOf(".")) + ".txt";

                    using (inFs)
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
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        }

        public void decFile(string inFile, string csppName)
        {
            bool encFiles = DecryptFile(inFile, csppName);

            if (encFiles == true)
            {
                MessageBox.Show("Файл успешно расшифрован");
            }
            else
            {
                MessageBox.Show("Ошибка при расшифровке");
            }
        }
    }
}
