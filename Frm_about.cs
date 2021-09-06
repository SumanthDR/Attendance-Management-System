using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_about : Form
    {
        public Frm_about()
        {
            InitializeComponent();
        }
        
        private void linkLabel_web_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.sumanthgowdacom.wordpress.com");
        }

        private void linkLabel_email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:drgowda6@gmail.com");
        }
    }
}
