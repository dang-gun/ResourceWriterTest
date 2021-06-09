using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceWriterTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            using (IResourceWriter writer = new ResourceWriter("Form1.jp.resx"))
            {
                writer.AddResource("$this.Text", "First String");
            }

            Thread.CurrentThread.CurrentCulture
                = new System.Globalization.CultureInfo("jp");
            Thread.CurrentThread.CurrentUICulture
                = new System.Globalization.CultureInfo("jp");

            InitializeComponent();
        }

        private void btnEn_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2("en");
            frm2.Show();

        }

        private void btnKo_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2("ko");
            frm2.Show();
        }
    }
}
