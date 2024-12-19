using System.Data;

namespace Firm
{
    partial class AddUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxUserRole;
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

        private TextBox textBoxMiddleName;
        private TextBox textBoxUserPassword;
private TextBox textBoxUsername;

        private void InitializeComponent()
        {
            this.textBoxFirstName = new TextBox();
            this.textBoxMiddleName = new TextBox(); // New field
            this.textBoxLastName = new TextBox();
            this.textBoxUserRole = new TextBox();
            this.textBoxPhoneNumber = new TextBox();
            this.textBoxUsername = new TextBox(); // New field
            this.textBoxUserPassword = new TextBox(); // New field
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(12, 12);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(260, 23);
            this.textBoxFirstName.TabIndex = 0;
            this.textBoxFirstName.PlaceholderText = "First Name";

            // 
            // textBoxMiddleName
            // 
            this.textBoxMiddleName.Location = new System.Drawing.Point(12, 41);
            this.textBoxMiddleName.Name = "textBoxMiddleName";
            this.textBoxMiddleName.Size = new System.Drawing.Size(260, 23);
            this.textBoxMiddleName.TabIndex = 1;
            this.textBoxMiddleName.PlaceholderText = "Middle Name"; // New field

            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(12, 70);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(260, 23);
            this.textBoxLastName.TabIndex = 2;
            this.textBoxLastName.PlaceholderText = "Last Name";

            // 
            // textBoxUser Role
            // 
            this.textBoxUserRole.Location = new System.Drawing.Point(12, 99);
            this.textBoxUserRole.Name = "textBoxUser Role";
            this.textBoxUserRole.Size = new System.Drawing.Size(260, 23);
            this.textBoxUserRole.TabIndex = 3;
            this.textBoxUserRole.PlaceholderText = "Role";

            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(12, 128);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(260, 23);
            this.textBoxPhoneNumber.TabIndex = 4;
            this.textBoxPhoneNumber.PlaceholderText = "Phone Number";

            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(12, 157);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(260, 23);
            this.textBoxUsername.TabIndex = 5;
            this.textBoxUsername.PlaceholderText = "Username"; // New field

            // 
            // textBoxUser Password
            // 
            this.textBoxUserPassword.Location = new System.Drawing.Point(12, 186);
            this.textBoxUserPassword.Name = "textBoxUser Password";
            this.textBoxUserPassword.Size = new System.Drawing.Size(260, 23);
            this.textBoxUserPassword.TabIndex = 6;
            this.textBoxUserPassword.PlaceholderText = "User  Password"; // New field
            this.textBoxUserPassword.UseSystemPasswordChar = true; // Mask the password input

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(116, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // AddUser Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxUserPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.textBoxUserRole);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxMiddleName); // New field
            this.Controls.Add(this.textBoxFirstName);
            this.Name = "AddUser Form";
            this.Text = "Add / Edit User";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
