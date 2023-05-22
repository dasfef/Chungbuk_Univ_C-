using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BMS
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost; Port=3306; Database=testdatabase; Uid=root; pwd=123456789");

        public Form1()
        {
            InitializeComponent();
        }

        public void LoadList()
        {
            lstSales.Items.Clear();

            conn.Open();
            string query = "select * from sales";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            string[] fields = new string[6];
            while (rd.Read())
            {
                for (int k = 0; k < 6; k++) fields[k] = rd[k].ToString();
                fields[3] = fields[3].Substring(0, 12);
                ListViewItem row = new ListViewItem(fields);
                lstSales.Items.Add(row);
            }

            conn.Close();
            txtCustomer.Text = "";
            txtItem.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        public int NewSaleCode()
        {
            conn.Open();

            string query = "select max(salecode) + 1 from sales";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            int salecode = 1;
            if (rd[0].ToString().Length > 0) salecode = Int32.Parse(rd[0].ToString());
            rd.Close();

            conn.Close();
            return salecode;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtCustomer.Text.Length == 0 || txtItem.Text.Length == 0 || txtQty.Text.Length == 0 || txtPrice.Text.Length == 0)
            {
                MessageBox.Show("고객명, 품목, 수량, 가격을 확인하세요", "등록 값 오류");
                return;
            }

            int salecode = NewSaleCode(); string customer = txtCustomer.Text; string item = txtItem.Text;
            string date = dtpDate.Text; int qty = Int32.Parse(txtQty.Text); int price = Int32.Parse(txtPrice.Text);

            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into sales(salecode, customer, item, date, qty, price) values(@salecode, @customer, @item, @date, @qty, @price)";
            cmd.Parameters.Add("@salecode", MySqlDbType.VarChar).Value = salecode.ToString();
            cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = customer;
            cmd.Parameters.Add("@item", MySqlDbType.VarChar).Value = item;
            cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@qty", MySqlDbType.VarChar).Value = qty.ToString();
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = price.ToString();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadList();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(lstSales.SelectedItems.Count > 0)
            {
                string salecode = lstSales.SelectedItems[0].Text;

                conn.Open();

                string query = string.Format("delete from sales where salecode = \"{0}\"", salecode);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

                LoadList();
            }
        }

        private void btnCustomerSales_Click(object sender, EventArgs e)
        {
            txtAnalysis.Text = "";

            conn.Open();

            string query = "select customer, sum(price) from sales group by customer";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            txtAnalysis.Text = "고객명\t누적판매금액\r\n";
            
            while (rd.Read())
            {
                string row = String.Format("{0}\t{1}\r\n", rd[0].ToString(), rd[1].ToString());
                txtAnalysis.Text += row;
            }

            conn.Close();
        }

        private void btnItemSales_Click(object sender, EventArgs e)
        {
            txtAnalysis.Text = "";

            conn.Open();

            string query = "select item, sum(price) from sales group by item";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            txtAnalysis.Text = "제품명\t누적판매금액\r\n";
          
            while (rd.Read())
            {
                string row = String.Format("{0}\t{1}\r\n", rd[0].ToString(), rd[1].ToString());
                txtAnalysis.Text += row;
            }

            conn.Close();
        }
    }
}
