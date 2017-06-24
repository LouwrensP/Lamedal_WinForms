using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LamedalCore.zz;
using Lamedal_UIWinForms.domain.Events;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls.Charts
{
    /// <code>CTI;</code>
    public sealed class Charts_Mouse
    {
        /// <summary>
        /// Determines whether the chart is exploded.
        /// </summary>
        /// <param name="chart">The chart</param>
        /// <param name="clickPoint">The click point</param>
        /// <param name="resetExploded">Reset exploded indicator. Default value = false.</param>
        /// <returns>bool</returns>
        public bool Mouse_ExplodeCheck(Chart chart, HitTestResult clickPoint, bool resetExploded = false)
        {
            bool result = (chart.Series[0].Points[clickPoint.PointIndex].CustomProperties == "Exploded=true");
            if (resetExploded) Mouse_ExplodeReset(chart);
            return result;
        }

        /// <summary>
        /// Resets the chart Exploded attribute.
        /// </summary>
        /// <param name="chart">The chart</param>
        public void Mouse_ExplodeReset(Chart chart)
        {
            foreach (DataPoint point in chart.Series[0].Points)
            {
                point.CustomProperties = "";
            }
        }

        /// <summary>
        /// Setups the chart selection.
        /// </summary>
        /// <param name="chart">The chart</param>
        /// <param name="clickPoint">The click point</param>
        public void Mouse_SelectionSetup(Chart chart, HitTestResult clickPoint)
        {
            // Find selected data point
            DataPoint point = chart.Series[0].Points[clickPoint.PointIndex];

            // Set End Gradient Color to White
            point.BackSecondaryColor = Color.White;

            // Set selected hatch style
            point.BackHatchStyle = ChartHatchStyle.Percent25;

            // Increase border width
            point.BorderWidth = 2;
        }

        /// <summary>
        /// Resets the chart selection.
        /// </summary>
        /// <param name="chart">The chart</param>
        public void Mouse_SelectionReset(Chart chart)
        {
            foreach (DataPoint point in chart.Series[0].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }
        }

        /// <summary>
        /// Calculate the Chart click point data values.
        /// </summary>
        /// <param name="chart">The chart</param>
        /// <param name="clickPoint">The click point</param>
        /// <param name="label">Return the label</param>
        /// <param name="value">Return the value</param>
        /// <param name="explode">Explode indicator. Default value = false.</param>
        public void Mouse_HitPointData(Chart chart, HitTestResult clickPoint, out string label, out double value, bool explode = false)
        {
            label = "";
            value = 0;
            if (chart.Series.Count == 0) return;
            if (chart.Series[0].Points.Count == 0) return;
            if (clickPoint.PointIndex == -1) return;

            DataPoint point = chart.Series[0].Points[clickPoint.PointIndex];
            label = point.AxisLabel;
            value = point.YValues[0];

            if (explode)
            {
                Mouse_ExplodeReset(chart);
                point.CustomProperties = "Exploded = true";
            }
        }

        /// <summary>
        /// Hitpoint information chart mouse.
        /// </summary>
        /// <param name="chart">The chart</param>
        /// <param name="e">The mouse event arguments</param>
        /// <param name="mousePoint">Return the mouse point</param>
        /// <param name="hitResult1">Return the hit result1</param>
        /// <param name="xValue">Return the x value</param>
        /// <param name="yValue">Return the y value</param>
        public void Mouse_HitpointInfo(Chart chart, MouseEventArgs e, out Point mousePoint, out HitTestResult hitResult1, out double xValue, out double yValue)
        {
            mousePoint = e.Location;
            hitResult1 = chart.HitTest(e.X, e.Y);
            if (hitResult1.ChartArea != null)
            {
                xValue = hitResult1.ChartArea.AxisX.PixelPositionToValue(mousePoint.X);
                yValue = hitResult1.ChartArea.AxisY.PixelPositionToValue(mousePoint.Y);
            }
            else
            {
                xValue = 0;
                yValue = 0;
            }
        }

        /// <summary>
        /// Determines whether the click point is within a chart series element.
        /// </summary>
        /// <param name="sender">The source of the event method</param>
        /// <param name="e">The mouse event arguments</param>
        /// <param name="chartInfo">The chart information.</param>
        /// <param name="explode">if set to <c>true</c> [explode].</param>
        /// <returns>
        /// bool
        /// </returns>
        public bool Mouse_HitPoint(object sender, MouseEventArgs e, out onChart_HitInfoEventArgs chartInfo, bool explode = false)
        {
            chartInfo = new onChart_HitInfoEventArgs(sender as Chart, e, explode);
            return chartInfo.HitPoint;
        }

        /// <summary>
        /// Determines whether the chart element type is in scope of a mouse click event.
        /// </summary>
        /// <param name="chartElementType">The chart element type</param>
        /// <returns>bool</returns>
        public bool Mouse_IsOnChartElement(ChartElementType chartElementType)
        {
            return chartElementType.zIn(ChartElementType.DataPointLabel, ChartElementType.DataPoint, ChartElementType.LegendItem);
        }

    }
}
