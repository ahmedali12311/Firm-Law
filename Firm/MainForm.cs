using System;
using System.Windows.Forms;
using LegalCaseManagementSystem.CRUD;
using LegalCaseManagementSystem.Models;

namespace Firm
{
    public partial class MainForm : Form
    {
        private SystemUser _currentUser; // Store the current user

        public MainForm(SystemUser user) // Accept the user as a parameter
        {
            InitializeComponent();
            _currentUser = user; // Store the user
            InitializeCustomComponents();
            DisplayUserName(); // Call the method to display the username
        }

        private void DisplayUserName()
        {
            // Assuming label2 is the label for the username
            label2.Text = $"اسم المستخدم: {_currentUser.FirstName}"; // Display the user's first name
        }


        private void InitializeCustomComponents()
        {
            // Set form properties
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الصفحة الرئيسية";

            // Create containers for each statistic group
            Panel pnlCaseNumbers = CreateStatContainer(label7, label10, "عدد القضايا");
            pnlCaseNumbers.Location = new Point(622, 270);

            Panel pnlCaseTrending = CreateStatContainer(label8, label11, "القضايا المتداولة");
            pnlCaseTrending.Location = new Point(405, 270);

            Panel pnlCasesFinished = CreateStatContainer(label9, label12, "القضايا المنتهية");
            pnlCasesFinished.Location = new Point(158, 270);

            // Add panels to form
            this.Controls.Add(pnlCaseNumbers);
            this.Controls.Add(pnlCaseTrending);
            this.Controls.Add(pnlCasesFinished);

            // Update statistics
            UpdateStatistics();
        }

        private Panel CreateStatContainer(Label titleLabel, Label valueLabel, string messageText)
        {
            Panel panel = new Panel();
            panel.Size = new Size(200, 100);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.White;

            // Position labels within the panel
            titleLabel.Location = new Point(10, 10);
            valueLabel.Location = new Point(10, 40);

            // Add labels to panel
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(valueLabel);
            if (_currentUser.UserRole != "1") // Replace "Admin" with the actual role name
            {
                label4.Visible = false; // Assuming label4 is the label for User Management
            }

            // Define the click event logic based on messageText
            EventHandler clickHandler = (sender, e) =>
            {
                switch (messageText)
                {
                    case "عدد القضايا":
                        CourtCaseManagement courtCaseManagement = new CourtCaseManagement(_currentUser);
                        courtCaseManagement.Show();
                        break;

                    case "القضايا المتداولة":
                        OngoingCaseForm ongoingForm = new OngoingCaseForm();
                        ongoingForm.Show();
                        break;

                    case "القضايا المنتهية":
                        FinishedCasesForm finishedForm = new FinishedCasesForm();
                        finishedForm.Show();
                        break;

                    default:
                        MessageBox.Show("غير معروف: " + messageText);
                        break;
                }
            };

            // Make panel and labels clickable
            panel.Click += clickHandler;
            titleLabel.Click += clickHandler;
            valueLabel.Click += clickHandler;

            // Change cursor to indicate clickability
            panel.Cursor = Cursors.Hand;
            titleLabel.Cursor = Cursors.Hand;
            valueLabel.Cursor = Cursors.Hand;

            return panel;
        }


        private void UpdateStatistics()
        {
            int totalCases = CourtCaseCRUD.GetTotalCaseNumbers();
            label10.Text = totalCases.ToString(); // Update label for total cases

            // Get the number of ongoing cases
            int ongoingCases = CourtCaseCRUD.GetCaseTrending();
            label11.Text = ongoingCases.ToString(); // Update label for ongoing cases

            // Get the number of finished cases
            int finishedCases = CourtCaseCRUD.GetCaseFinished();
            label12.Text = finishedCases.ToString();
        }

        // Event handler for label2 click
        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("اسم المستخدم clicked!"); // Example action
        }

        // Event handler for label3 click
        private void label3_Click(object sender, EventArgs e)
        {
            CourtCaseManagement userForm = new CourtCaseManagement(_currentUser); // Pass the current user
            userForm.Show();
        }

        // Event handler for label4 click
        private void label4_Click(object sender, EventArgs e)
        {
            UserManagement UserForm = new UserManagement();
            UserForm.Show();
        }

        // Event handler for label5 click
        private void label5_Click(object sender, EventArgs e)
        {
            LawyerManagement LawyerManagement = new LawyerManagement(_currentUser);
            LawyerManagement.Show();
        }

        // Event handler for label6 click
        private void label6_Click(object sender, EventArgs e)
        {
            Form1 LogIn = new Form1();
            LogIn.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            LegalCourtForm LegalCourtForm = new LegalCourtForm(_currentUser.UserID);
            LegalCourtForm.Show();
            this.Hide();
        }

        private void pnlSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
