using System;
using System.Drawing;
using System.Windows.Forms;
using LegalCaseManagementSystem.CRUD;
using LegalCaseManagementSystem.Models;

namespace Firm
{
    public partial class LegalCourtForm : Form
    {
        private int userRole; // Property to hold the user's role

        public LegalCourtForm(int role) // Constructor accepting user role
        {
            InitializeComponent();
            userRole = role; // Set the user role
            ConfigureListView();
            LoadCourts();
            SetButtonVisibility(); // Set button visibility based on role
        }

        private void SetButtonVisibility()
        {
            // Only show the button if the user role is 1
            btnAddCourtLegal.Visible = (userRole == 1);
        }

        private void ConfigureListView()
        {
            listView1.Columns.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("رقم الجلسة", 130);
            listView1.Columns.Add("يوم الجلسة", 130);
            listView1.Columns.Add("القاضي الأول", 130);
            listView1.Columns.Add("القاضي الثاني", 130);
            listView1.Columns.Add("القاضي الثالث", 130);
            listView1.Columns.Add("القاضي الاحتياطي", 130);
            listView1.Columns.Add("العمليات", 130);

            listView1.OwnerDraw = true;
            listView1.DrawColumnHeader += listView1_DrawColumnHeader;
            listView1.DrawSubItem += listView1_DrawSubItem;
            listView1.MouseClick += listView1_MouseClick;
            listView1.MouseMove += listView1_MouseMove;
        }

        private void LoadCourts()
        {
            listView1.Items.Clear();
            var courts = LegalCourtCRUD.GetAllLegalCourts();
            foreach (var court in courts)
            {
                var item = new ListViewItem(court.CourtID.ToString());
                item.SubItems.Add(court.SessionDay);
                item.SubItems.Add($"{court.Judge1FirstName} {court.Judge1MiddleName} {court.Judge1LastName}");
                item.SubItems.Add($"{court.Judge2FirstName} {court.Judge2MiddleName} {court.Judge2LastName}");
                item.SubItems.Add($"{court.Judge3FirstName} {court.Judge3MiddleName} {court.Judge3LastName}");
                item.SubItems.Add($"{court.ReserveJudgeFirstName} {court.ReserveJudgeMiddleName} {court.ReserveJudgeLastName}");
                item.SubItems.Add(""); 

                listView1.Items.Add(item);
            }
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            using (var headerFont = new Font("Segoe UI", 10, FontStyle.Bold))
            {
                e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds);
            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 6) // "العمليات" column
            {
                e.DrawDefault = false;
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);

                // Draw "Edit"
                TextRenderer.DrawText(e.Graphics, "Edit", e.Item.Font,
                    new Point(e.Bounds.Left + 5, e.Bounds.Top + (e.Bounds.Height - e.Item.Font.Height) / 2), Color.Blue);

                // Draw "Delete"
                TextRenderer.DrawText(e.Graphics, "Delete", e.Item.Font,
                    new Point(e.Bounds.Left + 50, e.Bounds.Top + (e.Bounds.Height - e.Item.Font.Height) / 2), Color.Blue);

                e.Graphics.DrawRectangle(Pens.LightGray, e.Bounds);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTest = listView1.HitTest(e.Location);
            if (hitTest.Item != null && hitTest.SubItem != null && (hitTest.SubItem.Text == "Edit" || hitTest.SubItem.Text == "Delete"))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTest = listView1.HitTest(e.Location);
            if (hitTest.Item != null && hitTest.SubItem != null)
            {
                int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
                if (columnIndex == 6) // "العمليات" column
                {
                    // Check for "Edit" click
                    if (e.X >= hitTest.SubItem.Bounds.Left + 5 && e.X <= hitTest.SubItem.Bounds.Left + 30)
                    {
                        var courtId = int.Parse(hitTest.Item.SubItems[0].Text);
                        var court = LegalCourtCRUD.GetLegalCourtById(courtId);
                        EditCourt(court);
                    }
                    // Check for "Delete" click
                    else if (e.X >= hitTest.SubItem.Bounds.Left + 50 && e.X <= hitTest.SubItem.Bounds.Left + 100)
                    {
                        var courtId = int.Parse(hitTest.Item.SubItems[0].Text);
                        DeleteCourt(courtId);
                    }
                }
            }
        }

        private void DeleteCourt(int courtId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this court?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                LegalCourtCRUD.DeleteLegalCourt(courtId);
                LoadCourts();
            }
        }

        private void EditCourt(LegalCourt court)
        {
            var editForm = new AddEditLegalCourtForm(court);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LegalCourtCRUD.UpdateLegalCourt(editForm.LegalCourt);
                LoadCourts();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddtLegalCourt(object sender, EventArgs e)
        {
            var form = new AddEditLegalCourtForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCourts(); 
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSearch.Text, out int courtId))
            {
                SearchCourtById(courtId);
            }
            else
            {
                MessageBox.Show("Please enter a valid Court ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSearch.Text, out int courtId))
            {
                SearchCourtById(courtId);
            }
            else if (string.IsNullOrEmpty(textBoxSearch.Text))
            {
                LoadCourts(); 
            }
            else
            {
                listView1.Items.Clear();
            }
        }

        private void SearchCourtById(int courtId)
        {
            var court = LegalCourtCRUD.GetLegalCourtById(courtId);
            listView1.Items.Clear(); 

            if (court != null)
            {
                var item = new ListViewItem(court.CourtID.ToString());
                item.SubItems.Add(court.SessionDay);
                item.SubItems.Add($"{court.Judge1FirstName} {court.Judge1MiddleName} {court.Judge1LastName}");
                item.SubItems.Add($"{court.Judge2FirstName} {court.Judge2MiddleName} {court.Judge2LastName}");
                item.SubItems.Add($"{court.Judge3FirstName} {court.Judge3MiddleName} {court.Judge3LastName}");
                item.SubItems.Add($"{court.ReserveJudgeFirstName} {court.ReserveJudgeMiddleName} {court.ReserveJudgeLastName}");
                item.SubItems.Add(""); 

                listView1.Items.Add(item);
            }

            //optional if needed(i think its annoying!) 
            //else
            //{
            //    MessageBox.Show("Court not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

       
    }
}
