namespace Firm
{
    partial class MainForm
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
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            pnlSideMenu = new Panel();
            label13 = new Label();
            lblTitle = new Label();
            pnlTop = new Panel();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            pnlSideMenu.SuspendLayout();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AccessibleName = "MainPage";
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(56, 140);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "الصفحة الرئيسية";
            // 
            // label2
            // 
            label2.AccessibleName = "username";
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(65, 45);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 1;
            label2.Text = "اسم المستخدم";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AccessibleName = "Filemanaging";
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(73, 187);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "إدارة الملفات";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AccessibleName = "usermanaging";
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(51, 305);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 3;
            label4.Text = "إدارة المستخدمين";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AccessibleName = "lawersmanging";
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(64, 232);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 4;
            label5.Text = "إدارة المحاميين";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AccessibleName = "signout";
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(84, 520);
            label6.Name = "label6";
            label6.Size = new Size(68, 15);
            label6.TabIndex = 5;
            label6.Text = "تسجيل خروج";
            label6.Click += label6_Click;
            // 
            // pnlSideMenu
            // 
            pnlSideMenu.BackColor = Color.FromArgb(32, 44, 95);
            pnlSideMenu.Controls.Add(label13);
            pnlSideMenu.Controls.Add(label6);
            pnlSideMenu.Controls.Add(label5);
            pnlSideMenu.Controls.Add(label4);
            pnlSideMenu.Controls.Add(label3);
            pnlSideMenu.Controls.Add(label2);
            pnlSideMenu.Controls.Add(label1);
            pnlSideMenu.Dock = DockStyle.Right;
            pnlSideMenu.Location = new Point(824, 0);
            pnlSideMenu.Name = "pnlSideMenu";
            pnlSideMenu.Size = new Size(200, 768);
            pnlSideMenu.TabIndex = 1;
            pnlSideMenu.Paint += pnlSideMenu_Paint;
            // 
            // label13
            // 
            label13.AccessibleName = "usermanaging";
            label13.AutoSize = true;
            label13.ForeColor = SystemColors.ControlLightLight;
            label13.Location = new Point(80, 270);
            label13.Name = "label13";
            label13.Size = new Size(63, 15);
            label13.TabIndex = 6;
            label13.Text = "إدارة الدوائر";
            label13.Click += label13_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(450, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(148, 29);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "الصفحة الرئيسية";
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(32, 44, 95);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(824, 60);
            pnlTop.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(622, 270);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 2;
            label7.Text = "عدد القضايا";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(405, 270);
            label8.Name = "label8";
            label8.Size = new Size(110, 15);
            label8.TabIndex = 3;
            label8.Text = "عدد القضايا المتداوله";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(158, 270);
            label9.Name = "label9";
            label9.Size = new Size(163, 15);
            label9.TabIndex = 4;
            label9.Text = "عدد القضايا المنتهية والمحفوظه";
            // 
            // label10
            // 
            label10.AccessibleName = "casenumbers";
            label10.AutoSize = true;
            label10.Location = new Point(642, 329);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 5;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.AccessibleName = "casetrending";
            label11.AutoSize = true;
            label11.Location = new Point(450, 329);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 6;
            label11.Text = "label11";
            // 
            // label12
            // 
            label12.AccessibleName = "casesfinished";
            label12.AutoSize = true;
            label12.Location = new Point(224, 329);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 7;
            label12.Text = "label12";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1024, 768);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(pnlTop);
            Controls.Add(pnlSideMenu);
            Name = "MainForm";
            pnlSideMenu.ResumeLayout(false);
            pnlSideMenu.PerformLayout();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void CreateStatisticsPanel(string title, string value, int x, int y)
        {
            Panel panel = new System.Windows.Forms.Panel();
            panel.Size = new System.Drawing.Size(200, 150);
            panel.Location = new System.Drawing.Point(x, y);
            panel.BackColor = System.Drawing.Color.White;
            panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            Label lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text = title;
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(50, 30);
            lblTitle.Font = new System.Drawing.Font("Arial", 12);

            Label lblValue = new System.Windows.Forms.Label();
            lblValue.Text = value;
            lblValue.AutoSize = true;
            lblValue.Location = new System.Drawing.Point(90, 70);
            lblValue.Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold);

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
            this.Controls.Add(panel);
        }

        private void AddMenuItem(string text, int y)
        {
            Button btn = new System.Windows.Forms.Button();
            btn.Text = text;
            btn.Width = 200;
            btn.Height = 40;
            btn.Location = new System.Drawing.Point(0, y);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.ForeColor = System.Drawing.Color.White;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btn.Font = new System.Drawing.Font("Arial", 12);

            this.pnlSideMenu.Controls.Add(btn);
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel pnlSideMenu;
        private Label lblTitle;
        private Panel pnlTop;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}