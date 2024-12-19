using LegalCaseManagementSystem;
using LegalCaseManagementSystem.CRUD;
using LegalCaseManagementSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Firm
{
    public partial class AddCourtCaseForm : Form
    {
        private CourtCase _courtCase;

        public AddCourtCaseForm(CourtCase courtCase = null)
        {
            InitializeComponent();
            _courtCase = courtCase;

            if (_courtCase != null)
            {
                textBoxDefendantName.Text = _courtCase.DefendantName;
                comboBoxCaseStatus.SelectedItem = _courtCase.CaseStatus;
                textBoxCharge.Text = _courtCase.Charge;
                dateTimePickerCaseDate.Value = _courtCase.CaseDate;
                textBoxProxyNumber.Text = _courtCase.ProxyNumber?.ToString() ?? string.Empty;
                dateTimePickerProxyDate.Value = _courtCase.ProxyDate ?? DateTime.Now;
                textBoxCourtID.Text = _courtCase.CourtID.ToString();
                textBoxLawyerID.Text = _courtCase.LawyerID.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_courtCase == null)
            {
                _courtCase = new CourtCase();
            }

            // Read form values into the CourtCase object
            _courtCase.DefendantName = textBoxDefendantName.Text;
            _courtCase.CaseStatus = comboBoxCaseStatus.SelectedItem?.ToString() ?? "Ongoing";
            _courtCase.Charge = textBoxCharge.Text;
            _courtCase.CaseDate = dateTimePickerCaseDate.Value;

            // Validate CaseStatus
            var validStatuses = new[] { "Ongoing", "Closed" };
            if (!validStatuses.Contains(_courtCase.CaseStatus))
            {
                MessageBox.Show("Invalid Case Status selected. Please choose either 'Ongoing' or 'Closed'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Handle Proxy Number
            int? proxyNumber = null;
            if (!string.IsNullOrEmpty(textBoxProxyNumber.Text))
            {
                if (!int.TryParse(textBoxProxyNumber.Text, out int parsedProxyNumber))
                {
                    MessageBox.Show("Please enter a valid Proxy Number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                proxyNumber = parsedProxyNumber;
            }
            _courtCase.ProxyNumber = proxyNumber;

            // Handle Proxy Date
            _courtCase.ProxyDate = dateTimePickerProxyDate.Value;

            // Validate CourtID
            if (!int.TryParse(textBoxCourtID.Text, out int courtID))
            {
                MessageBox.Show("Please enter a valid Court ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _courtCase.CourtID = courtID;

            // Validate LawyerID
            if (!int.TryParse(textBoxLawyerID.Text, out int lawyerID))
            {
                MessageBox.Show("Please enter a valid Lawyer ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _courtCase.LawyerID = lawyerID;

            try
            {
                // Check if CourtID exists
                if (!CourtCaseCRUD.CourtExists(courtID))
                {
                    MessageBox.Show("The specified Court ID does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if LawyerID exists
                if (! LegalLawyerCRUD.LawyerExists(lawyerID))
                {
                    MessageBox.Show("The specified Lawyer ID does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save or update the court case
                if (_courtCase.CaseID == 0)
                {
                    CourtCaseCRUD.AddCourtCase(_courtCase);
                }
                else
                {
                    CourtCaseCRUD.UpdateCourtCase(_courtCase);
                }

                MessageBox.Show("Court case saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


