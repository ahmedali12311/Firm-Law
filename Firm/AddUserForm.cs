using LegalCaseManagementSystem.CRUD;
using LegalCaseManagementSystem.Models;
using System;
using System.Windows.Forms;

namespace Firm
{
    public partial class AddUserForm : Form
    {
        private SystemUser _user;

        public AddUserForm(SystemUser user = null)
        {
            InitializeComponent();
            _user = user;

            if (_user != null)
            {
                textBoxFirstName.Text = _user.FirstName;
                textBoxMiddleName.Text = _user.MiddleName;
                textBoxLastName.Text = _user.LastName;
                textBoxUserRole.Text = _user.UserRole;
                textBoxPhoneNumber.Text = _user.PhoneNumber;
                textBoxUsername.Text = _user.Username;
                textBoxUserPassword.Text = _user.UserPassword;
                dateTimePickerDateAdded.Value = _user.DateAdded;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_user == null)
            {
                _user = new SystemUser();
            }

            _user.FirstName = textBoxFirstName.Text;
            _user.MiddleName = textBoxMiddleName.Text;
            _user.LastName = textBoxLastName.Text;
            _user.UserRole = textBoxUserRole.Text;
            _user.PhoneNumber = textBoxPhoneNumber.Text;
            _user.Username = textBoxUsername.Text;
            _user.UserPassword = textBoxUserPassword.Text;
            _user.DateAdded = dateTimePickerDateAdded.Value;

            if (_user.UserID == 0)
            {
                SystemUserCRUD.AddUser(_user);
            }
            else
            {
                SystemUserCRUD.UpdateUser(_user);
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxUserPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
