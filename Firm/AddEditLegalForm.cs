using LegalCaseManagementSystem.CRUD;
using LegalCaseManagementSystem.Models;
using System;
using System.Windows.Forms;
namespace Firm
{
    public partial class AddEditLegalCourtForm : Form
    {
        public LegalCourt LegalCourt { get; private set; }
        public bool IsEditMode { get; private set; }

        public AddEditLegalCourtForm(LegalCourt legalCourt = null)
        {
            InitializeComponent();  // This method should be in the Designer file
            LegalCourt = legalCourt ?? new LegalCourt();
            IsEditMode = legalCourt != null;
            PopulateFormFields();
        }
        private void PopulateFormFields()
        {
            if (IsEditMode)
            {
                txtSessionDay.Text = LegalCourt.SessionDay;
                txtJudge1FirstName.Text = LegalCourt.Judge1FirstName;
                txtJudge1MiddleName.Text = LegalCourt.Judge1MiddleName;
                txtJudge1LastName.Text = LegalCourt.Judge1LastName;
                txtJudge2FirstName.Text = LegalCourt.Judge2FirstName;
                txtJudge2MiddleName.Text = LegalCourt.Judge2MiddleName;
                txtJudge2LastName.Text = LegalCourt.Judge2LastName;
                txtJudge3FirstName.Text = LegalCourt.Judge3FirstName;
                txtJudge3MiddleName.Text = LegalCourt.Judge3MiddleName;
                txtJudge3LastName.Text = LegalCourt.Judge3LastName;
                txtReserveJudgeFirstName.Text = LegalCourt.ReserveJudgeFirstName;
                txtReserveJudgeMiddleName.Text = LegalCourt.ReserveJudgeMiddleName;
                txtReserveJudgeLastName.Text = LegalCourt.ReserveJudgeLastName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LegalCourt.SessionDay = txtSessionDay.Text;
                LegalCourt.Judge1FirstName = txtJudge1FirstName.Text;
                LegalCourt.Judge1MiddleName = txtJudge1MiddleName.Text;
                LegalCourt.Judge1LastName = txtJudge1LastName.Text;
                LegalCourt.Judge2FirstName = txtJudge2FirstName.Text;
                LegalCourt.Judge2MiddleName = txtJudge2MiddleName.Text;
                LegalCourt.Judge2LastName = txtJudge2LastName.Text;
                LegalCourt.Judge3FirstName = txtJudge3FirstName.Text;
                LegalCourt.Judge3MiddleName = txtJudge3MiddleName.Text;
                LegalCourt.Judge3LastName = txtJudge3LastName.Text;
                LegalCourt.ReserveJudgeFirstName = txtReserveJudgeFirstName.Text;
                LegalCourt.ReserveJudgeMiddleName = txtReserveJudgeMiddleName.Text;
                LegalCourt.ReserveJudgeLastName = txtReserveJudgeLastName.Text;

                if (IsEditMode)
                {
                    LegalCourtCRUD.UpdateLegalCourt(LegalCourt);
                    MessageBox.Show("Court details updated successfully!");
                }
                else
                {
                    LegalCourtCRUD.AddLegalCourt(LegalCourt);
                    MessageBox.Show("Court added successfully!");
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}