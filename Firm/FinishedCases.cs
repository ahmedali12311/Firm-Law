using LegalCaseManagementSystem.CRUD;
using LegalCaseManagementSystem.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Firm
{
    public partial class FinishedCasesForm : Form
    {
        private PrintDocument printDocument;
        private ListView listViewToPrint;

        public FinishedCasesForm()
        {
            InitializeComponent();
            ConfigureListView();
            ConfigurePrinting();
            comboBoxYear.SelectedIndexChanged += (s, e) => FilterFinishedCases();
            comboBoxMonth.SelectedIndexChanged += (s, e) => FilterFinishedCases();
        }


        private void ConfigurePrinting()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            listViewToPrint = new ListView();
        }

        private void ConfigureListView()
        {
            listView1.OwnerDraw = true;
            listView1.DrawItem += listView1_DrawItem;
            listView1.DrawSubItem += listView1_DrawSubItem;
            listView1.DrawColumnHeader += listView1_DrawColumnHeader;
        }

        private void FinishedCasesForm_Load(object sender, EventArgs e)
        {
            LoadYears();
            LoadMonths();
            LoadFinishedCases();

        }

        private void LoadYears()
        {
            for (int year = DateTime.Now.Year; year >= 2000; year--)
            {
                comboBoxYear.Items.Add(year);
            }
            comboBoxYear.SelectedItem = DateTime.Now.Year; // Set current year as default
        }

        private void LoadMonths()
        {
            for (int month = 1; month <= 12; month++)
            {
                comboBoxMonth.Items.Add(new DateTime(1, month, 1).ToString("MMMM")); // Add month names
            }
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1; // Set current month as default
        }
        private void FilterFinishedCases()
        {
            if (comboBoxYear.SelectedItem != null && comboBoxMonth.SelectedItem != null)
            {
                int selectedYear = (int)comboBoxYear.SelectedItem;
                int selectedMonth = comboBoxMonth.SelectedIndex + 1;

                var courtCases = CourtCaseCRUD.GetAllCourtCases();
                listView1.Items.Clear();

                foreach (var courtCase in courtCases)
                {
                    if (courtCase.CaseStatus.Equals("Closed", StringComparison.OrdinalIgnoreCase) &&
                        courtCase.CaseDate.Year == selectedYear &&
                        courtCase.CaseDate.Month == selectedMonth)
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
            }
        }
        private void LoadFinishedCases()
        {
            var courtCases = CourtCaseCRUD.GetAllCourtCases();
            listView1.Items.Clear();

            foreach (var courtCase in courtCases)
            {
                if (courtCase.CaseStatus.Equals("Closed", StringComparison.OrdinalIgnoreCase))
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
                    item.SubItems.Add("Edit | Delete"); // Add this line

                    listView1.Items.Add(item);
                }
            }
        }

        // Print Button Click Event
        private void btnPrintCourtTuple_Click(object sender, EventArgs e)
        {
            // Copy items to a new ListView for printing
            listViewToPrint.Columns.Clear();
            listViewToPrint.Items.Clear();

            // Copy columns
            foreach (ColumnHeader column in listView1.Columns)
            {
                listViewToPrint.Columns.Add(column.Text, column.Width);
            }

            // Copy items
            foreach (ListViewItem item in listView1.Items)
            {
                ListViewItem newItem = (ListViewItem)item.Clone();
                listViewToPrint.Items.Add(newItem);
            }

            // Show Print Dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Printing error: {ex.Message}", "Print Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Print Page Event Handler
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float topMargin = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;
            float lineHeight = 20f;
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font columnFont = new Font("Arial", 10, FontStyle.Bold);
            Font dataFont = new Font("Arial", 10);

            // Print Title
            e.Graphics.DrawString("Finished Court Cases", headerFont,
                Brushes.Black, leftMargin, topMargin);
            topMargin += lineHeight * 2;

            // Print Column Headers
            float currentX = leftMargin;
            foreach (ColumnHeader column in listViewToPrint.Columns)
            {
                e.Graphics.DrawString(column.Text, columnFont,
                    Brushes.Black, currentX, topMargin);
                currentX += column.Width;
            }
            topMargin += lineHeight;

            // Print Data Rows
            foreach (ListViewItem item in listViewToPrint.Items)
            {
                currentX = leftMargin;
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    e.Graphics.DrawString(item.SubItems[i].Text, dataFont,
                        Brushes.Black, currentX, topMargin);
                    currentX += listViewToPrint.Columns[i].Width;
                }
                topMargin += lineHeight;
            }
        }

        private void BtnAddCourtCase_Click(object sender, EventArgs e)
        {
            var addForm = new AddCourtCaseForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadFinishedCases();
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

                // Load icons
                Image editIcon = Image.FromFile(@"C:\Users\oG_Ju\source\repos\Firm\Firm\edit-icon.png");
                Image deleteIcon = Image.FromFile(@"C:\Users\oG_Ju\source\repos\Firm\Firm\delete-icon.png");

                // Define icon positions
                Rectangle editBounds = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + (e.Bounds.Height - 16) / 2, 16, 16);
                Rectangle deleteBounds = new Rectangle(e.Bounds.Left + 50, e.Bounds.Top + (e.Bounds.Height - 16) / 2, 16, 16);

                // Draw icons
                e.Graphics.DrawImage(editIcon, editBounds);
                e.Graphics.DrawImage(deleteIcon, deleteBounds);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTest = listView1.HitTest(e.Location);
            if (hitTest.Item != null)
            {
                int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
                if (columnIndex == 9) // Actions column
                {
                    // Check if click is on edit icon
                    Rectangle editBounds = new Rectangle(hitTest.SubItem.Bounds.Left + 5, hitTest.SubItem.Bounds.Top + (hitTest.SubItem.Bounds.Height - 16) / 2, 16, 16);
                    if (editBounds.Contains(e.Location))
                    {
                        var caseId = int.Parse(hitTest.Item.SubItems[0].Text);
                        var courtCase = CourtCaseCRUD.GetCourtCaseById(caseId);
                        EditCourtCase(courtCase);
                    }

                    // Check if click is on delete icon
                    Rectangle deleteBounds = new Rectangle(hitTest.SubItem.Bounds.Left + 50, hitTest.SubItem.Bounds.Top + (hitTest.SubItem.Bounds.Height - 16) / 2, 16, 16);
                    if (deleteBounds.Contains(e.Location))
                    {
                        var caseId = int.Parse(hitTest.Item.SubItems[0].Text);
                        DeleteCourtCase(caseId);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();

        }
        private void PerformSearch()
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadFinishedCases(); // Reload all users
                return;
            }

            var FilterCases = CourtCaseCRUD.SearchCourtCasesByDefendantFinished(searchText);
            listView1.Items.Clear();

            foreach (var courtCase in FilterCases)
            {
                var item = new ListViewItem(courtCase.CourtID.ToString());
                item.SubItems.Add(courtCase.DefendantName);
                item.SubItems.Add(courtCase.CaseStatus);
                item.SubItems.Add(courtCase.Charge);
                item.SubItems.Add(courtCase.CaseDate.ToString("dd/MM/yyyy")); // Change this line
                item.SubItems.Add(courtCase.ProxyNumber?.ToString() ?? "N/A");
                item.SubItems.Add(courtCase.ProxyDate?.ToString("dd/MM/yyyy") ?? "N/A"); // Change this line
                item.SubItems.Add(courtCase.CourtID.ToString());
                item.SubItems.Add(courtCase.LawyerID.ToString());
                item.SubItems.Add("Edit | Delete");

                listView1.Items.Add(item);
            }
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
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

        private void EditCourtCase(CourtCase courtCase)
        {
            var editCourtCaseForm = new AddCourtCaseForm(courtCase);
            if (editCourtCaseForm.ShowDialog() == DialogResult.OK)
            {
                LoadFinishedCases();
            }
        }

        private void DeleteCourtCase(int caseId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this court case?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CourtCaseCRUD.DeleteCourtCase(caseId);
                LoadFinishedCases();
            }
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}