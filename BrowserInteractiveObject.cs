using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace Snap.Genshin.MapTrack
{
    public class BrowserInteractiveObject
    {

        [DllImport("CVAUTOTRACK.dll")]
        internal static extern bool init();

        [DllImport("CVAUTOTRACK.dll")]
        internal static extern bool uninit();

        [DllImport("CVAUTOTRACK.dll")]
        static extern bool SetHandle(IntPtr handle);


        [DllImport("CVAUTOTRACK.dll")]
        static extern bool GetTransform(
            ref float x,
            ref float y,
            ref float a
        );
	
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);


        IntPtr _hwd = IntPtr.Zero;
        public float[]? GetPosition()
        {
            if (this._hwd == IntPtr.Zero || !IsWindow(this._hwd))
            {
                this._hwd = Process.GetProcessesByName("YuanShen").FirstOrDefault()?.MainWindowHandle ?? IntPtr.Zero;
                if(this._hwd == IntPtr.Zero || !IsWindow(this._hwd)) return null;
                SetHandle(this._hwd);
            }
		
            const float scale = 2f / 3f;
            var result = new float[3];
            var success = GetTransform(ref result[0], ref result[1], ref result[2]);
            result[0] *= scale;
            result[1] *= scale;
            result[2] *= -1;
            return result;
        }
    }
}