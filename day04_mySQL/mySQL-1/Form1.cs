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

namespace mySQL_1
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Port=3306;Database = testdatabase;Uid=root;Pwd = 123456789");

        public int RndValue;
        public Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        public bool mySql_Open()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                switch(ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot contact MySQL Server", "mySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 1:
                        MessageBox.Show("Invalid username/password, please try again", "mySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show(ex.ToString(), "mySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
        }

        public bool mySql_Close()
        {
            try
            {
                conn.Close();
                return true;
            }

            catch
            {
                return false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(pictureBox1.BackColor == Color.DarkGray)
            {
                if (mySql_Open())
                {
                    pictureBox1.BackColor = Color.LawnGreen;
                    statuslabel.Text = "Connection OK";
                    btnStart.Enabled = true;
                }
                else
                {
                    pictureBox1.BackColor = Color.Coral;
                    statuslabel.Text = "Connection Failed";
                    btnStart.Enabled = true;
                }
            }
            else
            {
                if(mySql_Close())
                {
                    pictureBox1.BackColor = Color.DarkGray;
                    statuslabel.Text = "DB Closing OK";
                }
                else
                {
                    pictureBox1.BackColor = Color.Coral;
                    statuslabel.Text = "DB Closing Failed";
                }
            }
        }

        public void InsertData(int Data_1, int Data_2)
        {
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "INSERT INTO testdatabase(time, temp, humi) values (@time, @temp, @humi)";
            command.Parameters.Add("@time", MySqlDbType.VarChar).Value = DateTime.Now.ToString("HH:mm:ss");
            command.Parameters.Add("@temp", MySqlDbType.VarChar).Value = Data_1.ToString();
            command.Parameters.Add("@humi", MySqlDbType.VarChar).Value = Data_2.ToString();
            command.ExecuteNonQuery();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(btnStart.Text == "Start")
            {
                btnStart.Text = "Stop";
                timer1.Start();
            }
            else
            {
                btnStart.Text = "Start";
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int rndData1 = rnd.Next(0, 100);
            int rndData2 = rnd.Next(100, 200);

            Temp.Text = rndData1.ToString();
            Humi.Text = rndData2.ToString();

            InsertData(rndData1, rndData2);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if(conn.State == ConnectionState.Open)
            {
                try
                {
                    string sql = textBox1.Text;

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    textBox1.Text = "";
                }
                catch(MySqlException ex)
                {
                    statuslabel.Text = ex.ToString();
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                if(e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        string sql = textBox1.Text;

                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();

                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                        textBox1.Text = "";
                    }
                    catch (MySqlException ex)
                    {
                        statuslabel.Text = ex.ToString();
                    }
                }
                
            }
        }
    }
}
