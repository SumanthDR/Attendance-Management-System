using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_student : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;        
        public Frm_student()
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
        public void saveUpdate(int flag)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Prc_InsertStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag",flag);
            cmd.Parameters.AddWithValue("@student_id", Frm_studentView.studentid);
            cmd.Parameters.AddWithValue("@student_usn", txtbx_usn.Text);
            cmd.Parameters.AddWithValue("@student_name", txtbx_name.Text);
            cmd.Parameters.AddWithValue("@student_crsid", combo_course.SelectedValue);
            cmd.Parameters.AddWithValue("@student_sem", "X");
            cmd.Parameters.AddWithValue("@student_batch", txtbx_batch.Text);
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
        private void Frm_student_Load(object sender, EventArgs e)
        {
            Frm_homeAdmin.Load_SubjectCombo(combo_course);
            if(Frm_studentView.flag1==1)
            {
                txtbx_usn.Enabled = false;
                txtbx_name.Enabled = false;
                combo_course.Enabled = false;
                combo_semester.Enabled = false;
                txtbx_batch.Enabled = false;

                btn_edit.Visible = true;
                btn_Update.Visible = false;
                btn_cancel.Visible = false;
                btn_save.Visible = false;

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Prc_ViewStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", 5);
                cmd.Parameters.AddWithValue("@para", Frm_studentView.studentid);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtbx_usn.Text = dr["Student_USN"].ToString();
                        txtbx_name.Text = dr["Student_Name"].ToString();
                        combo_course.Text = dr["Course_Code"].ToString();
                        combo_semester.Text = dr["Student_Sem"].ToString();
                        txtbx_batch.Text = dr["Student_Batch"].ToString();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Something went wrong !!\n\n" + ex);
                }
                finally { con.Close(); }

                Frm_studentView.flag1 = 0;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            saveUpdate(1);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            txtbx_usn.Enabled = true;
            txtbx_name.Enabled = true;
            combo_course.Enabled = true;
            combo_semester.Enabled = true;
            txtbx_batch.Enabled = true;

            btn_edit.Visible = false;
            btn_Update.Visible = true;
            btn_cancel.Visible = true;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            saveUpdate(2);
        }

        private void combo_course_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void combo_semester_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
