namespace Firm
{
    partial class AddEditLegalCourtForm
    {
       
            private System.ComponentModel.IContainer components = null;
        private Label lblSessionDate;
        private TextBox txtSessionDate;
        private Label lblSessionDay;
        private TextBox txtSessionDay;
        private Label lblJudge1FirstName;
        private TextBox txtJudge1FirstName;
        private Label lblJudge1MiddleName;
        private TextBox txtJudge1MiddleName;
        private Label lblJudge1LastName;
        private TextBox txtJudge1LastName;
        private Label lblJudge2FirstName;
        private TextBox txtJudge2FirstName;
        private Label lblJudge2MiddleName;
        private TextBox txtJudge2MiddleName;
        private Label lblJudge2LastName;
        private TextBox txtJudge2LastName;
        private Label lblJudge3FirstName;
        private TextBox txtJudge3FirstName;
        private Label lblJudge3MiddleName;
        private TextBox txtJudge3MiddleName;
        private Label lblJudge3LastName;
        private TextBox txtJudge3LastName;
        private Label lblReserveJudgeFirstName;
        private TextBox txtReserveJudgeFirstName;
        private Label lblReserveJudgeMiddleName;
        private TextBox txtReserveJudgeMiddleName;
        private Label lblReserveJudgeLastName;
        private TextBox txtReserveJudgeLastName;
        private Button btnSave;
        private Button btnCancel;


