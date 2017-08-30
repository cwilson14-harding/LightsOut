// Project: LightsOut
// Author: Curtis Wilson
// COMP 445

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LightsOut
{
    public partial class MainForm : Form
    {
        private const int GridOffset = 25;
		private const int GridOffsetTop = 0;
		private const int GridOffsetBottom = 90;
        private int GridLength = 200;
        private int NumRows = 3;
        private int NumColumns = 3;
        private int CellLength;
		private int LeftStart;
		private int TopStart;
		private bool PartyMode = false;
		private SelectionMode selectionMode = SelectionMode.Square;

		private List<List<bool>> grid;
        private Random rand;

		private enum SelectionMode
		{
			Square,
			Cross
		}

		public MainForm()
        {
            InitializeComponent();
            rand = new Random();
            grid = new List<List<bool>>();
			RecalculateGridSize();
			NewGame();
        }

        private void NewGame()
        {
			// Turn off party mode.
			PartyMode = false;
			partyModeTimer.Enabled = false;

			// Remove all rows.
			grid.Clear();

            // Create rows.
            while (NumRows > grid.Count)
            {
                grid.Add(new List<bool>(NumColumns));
            }

            // Initialize all cells to 0.
            for (int r = 0; r < NumRows; ++r)
                for (int c = 0; c < NumColumns; ++c)
                    grid[r].Add(((rand.Next(0, 2) == 1) ? true : false));

			// Redraw the grid.
			Invalidate();
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Update the check marks.
			x3ToolStripMenuItem.Checked = true;
            x4ToolStripMenuItem.Checked = false;
            x5ToolStripMenuItem.Checked = false;
			customToolStripMenuItem.Checked = false;

			// Update the number of rows and columns.
			NumRows = 3;
			NumColumns = 3;

			// Recalculate the size.
			RecalculateGridSize();

			// Start a new game.
			NewGame();
		}

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Update the check marks.
			x3ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = true;
            x5ToolStripMenuItem.Checked = false;
			customToolStripMenuItem.Checked = false;

			// Update the number of rows and columns.
			NumRows = 4;
			NumColumns = 4;

			// Recalculate the size.
			RecalculateGridSize();

			// Start a new game.
			NewGame();
		}

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
			// Update the check marks.
            x3ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            x5ToolStripMenuItem.Checked = true;
			customToolStripMenuItem.Checked = false;

			// Update the number of rows and columns.
			NumRows = 5;
            NumColumns = 5;

			// Recalculate the size.
			RecalculateGridSize();

			// Start a new game.
			NewGame();
		}

		private void customToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CustomSizeForm form = new CustomSizeForm(NumRows, NumColumns);
			DialogResult dialogResult = form.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				// Update the check marks.
				x3ToolStripMenuItem.Checked = false;
				x4ToolStripMenuItem.Checked = false;
				x5ToolStripMenuItem.Checked = false;
				customToolStripMenuItem.Checked = true;

				// Update the number of rows and columns.
				NumRows = form.NumRows;
				NumColumns = form.NumColumns;

				// Recalculate the size.
				RecalculateGridSize();

				// Start a new game.
				NewGame();
			}
		}

		private void RecalculateGridSize()
		{
			GridLength = Math.Min(ClientSize.Width - GridOffset * 2, ClientSize.Height - GridOffsetTop - GridOffsetBottom);
			CellLength = GridLength / Math.Max(NumRows, NumColumns);
			LeftStart = Math.Max(GridOffset, (ClientSize.Width - CellLength * NumColumns) / 2);
			TopStart = Math.Max(GridOffsetTop, (ClientSize.Height - CellLength * NumRows) / 2);
		}

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

			// Draw the grid.
            for (int r = 0; r < NumRows; ++r)
            {
                for (int c = 0; c < NumColumns; ++c)
                {
                    Brush brush;
                    Pen pen;

					if (PartyMode)
					{
						pen = Pens.Black;
						brush = new SolidBrush(Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)));
					} else if (grid[r][c])
                    {
						// Cell is on.
                        pen = Pens.Black;
						brush = Brushes.White;
                    } else
					{
						// Cell is off.
						pen = Pens.White;
						brush = Brushes.Black;
					}

					// Get the new X and Y position and center it.
					int x = c * CellLength + LeftStart;
					int y = r * CellLength + TopStart;

					// Draw the cell.
					g.DrawRectangle(pen, x, y, CellLength, CellLength);
					g.FillRectangle(brush, x + 1, y + 1, CellLength - 1, CellLength - 1);
                }
            }
        }

		private void MainForm_MouseDown(object sender, MouseEventArgs e)
		{
			// Don't allow a move after the game has been won.
			if (!PartyMode)
			{
				// Determine if the user clicked a cell.
				if (e.X < LeftStart || e.X > CellLength * NumColumns + LeftStart ||
					e.Y < TopStart || e.Y > CellLength * NumRows + TopStart) return;

				// Find the cell that was clicked.
				int r = (e.Y - TopStart) / CellLength;
				int c = (e.X - LeftStart) / CellLength;

				// Invert the cell and those surrounding.
				for (int row = r - 1; row <= r + 1; ++row)
					for (int col = c - 1; col <= c + 1; col++)
						if (row >= 0 && row < NumRows && col >= 0 && col < NumColumns)
							// Fill in the cells in the grid according to the given pattern.
							if (selectionMode == SelectionMode.Square)
							{
								grid[row][col] = !grid[row][col];
							}
							else if (selectionMode == SelectionMode.Cross && (row == r || col == c))
							{
								grid[row][col] = !grid[row][col];
							}

				// Redraw the grid.
				Invalidate();

				// Show the victory message if the player won.
				if (PlayerWon())
				{
					MessageBox.Show(this, "Congratulations! You've won!", "Lights Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

					// Turn on the celebratory colors and redraw the grid.
					PartyMode = true;
					partyModeTimer.Enabled = true;
					Invalidate();
				}
			}
		}

		// Check if the player has won.
		// Return true if all the lights are out.
		private bool PlayerWon()
		{
			for (int r = 0; r < NumRows; ++r)
				for (int c = 0; c < NumColumns; ++c)
					if (grid[r][c]) return false;
			return true;
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			RecalculateGridSize();
			Invalidate();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AboutForm().ShowDialog();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnNewGame_Click(object sender, EventArgs e)
		{
			NewGame();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewGame();
		}

		private void partyModeTimer_Tick(object sender, EventArgs e)
		{
			// Force a redraw of the grid, resulting in colors, when party mode is enabled.
			Invalidate();
		}

		private void squareToolStripMenuItem_Click(object sender, EventArgs e)
		{
			squareToolStripMenuItem.Checked = true;
			crossToolStripMenuItem.Checked = false;
			selectionMode = SelectionMode.Square;
			NewGame();
		}

		private void crossToolStripMenuItem_Click(object sender, EventArgs e)
		{
			squareToolStripMenuItem.Checked = false;
			crossToolStripMenuItem.Checked = true;
			selectionMode = SelectionMode.Cross;
			NewGame();
		}
	}
}
