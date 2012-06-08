using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SilviaPlayer
{

    class Win32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, right, bottom;

            public override string ToString()
            {
                return string.Format("({0},{1}) {2}x{3}",
                                     left, top, right, bottom);
            }
        }

        public delegate int Callback(int hWnd, int lParam);


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(int hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(int hWnd, out RECT lpRect);

        [DllImport("User32.dll")]
        public static extern Boolean EnumChildWindows(int hWndParent, Delegate lpEnumFunc, int lParam);

        [DllImport("User32.dll")]
        public static extern Int32 GetWindowText(int hWnd, StringBuilder s, int nMaxCount);

        [DllImport("User32.dll")]
        public static extern Int32 GetClassName(int hWnd, StringBuilder s, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(int hWndChild, int hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(int hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    }
}
