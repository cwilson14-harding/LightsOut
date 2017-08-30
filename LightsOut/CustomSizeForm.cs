using System;
using System.Windows.Forms;

namespace LightsOut
{
	public partial class CustomSizeForm : Form
	{
		// These values will be where the form results can be accessed.
		public int NumRows;
		public int NumColumns;

		public CustomSizeForm(int CurrentRows, int CurrentColumns)
		{
			InitializeComponent();

			// Initialize the fields with the current number of rows and columns.
			inputNumRows.Value = CurrentRows;
			inputNumCols.Value = CurrentColumns;
		}

		private void btnOkay_Click(object sender, EventArgs e)
		{
			// Set the return values and close the form.
			NumRows = (int)inputNumRows.Value;
			NumColumns = (int)inputNumCols.Value;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
