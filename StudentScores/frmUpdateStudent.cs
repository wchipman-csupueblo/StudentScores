using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class frmUpdateStudent : Form
    {
        public frmUpdateStudent()
        {
            InitializeComponent();
        }

       Student student = new Student();

        private void frmUpdateStudent_Load(object sender, EventArgs e)
        {
            Student s = (Student)Tag;
            student = (Student)s.Clone();

            lblName.Text = student.Name;
            DisplayScores();
            if (student.Scores.Count > 1)
                lstStudentScores.SelectedIndex = 0;
        }

        private void DisplayScores()
        {
            lstStudentScores.Items.Clear();
            if (student.Scores.Count > 0)
            {
                foreach (int i in student.Scores)
                {
                    lstStudentScores.Items.Add(i);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addForm = new frmAddUpdateScore();

            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                int score = (int)addForm.Tag;
                student.Scores.Add(score);
                DisplayScores();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstStudentScores.SelectedIndex;
            if (selectedIndex > -1)
            {
                Form updateForm = new frmAddUpdateScore
                {
                    Text = "Update Score",
                    Tag = lstStudentScores.SelectedItem
                };

                DialogResult result = updateForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int score = (int)updateForm.Tag;
                    student.Scores.RemoveAt(selectedIndex);
                    student.Scores.Insert(selectedIndex, score);
                    DisplayScores();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (student.Scores.Count > 0)
            {
                student.Scores.RemoveAt(lstStudentScores.SelectedIndex);
                DisplayScores();
            }
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            student.Scores.Clear();
            lstStudentScores.Items.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Tag = student;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
