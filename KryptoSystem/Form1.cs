using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KryptoSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void encDecBtn_Click(object sender, EventArgs e)
        {
            EncDecForm encDecForm = new EncDecForm();
            encDecForm.Show();
        }

		private void signatureBtn_Click(object sender, EventArgs e)
		{
			Signature signatureForm= new Signature();
			signatureForm.Show();
		}
	}
}
