using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_subject : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;        
        public Frm_subject()
        {
            InitializeComponent();
            //Frm_subjectView.Subject_id = "0";
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
        public void saveUpdate(int flag)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Prc_InsertSubject", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag",flag);
            cmd.Parameters.AddWithValue("@subject_id", Frm_subjectView.Subject_id);
            cmd.Parameters.AddWithValue("@subject_code", txtbx_subcode.Text);
            cmd.Parameters.AddWithValue("@subject_name", txtbx_subname.Text);
            cmd.Parameters.AddWithValue("@subject_crsid", combo_course.SelectedValue);
            cmd.Parameters.AddWithValue("@subject_sem", combo_semester.Text);
            cmd.Parameters.AddWithValue("@subject_totalhrs", txtbx_subtotalhrs.Text);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully");
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
        private void Frm_subject_Load(object sender, EventArgs e)
        {
            Frm_homeAdmin.Load_SubjectCombo(combo_course);
            if(Frm_subjectView.flag==1)
            {
                txtbx_subcode.Enabled = false;
                txtbx_subname.Enabled = false;
                combo_course.Enabled = false;
                combo_semester.Enabled = false;
                txtbx_subtotalhrs.Enabled = false;

                btn_edit.Visible = true;
                btn_save.Visible = false;
                btn_cancel.Visible = false;

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Prc_ViewSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", 4);
                cmd.Parameters.AddWithValue("@para", Frm_subjectView.Subject_id);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtbx_subcode.Text = dr["Subject_Code"].ToString();
                        txtbx_subname.Text = dr["Subject_Name"].ToString();
                        combo_course.Text = dr["Course_Code"].ToString();
                        combo_semester.Text = dr["Subject_Sem"].ToString();
                        txtbx_subtotalhrs.Text = dr["Subject_TotalHrs"].ToString();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Something went wrong !!\n\n" + ex);
                }
                finally { con.Close(); }

                Frm_subjectView.flag = 0;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            saveUpdate(1);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            txtbx_subcode.Enabled = true;
            txtbx_subname.Enabled = true;
            combo_course.Enabled = true;
            combo_semester.Enabled = true;
            txtbx_subtotalhrs.Enabled = true;

            btn_edit.Visible = false;
            btn_update.Visible = true;
            btn_cancel.Visible = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            saveUpdate(2);
        }

        private void combo_course_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
