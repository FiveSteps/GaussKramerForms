using Gauss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GaussKramerProjectForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gaussBtn_Click(object sender, EventArgs e)
        {
            GaussPage gaussPage = new GaussPage();
            gaussPage.Show();
        }

        private void kramerBtn_Click(object sender, EventArgs e)
        {
            KramerPage kramerPage = new KramerPage();
            kramerPage.Show();
        }
    }
}
