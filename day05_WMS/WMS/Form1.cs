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

namespace WMS
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; port=3306; database=testdatabase; uid=root; pwd=123456789;");
        
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadList()
        {
            lstInOut.Items.Clear();

            conn.Open();

            string query = "select * from inouts";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            string[] fields = new string[6];
            while (rd.Read())
            {
                for (int k = 0; k < 5; k++) fields[k] = rd[k].ToString();
                ListViewItem row = new ListViewItem(fields);
                lstInOut.Items.Add(row);
            }
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] comboListRack = new string[] { "창고1", "창고2", "창고3" };
            cmbRack.Items.Clear();
            cmbRack.Items.AddRange(comboListRack);

            string[] comboListItem = new string[] { "마가레트", "쿠크다스", "포카칩", "꼬깔콘", "카스타드" };
            cmbItem.Items.Clear();
            cmbItem.Items.AddRange(comboListItem);

            LoadList();
        }

        public int NewInOutCode()
        {
            conn.Open();

            string query = "select max(inoutcode) + 1 from inouts";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            int inoutcode = 1;
            if (rd[0].ToString().Length > 0) inoutcode = Int32.Parse(rd[0].ToString());
            rd.Close();

            conn.Close();
            return inoutcode;
        }

        private void btnAddIn_Click(object sender, EventArgs e)
        {
            int inoutcode = NewInOutCode();
            string rack = cmbRack.SelectedItem.ToString();
            string item = cmbItem.SelectedItem.ToString();
            string date = dtpDate.Value.Date.ToString("yyyy-MM-dd");
            int qty = Int32.Parse(txtQty.Text);

            conn.Open();
            string query = String.Format("insert into inouts (inoutcode, rack, item, date, qty) values({0}, \"{1}\", \"{2}\", \"{3}\", {4})", inoutcode, rack, item, date, qty);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            LoadList();
        }

        private void btnAddOut_Click(object sender, EventArgs e)
        {
            int inoutcode = NewInOutCode();
            string rack = cmbRack.SelectedItem.ToString();
            string item = cmbItem.SelectedItem.ToString();
            string date = dtpDate.Value.Date.ToString("yyyy-MM-dd");
            int qty = -Convert.ToInt32(txtQty.Text);

            conn.Open();

            string query = String.Format("insert into inouts(inoutcode, rack, item, date, qty) values({0}, \"{1}\", \"{2}\", \"{3}\", {4})", inoutcode, rack, item, date, qty);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            LoadList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lstInOut.SelectedItems.Count > 0)
            {
                string inoutcode = lstInOut.SelectedItems[0].Text;

                conn.Open();

                string query = String.Format("delete from inouts where inoutcode = \"{0}\"", inoutcode);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

                LoadList();
            }
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            if(cmbRack.SelectedItem == null || cmbItem.SelectedItem == null)
            {
                MessageBox.Show("창고, 품목을 선택하세요");
                return;
            }
            string rack = cmbRack.SelectedItem.ToString();
            string item = cmbItem.SelectedItem.ToString();
            txtAnalysis.Text = "";
            string query;
            MySqlCommand cmd;
            MySqlDataReader rd;

            conn.Open();

            query = String.Format("select sum(qty) from inouts where rack = \"{0}\" and item = \"{1}\" and qty > 0", rack, item);
            cmd = new MySqlCommand(query, conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            int inQty = Convert.ToInt32(rd[0].ToString());
            txtAnalysis.Text += "총 입고량 : " + inQty + "\r\n";
            rd.Close();

            query = String.Format("select sum(qty) from inouts where rack=\"{0}\" and item = \"{1}\" and qty < 0", rack, item);
            cmd = new MySqlCommand(query, conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            int outQty = Convert.ToInt32(rd[0].ToString()) * -1;
            txtAnalysis.Text += "현 재고량 : " + outQty + "\r\n";
            rd.Close();

            int currentQty = inQty - outQty;
            txtAnalysis.Text += "현 재고량 : " + currentQty + "\r\n";

            conn.Close();
        }
    }
}
