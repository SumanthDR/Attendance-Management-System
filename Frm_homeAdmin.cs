using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_homeAdmin : Form
    {
        public static int flag = 0;
       // string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        public Frm_homeAdmin()
        {
            InitializeComponent();
        }

        //==========================BIND COURSE INTO COMBO_BOX =================================== //

        public static void Load_SubjectCombo(ComboBox cmb)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Prc_ExtractCourse", con);                
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();                
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                cmb.DataSource = dt;
                cmb.DisplayMember = "value";
                cmb.ValueMember = "keys";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong please try again !! \n\n" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        public void openMdiChild(Form FormOpen)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();            
            FormOpen.MdiParent = this;
            FormOpen.Show();
        }
        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_course fc = new Frm_course();
            openMdiChild(fc);
        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_subject fs = new Frm_subject();
            openMdiChild(fs);
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_student fst = new Frm_student();
            openMdiChild(fst);
        }

        private void courseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_courseView fcv = new Frm_courseView();
            openMdiChild(fcv);
        }

        private void subjectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_subjectView fsv = new Frm_subjectView();
            openMdiChild(fsv);
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_studentView fstv = new Frm_studentView();
            openMdiChild(fstv);
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_class fcs = new Frm_class();
            openMdiChild(fcs);
        }

        private void classToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_classView fcsv = new Frm_classView();
            openMdiChild(fcsv);
        }

        private void statisticalViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_attendanceView fav = new Frm_attendanceView();
            openMdiChild(fav);
        }

        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_help fh = new Frm_help();
            openMdiChild(fh);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_about fa = new Frm_about();
            openMdiChild(fa);
        }
    }
}
