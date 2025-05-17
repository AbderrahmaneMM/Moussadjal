using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moussadjal_mobile_app
{
    public static class WindowExtensions
    {
        public static void SetBorderColor(this Window window, Color color)
        {
#if WINDOWS
        var nativeWindow = window.Handler.PlatformView as Microsoft.UI.Xaml.Window;
        if (nativeWindow != null)
        {
            var res = Microsoft.UI.ColorHelper.FromArgb(
                (byte)(color.Alpha * 255),
                (byte)(color.Red * 255),
                (byte)(color.Green * 255),
                (byte)(color.Blue * 255));
            
            nativeWindow.AppWindow.TitleBar.ButtonBackgroundColor = res;
            nativeWindow.AppWindow.TitleBar.ButtonInactiveBackgroundColor = res;
        }
#endif
        }
    }
}
