namespace Connector.Client
{
    partial class frmRestClient
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMethod = new Label();
            cmbMethod = new ComboBox();
            lblName = new Label();
            txtName = new TextBox();
            txtAuthUrl = new TextBox();
            lblAuthUrl = new Label();
            cmbAuthType = new ComboBox();
            lblAuthType = new Label();
            txtKey = new TextBox();
            txtSecret = new TextBox();
            txtToken = new TextBox();
            lblKey = new Label();
            lblSecret = new Label();
            lblToken = new Label();
            txtBaseUrl = new TextBox();
            lblBaseUrl = new Label();
            txtResourceUrl = new TextBox();
            lblResourceUrl = new Label();
            trOutput = new TreeView();
            lblResponseOutput = new Label();
            txtNextUrl = new TextBox();
            lblNextUrl = new Label();
            btnAuthGo = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            lblHeaders = new Label();
            lblParameters = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btnSaveAuthDetails = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Location = new Point(6, 80);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(49, 15);
            lblMethod.TabIndex = 0;
            lblMethod.Text = "Method";
            // 
            // cmbMethod
            // 
            cmbMethod.FormattingEnabled = true;
            cmbMethod.Location = new Point(80, 77);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(168, 23);
            cmbMethod.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(25, 22);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(106, 19);
            txtName.Name = "txtName";
            txtName.Size = new Size(394, 23);
            txtName.TabIndex = 3;
            // 
            // txtAuthUrl
            // 
            txtAuthUrl.Location = new Point(80, 28);
            txtAuthUrl.Name = "txtAuthUrl";
            txtAuthUrl.Size = new Size(395, 23);
            txtAuthUrl.TabIndex = 5;
            // 
            // lblAuthUrl
            // 
            lblAuthUrl.AutoSize = true;
            lblAuthUrl.Location = new Point(3, 31);
            lblAuthUrl.Name = "lblAuthUrl";
            lblAuthUrl.Size = new Size(57, 15);
            lblAuthUrl.TabIndex = 4;
            lblAuthUrl.Text = "Auth URL";
            // 
            // cmbAuthType
            // 
            cmbAuthType.FormattingEnabled = true;
            cmbAuthType.Location = new Point(348, 77);
            cmbAuthType.Name = "cmbAuthType";
            cmbAuthType.Size = new Size(127, 23);
            cmbAuthType.TabIndex = 7;
            // 
            // lblAuthType
            // 
            lblAuthType.AutoSize = true;
            lblAuthType.Location = new Point(275, 80);
            lblAuthType.Name = "lblAuthType";
            lblAuthType.Size = new Size(60, 15);
            lblAuthType.TabIndex = 6;
            lblAuthType.Text = "Auth Type";
            // 
            // txtKey
            // 
            txtKey.Location = new Point(81, 127);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(167, 23);
            txtKey.TabIndex = 8;
            // 
            // txtSecret
            // 
            txtSecret.Location = new Point(348, 127);
            txtSecret.Name = "txtSecret";
            txtSecret.Size = new Size(127, 23);
            txtSecret.TabIndex = 9;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(81, 168);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(395, 23);
            txtToken.TabIndex = 10;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Location = new Point(6, 130);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(26, 15);
            lblKey.TabIndex = 11;
            lblKey.Text = "Key";
            // 
            // lblSecret
            // 
            lblSecret.AutoSize = true;
            lblSecret.Location = new Point(275, 130);
            lblSecret.Name = "lblSecret";
            lblSecret.Size = new Size(39, 15);
            lblSecret.TabIndex = 12;
            lblSecret.Text = "Secret";
            // 
            // lblToken
            // 
            lblToken.AutoSize = true;
            lblToken.Location = new Point(3, 171);
            lblToken.Name = "lblToken";
            lblToken.Size = new Size(38, 15);
            lblToken.TabIndex = 13;
            lblToken.Text = "Token";
            // 
            // txtBaseUrl
            // 
            txtBaseUrl.Location = new Point(134, 30);
            txtBaseUrl.Name = "txtBaseUrl";
            txtBaseUrl.Size = new Size(346, 23);
            txtBaseUrl.TabIndex = 15;
            // 
            // lblBaseUrl
            // 
            lblBaseUrl.AutoSize = true;
            lblBaseUrl.Location = new Point(18, 30);
            lblBaseUrl.Name = "lblBaseUrl";
            lblBaseUrl.Size = new Size(55, 15);
            lblBaseUrl.TabIndex = 14;
            lblBaseUrl.Text = "Base URL";
            // 
            // txtResourceUrl
            // 
            txtResourceUrl.Location = new Point(134, 76);
            txtResourceUrl.Name = "txtResourceUrl";
            txtResourceUrl.Size = new Size(346, 23);
            txtResourceUrl.TabIndex = 17;
            // 
            // lblResourceUrl
            // 
            lblResourceUrl.AutoSize = true;
            lblResourceUrl.Location = new Point(18, 79);
            lblResourceUrl.Name = "lblResourceUrl";
            lblResourceUrl.Size = new Size(79, 15);
            lblResourceUrl.TabIndex = 16;
            lblResourceUrl.Text = "Resource URL";
            // 
            // trOutput
            // 
            trOutput.Location = new Point(25, 323);
            trOutput.Name = "trOutput";
            trOutput.Size = new Size(484, 306);
            trOutput.TabIndex = 18;
            trOutput.NodeMouseClick += trOutput_NodeMouseClick;
            // 
            // lblResponseOutput
            // 
            lblResponseOutput.AutoSize = true;
            lblResponseOutput.Location = new Point(25, 305);
            lblResponseOutput.Name = "lblResponseOutput";
            lblResponseOutput.Size = new Size(98, 15);
            lblResponseOutput.TabIndex = 19;
            lblResponseOutput.Text = "Response Output";
            // 
            // txtNextUrl
            // 
            txtNextUrl.Location = new Point(133, 488);
            txtNextUrl.Name = "txtNextUrl";
            txtNextUrl.Size = new Size(347, 23);
            txtNextUrl.TabIndex = 21;
            // 
            // lblNextUrl
            // 
            lblNextUrl.AutoSize = true;
            lblNextUrl.Location = new Point(18, 488);
            lblNextUrl.Name = "lblNextUrl";
            lblNextUrl.Size = new Size(56, 15);
            lblNextUrl.TabIndex = 20;
            lblNextUrl.Text = "Next URL";
            // 
            // btnAuthGo
            // 
            btnAuthGo.Location = new Point(401, 202);
            btnAuthGo.Name = "btnAuthGo";
            btnAuthGo.Size = new Size(75, 23);
            btnAuthGo.TabIndex = 22;
            btnAuthGo.Text = "Validate";
            btnAuthGo.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(405, 543);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 23;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(307, 543);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblHeaders
            // 
            lblHeaders.AutoSize = true;
            lblHeaders.Location = new Point(23, 129);
            lblHeaders.Name = "lblHeaders";
            lblHeaders.Size = new Size(50, 15);
            lblHeaders.TabIndex = 25;
            lblHeaders.Text = "Headers";
            // 
            // lblParameters
            // 
            lblParameters.AutoSize = true;
            lblParameters.Location = new Point(18, 292);
            lblParameters.Name = "lblParameters";
            lblParameters.Size = new Size(66, 15);
            lblParameters.TabIndex = 26;
            lblParameters.Text = "Parameters";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSaveAuthDetails);
            groupBox1.Controls.Add(btnAuthGo);
            groupBox1.Controls.Add(lblToken);
            groupBox1.Controls.Add(lblSecret);
            groupBox1.Controls.Add(lblKey);
            groupBox1.Controls.Add(txtToken);
            groupBox1.Controls.Add(txtSecret);
            groupBox1.Controls.Add(txtKey);
            groupBox1.Controls.Add(cmbAuthType);
            groupBox1.Controls.Add(lblAuthType);
            groupBox1.Controls.Add(txtAuthUrl);
            groupBox1.Controls.Add(lblAuthUrl);
            groupBox1.Controls.Add(cmbMethod);
            groupBox1.Controls.Add(lblMethod);
            groupBox1.Location = new Point(25, 43);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(484, 243);
            groupBox1.TabIndex = 27;
            groupBox1.TabStop = false;
            groupBox1.Text = "Authentication";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblParameters);
            groupBox2.Controls.Add(lblHeaders);
            groupBox2.Controls.Add(btnCancel);
            groupBox2.Controls.Add(btnSave);
            groupBox2.Controls.Add(txtNextUrl);
            groupBox2.Controls.Add(lblNextUrl);
            groupBox2.Controls.Add(txtResourceUrl);
            groupBox2.Controls.Add(lblResourceUrl);
            groupBox2.Controls.Add(txtBaseUrl);
            groupBox2.Controls.Add(lblBaseUrl);
            groupBox2.Location = new Point(517, 44);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(485, 585);
            groupBox2.TabIndex = 28;
            groupBox2.TabStop = false;
            groupBox2.Text = "Resource";
            // 
            // btnSaveAuthDetails
            // 
            btnSaveAuthDetails.Location = new Point(320, 202);
            btnSaveAuthDetails.Name = "btnSaveAuthDetails";
            btnSaveAuthDetails.Size = new Size(75, 23);
            btnSaveAuthDetails.TabIndex = 23;
            btnSaveAuthDetails.Text = "Save";
            btnSaveAuthDetails.UseVisualStyleBackColor = true;
            btnSaveAuthDetails.Click += btnSaveAuthDetails_Click;
            // 
            // frmRestClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 641);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblResponseOutput);
            Controls.Add(trOutput);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Name = "frmRestClient";
            Text = "REST Client";
            Load += frmRestClient_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMethod;
        private ComboBox cmbMethod;
        private Label lblName;
        private TextBox txtName;
        private TextBox txtAuthUrl;
        private Label lblAuthUrl;
        private ComboBox cmbAuthType;
        private Label lblAuthType;
        private TextBox txtKey;
        private TextBox txtSecret;
        private TextBox txtToken;
        private Label lblKey;
        private Label lblSecret;
        private Label lblToken;
        private TextBox txtBaseUrl;
        private Label lblBaseUrl;
        private TextBox txtResourceUrl;
        private Label lblResourceUrl;
        private TreeView trOutput;
        private Label lblResponseOutput;
        private TextBox txtNextUrl;
        private Label lblNextUrl;
        private Button btnAuthGo;
        private Button btnSave;
        private Button btnCancel;
        private Label lblHeaders;
        private Label lblParameters;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnSaveAuthDetails;
    }
}