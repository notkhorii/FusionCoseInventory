using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fusion_Core_Managment_System__FCMS_
{
    public partial class Main2 : Form
    {
        private bool isCollapsed;
        public Main2()
        {
            InitializeComponent();
            cdesign();
        }
        private void cdesign()
        {

        }
  //      private void dropdown()
  //      {

  //      }

        private void reportbtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
 //           dropdown();
 //           showdropdown();
        }

        private void Main2_Load(object sender, EventArgs e)
        {

        }



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                reportdropdown.Height += 10;
                if (reportdropdown.Size == reportdropdown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                if (isCollapsed)
                {
                    reportdropdown.Height -= 10;
                    if (reportdropdown.Size == reportdropdown.MinimumSize)
                    {
                        timer1.Stop();
                        isCollapsed = true;
                    }
                }
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            
                activeForm.Close();
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                Childformpanel.Controls.Add(childForm);
                Childformpanel.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            
        }
        private void reportbtn1_Click(object sender, EventArgs e)
        {

        }

        private void Childformpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            Login login = new();
            login.Show();
            this.Hide();

        }

        private void productbtn_Click(object sender, EventArgs e)
        {
            products pr = new products();
            //          openChildForm(new products());
            pr.Show();




        }

        private void panelsidemenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
