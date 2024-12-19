namespace Firm
{
    partial class AddUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxFirstName;
        private TextBox textBoxMiddleName;
        private TextBox textBoxLastName;
        private TextBox textBoxUserRole;
        private TextBox textBoxUsername;
        private DateTimePicker dateTimePickerDateAdded;
        private TextBox textBoxUserPassword;
        private TextBox textBoxPhoneNumber;
        private Button btnSave;
        private Button btnCancel;

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
            textBoxFirstName = new TextBox();
            textBoxMiddleName = new TextBox();
            textBoxLastName = new TextBox();
            textBoxUserRole = new TextBox();
            textBoxPhoneNumber = new TextBox();
            textBoxUsername = new TextBox();
            textBoxUserPassword = new TextBox();
            dateTimePickerDateAdded = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(12, 12);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.PlaceholderText = "First Name";
            textBoxFirstName.Size = new Size(260, 23);
            textBoxFirstName.TabIndex = 0;
            // 
            // textBoxMiddleName
            // 
            textBoxMiddleName.Location = new Point(12, 41);
            textBoxMiddleName.Name = "textBoxMiddleName";
            textBoxMiddleName.PlaceholderText = "Middle Name";
            textBoxMiddleName.Size = new Size(260, 23);
            textBoxMiddleName.TabIndex = 1;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(12, 70);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.PlaceholderText = "Last Name";
            textBoxLastName.Size = new Size(260, 23);
            textBoxLastName.TabIndex = 2;
            // 
            // textBoxUserRole
            // 
            textBoxUserRole.Location = new Point(12, 99);
            textBoxUserRole.Name = "textBoxUserRole";
            textBoxUserRole.PlaceholderText = "Role";
            textBoxUserRole.Size = new Size(260, 23);
            textBoxUserRole.TabIndex = 3;
            textBoxUserRole.KeyPress += textBox_KeyPress_NumberOnly;
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.Location = new Point(12, 128);
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.PlaceholderText = "Phone Number";
            textBoxPhoneNumber.Size = new Size(260, 23);
            textBoxPhoneNumber.TabIndex = 4;
            textBoxPhoneNumber.KeyPress += textBox_KeyPress_NumberOnly;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(12, 157);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "Username";
            textBoxUsername.Size = new Size(260, 23);
            textBoxUsername.TabIndex = 5;
            // 
            // textBoxUserPassword
            // 
            textBoxUserPassword.Location = new Point(12, 186);
            textBoxUserPassword.Name = "textBoxUserPassword";
            textBoxUserPassword.PlaceholderText = "Password";
            textBoxUserPassword.Size = new Size(260, 23);
            textBoxUserPassword.TabIndex = 6;
            textBoxUserPassword.UseSystemPasswordChar = true;
            textBoxUserPassword.TextChanged += textBoxUserPassword_TextChanged;
            // 
            // dateTimePickerDateAdded
            // 
            dateTimePickerDateAdded.Location = new Point(12, 215);
            dateTimePickerDateAdded.Name = "dateTimePickerDateAdded";
            dateTimePickerDateAdded.Size = new Size(260, 23);
            dateTimePickerDateAdded.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(116, 244);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(197, 244);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 281);
            Controls.Add(dateTimePickerDateAdded);
            Controls.Add(textBoxUserPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(textBoxUserRole);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxMiddleName);
            Controls.Add(textBoxFirstName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Name = "AddUserForm";
            Text = "Add / Edit User";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
