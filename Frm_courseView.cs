using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_courseView : Form
    {
        public static String CourseId;
        public static int flag = 0;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        public Frm_courseView()
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
                    cmd.Parameters.AddWithValue("@para", "parameter");                
                else
                    cmd.Parameters.AddWithValue("@para", txtbx_usn_name.Text);
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
                    dataGridView1.ColumnCount = 4;


                    //Add Columns

                    dataGridView1.Columns[1].HeaderText = "Code";
                    dataGridView1.Columns[1].Name = "Code";
                    dataGridView1.Columns[1].DataPropertyName = "Course_Code";
                    dataGridView1.Columns[1].Width = 120;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[2].Name = "Name";
                    dataGridView1.Columns[2].HeaderText = "Name";
                    dataGridView1.Columns[2].DataPropertyName = "Course_Name";
                    dataGridView1.Columns[2].Width = 340;
                    dataGridView1.Columns[2].ReadOnly = true;


                    // THESE ARE NOT DISPLAYED . FOR PROGRAMMING PURPOSE ONLY //

                    dataGridView1.Columns[3].DataPropertyName = "Course_Id";
                    dataGridView1.Columns[3].Visible = false;
                   
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
        private void Frm_courseView_Load(object sender, EventArgs e)
        {
            Load_GridView("Prc_ViewCourse", 1);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void txtbx_usn_name_TextChanged(object sender, EventArgs e)
        {
            Load_GridView("Prc_ViewCourse", 2);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                flag = 1;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                //populate the textbox from specific value of the coordinates of column and row.
                Frm_courseView.CourseId = row.Cells[3].Value.ToString();
                
                Frm_course fc = new Frm_course();                
                fc.Show();                
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Load_GridView("Prc_ViewCourse", 1);
            txtbx_usn_name.Text = "";
        }
    }
}
