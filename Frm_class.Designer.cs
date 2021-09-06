
namespace QuizMgmtSystem
{
    partial class Frm_class
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.combo_course = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combo_subject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_ttlhrs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbx_hrs_taken = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTime_class = new System.Windows.Forms.DateTimePicker();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txtbx_batch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(256, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Class";
            // 
            // combo_course
            // 
            this.combo_course.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.combo_course.FormattingEnabled = true;
            this.combo_course.Location = new System.Drawing.Point(181, 74);
            this.combo_course.Name = "combo_course";
            this.combo_course.Size = new System.Drawing.Size(375, 29);
            this.combo_course.TabIndex = 40;
            this.combo_course.SelectedIndexChanged += new System.EventHandler(this.combo_course_SelectedIndexChanged);
            this.combo_course.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_course_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(67, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 21);
            this.label5.TabIndex = 39;
            this.label5.Text = "Course Code";
            // 
            // combo_subject
            // 
            this.combo_subject.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.combo_subject.FormattingEnabled = true;
            this.combo_subject.Location = new System.Drawing.Point(181, 135);
            this.combo_subject.Name = "combo_subject";
            this.combo_subject.Size = new System.Drawing.Size(375, 29);
            this.combo_subject.TabIndex = 42;
            this.combo_subject.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_subject_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 41;
            this.label2.Text = "Subject Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 43;
            this.label3.Text = "Batch";
            // 
            // txtbx_ttlhrs
            // 
            this.txtbx_ttlhrs.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_ttlhrs.Location = new System.Drawing.Point(181, 242);
            this.txtbx_ttlhrs.Name = "txtbx_ttlhrs";
            this.txtbx_ttlhrs.ReadOnly = true;
            this.txtbx_ttlhrs.Size = new System.Drawing.Size(183, 25);
            this.txtbx_ttlhrs.TabIndex = 46;
            this.txtbx_ttlhrs.Text = "60";
            this.txtbx_ttlhrs.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 21);
            this.label4.TabIndex = 45;
            this.label4.Text = "No. of Hrs Allotted";
            this.label4.Visible = false;
            // 
            // txtbx_hrs_taken
            // 
            this.txtbx_hrs_taken.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_hrs_taken.Location = new System.Drawing.Point(181, 291);
            this.txtbx_hrs_taken.Name = "txtbx_hrs_taken";
            this.txtbx_hrs_taken.Size = new System.Drawing.Size(183, 25);
            this.txtbx_hrs_taken.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 21);
            this.label6.TabIndex = 47;
            this.label6.Text = "No of Hours Taken";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 21);
            this.label7.TabIndex = 49;
            this.label7.Text = "Date of Class Taken";
            // 
            // dateTime_class
            // 
            this.dateTime_class.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTime_class.Location = new System.Drawing.Point(181, 338);
            this.dateTime_class.Name = "dateTime_class";
            this.dateTime_class.Size = new System.Drawing.Size(183, 27);
            this.dateTime_class.TabIndex = 50;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_save.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(471, 410);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(85, 31);
            this.btn_save.TabIndex = 52;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(361, 410);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(85, 31);
            this.btn_cancel.TabIndex = 51;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // txtbx_batch
            // 
            this.txtbx_batch.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_batch.Location = new System.Drawing.Point(181, 192);
            this.txtbx_batch.Name = "txtbx_batch";
            this.txtbx_batch.Size = new System.Drawing.Size(183, 25);
            this.txtbx_batch.TabIndex = 44;
            // 
            // Frm_class
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 464);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.dateTime_class);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtbx_hrs_taken);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbx_ttlhrs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbx_batch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_subject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_course);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_class";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm_Class_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_course;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_subject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbx_ttlhrs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbx_hrs_taken;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTime_class;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox txtbx_batch;
    }
}