namespace WindowsFormsApp1
{
	partial class Form1
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.dgvResult = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DISTRICT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.plQueryCondition = new System.Windows.Forms.Panel();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblAddress = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblDistrict = new System.Windows.Forms.Label();
			this.cboDistrict = new System.Windows.Forms.ComboBox();
			this.btnQuery = new System.Windows.Forms.Button();
			this.btnExpJson = new System.Windows.Forms.Button();
			this.btnImport = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
			this.plQueryCondition.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvResult
			// 
			this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ITEM,
            this.NAME,
            this.DISTRICT,
            this.PHONE,
            this.ADDRESS});
			this.dgvResult.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgvResult.Location = new System.Drawing.Point(0, 269);
			this.dgvResult.Name = "dgvResult";
			this.dgvResult.RowHeadersWidth = 62;
			this.dgvResult.RowTemplate.Height = 31;
			this.dgvResult.Size = new System.Drawing.Size(800, 375);
			this.dgvResult.TabIndex = 0;
			// 
			// ID
			// 
			this.ID.HeaderText = "ID";
			this.ID.MinimumWidth = 8;
			this.ID.Name = "ID";
			// 
			// ITEM
			// 
			this.ITEM.HeaderText = "ITEM";
			this.ITEM.MinimumWidth = 8;
			this.ITEM.Name = "ITEM";
			this.ITEM.ReadOnly = true;
			// 
			// NAME
			// 
			this.NAME.HeaderText = "NAME";
			this.NAME.MinimumWidth = 8;
			this.NAME.Name = "NAME";
			// 
			// DISTRICT
			// 
			this.DISTRICT.HeaderText = "DISTRICT";
			this.DISTRICT.MinimumWidth = 8;
			this.DISTRICT.Name = "DISTRICT";
			// 
			// PHONE
			// 
			this.PHONE.HeaderText = "PHONE";
			this.PHONE.MinimumWidth = 8;
			this.PHONE.Name = "PHONE";
			// 
			// ADDRESS
			// 
			this.ADDRESS.HeaderText = "ADDRESS";
			this.ADDRESS.MinimumWidth = 8;
			this.ADDRESS.Name = "ADDRESS";
			// 
			// plQueryCondition
			// 
			this.plQueryCondition.Controls.Add(this.txtAddress);
			this.plQueryCondition.Controls.Add(this.txtName);
			this.plQueryCondition.Controls.Add(this.lblAddress);
			this.plQueryCondition.Controls.Add(this.lblName);
			this.plQueryCondition.Controls.Add(this.lblDistrict);
			this.plQueryCondition.Controls.Add(this.cboDistrict);
			this.plQueryCondition.Location = new System.Drawing.Point(10, 21);
			this.plQueryCondition.Name = "plQueryCondition";
			this.plQueryCondition.Size = new System.Drawing.Size(782, 186);
			this.plQueryCondition.TabIndex = 1;
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(297, 149);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(350, 29);
			this.txtAddress.TabIndex = 5;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(297, 83);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(212, 29);
			this.txtName.TabIndex = 4;
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.Location = new System.Drawing.Point(202, 154);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(64, 18);
			this.lblAddress.TabIndex = 3;
			this.lblAddress.Text = "Address";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(202, 88);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(49, 18);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "Name";
			// 
			// lblDistrict
			// 
			this.lblDistrict.AutoSize = true;
			this.lblDistrict.Location = new System.Drawing.Point(202, 22);
			this.lblDistrict.Name = "lblDistrict";
			this.lblDistrict.Size = new System.Drawing.Size(61, 18);
			this.lblDistrict.TabIndex = 1;
			this.lblDistrict.Text = "District";
			// 
			// cboDistrict
			// 
			this.cboDistrict.FormattingEnabled = true;
			this.cboDistrict.Location = new System.Drawing.Point(297, 20);
			this.cboDistrict.Name = "cboDistrict";
			this.cboDistrict.Size = new System.Drawing.Size(212, 26);
			this.cboDistrict.TabIndex = 0;
			// 
			// btnQuery
			// 
			this.btnQuery.Location = new System.Drawing.Point(317, 213);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(119, 39);
			this.btnQuery.TabIndex = 2;
			this.btnQuery.Text = "Query";
			this.btnQuery.UseVisualStyleBackColor = true;
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// btnExpJson
			// 
			this.btnExpJson.Location = new System.Drawing.Point(674, 213);
			this.btnExpJson.Name = "btnExpJson";
			this.btnExpJson.Size = new System.Drawing.Size(119, 39);
			this.btnExpJson.TabIndex = 3;
			this.btnExpJson.Text = "Export";
			this.btnExpJson.UseVisualStyleBackColor = true;
			this.btnExpJson.Click += new System.EventHandler(this.btnExpJson_Click);
			// 
			// btnImport
			// 
			this.btnImport.Location = new System.Drawing.Point(555, 213);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(119, 39);
			this.btnImport.TabIndex = 4;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(436, 213);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(119, 39);
			this.btnUpdate.TabIndex = 5;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 644);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.btnExpJson);
			this.Controls.Add(this.btnQuery);
			this.Controls.Add(this.plQueryCondition);
			this.Controls.Add(this.dgvResult);
			this.Name = "Form1";
			this.Text = "臺中市百大名攤名產";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
			this.plQueryCondition.ResumeLayout(false);
			this.plQueryCondition.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvResult;
		private System.Windows.Forms.Panel plQueryCondition;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblAddress;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblDistrict;
		private System.Windows.Forms.ComboBox cboDistrict;
		private System.Windows.Forms.Button btnQuery;
		private System.Windows.Forms.Button btnExpJson;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ITEM;
		private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
		private System.Windows.Forms.DataGridViewTextBoxColumn DISTRICT;
		private System.Windows.Forms.DataGridViewTextBoxColumn PHONE;
		private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS;
	}
}

