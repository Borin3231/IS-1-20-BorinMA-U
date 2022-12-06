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
using static Zadanie3.Program;

namespace Zadanie3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_4;database=is_1_20_st4_KURS;password=32006333;";
        DataTable dataTable = new DataTable();
        MySqlDataAdapter klk = new MySqlDataAdapter();
        BindingSource jgj = new BindingSource();
        public void tablica()
        {
            dataTable.Clear();
            string ikik = "SELECT Client.id_Client AS 'ID',Client.Name AS 'name',Client.Addres AS 'addres',Client.Phone AS 'phone',Client.el_pochta AS 'El_Pochta' FROM Client JOIN Main ON Client.id_Client = Main.id_Client";
            conn.Open();

            klk.SelectCommand=new MySqlCommand(ikik,conn);
            klk.Fill(dataTable);

            jgj.DataSource = dataTable;

            dataGridView1.DataSource= jgj;
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
        

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            tablica();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells["0"].Value.ToString();
            conn.Open();
            string p1 = "";
            string p2 = "";
            string p3 = "";
            string p4 = "";
            string lll = ($"SELECT Client.id_Client AS 'ID',Client.Name AS 'name', Client.Addres AS 'addres', Client.Phone AS 'phone', Client.el_pochta AS 'El_Pochta' FROM Client JOIN Main ON Client.id_Client = Main.id_Client WHERE Client.ID =" + id);
            MySqlCommand comm = new MySqlCommand(lll, conn);
            MySqlDataReader hhh = comm.ExecuteReader();
            while (hhh.Read())
            {
                p1 = hhh[0].ToString();
                p2 = hhh[1].ToString();
                p3 = hhh[2].ToString();
                p4 = hhh[3].ToString();
            }
            hhh.Close();
            label1.Text = $" ID: " + p1 + " Name: " + p2 + " Addres:" + p3 + "Phone" + p4 + "el_pochta";
            label1.Visible = true;
            conn.Close();
        }
    }
}
