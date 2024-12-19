using LegalCaseManagementSystem.CRUD;
using LegalCaseManagementSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Firm
{
    public partial class LawyerManagement : Form
    {
        SystemUser _currentUser;
        public LawyerManagement(SystemUser user)
        {
            InitializeComponent();
            _currentUser = user;
            ConfigureListView();
            CheckUserRole(); // Check user role to enable/disable add case button
        }

        private void CheckUserRole()
        {
            // Assuming btnAddCourtCase is the button for adding a court case
            btnAddLawyer.Visible = _currentUser.UserRole == "1"; // Show button only for admin
        }
        private void ConfigureListView()
        {
            listView1.Columns.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true; // Optional: adds grid lines

            // Add column headers
            listView1.Columns.Add("Lawyer ID", 100);
            listView1.Columns.Add("First Name", 100);
            listView1.Columns.Add("Middle Name", 100);
            listView1.Columns.Add("Last Name", 100);
            listView1.Columns.Add("Specialization", 100);
            listView1.Columns.Add("Phone Number", 100);
            listView1.Columns.Add("Case Count", 100);
            listView1.Columns.Add("Court ID", 100);
            listView1.Columns.Add("Actions", 100); // Actions column

            // Enable owner drawing
            listView1.OwnerDraw = true;

            // Set up event handlers for drawing
            listView1.DrawItem += listView1_DrawItem;
            listView1.DrawSubItem += listView1_DrawSubItem;
            listView1.DrawColumnHeader += listView1_DrawColumnHeader;
            listView1.MouseClick += ListView1_MouseClick;
            listView1.MouseMove += ListView1_MouseMove;
        }

        private void LawyerManagement_Load(object sender, EventArgs e)
        {
            LoadLawyers();
        }

        private void LoadLawyers()
        {
            var lawyers = LegalLawyerCRUD.GetAllLegalLawyers();
            listView1.Items.Clear();

            foreach (var lawyer in lawyers)
            {
                var item = new ListViewItem(lawyer.LawyerID.ToString());
                item.SubItems.Add(lawyer.FirstName);
                item.SubItems.Add(lawyer.MiddleName);
                item.SubItems.Add(lawyer.LastName);
                item.SubItems.Add(lawyer.Specialization);
                item.SubItems.Add(lawyer.PhoneNumber);
                item.SubItems.Add(lawyer.CaseCount.ToString());
                item.SubItems.Add(lawyer.CourtID.ToString());
                item.SubItems.Add("Edit | Delete"); // Combine actions into one sub-item

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
            if (e.ColumnIndex == 8) // Actions column
            {
                e.DrawDefault = false;

                // Draw background
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);

                // Draw Edit text
                TextRenderer.DrawText(e.Graphics, "Edit", e.Item.Font,
                    new Point(e.Bounds.Left + 5, e.Bounds.Top), Color.Blue, TextFormatFlags.VerticalCenter);

                // Draw Delete text
                TextRenderer.DrawText(e.Graphics, "Delete", e.Item.Font,
                    new Point(e.Bounds.Left + 50, e.Bounds.Top), Color.Blue, TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.DrawDefault = true; // Draw other subitems normally
            }
        }

        private void ListView1_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTest = listView1.HitTest(e.Location);

            // Check if the item is not null and the subItem is not null
            if (hitTest.Item != null && hitTest.SubItem != null)
            {
                // Check if the text of the subItem is "Edit" or "Delete"
                if (hitTest.SubItem.Text == "Edit" || hitTest.SubItem.Text == "Delete")
                {
                    Cursor = Cursors.Hand; // Change cursor to hand
                }
                else
                {
                    Cursor = Cursors.Default; // Change cursor to default
                }
            }
            else
            {
                Cursor = Cursors.Default; // Change cursor to default if no item or subItem
            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTest = listView1.HitTest(e.Location);

            if (hitTest.Item != null && hitTest.SubItem != null) // Check if SubItem is not null
            {
                int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);

                // Check if Actions column is clicked
                if (columnIndex == 8) // Actions column
                {
                    // Determine which action was clicked based on mouse position
                    if (e.X >= hitTest.SubItem.Bounds.Left + 5 && e.X <= hitTest.SubItem.Bounds.Left + 30) // Edit text area
                    {
                        var lawyerId = int.Parse(hitTest.Item.SubItems[0].Text);
                        var lawyer = LegalLawyerCRUD.GetLawyerById(lawyerId);
                        EditLawyer(lawyer);
                    }
                    else if (e.X >= hitTest.SubItem.Bounds.Left + 50 && e.X <= hitTest.SubItem.Bounds.Left + 100) // Delete text area
                    {
                        var lawyerId = int.Parse(hitTest.Item.SubItems[0].Text);
                        DeleteLawyer(lawyerId);
                    }
                }
            }
        }

        private void btnAddLawyer_Click(object sender, EventArgs e)
        {
            var addLawyerForm = new AddLawyerForm();
            if (addLawyerForm.ShowDialog() == DialogResult.OK)
            {
                LoadLawyers();
            }
        }

        private void EditLawyer(LegalLawyer lawyer)
        {
            var editLawyerForm = new AddLawyerForm(lawyer);
            if (editLawyerForm.ShowDialog() == DialogResult.OK)
            {
                LoadLawyers();
            }
        }

        private void DeleteLawyer(int lawyerId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this lawyer?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                LegalLawyerCRUD.DeleteLegalLawyer(lawyerId);
                LoadLawyers();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle list view item selection if needed
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            // If search text is empty, reload all lawyers
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadLawyers();
                return;
            }

            // Perform a database search using the search text
            var filteredLawyers = LegalLawyerCRUD.SearchLawyers(searchText);

            // Clear and reload the ListView with filtered results
            listView1.Items.Clear();

            foreach (var lawyer in filteredLawyers)
            {
                var item = new ListViewItem(lawyer.LawyerID.ToString());
                item.SubItems.Add(lawyer.FirstName);
                item.SubItems.Add(lawyer.MiddleName);
                item.SubItems.Add(lawyer.LastName);
                item.SubItems.Add(lawyer.Specialization);
                item.SubItems.Add(lawyer.PhoneNumber);
                item.SubItems.Add(lawyer.CaseCount.ToString());
                item.SubItems.Add(lawyer.CourtID.ToString());
                item.SubItems.Add("Edit | Delete");

                listView1.Items.Add(item);
            }
        }
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            // Handle text change if needed
        }
    }
}