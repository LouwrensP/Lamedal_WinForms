using System.Drawing;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.libUI.WinForms.WinDB.WinGridView
{
    /// <code>CTI;</code>
    public sealed class WinGridView_Rows
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;
        private readonly WinGridView_ Parent;

        internal WinGridView_Rows(WinGridView_ parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// The select mode.
        /// </summary>
        /// <param name="grid">The data grid view.</param>
        /// <param name="mode">The data grid view selection mode.</param>
        public void SelectMode(DataGridView grid, DataGridViewSelectionMode mode = DataGridViewSelectionMode.FullRowSelect)
        {
            grid.SelectionMode = mode;  // CellSelect, FullColumnSelect, RowHeaderSelect, ColumnHeaderSelect, FullRowSelect
        }

        /// <summary>
        /// Deletes the specified grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="confirmDelete">if set to <c>true</c> [confirm delete].</param>
        public void Delete(DataGridView grid, bool confirmDelete = true)
        {
            var row = Index_Selected(grid);
            if (row == -1) return;

            if ("Delete selected rows?".zDialog().MessageBox_YesNo("Delete") == false) return;
            while (row != -1)
            {
                grid.Rows.RemoveAt(row);
                row = Index_Selected(grid);
            }
        }

        /// <summary>
        /// Return the selected row of the specified grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <returns></returns>
        public int Index_Selected(DataGridView grid)
        {
            int row = grid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            return row;
        }

        /// <summary>
        /// return row index.
        /// </summary>
        /// <param name="grid">The data gridentifier view.</param>
        /// <returns>int</returns>
        public int Index_Get(DataGridView grid)
        {
            if (grid.zObject().IsNull(showError: true)) return -1;
            return grid.CurrentRow.Index;
        }
        public void Index_Set(DataGridView grid, int rowIndex)
        {
            if (rowIndex >= grid.Rows.Count) rowIndex = grid.Rows.Count - 1;
            if (rowIndex < 0) rowIndex = 0;

            var col = Parent.Columns.Index(grid);
            if (rowIndex == 0 && grid.Rows.Count > 1)
            {
                grid.CurrentCell = grid.Rows[1].Cells[col];
                grid.CurrentCell = grid.Rows[0].Cells[col];
            } else grid.CurrentCell = grid.Rows[rowIndex].Cells[col];
        }

        /// <summary>
        /// Determines whether the data gridentifier view is e o f row.
        /// </summary>
        /// <param name="grid">The data gridentifier view.</param>
        /// <returns><c>true</c> if is e o f row, <c>false</c> otherwise.</returns>
        public bool IsEOF(DataGridView grid)
        {
            return (Index_Get(grid) >= grid.Rows.Count);
        }

        /// <summary>
        /// The first row.
        /// </summary>
        /// <param name="grid">The data grid view.</param>
        public void Move_First(DataGridView grid)
        {
            Index_Set(grid, 0);
        }

        /// <summary>
        /// The last row.
        /// </summary>
        /// <param name="grid">The data grid view.</param>
        public void Move_Last(DataGridView grid)
        {
            Index_Set(grid, grid.Rows.Count - 1);
        }

        /// <summary>
        /// Move to the next row.
        /// </summary>
        /// <param name="grid">The data grid view.</param>
        public void Move_MoveNext(DataGridView grid)
        {
            Index_Set(grid, Index_Get(grid) + 1);
        }

        /// <summary>
        /// Setups the specified grid row.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="backColor1">The back color1.</param>
        /// <param name="backColor2">The back color2.</param>
        public void Setup(DataGridView grid, Color? backColor1 = null, Color? backColor2 = null)
        {
            Color backColor11 = _lamedWin.libUI.WinForms.Setting.DefaultColor(backColor1, Color.White);
            grid.RowsDefaultCellStyle.BackColor = backColor11;

            Color backColor22 = _lamedWin.libUI.WinForms.Setting.DefaultColor(backColor2, Color.LightGray);
            grid.AlternatingRowsDefaultCellStyle.BackColor = backColor22;
        }
    }
}
