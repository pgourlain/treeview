using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;

namespace Genius.Controls
{
	/// <summary>
	/// Summary description for NativeMethods.
	/// </summary>
	public class NativeMethods
	{
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static internal extern Int16 GetKeyState(VirtualKeys nVirtKey);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static internal extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static internal extern int DrawFrameControl(IntPtr hdc, ref RECT pRect, Int32 uType, Int32 uState);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static internal extern bool DrawFocusRect(IntPtr hdc, RECT pRect);
 
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static internal extern int GetScrollInfo(IntPtr hwnd, int bar, ref SCROLLINFO si);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static internal extern int ShowScrollBar(IntPtr hWnd, int bar,  bool show);		
		
		//[DllImport("user32.dll", CharSet=CharSet.Auto)]
		//static internal extern int GetScrollBarInfo(IntPtr hWnd, SystemObject id, ref SCROLLBARINFO sbi);
		
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static internal extern int SetScrollInfo(IntPtr hwnd,  int bar, ref SCROLLINFO si, bool fRedraw);	


		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static internal extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy, ref RECT rcScroll, 
													ref RECT rcClip, IntPtr UpdateRegion, 
													ref RECT rcInvalidated, int flags);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static internal extern bool ScrollWindow(IntPtr hWnd, int dx, int dy, ref RECT rcScroll, ref RECT rcClip);
		
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static int InvalidateRect(IntPtr hWnd,  ref RECT rc, int bErase);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static int InvalidateRect(IntPtr hWnd,  IntPtr rc, bool bErase);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, FlagsDCX flags);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static IntPtr GetDC(IntPtr hWnd);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static IntPtr GetWindowDC(IntPtr hWnd);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static bool RedrawWindow(IntPtr hWnd, ref RECT rc, IntPtr hrgnUpdate, FlagsRDW flags);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static bool GetWindowRect(IntPtr hWnd, ref RECT rc);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static bool GetClientRect(IntPtr hWnd, ref RECT rc);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref RECT rc, uint nbpoints);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static IntPtr SetCursor(uint hCursor);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		internal extern static int GetRgnBox(IntPtr hrgn, ref RECT lprc);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		internal extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
												int x, int y, int cx, int cy, FlagsSetWindowPos uflags);
		
		[DllImport("user32.dll", CharSet=CharSet.Auto, EntryPoint="SetLayeredWindowAttributes")]
		private extern static bool InternalSetLayeredWindowAttributes(IntPtr hWnd, uint rgb, int alpha, int flags);

        internal static void SetLayeredWindowAttributes(IntPtr hWnd, uint rgb, int alpha, int flags)
        {
            if (!InternalSetLayeredWindowAttributes(hWnd, rgb, alpha, flags))
            {
                System.Diagnostics.Trace.TraceWarning("SetLayeredWindowAttributes failed");
            }
        }
 
		internal static int InvalidateRect(IntPtr hWnd,  Rectangle rc, int bErase)
		{
			RECT r = RECT.FromRectangle(rc);
			return InvalidateRect(hWnd, ref r, bErase);
		}
		
		[DllImport("user32.dll")]
		internal static extern IntPtr SetWindowsHookEx(HookType hook, HookProc callback, IntPtr hMod, uint dwThreadId);
		[DllImport("user32.dll")]
		internal static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

		#region themes
		[DllImport("uxtheme.dll")]
		internal extern static IntPtr GetWindowTheme(IntPtr hWnd);

		[DllImport("uxtheme.dll", CharSet=CharSet.Unicode)]
		internal extern static IntPtr OpenThemeData(IntPtr hWnd, string szClass);

		[DllImport("uxtheme.dll", CharSet=CharSet.Unicode)]
		internal extern static int CloseThemeData(IntPtr hWnd);

		[DllImport("uxtheme", ExactSpelling=true, EntryPoint="DrawThemeBackground")]
		private extern static Int32 InternalDrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
			int iStateId, ref RECT pRect, ref RECT pClipRect);
        
        internal static void DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
            int iStateId, ref RECT pRect, ref RECT pClipRect)
        {
            if (InternalDrawThemeBackground(hTheme, hdc, iPartId, iStateId, ref pRect, ref pClipRect) == 0)
            {
                Trace.TraceWarning("DrawThemeBackground failed");
            }
        }
        #endregion

		internal const int SIF_RANGE = 1;
		internal const int SIF_PAGE = 2;
		internal const int SIF_POS = 4;
		internal const int SIF_DISABLENOSCROLL = 8;
		internal const int SIF_TRACKPOS = 0x10;
		internal const int SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS);
		internal const int SB_HORZ = 0;
		internal const int SB_VERT = 1;
		internal const int SB_CTL = 2;
		internal const int SB_BOTH = 3;	
	}

	#region structures 
	#region SCROLLINFO
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal struct SCROLLINFO
	{
		internal int cbSize;
		internal int fMask;
		internal int nMin;
		internal int nMax;
		internal int nPage;
		internal int nPos;
		internal int nTrackPos;
	}
	#endregion
	
	#region SCROLLBARINFO
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
	internal struct SCROLLBARINFO
	{
		internal int  cbSize;
		internal RECT  rcScrollBar;
		internal int   dxyLineButton;
		internal int   xyThumbTop;
		internal int   xyThumbBottom;
		internal int   reserved;
		[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=6)]
		internal int[] rgstate;
	}
	#endregion

	#region RECT
	[Serializable, StructLayout(LayoutKind.Sequential)]
	internal struct RECT 
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;

		public RECT(int left_, int top_, int right_, int bottom_) 
		{
			Left = left_;
			Top = top_;
			Right = right_;
			Bottom = bottom_;
		}

		public int Height { get { return Bottom - Top; } }
		public int Width { get { return Right - Left; } }
		public Size Size { get { return new Size(Width, Height); } }

		public Point Location { get { return new Point(Left, Top); } }

		// Handy method for converting to a System.Drawing.Rectangle
		public Rectangle ToRectangle()
		{ return Rectangle.FromLTRB(Left, Top, Right, Bottom); }

		public static RECT FromRectangle(Rectangle rectangle) 
		{
			return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
		}

		public override int GetHashCode() 
		{
			return Left ^ ((Top << 13) | (Top >> 0x13))
				^ ((Width << 0x1a) | (Width >> 6))
				^ ((Height << 7) | (Height >> 0x19));
		}
	}
	#endregion

	#region POINT
	[StructLayout(LayoutKind.Sequential)]
	internal struct POINT
	{
		internal int X;
		internal int Y;
	}
	#endregion

	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
	internal struct WINDOWPOS
	{
		int hwnd;
		int hwndInsertAfter;
		int x;
		int y;
		int cx;
		int cy;
		uint flags;
	}

	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
	internal struct NCCalcSizeParams
	{
		public RECT rgrc0;
		public RECT rgrc1;
		public RECT rgrc2;
		public WINDOWPOS lppos;
	}

	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
	internal struct WMNCPaint
	{
		int Msg;
		IntPtr RGN;
		int Unused;
		int Result;
	}

	/// <summary>
	/// enumération pour les hooks <see cref="HookProc"/>, <see cref="NativeMethods.SetWindowsHookEx"/>
	/// </summary>
	public enum HookType : int
	{
		/// <summary>
		/// 
		/// </summary>
		WH_JOURNALRECORD = 0,
		/// <summary>
		/// 
		/// </summary>
		WH_JOURNALPLAYBACK = 1,
		/// <summary>
		/// 
		/// </summary>
		WH_KEYBOARD = 2,
		/// <summary>
		/// 
		/// </summary>
		WH_GETMESSAGE = 3,
		/// <summary>
		/// 
		/// </summary>
		WH_CALLWNDPROC = 4,
		/// <summary>
		/// 
		/// </summary>
		WH_CBT = 5,
		/// <summary>
		/// 
		/// </summary>
		WH_SYSMSGFILTER = 6,
		/// <summary>
		/// 
		/// </summary>
		WH_MOUSE = 7,
		/// <summary>
		/// 
		/// </summary>
		WH_HARDWARE = 8,
		/// <summary>
		/// 
		/// </summary>
		WH_DEBUG = 9,
		/// <summary>
		/// 
		/// </summary>
		WH_SHELL = 10,
		/// <summary>
		/// 
		/// </summary>
		WH_FOREGROUNDIDLE = 11,
		/// <summary>
		/// 
		/// </summary>
		WH_CALLWNDPROCRET = 12,    
		/// <summary>
		/// 
		/// </summary>
		WH_KEYBOARD_LL = 13,
		/// <summary>
		/// 
		/// </summary>
		WH_MOUSE_LL = 14
	}
	
	/// <summary>
	/// déléguée associée à <see cref="NativeMethods.SetWindowsHookEx"/>
	/// </summary>
	public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);
	#endregion
}
