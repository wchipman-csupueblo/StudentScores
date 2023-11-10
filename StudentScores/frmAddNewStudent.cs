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
    public partial class frmAddNewStudent : Form
    {
        public frmAddNewStudent()
        {
            InitializeComponent();
        }

        Student student = new Student();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidScore())
            {
                int score = Convert.ToInt32(txtScore.Text);
                student.Scores.Add(score);
                DisplayScores();
                txtScore.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            student.Scores.Clear();
            lblScores.Text = "";
            txtScore.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsValidName())
            {
                student.Name = txtName.Text;
                Tag = student;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayScores()
        {
            StringBuilder sb = new StringBuilder(); 
            foreach (int score in student.Scores)
            {
                sb.Append($"{score} ");
            }
            lblScores.Text = sb.ToString();
        }

        private bool IsValidScore()
        {
            bool success = true;

            StringBuilder sb = new StringBuilder();
            sb.Append(Validator.IsPresent(txtScore.Text, "Score"));
            sb.Append(Validator.IsInt32(txtScore.Text, "Score"));
            sb.Append(Validator.IsWithinRange(txtScore.Text, "Score", 0, 100));
            string errorMsg = sb.ToString();

            if (!String.IsNullOrEmpty(errorMsg))
            {
                success = false;
                MessageBox.Show(errorMsg, "Entry Error");
            }

            return success;
        }

        private bool IsValidName()
        {
            bool success = true;

            string errorMsg = Validator.IsPresent(txtName.Text, "Name");
            if(!String.IsNullOrEmpty(errorMsg))
            {
                success = false;
                MessageBox.Show(errorMsg, "Entry Error");
            }
            return success;
        }

    }
}
