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
    public partial class frmStudentScores : Form
    {
        public frmStudentScores()
        {
            InitializeComponent();
        }

        public List<Student> students = new List<Student>();

        private void frmStudentScores_Load(object sender, EventArgs e)
        {
            students = StudentDB.GetStudents();
            LoadStudentListBox();
        }

        private void LoadStudentListBox(int selectedIndex = 0)
        {
            lstStudents.Items.Clear();

            students = students.OrderBy(s => s.Name).ToList();

            foreach(Student s in students)
            {
                lstStudents.Items.Add(s);
            }

            if (lstStudents.Items.Count > 0)
            {
                lstStudents.SelectedIndex = selectedIndex;
            }
            else
            {
                ClearLabels();
            }

            lstStudents.Focus();

        }

        private void ClearLabels()
        {
            lblScoreCount.Text = "";
            lblAverage.Text = "";
            lblScoreTotal.Text = "";
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStudents.SelectedIndex != -1)
            {
                Student student = (Student)lstStudents.SelectedItem;

                lblScoreTotal.Text = student.ScoreTotal.ToString();
                lblScoreCount.Text = student.ScoreCount.ToString();
                lblAverage.Text = student.ScoreAverage.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (students.Count > 0)
            {
                students.RemoveAt(lstStudents.SelectedIndex);
                StudentDB.SaveStudents(students);
                LoadStudentListBox();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form addForm = new frmAddNewStudent();
            DialogResult result = addForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                students.Add((Student)addForm.Tag);
                StudentDB.SaveStudents(students);
                LoadStudentListBox();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (students.Count > 0 )
            {
                Student student = (Student)lstStudents.SelectedItem;

                Form updateForm = new frmUpdateStudent();
                updateForm.Tag = student;

                DialogResult result = updateForm.ShowDialog();
                if (result == DialogResult.OK) {
                    students.RemoveAt(lstStudents.SelectedIndex);
                    students.Insert(lstStudents.SelectedIndex, (Student)updateForm.Tag);

                    StudentDB.SaveStudents(students);
                    LoadStudentListBox();
                }
            }
        }
    }
}
