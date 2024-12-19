using System.Drawing;
using System.Windows.Forms;

namespace Firm
{
    partial class CourtCaseManagement
    {
        private System.ComponentModel.IContainer components = null;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Button btnAddCourtCase;
        private ImageList imageList1;
        private Button btnEditCase; // Button for editing cases
        private Button btnDeleteCase; // Button for deleting cases
        private Button btnViewCase; // Button for viewing case details
        private ComboBox comboBoxYear;
        private ComboBox comboBoxMonth;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            imageList1 = new ImageList(components);
            btnAddCourtCase = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            btnEditCase = new Button();
            btnDeleteCase = new Button();
            btnViewCase = new Button();
            comboBoxYear = new ComboBox();
            comboBoxMonth = new ComboBox();
            SuspendLayout();
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            listView1.Location = new Point(-1, 255);
            listView1.Name = "listView1";
            listView1.Size = new Size(1083, 264);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Case ID";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.DisplayIndex = 2;
            columnHeader2.Text = "Defendant Name";
            columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            columnHeader3.DisplayIndex = 4;
            columnHeader3.Text = "Case Status";
            columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            columnHeader4.DisplayIndex = 1;
            columnHeader4.Text = "Charge";
            columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            columnHeader5.DisplayIndex = 3;
            columnHeader5.Text = "Case Date";
            columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Proxy Number";
            columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Proxy Date";
            columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Court ID";
            columnHeader8.Width = 70;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Lawyer ID";
            columnHeader9.Width = 130;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Actions";
            columnHeader10.Width = 100;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // btnAddCourtCase
            // 
            btnAddCourtCase.Location = new Point(935, 188);
            btnAddCourtCase.Name = "btnAddCourtCase";
            btnAddCourtCase.Size = new Size(114, 46);
            btnAddCourtCase.TabIndex = 4;
            btnAddCourtCase.Text = "Add Court Case";
            btnAddCourtCase.UseVisualStyleBackColor = true;
            btnAddCourtCase.Click += btnAddCourtCase_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.WhiteSmoke;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 19F);
            textBox2.Location = new Point(405, 45);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(251, 34);
            textBox2.TabIndex = 5;
            textBox2.Text = "Court Case Management";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(312, 122);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(442, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnEditCase
            // 
            btnEditCase.Location = new Point(665, 180);
            btnEditCase.Name = "btnEditCase";
            btnEditCase.Size = new Size(75, 23);
            btnEditCase.TabIndex = 0;
            btnEditCase.Text = "Edit Case";
            btnEditCase.Click += btnEditCase_Click;
            // 
            // btnDeleteCase
            // 
            btnDeleteCase.Location = new Point(750, 180);
            btnDeleteCase.Name = "btnDeleteCase";
            btnDeleteCase.Size = new Size(75, 23);
            btnDeleteCase.TabIndex = 0;
            btnDeleteCase.Text = "Delete Case";
            btnDeleteCase.Click += btnDeleteCase_Click;
            // 
            // btnViewCase
            // 
            btnViewCase.Location = new Point(835, 180);
            btnViewCase.Name = "btnViewCase";
            btnViewCase.Size = new Size(75, 23);
            btnViewCase.TabIndex = 0;
            btnViewCase.Text = "View Case";
            btnViewCase.Click += btnViewCase_Click;
            // 
            // comboBoxYear
            // 
            comboBoxYear.Location = new Point(405, 188);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(100, 23);
            comboBoxYear.TabIndex = 6;
            // 
            // comboBoxMonth
            // 
            comboBoxMonth.Location = new Point(556, 188);
            comboBoxMonth.Name = "comboBoxMonth";
            comboBoxMonth.Size = new Size(100, 23);
            comboBoxMonth.TabIndex = 7;
            // 
            // CourtCaseManagement
            // 
            ClientSize = new Size(1072, 450);
            Controls.Add(textBox2);
            Controls.Add(btnAddCourtCase);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            Controls.Add(comboBoxYear);
            Controls.Add(comboBoxMonth);
            Name = "CourtCaseManagement";
            Load += CourtCaseManagement_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBox1;
        private TextBox textBox2;
    }
}
