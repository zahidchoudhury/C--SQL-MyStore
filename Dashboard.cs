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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void insertBT_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Zahid\Documents\ZmyStoreDB.mdf;Integrated Security=True;Connect Timeout=30");

            {
                con.Open();
                var sql = "INSERT INTO productTable(ProductName, ProductQuantity, ProductPrice, ProductCategory) VALUES(@prnames, @pquantitys, @pprices, @pcategorys)";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@prnames", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pquantitys", textBox2.Text);
                    cmd.Parameters.AddWithValue("@pprices", textBox3.Text);
                    cmd.Parameters.AddWithValue("@pcategorys", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
            }

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'zmyStoreDBDataSet2.productTable' table. You can move, or remove it, as needed.
            this.productTableTableAdapter.Fill(this.zmyStoreDBDataSet2.productTable);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
