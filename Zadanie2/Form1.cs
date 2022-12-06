using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Zadanie2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class SYBD
        {
            MySqlConnection connection = new MySqlConnection("server=chuc.caseum.ru;port=33333;user=uchebka;database=uchebka;password=uchebka;");

            public void Podklychenie()
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Подключение.");
                }
                catch
                {
                    MessageBox.Show("Вы не смогли подключится.");
                }
                finally
                {
                    MessageBox.Show("Вы успешно подключились.");
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                SYBD sybd = new SYBD();
                sybd.Podklychenie();
            }
        }
    }
}
