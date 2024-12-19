namespace Firm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            Username = new Label();
            label1 = new Label();
            submit = new Button();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(247, 145);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 23);
            textBox1.TabIndex = 0;
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Location = new Point(467, 153);
            Username.Name = "Username";
            Username.Size = new Size(78, 15);
            Username.TabIndex = 1;
            Username.Text = "اسم المستخدم";
            Username.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(467, 224);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 2;
            label1.Text = "كلمة المرور";
            // 
            // submit
            // 
            submit.Location = new Point(327, 284);
            submit.Name = "submit";
            submit.Size = new Size(89, 23);
            submit.TabIndex = 3;
            submit.Text = "تسجيل دخول";
            submit.UseVisualStyleBackColor = true;
            submit.Click += submit_Click;
            // 
            // textBox2
            // 
            textBox2.AccessibleName = "passwordbox";
            textBox2.Anchor = AnchorStyles.None;
            textBox2.Location = new Point(247, 216);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 23);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox2);
            Controls.Add(submit);
            Controls.Add(label1);
            Controls.Add(Username);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