        private void InitializeComponent()
        {
            this.lblSessionDay = new Label();
            this.txtSessionDay = new TextBox();
            this.lblJudge1FirstName = new Label();
            this.txtJudge1FirstName = new TextBox();
            this.lblJudge1MiddleName = new Label();
            this.txtJudge1MiddleName = new TextBox();
            this.lblJudge1LastName = new Label();
            this.txtJudge1LastName = new TextBox();
            this.lblJudge2FirstName = new Label();
            this.txtJudge2FirstName = new TextBox();
            this.lblJudge2MiddleName = new Label();
            this.txtJudge2MiddleName = new TextBox();
            this.lblJudge2LastName = new Label();
            this.txtJudge2LastName = new TextBox();
            this.lblJudge3FirstName = new Label();
            this.txtJudge3FirstName = new TextBox();
            this.lblJudge3MiddleName = new Label();
            this.txtJudge3MiddleName = new TextBox();
            this.lblJudge3LastName = new Label();
            this.txtJudge3LastName = new TextBox();
            this.lblReserveJudgeFirstName = new Label();
            this.txtReserveJudgeFirstName = new TextBox();
            this.lblReserveJudgeMiddleName = new Label();
            this.txtReserveJudgeMiddleName = new TextBox();
            this.lblReserveJudgeLastName = new Label();
            this.txtReserveJudgeLastName = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            // Session Day
            this.lblSessionDay.Text = "Session Day:";
            this.lblSessionDay.Location = new Point(10, 10);
            this.txtSessionDay.Location = new Point(120, 10);

            // Judge 1 First Name
            this.lblJudge1FirstName.Text = "Judge 1 First Name:";
            this.lblJudge1FirstName.Location = new Point(10, 40);
            this.txtJudge1FirstName.Location = new Point(120, 40);

            // Judge 1 Middle Name
            this.lblJudge1MiddleName.Text = "Judge 1 Middle Name:";
            this.lblJudge1MiddleName.Location = new Point(10, 70);
            this.txtJudge1MiddleName.Location = new Point(120, 70);

            // Judge 1 Last Name
            this.lblJudge1LastName.Text = "Judge 1 Last Name:";
            this.lblJudge1LastName.Location = new Point(10, 100);
            this.txtJudge1LastName.Location = new Point(120, 100);

            // Judge 2 First Name
            this.lblJudge2FirstName.Text = "Judge 2 First Name:";
            this.lblJudge2FirstName.Location = new Point(10, 130);
            this.txtJudge2FirstName.Location = new Point(120, 130);

            // Judge 2 Middle Name
            this.lblJudge2MiddleName.Text = "Judge 2 Middle Name:";
            this.lblJudge2MiddleName.Location = new Point(10, 160);
            this.txtJudge2MiddleName.Location = new Point(120, 160);

            // Judge 2 Last Name
            this.lblJudge2LastName.Text = "Judge 2 Last Name:";
            this.lblJudge2LastName.Location = new Point(10, 190);
            this.txtJudge2LastName.Location = new Point(120, 190);

            // Judge 3 First Name
            this.lblJudge3FirstName.Text = "Judge 3 First Name:";
            this.lblJudge3FirstName.Location = new Point(10, 220);
            this.txtJudge3FirstName.Location = new Point(120, 220);

            // Judge 3 Middle Name
            this.lblJudge3MiddleName.Text = "Judge 3 Middle Name:";
            this.lblJudge3MiddleName.Location = new Point(10, 250);
            this.txtJudge3MiddleName.Location = new Point(120, 250);

            // Judge 3 Last Name
            this.lblJudge3LastName.Text = "Judge 3 Last Name:";
            this.lblJudge3LastName.Location = new Point(10, 280);
            this.txtJudge3LastName.Location = new Point(120, 280);

            // Reserve Judge First Name
            this.lblReserveJudgeFirstName.Text = "Reserve Judge First Name:";
            this.lblReserveJudgeFirstName.Location = new Point(10, 310);
            this.txtReserveJudgeFirstName.Location = new Point(120, 310);

            // Reserve Judge Middle Name
            this.lblReserveJudgeMiddleName.Text = "Reserve Judge Middle Name:";
            this.lblReserveJudgeMiddleName.Location = new Point(10, 340);
            this.txtReserveJudgeMiddleName.Location = new Point(120, 340);

            // Reserve Judge Last Name
            this.lblReserveJudgeLastName.Text = "Reserve Judge Last Name:";
            this.lblReserveJudgeLastName.Location = new Point(10, 370);
            this.txtReserveJudgeLastName.Location = new Point(120, 370);

            // Save Button
            this.btnSave.Text = "Save";
            this.btnSave.Location = new Point(50, 420);
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // Cancel Button
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new Point(150, 420);
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize = new Size(300, 480);
            this.Controls.Add(this.lblSessionDay);
            this.Controls.Add(this.txtSessionDay);
            this.Controls.Add(this.lblJudge1FirstName);
            this.Controls.Add(this.txtJudge1FirstName);
            this.Controls.Add(this.lblJudge1MiddleName);
            this.Controls.Add(this.txtJudge1MiddleName);
            this.Controls.Add(this.lblJudge1LastName);
            this.Controls.Add(this.txtJudge1LastName);
            this.Controls.Add(this.lblJudge2FirstName);
            this.Controls.Add(this.txtJudge2FirstName);
            this.Controls.Add(this.lblJudge2MiddleName);
            this.Controls.Add(this.txtJudge2MiddleName);
            this.Controls.Add(this.lblJudge2LastName);
            this.Controls.Add(this.txtJudge2LastName);
            this.Controls.Add(this.lblJudge3FirstName);
            this.Controls.Add(this.txtJudge3FirstName);
            this.Controls.Add(this.lblJudge3MiddleName);
            this.Controls.Add(this.txtJudge3MiddleName);
            this.Controls.Add(this.lblJudge3LastName);
            this.Controls.Add(this.txtJudge3LastName);
            this.Controls.Add(this.lblReserveJudgeFirstName);
            this.Controls.Add(this.txtReserveJudgeFirstName);
            this.Controls.Add(this.lblReserveJudgeMiddleName);
            this.Controls.Add(this.txtReserveJudgeMiddleName);
            this.Controls.Add(this.lblReserveJudgeLastName);
            this.Controls.Add(this.txtReserveJudgeLastName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "Add / Edit Court Form";
            this.Text = "Add / Edit Court Case";
            this.PerformLayout();

        }

    }
}
