using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ZmyStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Zahid\Documents\ZmyStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) From ZloginTB where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Dashboard ss = new Dashboard();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Please check your User name and password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
