using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Genius.Controls.NativeWindow
{
	using GeniusTreeView = Control;
	/// <summary>
	/// Summary description for BaseNativeWindow.
	/// </summary>
	public class BaseNativeWindow : System.Windows.Forms.NativeWindow, IDisposable
	{
		#region Variables
		private GeniusTreeView FTree;
		private int FAlpha; 
		private Rectangle FRect;
		private bool FVisible;
		private int FFadeIn;
		#endregion

		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="tv"></param>
		public BaseNativeWindow(GeniusTreeView tv)
		{
			FTree = tv;
			FAlpha = 254;
			FRect = Rectangle.Empty;
		}

		/// <summary>
		/// Le treeview lié
		/// </summary>
		protected GeniusTreeView Tree
		{
			get
			{
				return FTree;
			}
		}

		/// <summary>
		/// surcharge de WndProc pour le paint
		/// </summary>
		/// <param name="m"></param>
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

		/// <summary>
		/// à surcharger par le descendant, pour le paint du hint
		/// </summary>
		/// <param name="g"></param>
		protected virtual void DoPaint(Graphics g)
		{
		}

		private void SetAlpha(int value)
		{
			Alpha = value;		
		}

		private void FadeInWindow()
		{
			int sleepTime = FFadeIn / 10;
			int alphaStep = Alpha / 10;
			for (int i = 0; i < 10; i++)
			{
				Alpha += alphaStep;
				Thread.Sleep(sleepTime);
			}
		}

		#region Méthodes Publiques
		/// <summary>
		/// affiche la fenêtre
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void Show(int x, int y)
		{
			Position = new Point(x,y);
			if (!FVisible)
				Visible = true;
		}

		/// <summary>
		/// transparence de la fenêtre
		/// </summary>
		public int Alpha
		{
			get
			{
				return FAlpha;
			}
			set
			{
				if (FAlpha != value)
				{
					int oldValue = FAlpha;
					FAlpha = value;
					if (HandleCreated)
					{
						if (oldValue < 255)
							NativeMethods.SetLayeredWindowAttributes(this.Handle, 0, FAlpha, 0x02);
						else
							RecreateHandle();
					}
				}
			}
		}

		/// <summary>
		/// retourne le rectangle de la fenêtre
		/// </summary>
		public Rectangle WindowRect
		{
			get
			{
				RECT rc = new RECT();
				if (NativeMethods.GetWindowRect(this.Handle, ref rc))
					return rc.ToRectangle();
				return FRect;
			}
			set
			{
				HandleRequest();
				NativeMethods.SetWindowPos(this.Handle, IntPtr.Zero, value.Left, value.Top,  value.Width, value.Height,
				FlagsSetWindowPos.SWP_NOOWNERZORDER | FlagsSetWindowPos.SWP_NOACTIVATE);
			}
		}

		/// <summary>
		/// position de la fenêtre
		/// </summary>
		public Point Position
		{
			get
			{
				Rectangle r = WindowRect;
				return new Point(r.Left, r.Top);
			}
			set
			{
				HandleRequest();
				NativeMethods.SetWindowPos(this.Handle, IntPtr.Zero, value.X, value.Y,  0, 0,
					FlagsSetWindowPos.SWP_NOOWNERZORDER | FlagsSetWindowPos.SWP_NOACTIVATE | FlagsSetWindowPos.SWP_NOSIZE);
			}
		}

		/// <summary>
		/// taille de la fenêtre
		/// </summary>
		public Size WindowSize
		{
			get
			{
				Rectangle r = WindowRect;
				return new Size(r.Width, r.Height);				
			}
			set
			{
				HandleRequest();
				NativeMethods.SetWindowPos(this.Handle, IntPtr.Zero, 0, 0,  value.Width, value.Height,
					FlagsSetWindowPos.SWP_NOOWNERZORDER | FlagsSetWindowPos.SWP_NOACTIVATE | FlagsSetWindowPos.SWP_NOMOVE);				
			}
		}

		/// <summary>
		/// retourne le rectangle de l'aire cliente
		/// </summary>
		public Rectangle ClientRectangle
		{
			get
			{
				RECT rc = new RECT();
				if (NativeMethods.GetClientRect(this.Handle, ref rc))
					return rc.ToRectangle();
				return Rectangle.Empty;
			}
		}

		/// <summary>
		/// obtient ou défini la visibilité de la fenêtre
		/// </summary>
		public bool Visible
		{
			get
			{
				return FVisible;
			}
			set
			{
				if (FVisible != value)
				{
					HandleRequest();
					FVisible = value;
					int oldAlpha = Alpha;
					if (FVisible && FFadeIn > 0)
						Alpha = Alpha / 10;
					FlagsSetWindowPos flags = FlagsSetWindowPos.SWP_NOACTIVATE | FlagsSetWindowPos.SWP_NOMOVE | FlagsSetWindowPos.SWP_NOSIZE | FlagsSetWindowPos.SWP_NOZORDER;
					flags |= FVisible ? FlagsSetWindowPos.SWP_SHOWWINDOW : FlagsSetWindowPos.SWP_HIDEWINDOW;
					NativeMethods.SetWindowPos(this.Handle, IntPtr.Zero, 0,0,0,0, flags);
					if (FVisible && FFadeIn > 0)
					{
						FadeInWindow();
						Alpha = oldAlpha;
					}
				}
			}
		}

		/// <summary>
		/// permet d'afficher la fenêtre progressivement
		/// </summary>
		public int FadeIn
		{
			get
			{
				return FFadeIn;
			}
			set
			{
				FFadeIn = value;
			}
		}
		#endregion

		#region IDisposable Members

		/// <summary>
		/// dispose du handle de la fenêtre
		/// </summary>
		public virtual void Dispose()
		{
			this.DestroyHandle();
		}

		#endregion

		private void HandleRequest()
		{
			if (!HandleCreated)
			{
				CreateParams cp = new CreateParams();
            
				cp.X = FRect.Left;
				cp.Y = FRect.Top;
				cp.Height = FRect.Height;
				cp.Width = FRect.Width;

				//TODO: demander le style de la fenêtre
				WindowStyles style = (WindowStyles.WS_POPUP);
				cp.Style = (int)style;
				cp.Parent = FTree.Handle;
			
				if (Alpha < 255)
					cp.ExStyle |= (int)WindowExStyles.WS_EX_LAYERED;
				this.CreateHandle(cp);
				if (Alpha < 255)
					NativeMethods.SetLayeredWindowAttributes(this.Handle, 0, Alpha, 0x02);				
				AfterHandleCreated();
			}
		}

		/// <summary>
		/// renvoi true si le handle de la fenêtre est créer
		/// </summary>
		protected bool HandleCreated
		{
			get { return this.Handle != IntPtr.Zero; }
		}

		private void RecreateHandle()
		{
			FRect = WindowRect;
			DestroyHandle();
			HandleRequest();
			if (FVisible)
			{
				FVisible = false;
				Visible = true;
			}
		}

		/// <summary>
		/// provoque le raffraichissement de la fenêtre
		/// </summary>
		protected void Invalidate()
		{
			if (HandleCreated)
				NativeMethods.InvalidateRect(this.Handle, this.ClientRectangle, 0);
		}

		/// <summary>
		/// à surcharger par les descendant, cette méthode est appelé à la fin de 
		/// la création de la fenêtre
		/// </summary>
		protected virtual void AfterHandleCreated()
		{
			
		}
	}
}
