﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFHANLER
{
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="Aravindhan" && textBox2.Text == "Welcome@123")
            {

            }
        }
    }
}
