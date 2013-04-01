using System;
using System.Drawing;
using System.Windows.Forms;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// Summary description for GeniusNativeWindow.
	/// </summary>
	class GeniusNativeWindow : System.Windows.Forms.NativeWindow, IDisposable
	{
		#region Variables
		protected GeniusTreeView FTree;
		#endregion

		public GeniusNativeWindow(GeniusTreeView tv)
		{
			FTree = tv;
		}

		private Rectangle ClientRectangle
		{
			get
			{
				RECT rc = new RECT();
				NativeMethods.GetClientRect(this.Handle, ref rc);
				return rc.ToRectangle();
			}
		}

		protected override void WndProc(ref Message m)
		{
			switch((Msgs)m.Msg)
			{
				case Msgs.WM_PAINT :
					base.WndProc (ref m);
					using (Graphics g = Graphics.FromHwnd(m.HWnd))
					{
						DoPaint(g);
					}
					m.Result = IntPtr.Zero;
					break;
				default :
					base.WndProc (ref m);
					break;
			}
		}

		protected virtual void DoPaint(Graphics g)
		{
		}

		protected void SetPosition(int x, int y)
		{
			NativeMethods.SetWindowPos(this.Handle, IntPtr.Zero, x, y, 0, 0, 
				FlagsSetWindowPos.SWP_NOOWNERZORDER | 
				FlagsSetWindowPos.SWP_NOSIZE | 
				FlagsSetWindowPos.SWP_NOACTIVATE |
				FlagsSetWindowPos.SWP_SHOWWINDOW);
		}

		public void Hide()
		{
			NativeMethods.SetWindowPos(this.Handle, IntPtr.Zero, 0, 0, 0, 0, 
				FlagsSetWindowPos.SWP_NOOWNERZORDER | 
				FlagsSetWindowPos.SWP_NOSIZE | 
				FlagsSetWindowPos.SWP_NOMOVE |
				FlagsSetWindowPos.SWP_NOACTIVATE |
				FlagsSetWindowPos.SWP_HIDEWINDOW);
		}

        //protected void Invalidate()
        //{
        //    NativeMethods.InvalidateRect(this.Handle, this.ClientRectangle, 0);
        //}

		
		protected void Show(int x, int y, int w, int h, byte alpha)
		{
			CreateParams cp = new CreateParams();
            
			cp.X = x;
			cp.Y = y;
			cp.Height = h;
			cp.Width = w;

			WindowStyles style = (WindowStyles.WS_POPUP);
			cp.Style = (int)style;
			cp.Parent = FTree.Handle;
			
			if (alpha < 255)
				cp.ExStyle |= (int)WindowExStyles.WS_EX_LAYERED;
			this.CreateHandle(cp);
			if (alpha < 255)
				NativeMethods.SetLayeredWindowAttributes(this.Handle, 0, alpha, 0x02);
			//NativeMethods.SetLayeredWindowAttributes(this.Handle, 0, 255, 0x02);
		}

		public virtual void Show(int x, int y)
		{
			Show(x, y, 0, 0 , 254);
		}

		public void Position(int x, int y)
		{
			SetPosition(x, y);
		}

		public void SetRect(int x, int y, int w, int h)
		{
			NativeMethods.SetWindowPos(this.Handle, IntPtr.Zero, x, y, w, h, 
				FlagsSetWindowPos.SWP_NOOWNERZORDER | 
				FlagsSetWindowPos.SWP_NOACTIVATE |
				FlagsSetWindowPos.SWP_SHOWWINDOW);
		}

		public void SetSize(int w, int h)
		{
			NativeMethods.SetWindowPos(this.Handle, IntPtr.Zero, 0, 0, w, h, 
				FlagsSetWindowPos.SWP_NOOWNERZORDER | 
				FlagsSetWindowPos.SWP_NOACTIVATE |
				FlagsSetWindowPos.SWP_NOMOVE |
				FlagsSetWindowPos.SWP_SHOWWINDOW);
		}

		#region IDisposable Members

		public virtual void Dispose()
		{
			this.DestroyHandle();
		}

		#endregion
	}
}
