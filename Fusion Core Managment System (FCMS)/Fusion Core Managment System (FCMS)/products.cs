using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fusion_Core_Managment_System__FCMS_
{
    public partial class products : Form
    {
        public products()
        {
            InitializeComponent();
        }

        private void products_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            loadtable();
        }

            //in the thrid 
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {   
            //Code to insert Data into database and table..
            SqlConnection con = new(@"Data Source=DESKTOP-ULD3F7L\SQLEXPRESS;Initial Catalog=FusionInventory;Integrated Security=True");
            con.Open();
            bool status = false;
            if(comboBox1.SelectedIndex == 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }


            // Update Functionality..
            var sqlQuery = "";
            if (Ifproductexists(con, textBox1.Text))
            {
                sqlQuery = @"UPDATE [Products] SET [Product Name] = '" + textBox2.Text + "' ,[Status] = '" + status + "' WHERE [Product Code] = '" + textBox1.Text + "'";
                addbtn.Text = "Update";
            }
            else
            {
                sqlQuery = @"INSERT INTO [dbo].[Products] ([Product Code] ,[Product Name] ,[Status]) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + status + "')";
            }

            SqlCommand inscmd = new(sqlQuery, con);
            inscmd.ExecuteNonQuery();
            con.Close();

            //Reading data that was inserted into the table using a method..  
            loadtable();

        }
        //update method
        private bool Ifproductexists(SqlConnection con, string productCode)
        {
            SqlDataAdapter sda = new("Select 1 From [Products] WHERE [Product Code] = '" + productCode +"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                addbtn.Text = "Update";
                return true;
            }
            else
            {
                return false;
            }
        }
        public void loadtable()
        {
            SqlConnection con = new(@"Data Source=DESKTOP-ULD3F7L\SQLEXPRESS;Initial Catalog=FusionInventory;Integrated Security=True");
            SqlDataAdapter sda = new("Select * From [FusionInventory].[dbo].[Products]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["Product Code"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Product Name"].ToString();
                if ((bool)item["Status"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }

            }
        }

        //DataGridView..
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
            comboBox1.SelectedText = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            addbtn.Text = "Update";
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new(@"Data Source=DESKTOP-ULD3F7L\SQLEXPRESS;Initial Catalog=FusionInventory;Integrated Security=True");
            var sqlQuery = "";
            if (Ifproductexists(con, textBox1.Text))
            {
                sqlQuery = @"DELETE FROM [Products] WHERE [Product Code] = '" + textBox1.Text + "'";
                con.Open();
                SqlCommand inscmd = new(sqlQuery, con);
                inscmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Record does not exists");
            }

            //Reading data that was inserted into the table using a method..  
            loadtable();
        }
    }
}
