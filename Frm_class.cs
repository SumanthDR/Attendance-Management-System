using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{

    public partial class Frm_class : Form
    {
        public static int flag = 0;
        int done = 0;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        public Frm_class()
        {
            InitializeComponent();
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };
            func(Controls);
        }
        public void Load_Combo()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Prc_ExtractSubject", con);
                cmd.Parameters.AddWithValue("@Para", combo_course.SelectedValue);
                cmd.Parameters.AddWithValue("@flag", 1);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                combo_subject.DataSource = dt;
                combo_subject.DisplayMember = "id_value";
                combo_subject.ValueMember = "id_key";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong please try again !! \n\n" + ex);
            }
            finally { con.Close(); }
        }
        private void Frm_Class_Load(object sender, EventArgs e)
        {
            Frm_homeAdmin.Load_SubjectCombo(combo_course);
            Load_Combo();
            done = 1;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Prc_InsertClass", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@class_crsid", combo_course.SelectedValue);
            cmd.Parameters.AddWithValue("@class_subid", combo_subject.SelectedValue);
            cmd.Parameters.AddWithValue("@class_batch", txtbx_batch.Text);
            cmd.Parameters.AddWithValue("@class_totalhrs", 1);
            cmd.Parameters.AddWithValue("@class_hrstaken", txtbx_hrs_taken.Text);
            cmd.Parameters.AddWithValue("@class_date", dateTime_class.Text);
            cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                String msg = (string)cmd.Parameters["@ERROR"].Value;
                MessageBox.Show(msg);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Operation failed" + ex);
            }
            finally
            {
                con.Close();
                ClearTextBoxes();
            }
        }

        private void combo_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (done == 1)
            {
                combo_subject.Text = "";
                Load_Combo();
            }
        }

        private void combo_course_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void combo_subject_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }        
}
