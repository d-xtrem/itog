﻿using System;
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
    public partial class Form3 : Form
    {
        new Form2 frm2;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            this.Hide();
            frm2.Show();

        }
    }
}
