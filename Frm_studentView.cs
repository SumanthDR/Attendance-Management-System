using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_studentView : Form
    {
        int flag = 0;
        public static int flag1 = 0;
        public static String studentid="0";
        String connectionString= ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        public Frm_studentView()
        {
            InitializeComponent();
        }
        private void Load_GridView(string prc, int flag)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(prc, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (flag == 1)
                    cmd.Parameters.AddWithValue("@para", "");
                else if (flag == 2)
                    cmd.Parameters.AddWithValue("@para", txtbx_USN_name.Text);
                else if (flag == 3)
                    cmd.Parameters.AddWithValue("@para", txtbx_batch.Text);
                else if (flag == 4)
                    cmd.Parameters.AddWithValue("@para", combo_course.SelectedValue);
                cmd.Parameters.AddWithValue("@flag", flag);                
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


                    //Add Columns

                    dataGridView1.Columns[1].HeaderText = "USN";
                    dataGridView1.Columns[1].Name = "USN";
                    dataGridView1.Columns[1].DataPropertyName = "Student_USN";
                    dataGridView1.Columns[1].Width = 120;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[2].Name = "Name";
                    dataGridView1.Columns[2].HeaderText = "Name";
                    dataGridView1.Columns[2].DataPropertyName = "Student_Name";
                    dataGridView1.Columns[2].Width = 200;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Columns[3].Name = "Course_Code";
                    dataGridView1.Columns[3].HeaderText = "Course Code";
                    dataGridView1.Columns[3].DataPropertyName = "Course_Code";
                    dataGridView1.Columns[3].Width = 140;
                    dataGridView1.Columns[3].ReadOnly = true;

                    dataGridView1.Columns[4].Name = "Semester";
                    dataGridView1.Columns[4].HeaderText = "Semester";
                    dataGridView1.Columns[4].DataPropertyName = "Student_Sem";
                    dataGridView1.Columns[4].Width = 90;
                    dataGridView1.Columns[4].ReadOnly = true;

                    dataGridView1.Columns[5].Name = "Batch";
                    dataGridView1.Columns[5].HeaderText = "Batch";
                    dataGridView1.Columns[5].DataPropertyName = "Student_Batch";
                    dataGridView1.Columns[5].Width = 90;
                    dataGridView1.Columns[5].ReadOnly = true;


                    // THESE ARE NOT DISPLAYED . FOR PROGRAMMING PURPOSE ONLY //

                    dataGridView1.Columns[6].DataPropertyName = "Student_Id";
                    dataGridView1.Columns[6].Visible = false;

                    dataGridView1.Columns[7].DataPropertyName = "Course_Id";
                    dataGridView1.Columns[7].Visible = false;

                    ///     CREATES BUTTON IN DATAGRID VIEW  /////////////////
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Add(btn);
                    btn.HeaderText = "Action";
                    btn.Text = "View";
                    btn.Name = "btnGrid_Edit";
                    btn.UseColumnTextForButtonValue = true;
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
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void Frm_studentView_Load(object sender, EventArgs e)
        {
            Frm_homeAdmin.Load_SubjectCombo(combo_course);
            Load_GridView("Prc_ViewStudent", 1);
            flag = 1;
        }

        private void txtbx_USN_name_TextChanged(object sender, EventArgs e)
        {
            Load_GridView("Prc_ViewStudent", 2);
        }

        private void btn_batch_Click(object sender, EventArgs e)
        {
            txtbx_USN_name.Text = "";
            combo_course.Text = "Select";
            Load_GridView("Prc_ViewStudent", 3);
            if (dataGridView1.Rows.Count == 0)
                MessageBox.Show("No Records found!");
        }

        private void combo_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(flag==1)
            Load_GridView("Prc_ViewStudent", 4);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txtbx_batch.Text = "";
            combo_course.Text = "Select";
            txtbx_USN_name.Text = "";
            Load_GridView("Prc_ViewStudent", 1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==8)
            {
                flag1 = 1;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                Frm_studentView.studentid = row.Cells[6].Value.ToString();
                Frm_student fst = new Frm_student();
                fst.Show();
            }
        }
    }
}
