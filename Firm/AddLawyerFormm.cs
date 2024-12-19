using LegalCaseManagementSystem.Models;
using LegalCaseManagementSystem.CRUD;
using System;
using System.Windows.Forms;

namespace Firm
{
    public partial class AddLawyerForm : Form
    {
        private LegalLawyer _lawyer;

        public AddLawyerForm(LegalLawyer lawyer = null)
        {
            InitializeComponent();
            _lawyer = lawyer;

            if (_lawyer != null)
            {
                textBoxFirstName.Text = _lawyer.FirstName;
                textBoxMiddleName.Text = _lawyer.MiddleName;
                textBoxLastName.Text = _lawyer.LastName;
                textBoxSpecialization.Text = _lawyer.Specialization;
                textBoxPhoneNumber.Text = _lawyer.PhoneNumber;
                // Removed the UserID line
                textBoxCaseCount.Text = _lawyer.CaseCount.ToString();
                textBoxCourtID.Text = _lawyer.CourtID.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_lawyer == null)
            {
                _lawyer = new LegalLawyer();
            }

            _lawyer.FirstName = textBoxFirstName.Text;
            _lawyer.MiddleName = textBoxMiddleName.Text;
            _lawyer.LastName = textBoxLastName.Text;
            _lawyer.Specialization = textBoxSpecialization.Text;
            _lawyer.PhoneNumber = textBoxPhoneNumber.Text;

            // Use TryParse to avoid FormatException
            if (!int.TryParse(textBoxCaseCount.Text, out int caseCount))
            {
                MessageBox.Show("Please enter a valid Case Count.");
                return; // Exit the method if invalid input
            }
            _lawyer.CaseCount = caseCount;

            if (!int.TryParse(textBoxCourtID.Text, out int courtID))
            {
                MessageBox.Show("Please enter a valid Court ID.");
                return; // Exit the method if invalid input
            }
            // Check if CourtID exists
            if (!CourtCaseCRUD.CourtExists(courtID))
            {
                MessageBox.Show("The specified Court ID does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _lawyer.CourtID = courtID;

            // Check if LawyerID is 0 (new lawyer) or if we need to update an existing lawyer
            if (_lawyer.LawyerID == 0)
            {
                LegalLawyerCRUD.AddLegalLawyer(_lawyer);
            }
            else
            {
                LegalLawyerCRUD.UpdateLegalLawyer(_lawyer);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox_KeyPress_NumberOnly(object sender, KeyPressEventArgs e)
        {
            // Allow control characters such as backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press event
            }
        }
    }
}
