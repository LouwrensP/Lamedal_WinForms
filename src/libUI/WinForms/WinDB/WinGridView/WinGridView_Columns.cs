using System.Drawing;
using System.Windows.Forms;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.libUI.WinForms.WinDB.WinGridView
{
    /// <code>CTI;</code>
    public sealed class WinGridView_Columns
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;

        public DataGridViewColumn Column_Get(DataGridView grid, string colName)
        {
            return grid.Columns[colName];
        }

        /// <summary>
        /// Set the maximum size of a column.
        /// </summary>
        /// <param name="grid">The data gridentifier view.</param>
        /// <param name="maxSize">The maximum size.</param>
        public void MaxSize(DataGridView grid, int maxSize = 400)
        {
            foreach (DataGridViewColumn column in grid.Columns)
                if (column.Width > maxSize)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = maxSize;
                }
        }
        /// <summary>
        /// Set caption for DataGridView (using the the col name).
        /// </summary>
        /// <param name="grid">The data gridentifier view.</param>
        /// <param name="colName">The col name.</param>
        /// <param name="caption">The caption.</param>
        public void Caption_Set(DataGridView grid, string colName, string caption)
        {
            DataGridViewColumn col = Column_Get(grid, colName);
            col.HeaderText = caption;
        }

        /// <summary>
        /// Set bold in DataGridView (using the the col name).
        /// </summary>
        /// <param name="grid">The data gridentifier view.</param>
        /// <param name="colName">The col name.</param>
        /// <param name="isBold">The is bold.</param>
        public void Bold_Set(DataGridView grid, string colName, bool isBold = true)
        {
            Font font = _lamedWin.libUI.WinForms.Setting.Font_Setup(isBold: isBold);
            DataGridViewColumn col = Column_Get(grid, colName);
            col.HeaderCell.Style.Font = font;
            col.DefaultCellStyle.Font = font;
        }

        /// <summary>
        /// Set visible in DataGridView (using the colNames array).
        /// </summary>
        /// <param name="grid">The data gridentifier view.</param>
        /// <param name="isVisible">The is visible.</param>
        /// <param name="colNames">The col names array.</param>
        public void Visible_Set(DataGridView grid, bool isVisible = true, params string[] colNames)
        {
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (colNames.Length == 0) col.Visible = isVisible;
                else if (col.Name.zIn(colNames)) col.Visible = isVisible;
            }
        }

        /// <summary>
        /// Return secelcted column index definition.
        /// </summary>
        /// <param name="grid">The data gridentifier view.</param>
        /// <returns>int</returns>
        public int Index(DataGridView grid)
        {
            if (grid.zObject().IsNull(showError: true)) return -1;
            return (grid.SelectedCells.Count == 0) ? -1 : grid.SelectedCells[0].ColumnIndex;
        }

        /// <summary>
        /// Get value from DataGridView as object (using the specified the field name).
        /// </summary>
        /// <param name="grid">The data gridentifier view.</param>
        /// <param name="FieldName">The field name.</param>
        /// <returns>object</returns>
        public object Value_Get(DataGridView grid, string FieldName = "")
        {
            if (FieldName != "")
            {
                DataGridViewColumn colmn = Column_Get(grid, FieldName);
                var colNo = colmn.Index;
                grid.CurrentCell = grid.Rows[grid.CurrentRow.Index].Cells[colNo];
            }
            return grid.CurrentCell.Value;
        }

    }
}
