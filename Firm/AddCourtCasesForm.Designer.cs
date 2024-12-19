namespace Firm
{
    partial class AddCourtCaseForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBoxCaseStatus;
        private DateTimePicker dateTimePickerCaseDate;
        private DateTimePicker dateTimePickerProxyDate;
        private TextBox textBoxDefendantName;
        private TextBox textBoxCharge;
        private TextBox textBoxProxyNumber;
        private TextBox textBoxCourtID;
        private TextBox textBoxLawyerID;
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
            this.textBoxDefendantName = new TextBox();
            this.comboBoxCaseStatus = new ComboBox();
            this.textBoxCharge = new TextBox();
            this.dateTimePickerCaseDate = new DateTimePicker();
            this.textBoxProxyNumber = new TextBox();
            this.dateTimePickerProxyDate = new DateTimePicker();
            this.textBoxCourtID = new TextBox();
            this.textBoxLawyerID = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // 
            // textBoxDefendantName
            // 
            this.textBoxDefendantName.Location = new System.Drawing.Point(12, 12);
            this.textBoxDefendantName.Name = "textBoxDefendantName";
            this.textBoxDefendantName.Size = new System.Drawing.Size(260, 23);
            this.textBoxDefendantName.TabIndex = 0;
            this.textBoxDefendantName.PlaceholderText = "Defendant Name";

            // 
            // comboBoxCaseStatus
            // 
            this.comboBoxCaseStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxCaseStatus.Items.AddRange(new object[] { "Ongoing", "Closed" });
            this.comboBoxCaseStatus.Location = new System.Drawing.Point(12, 41);
            this.comboBoxCaseStatus.Name = "comboBoxCaseStatus";
            this.comboBoxCaseStatus.Size = new System.Drawing.Size(260, 23);
            this.comboBoxCaseStatus.TabIndex = 1;

            // 
            // textBoxCharge
            // 
            this.textBoxCharge.Location = new System.Drawing.Point(12, 70);
            this.textBoxCharge.Name = "textBoxCharge";
            this.textBoxCharge.Size = new System.Drawing.Size(260, 23);
            this.textBoxCharge.TabIndex = 2;
            this.textBoxCharge.PlaceholderText = "Charge";

            // 
            // dateTimePickerCaseDate
            // 
            this.dateTimePickerCaseDate.Location = new System.Drawing.Point(12, 99);
            this.dateTimePickerCaseDate.Name = "dateTimePickerCaseDate";
            this.dateTimePickerCaseDate.Size = new System.Drawing.Size(260, 23);
            this.dateTimePickerCaseDate.TabIndex = 3;

            // 
            // textBoxProxyNumber
            // 
            this.textBoxProxyNumber.Location = new System.Drawing.Point(12, 128);
            this.textBoxProxyNumber.Name = "textBoxProxyNumber";
            this.textBoxProxyNumber.Size = new System.Drawing.Size(260, 23);
            this.textBoxProxyNumber.TabIndex = 4;
            this.textBoxProxyNumber.PlaceholderText = "Proxy Number";
            this.textBoxProxyNumber.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress_NumberOnly);

            // 
            // dateTimePickerProxyDate
            // 
            this.dateTimePickerProxyDate.Location = new System.Drawing.Point(12, 157);
            this.dateTimePickerProxyDate.Name = "dateTimePickerProxyDate";
            this.dateTimePickerProxyDate.Size = new System.Drawing.Size(260, 23);
            this.dateTimePickerProxyDate.TabIndex = 5;

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
            // textBoxLawyerID
            // 
            this.textBoxLawyerID.Location = new System.Drawing.Point(12, 215);
            this.textBoxLawyerID.Name = "textBoxLawyerID";
            this.textBoxLawyerID.Size = new System.Drawing.Size(260, 23);
            this.textBoxLawyerID.TabIndex = 7;
            this.textBoxLawyerID.PlaceholderText = "Lawyer ID";
            this.textBoxLawyerID.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress_NumberOnly);

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(116, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // AddCourtCaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 281);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxLawyerID);
            this.Controls.Add(this.textBoxCourtID);
            this.Controls.Add(this.dateTimePickerProxyDate);
            this.Controls.Add(this.textBoxProxyNumber);
            this.Controls.Add(this.dateTimePickerCaseDate);
            this.Controls.Add(this.textBoxCharge);
            this.Controls.Add(this.comboBoxCaseStatus);
            this.Controls.Add(this.textBoxDefendantName);
            this.Name = "AddCourtCaseForm";
            this.Text = "Add / Edit Court Case";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        
    }
}
