using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_attendanceView : Form
    {
        int i = 0;
        string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        public Frm_attendanceView()
        {
            InitializeComponent();
        }

        private void Frm_attendanceView_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Prc_ExtractSubject", con);
                cmd.Parameters.AddWithValue("@Para", "");
                cmd.Parameters.AddWithValue("@flag", 3);
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

        private void btn_ok_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionStr);
            try
            {
                SqlCommand cmd = new SqlCommand("Prc_ViewAttendance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@class_batch", txtbx_batch.Text);
                cmd.Parameters.AddWithValue("@class_date", datetime_attendance.Text);
                cmd.Parameters.AddWithValue("@class_subid", combo_subject.SelectedValue);
                con.Open();
                using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    adt.Fill(dt);

                    ///     CREATES BUTTON IN DATAGRID VIEW  /////////////////

                    // Clear binding
                    dataGridView1.DataSource = null;

                    //Set AutoGenerateColumns False
                    dataGridView1.AutoGenerateColumns = false;

                    //Set Columns Count
                    dataGridView1.ColumnCount = 8;

                    dataGridView1.Columns[1].HeaderText = "USN";
                    dataGridView1.Columns[1].Name = "usn";
                    dataGridView1.Columns[1].DataPropertyName = "Student_USN";
                    dataGridView1.Columns[1].Width = 100;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[2].HeaderText = "Name";
                    dataGridView1.Columns[2].Name = "name";
                    dataGridView1.Columns[2].DataPropertyName = "Student_Name";
                    dataGridView1.Columns[2].Width = 160;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Columns[3].HeaderText = "Course";
                    dataGridView1.Columns[3].Name = "coursecode";
                    dataGridView1.Columns[3].DataPropertyName = "Course_Code";
                    dataGridView1.Columns[3].Width = 140;
                    dataGridView1.Columns[3].ReadOnly = true;

                    dataGridView1.Columns[4].HeaderText = "Subject";
                    dataGridView1.Columns[4].Name = "subjectcode";
                    dataGridView1.Columns[4].DataPropertyName = "Subject_Code";
                    dataGridView1.Columns[4].Width = 120;
                    dataGridView1.Columns[4].ReadOnly = true;

                    dataGridView1.Columns[5].HeaderText = "Batch";
                    dataGridView1.Columns[5].Name = "batch";
                    dataGridView1.Columns[5].DataPropertyName = "Student_Batch";
                    dataGridView1.Columns[5].Width = 140;
                    dataGridView1.Columns[5].ReadOnly = true;

                    dataGridView1.Columns[6].HeaderText = "Attendance_value";
                    dataGridView1.Columns[6].Name = "attendance_value";
                    dataGridView1.Columns[6].DataPropertyName = "Attendance_Absent";                    
                    dataGridView1.Columns[6].Width = 120;
                    dataGridView1.Columns[6].ReadOnly = true;
                    dataGridView1.Columns[6].Visible = false;

                    dataGridView1.Columns[7].HeaderText = "Attendance";
                    dataGridView1.Columns[7].Name = "attendance_trck";                    
                    dataGridView1.Columns[7].Width = 120;
                    dataGridView1.Columns[7].ReadOnly = true;

                    dataGridView1.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong\n\n" + ex);
            }
            finally { con.Close(); }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                if (row.Cells["attendance_value"].Value.ToString() == "0")                
                    dataGridView1.Rows[i].Cells["attendance_trck"].Value = "PRESENT";               
                else
                    dataGridView1.Rows[i].Cells["attendance_trck"].Value = "ABSENT";
                i++;             
            }
            i = 0;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
