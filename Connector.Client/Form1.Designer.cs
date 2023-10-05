﻿namespace Connector.Client
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
            groupBox1 = new GroupBox();
            cmbContentType = new ComboBox();
            lblContentType = new Label();
            groupBox2 = new GroupBox();
            tabControl = new TabControl();
            tabHeadersPage = new TabPage();
            dataGridViewHeader = new DataGridView();
            Key = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            tabQueryParametersPage = new TabPage();
            dataGridViewQueryParameters = new DataGridView();
            tabBodyPage = new TabPage();
            rtxBody = new RichTextBox();
            btnRun = new Button();
            QKey = new DataGridViewTextBoxColumn();
            QValue = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl.SuspendLayout();
            tabHeadersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHeader).BeginInit();
            tabQueryParametersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQueryParameters).BeginInit();
            tabBodyPage.SuspendLayout();
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
            cmbMethod.Size = new Size(117, 23);
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
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(394, 23);
            txtName.TabIndex = 3;
            // 
            // txtAuthUrl
            // 
            txtAuthUrl.Location = new Point(80, 28);
            txtAuthUrl.Name = "txtAuthUrl";
            txtAuthUrl.PlaceholderText = "Auth URL";
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
            cmbAuthType.Location = new Point(80, 124);
            cmbAuthType.Name = "cmbAuthType";
            cmbAuthType.Size = new Size(117, 23);
            cmbAuthType.TabIndex = 7;
            // 
            // lblAuthType
            // 
            lblAuthType.AutoSize = true;
            lblAuthType.Location = new Point(10, 127);
            lblAuthType.Name = "lblAuthType";
            lblAuthType.Size = new Size(60, 15);
            lblAuthType.TabIndex = 6;
            lblAuthType.Text = "Auth Type";
            // 
            // txtKey
            // 
            txtKey.Location = new Point(80, 175);
            txtKey.Name = "txtKey";
            txtKey.PlaceholderText = "Key";
            txtKey.Size = new Size(167, 23);
            txtKey.TabIndex = 8;
            // 
            // txtSecret
            // 
            txtSecret.Location = new Point(348, 175);
            txtSecret.Name = "txtSecret";
            txtSecret.PlaceholderText = "Secret";
            txtSecret.Size = new Size(127, 23);
            txtSecret.TabIndex = 9;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(80, 216);
            txtToken.Name = "txtToken";
            txtToken.PlaceholderText = "Token";
            txtToken.Size = new Size(395, 23);
            txtToken.TabIndex = 10;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Location = new Point(8, 178);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(26, 15);
            lblKey.TabIndex = 11;
            lblKey.Text = "Key";
            // 
            // lblSecret
            // 
            lblSecret.AutoSize = true;
            lblSecret.Location = new Point(277, 178);
            lblSecret.Name = "lblSecret";
            lblSecret.Size = new Size(39, 15);
            lblSecret.TabIndex = 12;
            lblSecret.Text = "Secret";
            // 
            // lblToken
            // 
            lblToken.AutoSize = true;
            lblToken.Location = new Point(5, 219);
            lblToken.Name = "lblToken";
            lblToken.Size = new Size(38, 15);
            lblToken.TabIndex = 13;
            lblToken.Text = "Token";
            // 
            // txtBaseUrl
            // 
            txtBaseUrl.Location = new Point(134, 30);
            txtBaseUrl.Name = "txtBaseUrl";
            txtBaseUrl.PlaceholderText = "Base URL";
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
            txtResourceUrl.PlaceholderText = "Resource URL";
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
            txtNextUrl.Location = new Point(129, 545);
            txtNextUrl.Name = "txtNextUrl";
            txtNextUrl.PlaceholderText = "Next Page URL";
            txtNextUrl.Size = new Size(347, 23);
            txtNextUrl.TabIndex = 21;
            // 
            // lblNextUrl
            // 
            lblNextUrl.AutoSize = true;
            lblNextUrl.Location = new Point(14, 545);
            lblNextUrl.Name = "lblNextUrl";
            lblNextUrl.Size = new Size(56, 15);
            lblNextUrl.TabIndex = 20;
            lblNextUrl.Text = "Next URL";
            // 
            // btnAuthGo
            // 
            btnAuthGo.Location = new Point(922, 22);
            btnAuthGo.Name = "btnAuthGo";
            btnAuthGo.Size = new Size(75, 23);
            btnAuthGo.TabIndex = 22;
            btnAuthGo.Text = "Validate";
            btnAuthGo.UseVisualStyleBackColor = true;
            btnAuthGo.Click += btnAuthGo_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(841, 22);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 23;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(760, 22);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbContentType);
            groupBox1.Controls.Add(lblContentType);
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
            groupBox1.Size = new Size(484, 259);
            groupBox1.TabIndex = 27;
            groupBox1.TabStop = false;
            groupBox1.Text = "Authentication";
            // 
            // cmbContentType
            // 
            cmbContentType.FormattingEnabled = true;
            cmbContentType.Location = new Point(307, 77);
            cmbContentType.Name = "cmbContentType";
            cmbContentType.Size = new Size(168, 23);
            cmbContentType.TabIndex = 15;
            // 
            // lblContentType
            // 
            lblContentType.AutoSize = true;
            lblContentType.Location = new Point(208, 80);
            lblContentType.Name = "lblContentType";
            lblContentType.Size = new Size(79, 15);
            lblContentType.TabIndex = 14;
            lblContentType.Text = "Content-Type";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tabControl);
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
            // tabControl
            // 
            tabControl.Controls.Add(tabHeadersPage);
            tabControl.Controls.Add(tabQueryParametersPage);
            tabControl.Controls.Add(tabBodyPage);
            tabControl.Location = new Point(18, 123);
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(462, 416);
            tabControl.SizeMode = TabSizeMode.FillToRight;
            tabControl.TabIndex = 27;
            // 
            // tabHeadersPage
            // 
            tabHeadersPage.Controls.Add(dataGridViewHeader);
            tabHeadersPage.Location = new Point(4, 24);
            tabHeadersPage.Name = "tabHeadersPage";
            tabHeadersPage.Padding = new Padding(3);
            tabHeadersPage.Size = new Size(454, 388);
            tabHeadersPage.TabIndex = 0;
            tabHeadersPage.Text = "Headers";
            tabHeadersPage.UseVisualStyleBackColor = true;
            // 
            // dataGridViewHeader
            // 
            dataGridViewHeader.AllowUserToOrderColumns = true;
            dataGridViewHeader.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHeader.Columns.AddRange(new DataGridViewColumn[] { Key, Value });
            dataGridViewHeader.Location = new Point(6, 7);
            dataGridViewHeader.Name = "dataGridViewHeader";
            dataGridViewHeader.RowTemplate.Height = 25;
            dataGridViewHeader.Size = new Size(440, 375);
            dataGridViewHeader.TabIndex = 0;
            // 
            // Key
            // 
            Key.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Key.HeaderText = "Key";
            Key.Name = "Key";
            // 
            // Value
            // 
            Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Value.HeaderText = "Values";
            Value.Name = "Value";
            // 
            // tabQueryParametersPage
            // 
            tabQueryParametersPage.Controls.Add(dataGridViewQueryParameters);
            tabQueryParametersPage.Location = new Point(4, 24);
            tabQueryParametersPage.Name = "tabQueryParametersPage";
            tabQueryParametersPage.Padding = new Padding(3);
            tabQueryParametersPage.Size = new Size(454, 388);
            tabQueryParametersPage.TabIndex = 1;
            tabQueryParametersPage.Text = "Query Parameters";
            tabQueryParametersPage.UseVisualStyleBackColor = true;
            // 
            // dataGridViewQueryParameters
            // 
            dataGridViewQueryParameters.AllowUserToOrderColumns = true;
            dataGridViewQueryParameters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewQueryParameters.Columns.AddRange(new DataGridViewColumn[] { QKey, QValue });
            dataGridViewQueryParameters.Location = new Point(7, 7);
            dataGridViewQueryParameters.Name = "dataGridViewQueryParameters";
            dataGridViewQueryParameters.RowTemplate.Height = 25;
            dataGridViewQueryParameters.Size = new Size(440, 375);
            dataGridViewQueryParameters.TabIndex = 1;
            // 
            // tabBodyPage
            // 
            tabBodyPage.Controls.Add(rtxBody);
            tabBodyPage.Location = new Point(4, 24);
            tabBodyPage.Name = "tabBodyPage";
            tabBodyPage.Size = new Size(454, 388);
            tabBodyPage.TabIndex = 2;
            tabBodyPage.Text = "Body";
            tabBodyPage.UseVisualStyleBackColor = true;
            // 
            // rtxBody
            // 
            rtxBody.Location = new Point(1, 2);
            rtxBody.Name = "rtxBody";
            rtxBody.Size = new Size(450, 383);
            rtxBody.TabIndex = 0;
            rtxBody.Text = "";
            // 
            // btnRun
            // 
            btnRun.Location = new Point(679, 22);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(75, 23);
            btnRun.TabIndex = 29;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            // 
            // QKey
            // 
            QKey.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            QKey.HeaderText = "Key";
            QKey.Name = "QKey";
            // 
            // QValue
            // 
            QValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            QValue.HeaderText = "Value";
            QValue.Name = "QValue";
            // 
            // frmRestClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 641);
            Controls.Add(btnRun);
            Controls.Add(btnAuthGo);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
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
            tabControl.ResumeLayout(false);
            tabHeadersPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewHeader).EndInit();
            tabQueryParametersPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewQueryParameters).EndInit();
            tabBodyPage.ResumeLayout(false);
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
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TabControl tabControl;
        private TabPage tabHeadersPage;
        private TabPage tabQueryParametersPage;
        private DataGridView dataGridViewHeader;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn Value;
        private DataGridView dataGridViewQueryParameters;
        private ComboBox cmbContentType;
        private Label lblContentType;
        private TabPage tabBodyPage;
        private RichTextBox rtxBody;
        private Button btnRun;
        private DataGridViewTextBoxColumn QKey;
        private DataGridViewTextBoxColumn QValue;
    }
}