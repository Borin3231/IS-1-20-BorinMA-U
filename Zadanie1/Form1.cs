using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        abstract class accessories<P>
        {
            public int GodVipyska;
            public int Cena;
            public P Articul;

            public accessories(int god, int cena, P articul)
            {
                GodVipyska = god;
                Cena = cena;
                Articul = articul;
            }
            public virtual string Display()
            {
                return ($"Цена:{Cena}. Год выпуска:{GodVipyska}. Артикула:{Articul}.");
            }
        }
        class HDD<P> : accessories<P>
        {
            private int kolvoOborotov { get; set; }
            private string InFace { get; set; }
            private int Obem { get; set; }

            public HDD(int Cena,int GodVipyska,P Articul,int kolvoOborotovv,string Interface, int obem):base(GodVipyska,Cena,Articul)
            {
                kolvoOborotov = kolvoOborotovv;
                InFace = Interface;
                Obem = obem;
            }
            public override string Display()
            {
                return ($"Цена:{Cena}. Год выпуска{GodVipyska}. Артикул:{Articul}. Количество оборотов:{kolvoOborotov}. Интерфейс:{InFace}. Объём:{Obem}.");
            }
        }
        class VideoKarta<P> : accessories<P>
        {
            private int Frequency { get; set; } 
            private string Proizvoditel { get; set; }
            private int Pamyat { get; set; }

            public VideoKarta(int Cena,int GodVipyska, P Articul,int Freq, string manufact,int pamyat):base(Cena,GodVipyska,Articul)
            {
                Frequency = Freq;
                Proizvoditel = manufact;
                Pamyat = pamyat;
            }
            public override string Display()
            {
                return ($"Цена:{Cena}. Год выпуска:{GodVipyska}. Артикул:{Articul}. Частота:{Frequency}. Производитель:{Proizvoditel}. Объём памяти:{Pamyat}.");

            }
        }
        HDD<int> Disk;
        VideoKarta<int> karta;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Cena = Convert.ToInt32(textBox1.Text);
                int GodVipyska = Convert.ToInt32(textBox2.Text);
                int articul = Convert.ToInt32(textBox3.Text);
                int kolvoOborotov = Convert.ToInt32(textBox4.Text);
                string InFace = textBox5.Text;
                int Obem = Convert.ToInt32(textBox6.Text);
                Disk = new HDD<int>(Cena, GodVipyska, articul, kolvoOborotov, InFace, Obem);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                listBox1.Items.Add(Disk.Display());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int Cena = Convert.ToInt32(textBox1.Text);
                int GodVipyska = Convert.ToInt32(textBox2.Text);
                int articul = Convert.ToInt32(textBox3.Text);
                int Frequency = Convert.ToInt32(textBox7.Text);
                int Pamyat = Convert.ToInt32(textBox8.Text);
                string Proizvoditel = textBox9.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                listBox1.Items.Add(karta.Display());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
