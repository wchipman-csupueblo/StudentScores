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
            sb.Append(IsPresent(txtScore.Text, "Score"));
            sb.Append(IsInt32(txtScore.Text, "Score"));
            sb.Append(IsWithinRange(txtScore.Text, "Score", 0, 100));
            string errorMsg = sb.ToString();

            if (!String.IsNullOrEmpty(errorMsg))
            {
                success = false;
                MessageBox.Show(errorMsg, "Entry Error");
            }

            return success;
        }

        private string IsPresent(string value, string name)
        {
            string errorMsg = "";
            if (String.IsNullOrEmpty(value))
            {
                errorMsg = $"{name} is a required field.\n";
            }
            return errorMsg;
        }

        private string IsInt32(string value, string name)
        {
            string errorMsg = "";
            if (!Int32.TryParse(value, out _))
            {
                errorMsg = $"{name} must be a valid integer.\n";
            }
            return errorMsg;
        }

        private string IsWithinRange(string value, string name, decimal min, decimal max)
        {
            string errorMsg = "";
            if (Decimal.TryParse(value, out decimal number))
            {
                if (number < min || number > max)
                {
                    errorMsg = $"{name} must be between {min} and {max}.\n";
                }
            }
            return errorMsg;
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
