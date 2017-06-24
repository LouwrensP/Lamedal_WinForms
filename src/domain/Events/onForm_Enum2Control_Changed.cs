using System;

namespace Lamedal_UIWinForms.domain.Events
{
    public delegate void evEnum2Control_Changed<T>(object sender, EventArgs e, T enumValue);
}