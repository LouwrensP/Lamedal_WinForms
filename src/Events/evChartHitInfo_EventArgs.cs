using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lamedal_UIWinForms.Events
{
    /// <summary>
    /// Parameter state information. Used internally in event
    /// </summary>
    public sealed class evChartHitInfo_EventArgs
    {
        private readonly LaMedalPort.UIWindows IamWindows = LaMedalPort.UIWindows.Instance; // Set reference to Blueprint Windows lib
        
        public readonly Chart Chart;
        public HitTestResult hitResult = null;
        public Point MousePoint;
        public double Value_X;
        public double Value_Y;
        public readonly string Value_Label;
        public readonly double Value_;

        public evChartHitInfo_EventArgs(Chart chart, MouseEventArgs e, bool explode = false)
        {
            // Example:
            //toolTip1.Show("X=" + chartinfo.Value_X + ", Y=" + chartinfo.Value_Y, chartinfo.Chart, chartinfo.MousePoint.X, chartinfo.MousePoint.Y - 15);
            //if (eventtype== ChartEventType.Mouse_Down) (chartinfo.Value_Label + " = " + chartinfo.Value_).zOk();

            this.Chart = chart;
            if (chart == null) return;

            IamWindows.libUI.WinForms.Controls.Charts.Mouse.Mouse_HitpointInfo(chart, e, out MousePoint, out hitResult, out Value_X, out Value_Y);
            IamWindows.libUI.WinForms.Controls.Charts.Mouse.Mouse_HitPointData(chart, hitResult, out Value_Label, out Value_, explode);
        }

        public bool HitPoint
        {
            get
            {
                if (Chart == null) return false;
                if (hitResult == null) return false;
                return (hitResult.PointIndex != -1);
            }
        }
    }
}