using LegalCaseManagementSystem.CRUD;
using LegalCaseManagementSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Firm
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
            ConfigureListView();
        }

        private void ConfigureListView()
        {
            listView1.Columns.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true; // Optional: adds grid lines

            // Add column headers
            listView1.Columns.Add("User ID", 130);
            listView1.Columns.Add("First Name", 130);
            listView1.Columns.Add("Last Name", 130);
            listView1.Columns.Add("Role", 130);
            listView1.Columns.Add("Phone Number", 130);
            listView1.Columns.Add("Date Added", 130);
            listView1.Columns.Add("Actions", 130);

            // Enable owner drawing
            listView1.OwnerDraw = true;

            // Set up event handlers for drawing
            listView1.DrawItem += listView1_DrawItem;
            listView1.DrawSubItem += listView1_DrawSubItem;
            listView1.DrawColumnHeader += listView1_DrawColumnHeader;
            listView1.MouseClick += ListView1_MouseClick;
            listView1.MouseMove += ListView1_MouseMove;
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            listView1.Items.Clear();

            var users = SystemUserCRUD.GetAllUsers();
            foreach (var user in users)
            {
                var item = new ListViewItem(user.UserID.ToString());
                item.SubItems.Add(user.FirstName);
                item.SubItems.Add(user.LastName);
                item.SubItems.Add(user.UserRole);
                item.SubItems.Add(user.PhoneNumber);
                item.SubItems.Add(user.DateAdded.ToString("dd-MM-yyyy"));
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
            if (e.ColumnIndex == 6) // Actions column
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
                e.DrawDefault = true;
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
                if (columnIndex == 6) // Actions column
                {
                    // Determine which action was clicked based on mouse position
                    if (e.X >= hitTest.SubItem.Bounds.Left + 5 && e.X <= hitTest.SubItem.Bounds.Left + 30) // Edit text area
                    {
                        var userId = int.Parse(hitTest.Item.SubItems[0].Text);
                        var user = SystemUserCRUD.GetUserById(userId);
                        EditUser(user);
                    }
                    else if (e.X >= hitTest.SubItem.Bounds.Left + 50 && e.X <= hitTest.SubItem.Bounds.Left + 100) // Delete text area
                    {
                        var userId = int.Parse(hitTest.Item.SubItems[0].Text);
                        DeleteUser(userId);
                    }
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var addUserForm = new AddUserForm();
            if (addUserForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void EditUser(SystemUser user)
        {
            var editUserForm = new AddUserForm(user);
            if (editUserForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void DeleteUser(int userId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SystemUserCRUD.DeleteUser(userId);
                LoadUsers();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }


        private void PerformSearch()
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadUsers(); // Reload all users
                return;
            }

            var filteredUsers = SystemUserCRUD.SearchUsersByName(searchText);
            listView1.Items.Clear();

            foreach (var user in filteredUsers)
            {
                var item = new ListViewItem(user.UserID.ToString());
                item.SubItems.Add(user.FirstName);
                item.SubItems.Add(user.MiddleName);
                item.SubItems.Add(user.LastName);
                item.SubItems.Add(user.UserRole);
                item.SubItems.Add(user.PhoneNumber ?? string.Empty);
                item.SubItems.Add(user.DateAdded.ToString("dd-MM-yyyy"));
                item.SubItems.Add("Edit | Delete");

                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
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

                // Instead of Visible, remove or re-add items
                if (!match)
                {
                    listView1.Items.Remove(item);
                }
            }

            // Reload all items if search text is empty
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadUsers();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            PerformSearch();
        }
    }
}
