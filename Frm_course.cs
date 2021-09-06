using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_course : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        public Frm_course()
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
            SqlCommand cmd = new SqlCommand("Prc_InsertCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.Parameters.AddWithValue("@course_id", Frm_courseView.CourseId);
            cmd.Parameters.AddWithValue("@course_code", txtbx_crscode.Text);
            cmd.Parameters.AddWithValue("@course_name", txtbx_crsname.Text);
            cmd.Parameters.AddWithValue("@course_desc", txtbx_crsdesc.Text);
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
        private void btn_save_Click(object sender, EventArgs e)
        {
            Frm_courseView.CourseId = "0";
            saveUpdate(1);            
        }

        private void Frm_course_Load(object sender, EventArgs e)
        {
            if(Frm_courseView.flag==1)
            {                
                txtbx_crscode.Enabled = false;
                txtbx_crsdesc.Enabled = false;
                txtbx_crsname.Enabled = false;
                btn_edit.Visible = true;
                btn_cancel.Visible = false;
                btn_save.Visible = false;

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Prc_ViewCourse",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", 3);
                cmd.Parameters.AddWithValue("@para", Frm_courseView.CourseId);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtbx_crscode.Text = dr["Course_Code"].ToString();
                        txtbx_crsname.Text = dr["Course_Name"].ToString();
                        txtbx_crsdesc.Text = dr["Course_Desc"].ToString();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Something went wrong !!\n\n" + ex);
                }
                finally { con.Close(); }
                
                Frm_courseView.flag = 0;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            txtbx_crscode.Enabled = true;
            txtbx_crsdesc.Enabled = true;
            txtbx_crsname.Enabled = true;
            btn_edit.Visible = false;            
            btn_update.Visible = true;
            btn_cancel.Visible = true;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            saveUpdate(2);
        }
    }
}
