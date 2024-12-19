using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Drawing;
using System.Windows.Forms;
using LegalCaseManagementSystem.CRUD;
using LegalCaseManagementSystem.Models;

namespace Firm
{
    partial class FinishedCasesForm : Form
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
        private ColumnHeader columnHeader10; // Actions column
        private Button btnAddCourtCase;
        private ImageList imageList1;
        private TextBox textBoxHeader;
        private TextBox textBox1;

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
            textBoxHeader = new TextBox();
            textBox1 = new TextBox();
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
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(0, 218);
            listView1.Name = "listView1";
            listView1.Size = new Size(945, 350);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.MouseClick += listView1_MouseClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Case ID";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Defendant Name";
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Case Status";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Charge";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Case Date";
            columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Proxy Number";
            columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Proxy Date";
            columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Court ID";
            columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Lawyer ID";
            columnHeader9.Width = 90;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = " Actions";
            columnHeader10.Width = 100;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // btnAddCourtCase
            // 
            btnAddCourtCase.Location = new Point(725, 160);
            btnAddCourtCase.Name = "btnAddCourtCase";
            btnAddCourtCase.Size = new Size(120, 40);
            btnAddCourtCase.TabIndex = 1;
            btnAddCourtCase.Text = "btnPrintCourtTuple";
            btnAddCourtCase.UseVisualStyleBackColor = true;
            btnAddCourtCase.Click += btnPrintCourtTuple_Click;
            // 
            // textBoxHeader
            // 
            textBoxHeader.BackColor = Color.WhiteSmoke;
            textBoxHeader.BorderStyle = BorderStyle.None;
            textBoxHeader.Font = new Font("Segoe UI", 16F);
            textBoxHeader.Location = new Point(260, 20);
            textBoxHeader.Name = "textBoxHeader";
            textBoxHeader.ReadOnly = true;
            textBoxHeader.Size = new Size(300, 29);
            textBoxHeader.TabIndex = 2;
            textBoxHeader.Text = "Finished Court Cases";
            textBoxHeader.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(260, 112);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(331, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBoxYear
            // 
            comboBoxYear.Location = new Point(297, 160);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(100, 23);
            comboBoxYear.TabIndex = 8;
            // 
            // comboBoxMonth
            // 
            comboBoxMonth.Location = new Point(448, 160);
            comboBoxMonth.Name = "comboBoxMonth";
            comboBoxMonth.Size = new Size(100, 23);
            comboBoxMonth.TabIndex = 9;
            // 
            // FinishedCasesForm
            // 
            ClientSize = new Size(943, 570);
            Controls.Add(comboBoxYear);
            Controls.Add(comboBoxMonth);
            Controls.Add(textBox1);
            Controls.Add(textBoxHeader);
            Controls.Add(btnAddCourtCase);
            Controls.Add(listView1);
            Name = "FinishedCasesForm";
            Text = "Finished Cases";
            Load += FinishedCasesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox comboBoxYear;
        private ComboBox comboBoxMonth;
    }
}