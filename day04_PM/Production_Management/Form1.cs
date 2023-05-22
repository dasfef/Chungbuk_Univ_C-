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

namespace Production_Management
{
    public partial class Form1 : Form
    {

        MySqlConnection conn = new MySqlConnection("server=localhost; port=3306; database=testdatabase; uid=root; pwd=123456789");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] comboListYear = new string[] { "2020", "2021", "2022", "2023", "2024" };
            cmbYear.Items.Clear();
            cmbYear.Items.AddRange(comboListYear);

            string[] comboListMonth = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            cmbMonth.Items.Clear();
            cmbMonth.Items.AddRange(comboListMonth);

            string[] comboListItem = new string[] { "Python", "C언어", "Arduino", "DataBase", "C#", "android", "DeepLearning" };
            cmbItem.Items.Clear();
            cmbItem.Items.AddRange(comboListItem);

            string[] comboListWorkCenter = new string[] { "C101", "C102", "C103", "C104" };
            cmbWorkCenter.Items.Clear();
            cmbWorkCenter.Items.AddRange(comboListWorkCenter);
        }

        public void LoadPlan()
        {
            if (cmbYear.SelectedItem == null || cmbMonth.SelectedItem == null)
            {
                MessageBox.Show("년도, 월을 선택하세요", "Caution");
                return;
            }

            string planYear = cmbYear.SelectedItem.ToString();
            string planMonth = cmbMonth.SelectedItem.ToString();
            lstProducts.Items.Clear();

            conn.Open();

            string query = String.Format("select * from productions where YEAR(start_date) = {0} and_" +
                " MONTH(start_date) = {1}", planYear, planMonth);
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dr = cmd.ExecuteReader();
            string[] fields = new string[6];
            while (dr.Read())
            {
                for (int k = 0; k < 6; k++) fields[k] = dr[k].ToString();
                ListViewItem row = new ListViewItem(fields);
                lstProducts.Items.Add(row);
            }

            conn.Close();

        }

        public int NewProCode()
        {
            conn.Open();

            string query = "select max(procode) + 1 from productions";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            int procode = 1;
            if (rd[0].ToString().Length > 0) procode = Int32.Parse(rd[0].ToString());
            rd.Close();

            conn.Close();
            return procode;
        }

        private void btnPlanAdd_Click(object sender, EventArgs e)
        {
            if (cmbItem.SelectedItem == null || cmbWorkCenter.SelectedItem == null || txtQty.TextLength == 0)
            {
                MessageBox.Show("품목, 작업장, 수량을 확인하세요", "Caution");
                return;
            }

            int procode = NewProCode(); string item = cmbItem.SelectedItem.ToString();
            string WorkCenter = cmbWorkCenter.SelectedItem.ToString();
            string date = dtpStart.Value.Date.ToString("yyyy-MM-dd"); int qty = Int32.Parse(txtQty.Text);

            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into productions(procode, item, work_center, qty, start_date) values(@procode, @item, @work_center, @qty, @start_date)";
            cmd.Parameters.Add("@procode", MySqlDbType.VarChar).Value = procode.ToString();
            cmd.Parameters.Add("@item", MySqlDbType.VarChar).Value = item;
            cmd.Parameters.Add("@work_center", MySqlDbType.VarChar).Value = WorkCenter;
            cmd.Parameters.Add("@qty", MySqlDbType.VarChar).Value = qty.ToString();
            cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = date.ToString();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadPlan();
        }

        private void btnPlanDelete_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedItems.Count > 0)
            {
                string procode = lstProducts.SelectedItems[0].Text;

                conn.Open();

                string query = String.Format("delete from productions where procode = \"{0}\"", procode);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

                LoadPlan();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedItems.Count > 0)
            {
                string procode = lstProducts.SelectedItems[0].Text;
                string setdate = dtpEnd.Value.Date.ToString("yyyy-MM-dd");

                conn.Open();

                string query = String.Format("update productions set end_date=\"{0}\" where procode = \"{1}\"", setdate, procode);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

                LoadPlan();
            }
        }

        private void btnPlanQuery_Click(object sender, EventArgs e)
        {
            LoadPlan();
        }

        public int QueryPlanQty(string item, string planYear, string planMonth)
        {
            MySqlConnection connQ = new MySqlConnection("server=localhost; port=3306; database=testdatabase; uid=root; pwd=123456789");

            connQ.Open();

            string query = String.Format("select sum(qty) from productions where YEAR(start_date)={0} and MONTH(start_date)={1} and item=\"{2}\"", planYear, planMonth, item);
            MySqlCommand cmd = new MySqlCommand(query, connQ);
            MySqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            int qty = 0;
            if (rd[0].ToString().Length > 0) qty = int.Parse(rd[0].ToString());

            connQ.Close();

            return qty;
        }

        public int QueryCompleteQty(string item, string planYear, string planMonth)
        {
            MySqlConnection connQ = new MySqlConnection("server=localhost; port=3306; database=testdatabase; uid=root; pwd=123456789");

            connQ.Open();

            string query = String.Format("select sum(qty) from productions where YEAR(start_date) = {0} and month(start_date) = {1} and_" +
                " item = \"{2}\" and end_date is not null", planYear, planMonth, item);
            MySqlCommand cmd = new MySqlCommand(query, connQ);
            MySqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            int qty = 0;
            if (rd[0].ToString().Length > 0) qty = int.Parse(rd[0].ToString());

            connQ.Close();

            return qty;
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            if (cmbYear.SelectedItem == null || cmbMonth.SelectedItem == null)
            {
                MessageBox.Show("년도, 월을 선택하세요", "Caution");
                return;
            }

            string planYear = cmbYear.SelectedItem.ToString(); string planMonth = cmbMonth.SelectedItem.ToString();
            txtSummary.Text = "";

            conn.Open();
            string query = String.Format("select distinct(item) from productions where year(start_date) = {0} and_" +
                " month(start_date) = {1}", planYear, planMonth);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();

            txtSummary.Text = ""; string item;
            while (rd.Read())
            {
                item = rd[0].ToString();
                double planQty = QueryPlanQty(item, planYear, planMonth);
                double completeQty = QueryCompleteQty(item, planYear, planMonth);
                double progress = 0.0;
                if (planQty > 0) progress = (completeQty / planQty) * 100;
                txtSummary.Text += item + " : 계획량 = " + planQty + ", 완료량 = " + completeQty +
                    ", 진행율 = " + progress + "% \r\n";
            }
            conn.Close();
        }
    }
}
