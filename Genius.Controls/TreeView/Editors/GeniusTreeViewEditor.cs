using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Genius.Controls.TreeView.Core;
using System.Threading;

namespace Genius.Controls.TreeView.Editors
{
	#region Editeur de base
	/// <summary>
	/// classe de base pour l'édition
	/// </summary>
	public abstract class GeniusTreeViewEditorBase : ITreeViewEdit, IDisposable
	{
		/// <summary>
		/// le noeud en cours d'édition
		/// </summary>
		protected INode			FNode;
		/// <summary>
		/// la colonne en cours d'édition
		/// </summary>
		protected int			FCol;
		/// <summary>
		/// le treeview
		/// </summary>
		protected GeniusTreeView FTreeView;

		/// <summary>
		/// Rectangle de l'édition
		/// </summary>
		protected Rectangle FEditRect;

		/// <summary>
		/// Controle associé à l'édition
		/// </summary>
		protected Control FControl;

		private HookProc FKeysHook;
		private IntPtr FHook;

		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="tv"></param>
		public GeniusTreeViewEditorBase(GeniusTreeView tv)
		{
			FTreeView = tv;
			FControl = CreateEditorControl();
			FControl.Visible = false;
			FControl.Parent = FTreeView;
			FKeysHook = null;
			FHook = IntPtr.Zero;
		}
		#region ITreeViewEdit Members
		/// <summary>
		/// Edition d'un noeud
		/// </summary>
		/// <param name="aNode"></param>
		/// <param name="aCol"></param>
		/// <param name="aRect"></param>
		/// <param name="aValue"></param>
		public virtual void BeginEdit(INode aNode, int aCol, Rectangle aRect, object aValue)
		{
			FNode = aNode;
			FCol = aCol;
			FEditRect = aRect;
			FControl.Bounds = aRect;
			Value = aValue;
			//FControl.Text = FTreeView.GetNodeText(aNode, aCol);
			FControl.Show();
			FControl.Focus();
			FControl.Leave +=new EventHandler(FControl_Leave);
			//FControl.KeyDown +=new KeyEventHandler(FControl_KeyDown);
			Hook();
		}

		/// <summary>
		/// fin d'édition
		/// </summary>
		public virtual void EndEdit()
		{
			//FControl.KeyDown -=new KeyEventHandler(FControl_KeyDown);
			FControl.Leave -= new EventHandler(FControl_Leave);
			FTreeView.Focus();
			FControl.Hide();
			UnHook();
		}

		/// <summary>
		/// annulation de l'édition
		/// </summary>
		public virtual void CancelEdit()
		{
			FControl.KeyDown -=new KeyEventHandler(FControl_KeyDown);
			FControl.Leave -= new EventHandler(FControl_Leave);
			FTreeView.Focus();
			FControl.Hide();
			UnHook();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DoKeyDown(object sender, KeyEventArgs e)
		{
			if (FTreeView != null)
				FTreeView.Editor_OnKeyDown(sender, e);
		}

		/// <summary>
		/// Rectangle de la zone d'édition
		/// </summary>
		public Rectangle EditRect
		{
			get
			{
				return FEditRect;
			}
			set
			{
				FEditRect = value;
				DoSetBounds(value);
			}
		}
		#endregion

		/// <summary>
		///	indique aux descendants qu'il doivent retailler leur zone d'édition
		/// </summary>
		/// <param name="aRect"></param>
		protected void DoSetBounds(Rectangle aRect)
		{
			if (FControl != null)
				FControl.SetBounds(aRect.Left, aRect.Top,  aRect.Width, aRect.Height);
		}

		/// <summary>
		/// à dériver et créer votre control
		/// </summary>
		/// <returns></returns>
		protected abstract Control CreateEditorControl();

		/// <summary>
		/// valeur de l'éditeur
		/// </summary>
		public virtual object Value
		{
			get
			{
				return FControl.Text;
			}
			set
			{
				if (value != null)
					FControl.Text = value.ToString();
				else
					FControl.Text = string.Empty;
			}
		}

		/// <summary>
		/// Control associé à l'editeur
		/// </summary>
		public Control Control
		{
			get
			{
				return FControl;
			}
		}

		private void FControl_Leave(object sender, EventArgs e)
		{
			FTreeView.TryEndEdit();
		}

		private void FControl_KeyDown(object sender, KeyEventArgs e)
		{
			DoKeyDown(sender, e);
		}

		private int KeyBoardHookProc(int code, IntPtr wParam, IntPtr lParam)
		{
			if (code < 0)
				return NativeMethods.CallNextHookEx(FHook, code, wParam, lParam);
			Keys keyPressed = (Keys)wParam.ToInt32();
			int Result = NativeMethods.CallNextHookEx(FHook, code, wParam, lParam);

			if (FControl != null &&  FControl.Focused)
			{
				//dernier bit de lparam pour indiquer si la touche est pressé ou relachée
				if ((lParam.ToInt32() & 0x80000000) == 0)
				{
					if ((NativeMethods.GetKeyState(VirtualKeys.VK_CONTROL) & 0x80) > 0)
						keyPressed |=  Keys.Control;
					if ((NativeMethods.GetKeyState(VirtualKeys.VK_SHIFT) & 0x80) > 0)
						keyPressed |=  Keys.Shift;
					if ((lParam.ToInt32() & 0x20000000) > 0)
						keyPressed |=  Keys.Alt;

					KeyEventArgs ev = new KeyEventArgs(keyPressed);
					DoKeyDown(FControl, ev);
					Result = Convert.ToInt32(ev.Handled);
				}
			}
			return Result;
		}

		#region IDisposable Members
		/// <summary>
		/// Dispose, suppression du hook
		/// </summary>
		public virtual void Dispose()
		{
			UnHook();
		}

		#endregion

		private void Hook()
		{
			FKeysHook = new HookProc(KeyBoardHookProc);
			FHook = NativeMethods.SetWindowsHookEx(HookType.WH_KEYBOARD, FKeysHook, IntPtr.Zero, (uint)AppDomain.GetCurrentThreadId());			
		}

		private void UnHook()
		{
			if (FHook != IntPtr.Zero)
				NativeMethods.UnhookWindowsHookEx(FHook);
			FKeysHook = null;
			
		}
	}
	#endregion

	#region Editeur Texte
	/// <summary>
	/// classe d'exemple représentant une implémentation  <see cref="ITreeViewEdit"/>
	/// </summary>
	public class GeniusTreeViewEditor : GeniusTreeViewEditorBase
	{	
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="tv"></param>
		public GeniusTreeViewEditor(GeniusTreeView tv): base(tv)
		{
		}

		/// <summary>
		/// création du textebox éditor
		/// </summary>
		/// <returns></returns>
		protected override Control CreateEditorControl()
		{
			return new TreeViewTextBoxEditor();
		}

		/// <summary>
		/// demarre l'édition
		/// </summary>
		/// <param name="aNode"></param>
		/// <param name="aCol"></param>
		/// <param name="aRect"></param>
		/// <param name="aValue"></param>
		public override void BeginEdit(INode aNode, int aCol, Rectangle aRect, object aValue)
		{
			base.BeginEdit(aNode, aCol, aRect, aValue);
			(FControl as TreeViewTextBoxEditor).SelectAll();
		}

		/// <summary>
		/// valeur de l'editeur
		/// </summary>
		public override object Value
		{
			get
			{
				return (FControl as TreeViewTextBoxEditor).Text;
			}
		}
	}
	#endregion
}
