namespace Firm
{
    partial class LegalCourtForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnAddCourtLegal = new Button();
            textBox2 = new TextBox();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            textBoxSearch = new TextBox();
            SuspendLayout();
            // 
            // btnAddCourtLegal
            // 
            btnAddCourtLegal.BackColor = Color.MediumSeaGreen;
            btnAddCourtLegal.BackgroundImageLayout = ImageLayout.Center;
            btnAddCourtLegal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCourtLegal.ForeColor = Color.White;
            btnAddCourtLegal.ImageAlign = ContentAlignment.BottomLeft;
            btnAddCourtLegal.Location = new Point(12, 142);
            btnAddCourtLegal.Name = "btnAddCourtLegal";
            btnAddCourtLegal.Size = new Size(129, 48);
            btnAddCourtLegal.TabIndex = 8;
            btnAddCourtLegal.Text = "إضافة جلسة";
            btnAddCourtLegal.UseVisualStyleBackColor = false;
            btnAddCourtLegal.Click += btnAddtLegalCourt;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.WhiteSmoke;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 19F);
            textBox2.Location = new Point(405, 51);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(251, 34);
            textBox2.TabIndex = 7;
            textBox2.Text = "الدائرة";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // listView1
            // 
            listView1.BackgroundImageTiled = true;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8 });
            listView1.Location = new Point(1, 209);
            listView1.Name = "listView1";
            listView1.Size = new Size(1012, 264);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "رقم الجلسة";
            columnHeader1.Width = 130;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "يوم الجلسة";
            columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "القاضي الأول";
            columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "القاضي الثاني";
            columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "القاضي الثالث";
            columnHeader6.Width = 130;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "القاضي الاحتياطي";
            columnHeader7.Width = 130;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "العمليات";
            columnHeader8.Width = 130;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(302, 100);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Enter Court ID";
            textBoxSearch.Size = new Size(401, 23);
            textBoxSearch.TabIndex = 6;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // LegalCourtForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 485);
            Controls.Add(btnAddCourtLegal);
            Controls.Add(textBox2);
            Controls.Add(listView1);
            Controls.Add(textBoxSearch);
            Name = "LegalCourtForm";
            Text = "LegalCourtForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddCourtLegal;
        private TextBox textBox2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private TextBox textBoxSearch;
    }
}
