using System;
using System.Windows.Forms;
using System.Threading;

namespace QuizMgmtSystem
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();            
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            if((txtbx_name.Text=="admin")&&(txtbx_passwd.Text=="admin"))
            {
                this.Hide();
                Frm_homeAdmin fha = new Frm_homeAdmin();
                fha.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username and Password!!");
            }
        }
    }
}
