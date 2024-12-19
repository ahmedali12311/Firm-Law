    namespace Firm
    {
        partial class UserManagement
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
            private TextBox textBox1;
            private TextBox textBox2;
            private Button btnAddUser;
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnAddUser = new Button();
            imageList1 = new ImageList(components);
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
            listView1.BackgroundImageTiled = true;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listView1.Location = new Point(-1, 255);
            listView1.Name = "listView1";
            listView1.Size = new Size(912, 264);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "User ID";
            columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "First Name";
            columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Last Name";
            columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Role";
            columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Phone Number";
            columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Date Added";
            columnHeader6.Width = 130;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Actions";
            columnHeader7.Width = 130;
            // 
            // textBox1
            // 
            textBox1.AccessibleName = "SearchBar";
            textBox1.Location = new Point(204, 110);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(458, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.WhiteSmoke;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 19F);
            textBox2.Location = new Point(321, 29);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(251, 34);
            textBox2.TabIndex = 2;
            textBox2.Text = "User Management";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.MediumSeaGreen;
            btnAddUser.BackgroundImageLayout = ImageLayout.Center;
            btnAddUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.ImageAlign = ContentAlignment.BottomLeft;
            btnAddUser.Location = new Point(37, 193);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(122, 45);
            btnAddUser.TabIndex = 4;
            btnAddUser.Text = "إضافة مستخدمين";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // UserManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 519);
            Controls.Add(btnAddUser);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            Name = "UserManagement";
            Text = "UserManagement";
            Load += UserManagement_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
    }
