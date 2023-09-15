using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyCanRestorant
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnMalzemeler_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.ShowDialog();
        }

        private void btnYemekler_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YemekMalzemeTablosu form3 = new YemekMalzemeTablosu();
            form3.ShowDialog();
        }
    }
}
