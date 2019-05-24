using System;
using System.Xml;

namespace KryptoSystem
{
    class xmlWorker
    {
        private string getContName(string name)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(name);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode Cs = xRoot.LastChild.FirstChild;

            return Cs.Value;
        }

        private bool writeContName(string name, string keyName)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(name);
                XmlElement xRoot = xDoc.DocumentElement;
                XmlElement csppElem = xDoc.CreateElement("csppName");
                XmlText csppName = xDoc.CreateTextNode(keyName);
                csppElem.AppendChild(csppName);
                xRoot.AppendChild(csppElem);
                xDoc.Save(name);

                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool writeCsppName(string name, string keyName)
        {
            return writeContName(name, keyName);
        }

        public string getCsppName(string name)
        {
            return getContName(name);
        }
    }
}
