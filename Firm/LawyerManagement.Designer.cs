namespace Firm
{
    partial class LawyerManagement
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
        private Button btnAddLawyer;
        private ImageList imageList1;

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
            imageList1 = new ImageList(components);
            btnAddLawyer = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
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
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9 });
            listView1.Location = new Point(-1, 255);
            listView1.Name = "listView1";
            listView1.Size = new Size(896, 270);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Lawyer ID";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "First Name";
            columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Middle Name";
            columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Last Name";
            columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Specialization";
            columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "User ID";
            columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Case Count";
            columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Court ID";
            columnHeader8.Width = 70;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Phone Number";
            columnHeader9.Width = 130;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // btnAddLawyer
            // 
            btnAddLawyer.Location = new Point(781, 166);
            btnAddLawyer.Name = "btnAddLawyer";
            btnAddLawyer.Size = new Size(114, 46);
            btnAddLawyer.TabIndex = 4;
            btnAddLawyer.Text = "Add Lawyer";
            btnAddLawyer.UseVisualStyleBackColor = true;
            btnAddLawyer.Click += btnAddLawyer_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.WhiteSmoke;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 19F);
            textBox2.Location = new Point(270, 22);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(251, 34);
            textBox2.TabIndex = 5;
            textBox2.Text = "Lawyer Management";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(296, 122);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(209, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // LawyerManagement
            // 
            ClientSize = new Size(897, 450);
            Controls.Add(textBox2);
            Controls.Add(btnAddLawyer);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            Name = "LawyerManagement";
            Load += LawyerManagement_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
    }
}
