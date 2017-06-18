using System.Data;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms.WinDB.WinGridView
{
    public sealed class WinGridView_Setup
    {
        /// <summary>
        /// Clear the DataGridView.
        /// </summary>
        /// <param name="grid">The data grid view.</param>
        public void Clear(DataGridView grid)
        {
            grid.DataSource = null;
            grid.Columns.Clear();
            grid.AutoGenerateColumns = true;
        }

        /// <summary>
        /// Reset the DataGridView.
        /// </summary>
        /// <param name="grid">The data grid view.</param>
        public void Reset(DataGridView grid)
        {
            Clear(grid);
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;  // CellSelect, FullColumnSelect, RowHeaderSelect, ColumnHeaderSelect, FullRowSelect
        }

        /// <summary>
        /// Redraws the specified grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        public void Redraw(DataGridView grid)
        {
            grid.AutoResizeColumns();
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        /// <summary>
        /// Setups the specified grid with the data table.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="table">The table.</param>
        public void DataTable(DataGridView grid, DataTable table)
        {
            Clear(grid);

            grid.DataSource = table;
            grid.AutoResizeColumns();
        }
    }
}
