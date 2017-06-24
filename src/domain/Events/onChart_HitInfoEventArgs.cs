using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lamedal_UIWinForms.domain.Events
{
    /// <summary>
    /// Parameter state information. Used internally in event
    /// </summary>
    public sealed class onChart_HitInfoEventArgs
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;  // Load the winforms lib
        
        public readonly Chart Chart;
        public HitTestResult hitResult = null;
        public Point MousePoint;
        public double Value_X;
        public double Value_Y;
        public readonly string Value_Label;
        public readonly double Value_;

        public onChart_HitInfoEventArgs(Chart chart, MouseEventArgs e, bool explode = false)
        {
            // Example:
            //toolTip1.Show("X=" + chartinfo.Value_X + ", Y=" + chartinfo.Value_Y, chartinfo.Chart, chartinfo.MousePoint.X, chartinfo.MousePoint.Y - 15);
            //if (eventtype== ChartEventType.Mouse_Down) (chartinfo.Value_Label + " = " + chartinfo.Value_).zOk();

            this.Chart = chart;
            if (chart == null) return;

            _lamedWin.libUI.WinForms.Controls.Charts.Mouse.Mouse_HitpointInfo(chart, e, out MousePoint, out hitResult, out Value_X, out Value_Y);
            _lamedWin.libUI.WinForms.Controls.Charts.Mouse.Mouse_HitPointData(chart, hitResult, out Value_Label, out Value_, explode);
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