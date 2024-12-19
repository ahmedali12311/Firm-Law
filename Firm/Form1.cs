using System;
using System.Windows.Forms;
using LegalCaseManagementSystem.Models; // Include the namespace for the models
using LegalCaseManagementSystem.CRUD;  // Include the namespace for CRUD operations

namespace Firm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // This is auto-generated when the label is clicked. You can leave it empty.
        }

        private void submit_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if user exists in the database
            var user = SystemUserCRUD.GetAllUsers().Find(u => u.FirstName == username && u.UserPassword == password);

            if (user != null)
            {
                // Pass the user to the MainForm
                MainForm mainForm = new MainForm(user);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private TextBox textBox1;
        private Label Username;
        private Label label1;
        private Button submit;
        private TextBox textBox2;
    }
}
