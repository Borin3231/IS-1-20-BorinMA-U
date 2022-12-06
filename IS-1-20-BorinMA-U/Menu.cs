using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zadanie1;
using Zadanie2;
using Zadanie3;
using Zadanie4;

namespace IS_1_20_BorinMA_U
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zadanie1.Form1 a1 = new Zadanie1.Form1();
            this.Hide();
            a1.ShowDialog();
            this.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zadanie2.Form1 a2 = new Zadanie2.Form1();
            this.Hide();
            a2.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Zadanie3.Form1 a3 = new Zadanie3.Form1();
            this.Hide();
            a3.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Zadanie4.Form1 a4 = new Zadanie4.Form1();
            this.Hide();
            a4.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
