namespace Firm
{
    partial class AddLawyerForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxFirstName;
        private TextBox textBoxMiddleName;
        private TextBox textBoxLastName;
        private TextBox textBoxSpecialization;
        private TextBox textBoxPhoneNumber;
        private TextBox textBoxCaseCount;
        private TextBox textBoxCourtID;
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
            this.textBoxFirstName = new TextBox();
            this.textBoxMiddleName = new TextBox();
            this.textBoxLastName = new TextBox();
            this.textBoxSpecialization = new TextBox();
            this.textBoxPhoneNumber = new TextBox();
            this.textBoxCaseCount = new TextBox();
            this.textBoxCourtID = new TextBox();
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
            this.textBoxMiddleName.PlaceholderText = "Middle Name";

            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(12, 70);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(260, 23);
            this.textBoxLastName.TabIndex = 2;
            this.textBoxLastName.PlaceholderText = "Last Name";

            // 
            // textBoxSpecialization
            // 
            this.textBoxSpecialization.Location = new System.Drawing.Point(12, 99);
            this.textBoxSpecialization.Name = "textBoxSpecialization";
            this.textBoxSpecialization.Size = new System.Drawing.Size(260, 23);
            this.textBoxSpecialization.TabIndex = 3;
            this.textBoxSpecialization.PlaceholderText = "Specialization";

            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(12, 128);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(260, 23);
            this.textBoxPhoneNumber.TabIndex = 4;
            this.textBoxPhoneNumber.PlaceholderText = "Phone Number";
            this.textBoxPhoneNumber.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress_NumberOnly);

            // 
            // textBoxCaseCount
            // 
            this.textBoxCaseCount.Location = new System.Drawing.Point(12, 157);
            this.textBoxCaseCount.Name = "textBoxCaseCount";
            this.textBoxCaseCount.Size = new System.Drawing.Size(260, 23);
            this.textBoxCaseCount.TabIndex = 5;
            this.textBoxCaseCount.PlaceholderText = "Case Count";
            this.textBoxCaseCount.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress_NumberOnly);

            // 
            // textBoxCourtID
            // 
            this.textBoxCourtID.Location = new System.Drawing.Point(12, 186);
            this.textBoxCourtID.Name = "textBoxCourtID";
            this.textBoxCourtID.Size = new System.Drawing.Size(260, 23);
            this.textBoxCourtID.TabIndex = 6;
            this.textBoxCourtID.PlaceholderText = "Court ID";
            this.textBoxCourtID.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress_NumberOnly);

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
            // AddLawyerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 281);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxCourtID);
            this.Controls.Add(this.textBoxCaseCount);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.textBoxSpecialization);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxMiddleName);
            this.Controls.Add(this.textBoxFirstName);
            this.Name = "AddLawyerForm";
            this.Text = "Add / Edit Lawyer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
