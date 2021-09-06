using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_attendance : Form
    {
        public Frm_attendance()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;

        private void Load_GridView()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Prc_TakeAttendance", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@class_id", Frm_classView.ClassId);
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
                    dataGridView1.ColumnCount = 12;


                    //Add Columns

                    dataGridView1.Columns[1].HeaderText = "USN";
                    dataGridView1.Columns[1].Name = "usn";
                    dataGridView1.Columns[1].DataPropertyName = "Student_USN";
                    dataGridView1.Columns[1].Width = 120;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[2].HeaderText = "Name";
                    dataGridView1.Columns[2].Name = "name";                    
                    dataGridView1.Columns[2].DataPropertyName = "Student_Name";
                    dataGridView1.Columns[2].Width = 140;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Columns[3].HeaderText = "Course";
                    dataGridView1.Columns[3].Name = "course";
                    dataGridView1.Columns[3].DataPropertyName = "Course_Code";
                    dataGridView1.Columns[3].Width = 120;
                    dataGridView1.Columns[3].ReadOnly = true;

                    dataGridView1.Columns[4].HeaderText = "Subject";
                    dataGridView1.Columns[4].Name = "subject";
                    dataGridView1.Columns[4].DataPropertyName = "Subject_Code";
                    dataGridView1.Columns[4].Width = 140;
                    dataGridView1.Columns[4].ReadOnly = true;

                    dataGridView1.Columns[5].HeaderText = "Batch";
                    dataGridView1.Columns[5].Name = "batch";
                    dataGridView1.Columns[5].DataPropertyName = "Class_Batch";
                    dataGridView1.Columns[5].Width = 80;
                    dataGridView1.Columns[5].ReadOnly = true;

                    dataGridView1.Columns[6].HeaderText = "Date";
                    dataGridView1.Columns[6].Name = "date";                    
                    dataGridView1.Columns[6].DataPropertyName = "Class_Date";
                    dataGridView1.Columns[6].Width = 140;
                    dataGridView1.Columns[6].ReadOnly = true;

                    dataGridView1.Columns[7].HeaderText = "No. Hours";
                    dataGridView1.Columns[7].Name = "hours";
                    dataGridView1.Columns[7].DataPropertyName = "Class_HrsTaken";
                    dataGridView1.Columns[7].Width = 60;
                    dataGridView1.Columns[7].ReadOnly = true;
                    // THESE ARE NOT DISPLAYED . FOR PROGRAMMING PURPOSE ONLY //

                    dataGridView1.Columns[8].Name = "Class_Id";
                    dataGridView1.Columns[8].DataPropertyName = "Class_Id";
                    dataGridView1.Columns[8].Visible = false;

                    dataGridView1.Columns[9].Name = "Course_Id";
                    dataGridView1.Columns[9].DataPropertyName = "Course_Id";
                    dataGridView1.Columns[9].Visible = false;

                    dataGridView1.Columns[10].Name = "Subject_Id";
                    dataGridView1.Columns[10].DataPropertyName = "Subject_Id";
                    dataGridView1.Columns[10].Visible = false;

                    dataGridView1.Columns[11].Name = "Student_Id";
                    dataGridView1.Columns[11].DataPropertyName = "Student_Id";
                    dataGridView1.Columns[11].Visible = false;

                    ///     CREATES BUTTON IN DATAGRID VIEW  /////////////////
                    DataGridViewCheckBoxColumn chkbx = new DataGridViewCheckBoxColumn();
                    dataGridView1.Columns.Add(chkbx);                    
                    chkbx.Name = "btn_attendance";
                    chkbx.HeaderText = "Students on leave";                    
                    chkbx.FalseValue = 0;                    
                    chkbx.TrueValue = 1;                                     
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong please try again !! \n\n" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void Frm_attendance_Load(object sender, EventArgs e)
        {
            Load_GridView();

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                row.Cells[12].Value = row.Cells[12].Value == null ? false :false;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    SqlCommand cmd = new SqlCommand("Prc_InsertAttendance", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    if (dr.IsNewRow) continue;
                    {
                        cmd.Parameters.AddWithValue("@attendance_stuid", dr.Cells["Student_Id"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@attendance_classid", dr.Cells["Class_Id"].Value ?? DBNull.Value);                        
                        cmd.Parameters.AddWithValue("@attendance_absent", dr.Cells["btn_attendance"].Value ?? DBNull.Value);
                        cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                        cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lbl_status.Text=((string)cmd.Parameters["@ERROR"].Value);
                    }
                }
                dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong, Please try again !! \n\n" + ex);
            }
            finally { con.Close(); }
        }
    }
}
