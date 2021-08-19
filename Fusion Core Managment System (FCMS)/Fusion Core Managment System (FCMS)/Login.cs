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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new(@"Data Source=DESKTOP-ULD3F7L\SQLEXPRESS;Initial Catalog=FusionInventory;Integrated Security=True");
            SqlDataAdapter sda = new(@"SELECT *
            FROM [FusionInventory].[dbo].[login] WHERE username='"+ usernametxt.Text +"' and password='"+ passwordtxt.Text +"'",con);
            DataTable dt = new();
            sda.Fill(dt);

            //Validation if user name enterred is or is not correct 
            if (dt.Rows.Count == 1)
            {
                Main2 main = new();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            usernametxt.Clear();
            passwordtxt.Clear();
            usernametxt.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
