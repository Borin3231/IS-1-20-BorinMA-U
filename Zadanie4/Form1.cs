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
using ConnectBD;
using System.Net;

namespace Zadanie4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_4;database=is_1_20_st4_KURS;password=32006333;";
        DataTable dt = new DataTable();
        MySqlDataAdapter yyy = new MySqlDataAdapter();
        BindingSource aaa = new BindingSource();


        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            Table();
        }
        private void Table()
        {
            dt.Clear();

            string uuu = ($"SELECT t_datatime.id AS 'ID', t_datatime.FIO AS 'Name', t_datatime.Date_of_Birth AS 'date_of_birth', t_datatime.photoUrl AS 'Photo' FROM t_datatime;");
            conn.Open();

            yyy.SelectCommand = new MySqlCommand(uuu, conn);
            yyy.Fill(dt);

            aaa.DataSource = dt;
            dataGridView1.DataSource = aaa;
            conn.Close();

            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = true;
            label1.Visible = false;
        }
        void IPhoto(string a)
        {
            var z = WebRequest.Create(a);
            using (var hh = z.GetResponse())
            using(var zyz = hh.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(zyz);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            conn.Open();
            string z1 = "";
            string z2 = "";
            string z3 = "";
            string z4 = "";
            string kkk = ($"SELECT t_datatime.id AS 'ID', t_datatime.FIO AS 'Name', t_datatime.Date_of_Birth AS 'date_of_birth', t_datatime.photoUrl 'Photo', FROM t_datatime WHERE t_datatime.id = " + id);
            MySqlCommand cmm = new MySqlCommand(kkk, conn);
            MySqlDataReader read = cmm.ExecuteReader();
            while(read.Read())
            {
                z1 = read[0].ToString();
                z2 = read[1].ToString();
                z3 = read[2].ToString();
                z4 = read[3].ToString();
            }
            read.Close();
            label1.Text = ($"ID:" + z1 + "name:" + z2 + "date_of_birth:" + z3);
            label1.Visible = true;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                conn.Open();
                string vvv = "SELECT t_datatime.PhotoUrl AS 'Photo' FROM t_datatime WHERE t_datatime.id =" + id;
                MySqlCommand mm = new MySqlCommand(vvv, conn);
                string pictur = mm.ExecuteScalar().ToString();
                IPhoto(pictur);
                MySqlDataReader read = mm.ExecuteReader();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error!!" + ex.Message);
            }
        }
    }
}
