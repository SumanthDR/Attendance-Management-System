using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_classView : Form
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        public static string ClassId = "";
        int flag = 0;
        public Frm_classView()
        {
            InitializeComponent();
        }

        public void loadGridView(int flag)
        {
            SqlConnection con = new SqlConnection(connectionStr);
            try
            {
                SqlCommand cmd = new SqlCommand("Prc_ViewClass", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@flag", flag);
                if (flag == 1)
                    cmd.Parameters.AddWithValue("@para", datetime_classview.Text);
                if (flag == 2)
                    cmd.Parameters.AddWithValue("@para", txtbx_batch.Text);
                if (flag == 3)
                    cmd.Parameters.AddWithValue("@para", combo_subject.SelectedValue);                
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
                    dataGridView1.ColumnCount = 10;

                    dataGridView1.Columns[1].HeaderText = "Batch";
                    dataGridView1.Columns[1].Name = "batch";
                    dataGridView1.Columns[1].DataPropertyName = "Class_batch";
                    dataGridView1.Columns[1].Width = 100;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[2].HeaderText = "Course Code";
                    dataGridView1.Columns[2].Name = "coursecode";
                    dataGridView1.Columns[2].DataPropertyName = "Course_Code";
                    dataGridView1.Columns[2].Width = 160;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Columns[3].HeaderText = "Subject Code";
                    dataGridView1.Columns[3].Name = "subjectcode";
                    dataGridView1.Columns[3].DataPropertyName = "Subject_Code";
                    dataGridView1.Columns[3].Width = 140;
                    dataGridView1.Columns[3].ReadOnly = true;

                    dataGridView1.Columns[4].HeaderText = "Hours";
                    dataGridView1.Columns[4].Name = "hours";
                    dataGridView1.Columns[4].DataPropertyName = "Subject_TotalHrs";
                    dataGridView1.Columns[4].Width = 120;
                    dataGridView1.Columns[4].ReadOnly = true;

                    dataGridView1.Columns[5].HeaderText = "Hours Taken";
                    dataGridView1.Columns[5].Name = "hrstaken";
                    dataGridView1.Columns[5].DataPropertyName = "Class_HrsTaken";
                    dataGridView1.Columns[5].Width = 140;
                    dataGridView1.Columns[5].ReadOnly = true;

                    dataGridView1.Columns[6].HeaderText = "Date";
                    dataGridView1.Columns[6].Name = "date";
                    dataGridView1.Columns[6].DataPropertyName = "Class_Date";
                    dataGridView1.Columns[6].Width = 120;
                    dataGridView1.Columns[6].ReadOnly = true;

                    dataGridView1.Columns[7].DataPropertyName = "Class_Id";
                    dataGridView1.Columns[7].Visible = false;

                    dataGridView1.Columns[8].DataPropertyName = "Class_CrsId";
                    dataGridView1.Columns[8].Visible = false;

                    dataGridView1.Columns[9].DataPropertyName = "Class_SubId";
                    dataGridView1.Columns[9].Visible = false;

                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Add(btn);
                    btn.HeaderText = "Action";
                    btn.Text = "Attendance";
                    btn.Name = "btnGrid_Edit";
                    btn.UseColumnTextForButtonValue = true;
                    dataGridView1.DataSource = dt;
                }                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong\n\n"+ex);
            }
            finally { con.Close(); }
        }
        private void Frm_classView_Load(object sender, EventArgs e)
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
            datetime_classview.Text = "";
            combo_subject.Text = "";
            flag = 1;
        }

        private void datetime_classview_ValueChanged(object sender, EventArgs e)
        {
            txtbx_batch.Text = "";
            combo_subject.Text = "";
            loadGridView(1);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void combo_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbx_batch.Text = "";
            if(flag==1)
            loadGridView(3);
        }

        private void txtbx_batch_TextChanged(object sender, EventArgs e)
        {
            combo_subject.Text = "";
            if(flag==1)
            loadGridView(2);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txtbx_batch.Text = "";
            combo_subject.Text = "";
            datetime_classview.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                //populate the textbox from specific value of the coordinates of column and row.
                Frm_classView.ClassId = row.Cells[7].Value.ToString();

                Frm_attendance fa = new Frm_attendance();
                fa.Show();
            }
        }
    }
}
