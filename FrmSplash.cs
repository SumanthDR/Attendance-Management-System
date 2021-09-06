using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {

            InitializeComponent();
             
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 2;
            if(panel2.Width >= 700)
            {
                timer1.Stop();
                Frm_Login frmLogin = new Frm_Login();
                frmLogin.Show();
                this.Hide();
            }
        }
    }
}
