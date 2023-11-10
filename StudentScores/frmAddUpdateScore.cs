using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StudentScores
{
    public partial class frmAddUpdateScore : Form
    {
        public frmAddUpdateScore()
        {
            InitializeComponent();
        }

        private void frmAddUpdateScore_Load(object sender, EventArgs e)
        {
            if (Text == "Update Score")
            {
                btnAddUpdate.Text = "&Update";
                txtScore.Text = Tag?.ToString();
            }
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

       
        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (IsValidScore())
            {
                Tag = Convert.ToInt32(txtScore.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
