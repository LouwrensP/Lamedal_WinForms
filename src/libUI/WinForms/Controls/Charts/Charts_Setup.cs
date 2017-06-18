using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Lamedal_UIWinForms.Enumerals;
using Lamedal_UIWinForms.Events;
using Lamedal_UIWinForms.State;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls.Charts
{
    /// <code>CTI;</code>
    public sealed class Charts_Setup
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;

        private readonly Charts_Mouse _mouse = Lamedal_WinForms.Instance.libUI.WinForms.Controls.Charts.Mouse;

        private event evChartHitInfo _chartClickEvent;    // Event with all relevent information

        /// <summary>Setups the chart type.</summary>
        /// <param name="chart">The chart</param>
        /// <param name="chartType">The series chart type</param>
        /// <param name="evChartHitInfo">The chart click event.</param>
        /// <param name="enable3D">Enable3 d indicator. Default value = false.</param>
        public void Chart_Setup(Chart chart, SeriesChartType chartType, evChartHitInfo evChartHitInfo = null, bool enable3D = false)
        {
            chart.ChartAreas[0].Area3DStyle.Enable3D = enable3D;
            var series = chart.Series[0];
            series.ChartType = chartType;

            var state = chart.zzState();
            series.LegendText = state.LegendText;
            if (chartType == SeriesChartType.Pie) series.LegendText = "";  // Auto generated
            else if (chartType == SeriesChartType.Column)
            {
                chart.ChartAreas[0].AxisY.Title = state.Legend_yAxis;
                chart.Legends[0].Enabled = false;
            }

            Chart_Labels(series);

            // Events
            if (evChartHitInfo != null)
            {
                _chartClickEvent -= evChartHitInfo;
                _chartClickEvent += evChartHitInfo;
            }

            chart.MouseMove -= Event_MouseMove;
            chart.MouseMove += Event_MouseMove;

            chart.MouseDown -= Event_MouseDown;
            chart.MouseDown += Event_MouseDown;
        }

        /// <summary>
        /// Specify the data for the chart.
        /// </summary>
        /// <param name="chart">The chart.</param>
        /// <param name="keyValues">The key values dictionary</param>
        /// <param name="legendText">The legend text.</param>
        /// <param name="xAxisTitle">The x axis title.</param>
        /// <param name="yAxisTitle">The y axis title.</param>
        public void Chart_Data(Chart chart, Dictionary<string, double> keyValues, string legendText, string xAxisTitle, string yAxisTitle)
        {
            // Save state information
            var state = chart.zzState();
            state.LegendText = legendText;
            state.Legend_xAxis = xAxisTitle;
            state.Legend_yAxis = yAxisTitle;

            Chart_Data(chart.Series[0], keyValues);
            Chart_Labels(chart.Series[0]);  // Setup the labels

        }

        /// <summary>
        /// Data chart series setup.
        /// </summary>
        /// <param name="series"></param>
        /// <param name="keyValues">The key values dictionary</param>
        private void Chart_Data(Series series, Dictionary<string, double> keyValues)
        {
            //string[] keys = keyValues.Keys.ToArray();
            //double[] values = keyValues.Values.ToArray();
            //points.DataBindXY(keys, values);

            series.Points.DataBind(keyValues, "Key", "Value", "");
        }

        /// <summary>Setup Labels for the chart.</summary>
        /// <param name="series">The series</param>
        public void Chart_Labels(Series series)
        {
            if (series.Points.Count == 0) return;

            // Tooltips
            if (series.ChartType == SeriesChartType.Pie) series.ToolTip = "#VALY";
            else if (series.ChartType == SeriesChartType.Column) series.ToolTip = "#AXISLABEL";
            else series.ToolTip = "#VALY";  // Default

            // Labels
            if (series.ChartType == SeriesChartType.Radar)
                series.IsValueShownAsLabel = false;
            else series.IsValueShownAsLabel = true;

            series.SmartLabelStyle.Enabled = true;
            series["LabelStyle"] = "Top";
            series.Font = new Font("Ariel", 8);

            foreach (DataPoint point in series.Points)
            {
                //point.Label = "#AXISLABEL (#VALY)";
                if (series.ChartType == SeriesChartType.Pie) point.Label = "#AXISLABEL \n(#PERCENT%)"; // Pie
                else if (series.ChartType == SeriesChartType.Column) point.Label = "#VALY"; // Column
                else point.Label = ""; // Eable auto labeling
            }

            #region Label constants - for later reference
            // #VALY
            // #VALX
            // #VAL
            // #VAL{C}   // Curency
            // #VAL{$#,##0.00;($#,##0.00)}.  Numeric formating
            // #SERIESNAME
            // #LABEL
            // #AXISLABEL
            // #PERCENT
            // #INDEX
            // #LEGENDTEXT
            // #CUSTOMPROPERTY(customAttributeName)
            // #TOTAL
            // #AVG
            // #MIN
            // #MAX
            // #FIRST
            // #LAST
            #endregion
        }

        #region Events

        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            // Get chart and clickPoint
            evChartHitInfo_EventArgs chartInfo;
            bool chartHit = _mouse.Mouse_HitPoint(sender, e, out chartInfo);
            if (_chartClickEvent != null) _chartClickEvent(chartInfo, enChartEventType.Mouse_Move);

            Chart chart = chartInfo.Chart;

            var form = chart.FindForm();
            if (chartHit == false)
            {
                if (form != null) form.Cursor = Cursors.Default;
                _mouse.Mouse_SelectionReset(chart);
                return;
            }
            _mouse.Mouse_SelectionReset(chart);
            if (_mouse.Mouse_IsOnChartElement(chartInfo.hitResult.ChartElementType) == false)
            {
                if (form != null) form.Cursor = Cursors.Default;
                return; // Check chart type
            }

            // Set cursor type 
            if (form != null) form.Cursor = Cursors.Hand;
            _mouse.Mouse_SelectionSetup(chart, chartInfo.hitResult);
        }

        private void Event_MouseDown(object sender, MouseEventArgs e)
        {
            // Call Hit Test Method
            evChartHitInfo_EventArgs chartInfo;
            bool chartHit = _mouse.Mouse_HitPoint(sender, e, out chartInfo, explode: true);
            if (_chartClickEvent != null) _chartClickEvent(chartInfo, enChartEventType.Mouse_Down);

            if (chartHit == false) return;
            if (_mouse.Mouse_IsOnChartElement(chartInfo.hitResult.ChartElementType) == false) return; // Check chart type

            // Set Attribute
            //toolTip1.Show("X=" + chartInfo.Value_X + ", Y=" + chartInfo.Value_Y, chartInfo.Chart, chartInfo.MousePoint.X, chartInfo.MousePoint.Y - 15);
            //(chartInfo.Value_Label + " = " + chartInfo.Value_).zOk();
        }

        #endregion

    }
}
