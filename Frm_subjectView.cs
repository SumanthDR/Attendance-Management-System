using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMgmtSystem
{
    public partial class Frm_subjectView : Form
    {
        public static int flag = 0;
        public static string Subject_id="0";
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        public Frm_subjectView()
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
                else if (flag == 3)
                    cmd.Parameters.AddWithValue("@para", txtbx_sub_code_name.Text);
                else if (flag == 2)
                    cmd.Parameters.AddWithValue("@para", "");                  
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
                    dataGridView1.ColumnCount = 7;


                    //Add Columns

                    dataGridView1.Columns[1].HeaderText = "Code";
                    dataGridView1.Columns[1].Name = "Code";
                    dataGridView1.Columns[1].DataPropertyName = "Subject_Code";
                    dataGridView1.Columns[1].Width = 120;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[2].Name = "Name";
                    dataGridView1.Columns[2].HeaderText = "Name";
                    dataGridView1.Columns[2].DataPropertyName = "Subject_Name";
                    dataGridView1.Columns[2].Width = 200;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Columns[3].Name = "Course_Code";
                    dataGridView1.Columns[3].HeaderText = "Course Code";
                    dataGridView1.Columns[3].DataPropertyName = "Course_Code";
                    dataGridView1.Columns[3].Width = 140;
                    dataGridView1.Columns[3].ReadOnly = true;

                    dataGridView1.Columns[4].Name = "Subject_Sem";
                    dataGridView1.Columns[4].HeaderText = "Semester";
                    dataGridView1.Columns[4].DataPropertyName = "Subject_Sem";
                    dataGridView1.Columns[4].Width = 90;
                    dataGridView1.Columns[4].ReadOnly = true;


                    // THESE ARE NOT DISPLAYED . FOR PROGRAMMING PURPOSE ONLY //

                    dataGridView1.Columns[5].DataPropertyName = "Subject_Id";
                    dataGridView1.Columns[5].Visible = false;

                    dataGridView1.Columns[6].DataPropertyName = "Subject_CrsId";
                    dataGridView1.Columns[6].Visible = false;                    

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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void Frm_subjectView_Load(object sender, EventArgs e)
        {            
            Load_GridView("Prc_ViewSubject", 1);          
        }

        private void txtbx_sub_code_name_TextChanged(object sender, EventArgs e)
        {
            Load_GridView("Prc_ViewSubject", 3);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txtbx_sub_code_name.Text = "";            
            Load_GridView("Prc_ViewSubject", 1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                Frm_subjectView.flag = 1;
                //populate the textbox from specific value of the coordinates of column and row.
               Frm_subjectView.Subject_id= row.Cells[5].Value.ToString();
                Frm_subject fs = new Frm_subject();
                fs.Show();
            }
        }
    }
}
