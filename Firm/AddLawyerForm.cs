namespace Firm
{
    partial class AddLawyerForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtLastName;
        private TextBox txtSpecialization;
        private TextBox txtUserID;
        private TextBox txtCaseCount;
        private TextBox txtCourtID;
        private TextBox txtPhoneNumber;
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
            this.label1 = new Label();
            this.txtFirstName = new TextBox();
            this.txtMiddleName = new TextBox();
            this.txtLastName = new TextBox();
            this.txtSpecialization = new TextBox();
            this.txtUserID = new TextBox();
            this.txtCaseCount = new TextBox();
            this.txtCourtID = new TextBox();
            this.txtPhoneNumber = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(12, 25);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(176, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(12, 64);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(176, 20);
            this.txtMiddleName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(12, 103);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(176, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // txtSpecialization
            // 
            this.txtSpecialization.Location = new System.Drawing.Point(12, 142);
            this.txtSpecialization.Name = "txtSpecialization";
            this.txtSpecialization.Size = new System.Drawing.Size(176, 20);
            this.txtSpecialization.TabIndex = 4;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(12, 181);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(176, 20);
            this.txtUserID.TabIndex = 5;
            // 
            // txtCaseCount
            // 
            this.txtCaseCount.Location = new System.Drawing.Point(12, 220);
            this.txtCaseCount.Name = "txtCaseCount";
            this.txtCaseCount.Size = new System.Drawing.Size(176, 20);
            this.txtCaseCount.TabIndex = 6;
            // 
            // txtCourtID
            // 
            this.txtCourtID.Location = new System.Drawing.Point(12, 259);
            this.txtCourtID.Name = "txtCourtID";
            this.txtCourtID.Size = new System.Drawing.Size(176, 20);
            this.txtCourtID.TabIndex = 7;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(12, 298);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(176, 20);
            this.txtPhoneNumber.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 334);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(113, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddLawyerForm
            // 
            this.ClientSize = new System.Drawing.Size(200, 375);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtCourtID);
            this.Controls.Add(this.txtCaseCount);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtSpecialization);
            this.Controls.Add(this.txtLast
