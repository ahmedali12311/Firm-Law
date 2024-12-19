using LegalCaseManagementSystem.CRUD;
using LegalCaseManagementSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Firm
{
    public partial class CourtCaseManagement : Form
    {
        private SystemUser _currentUser;

        public CourtCaseManagement(SystemUser user)
        {
            InitializeComponent();
            _currentUser = user; // Store the current user
            ConfigureListView();
            CheckUserRole(); // Check user role to enable/disable add case button
        }

        private void CheckUserRole()
        {
            // Assuming btnAddCourtCase is the button for adding a court case
            btnAddCourtCase.Visible = _currentUser.UserRole == "1"; // Show button only for admin
        }
        private void ConfigureListView()
        {
            listView1.Columns.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("Case ID", 100);
            listView1.Columns.Add("Defendant Name", 100);
            listView1.Columns.Add("Case Status", 100);
            listView1.Columns.Add("Charge", 100);
            listView1.Columns.Add("Case Date", 100);
            listView1.Columns.Add("Proxy Number", 100);
            listView1.Columns.Add("Proxy Date", 100);
            listView1.Columns.Add("Court ID", 100);
            listView1.Columns.Add("Lawyer ID", 100);
            listView1.Columns.Add("Actions", 100);

            listView1.OwnerDraw = true;
            listView1.DrawItem += listView1_DrawItem;
            listView1.DrawSubItem += listView1_DrawSubItem;
            listView1.DrawColumnHeader += listView1_DrawColumnHeader;
            listView1.MouseClick += ListView1_MouseClick;
            listView1.MouseMove += ListView1_MouseMove;
        }

        private void CourtCaseManagement_Load(object sender, EventArgs e)
        {
            LoadYears();
            LoadMonths();
            LoadCourtCases(); // Load all cases initially
                              // Wire up ComboBox events
            comboBoxYear.SelectedIndexChanged += (s, e) => FilterCourtCases();
            comboBoxMonth.SelectedIndexChanged += (s, e) => FilterCourtCases();
        }

        private void LoadYears()
        {
            // Assuming you want to show the last 10 years
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear; year >= currentYear - 10; year--)
            {
                comboBoxYear.Items.Add(year);
            }
            comboBoxYear.SelectedItem = currentYear; // Set the current year as default
        }

        private void LoadMonths()
        {
            for (int month = 1; month <= 12; month++)
            {
                comboBoxMonth.Items.Add(new DateTime(1, month, 1).ToString("MMMM")); // Add month names
            }
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1; // Set the current month as default
        }

        private void LoadCourtCases()
        {
            var courtCases = CourtCaseCRUD.GetAllCourtCases();
            listView1.Items.Clear();

            foreach (var courtCase in courtCases)
            {
                var item = new ListViewItem(courtCase.CaseID.ToString());
                item.SubItems.Add(courtCase.DefendantName);
                item.SubItems.Add(courtCase.CaseStatus);
                item.SubItems.Add(courtCase.Charge);
                item.SubItems.Add(courtCase.CaseDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(courtCase.ProxyNumber?.ToString() ?? "N/A");
                item.SubItems.Add(courtCase.ProxyDate?.ToString("dd/MM/yyyy") ?? "N/A");
                item.SubItems.Add(courtCase.CourtID.ToString());
                item.SubItems.Add(courtCase.LawyerID.ToString());
                item.SubItems.Add("Edit | Delete");

                listView1.Items.Add(item);
            }
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Alternate row colors (White for even rows, LightGray for odd rows)
            if (e.ItemIndex % 2 == 0)
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds); // White for even rows
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Blue, e.Bounds); // LightGray for odd rows
            }

            // Draw the item using the default style
            e.DrawDefault = true;
        }
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Set the header background color to blue
            e.Graphics.FillRectangle(Brushes.DarkBlue, e.Bounds);

            // Set the header text color to white
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }


        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 9) // Actions column
            {
                e.DrawDefault = false;
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                TextRenderer.DrawText(e.Graphics, "Edit", e.Item.Font,
                    new Point(e.Bounds.Left + 5, e.Bounds.Top), Color.Blue, TextFormatFlags.VerticalCenter);
                TextRenderer.DrawText(e.Graphics, "Delete", e.Item.Font,
                    new Point(e.Bounds.Left + 50, e.Bounds.Top), Color.Blue, TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void ListView1_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTest = listView1.HitTest(e.Location);
            Cursor = (hitTest.Item != null && (hitTest.SubItem.Text == "Edit" || hitTest.SubItem.Text == "Delete"))
                ? Cursors.Hand : Cursors.Default;
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTest = listView1.HitTest(e.Location);
            if (hitTest.Item != null)
            {
                int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
                if (columnIndex == 9) // Actions column
                {
                    if (e.X >= hitTest.SubItem.Bounds.Left + 5 && e.X <= hitTest.SubItem.Bounds.Left + 30) // Edit
                    {
                        var caseId = int.Parse(hitTest.Item.SubItems[0].Text);
                        var courtCase = CourtCaseCRUD.GetCourtCaseById(caseId);
                        EditCourtCase(courtCase);
                    }
                    else if (e.X >= hitTest.SubItem.Bounds.Left + 50 && e.X <= hitTest.SubItem.Bounds.Left + 100) // Delete
                    {
                        var caseId = int.Parse(hitTest.Item.SubItems[0].Text);
                        DeleteCourtCase(caseId);
                    }
                }
            }
        }

        private void btnAddCourtCase_Click(object sender, EventArgs e)
        {
            var addCourtCaseForm = new AddCourtCaseForm();
            if (addCourtCaseForm.ShowDialog() == DialogResult.OK)
            {
                LoadCourtCases();
            }
        }

        private void EditCourtCase(CourtCase courtCase)
        {
            var editCourtCaseForm = new AddCourtCaseForm(courtCase);
            if (editCourtCaseForm.ShowDialog() == DialogResult.OK)
            {
                LoadCourtCases();
            }
        }

        private void DeleteCourtCase(int caseId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this court case?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CourtCaseCRUD.DeleteCourtCase(caseId);
                LoadCourtCases();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = textBox2.Text.ToLower();

            foreach (ListViewItem item in listView1.Items)
            {
                bool match = false;
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.ToLower().Contains(searchText))
                    {
                        match = true;
                        break;
                    }
                }

                if (!match)
                {
                    listView1.Items.Remove(item);
                }
            }

            // Reload all items if search text is empty
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadCourtCases();
            }
        }
        private void FilterCourtCases()
        {
            int selectedYear = (int)comboBoxYear.SelectedItem;
            int selectedMonth = comboBoxMonth.SelectedIndex + 1; // ComboBox index starts from 0

            var courtCases = CourtCaseCRUD.GetAllCourtCases();
            listView1.Items.Clear();

            // Filter the court cases based on the selected year and month
            var filteredCourtCases = courtCases
                .Where(cc => cc.CaseDate.Year == selectedYear && cc.CaseDate.Month == selectedMonth)
                .ToList();

            foreach (var courtCase in filteredCourtCases)
            {
                var item = new ListViewItem(courtCase.CaseID.ToString());
                item.SubItems.Add(courtCase.DefendantName);
                item.SubItems.Add(courtCase.CaseStatus);
                item.SubItems.Add(courtCase.Charge);
                item.SubItems.Add(courtCase.CaseDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(courtCase.ProxyNumber?.ToString() ?? "N/A");
                item.SubItems.Add(courtCase.ProxyDate?.ToString("dd/MM/yyyy") ?? "N/A");
                item.SubItems.Add(courtCase.CourtID.ToString());
                item.SubItems.Add(courtCase.LawyerID.ToString());
                item.SubItems.Add("Edit | Delete");
                listView1.Items.Add(item);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: Handle selection change if needed
        }

        private void PerformSearch()
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadCourtCases(); // Reload all users
                return;
            }

            var FilterCases = CourtCaseCRUD.SearchCourtCasesByDefendant(searchText);
            listView1.Items.Clear();

            foreach (var courtCase in FilterCases)
            {
                var item = new ListViewItem(courtCase.CourtID.ToString());
                item.SubItems.Add(courtCase.DefendantName);
                item.SubItems.Add(courtCase.CaseStatus);
                item.SubItems.Add(courtCase.Charge);
                item.SubItems.Add(courtCase.CaseDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(courtCase.ProxyNumber?.ToString() ?? "N/A");
                item.SubItems.Add(courtCase.ProxyDate?.ToString("dd/MM/yyyy") ?? "N/A");
                item.SubItems.Add(courtCase.CourtID.ToString());
                item.SubItems.Add(courtCase.LawyerID.ToString());
                item.SubItems.Add("Edit | Delete");
                listView1.Items.Add(item);
            }
        }
        private void btnEditCase_Click(object sender, EventArgs e)
        {
            // Handle edit case logic here
        }

        private void btnDeleteCase_Click(object sender, EventArgs e)
        {
            // Handle delete case logic here
        }

        private void btnViewCase_Click(object sender, EventArgs e)
        {
            // Handle view case logic here
        }
    }
}
