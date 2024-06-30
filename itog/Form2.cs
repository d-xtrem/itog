using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itog
{
    public partial class Form2 : Form
    {
        public Form1 frm1;
        public Form3 frm3;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frm1 = new Form1();
           this.Hide();
           frm1.Show();


        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm3 = new Form3();
            this.Hide();
            frm3.Show();
        }
    }
}
