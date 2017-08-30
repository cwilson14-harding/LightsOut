namespace LightsOut
{
	partial class CustomSizeForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOkay = new System.Windows.Forms.Button();
			this.inputNumRows = new System.Windows.Forms.NumericUpDown();
			this.inputNumCols = new System.Windows.Forms.NumericUpDown();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.inputNumRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.inputNumCols)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Rows:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Columns:";
			// 
			// btnOkay
			// 
			this.btnOkay.Location = new System.Drawing.Point(12, 56);
			this.btnOkay.Name = "btnOkay";
			this.btnOkay.Size = new System.Drawing.Size(75, 23);
			this.btnOkay.TabIndex = 2;
			this.btnOkay.Text = "&OK";
			this.btnOkay.UseVisualStyleBackColor = true;
			this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
			// 
			// inputNumRows
			// 
			this.inputNumRows.Location = new System.Drawing.Point(68, 7);
			this.inputNumRows.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.inputNumRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.inputNumRows.Name = "inputNumRows";
			this.inputNumRows.Size = new System.Drawing.Size(98, 20);
			this.inputNumRows.TabIndex = 3;
			this.inputNumRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// inputNumCols
			// 
			this.inputNumCols.Location = new System.Drawing.Point(68, 28);
			this.inputNumCols.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.inputNumCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.inputNumCols.Name = "inputNumCols";
			this.inputNumCols.Size = new System.Drawing.Size(98, 20);
			this.inputNumCols.TabIndex = 4;
			this.inputNumCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(91, 56);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// CustomSizeForm
			// 
			this.AcceptButton = this.btnOkay;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(178, 91);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.inputNumCols);
			this.Controls.Add(this.inputNumRows);
			this.Controls.Add(this.btnOkay);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "CustomSizeForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Lights Out! - Custom Game";
			((System.ComponentModel.ISupportInitialize)(this.inputNumRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.inputNumCols)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOkay;
		private System.Windows.Forms.NumericUpDown inputNumRows;
		private System.Windows.Forms.NumericUpDown inputNumCols;
		private System.Windows.Forms.Button btnCancel;
	}
}