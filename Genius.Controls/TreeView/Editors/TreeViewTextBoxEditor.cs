using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Genius.Controls.TreeView.Editors
{
	using System;
	using System.Security.Permissions;
	using System.Windows.Forms;

	/// <summary>
	/// Summary description for TreeViewTextBoxEditor.
	/// </summary>
	[ToolboxItem(false)]
	internal class TreeViewTextBoxEditor : RichTextBox
	{
		private bool FInComposition;
		private string FOldText;

		/// <summary>
		/// constructeur par défaut
		/// </summary>
		public TreeViewTextBoxEditor()
		{
			base.BorderStyle = BorderStyle.None;
			base.CausesValidation = false;
			FOldText = string.Empty;
			base.SetStyle(ControlStyles.Selectable, false);
			base.SetStyle(ControlStyles.StandardDoubleClick | ControlStyles.StandardClick, true);
		}

		/// <summary>
		/// suppression du drag de fichier et de parent notify
		/// </summary>
		protected override System.Windows.Forms.CreateParams CreateParams
		{
			[SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
			get
			{
				System.Windows.Forms.CreateParams baseParams = base.CreateParams;
				const int WS_EX_NOPARENTNOTIFY = 0x4;
				const int WS_EX_ACCEPTFILES = 0x10;
				//baseParams.ExStyle &= ~0x200;
				baseParams.ExStyle &= ~(WS_EX_NOPARENTNOTIFY | WS_EX_ACCEPTFILES);
				return baseParams;
			}
		}

		/// <summary>
		/// gestion de startComposition et EndComposition
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m)
		{
			const int WM_IME_STARTCOMPOSITION   = 0x010D;
			const int WM_IME_ENDCOMPOSITION     = 0x010E;
			const int WM_IME_COMPOSITION        = 0x010F;
			try
			{
				switch(m.Msg)
				{
					case WM_IME_STARTCOMPOSITION :
						FInComposition = true;
						break;
					case WM_IME_ENDCOMPOSITION :
						FInComposition = false;

						break;
					case WM_IME_COMPOSITION :
						break;
				}
				base.WndProc (ref m);
				switch((Msgs)m.Msg)
				{
					case Msgs.WM_NCCALCSIZE :
						int a = (int)m.WParam;
						if (a != 0)
						{
							NCCalcSizeParams size = (NCCalcSizeParams)Marshal.PtrToStructure(m.LParam, typeof(NCCalcSizeParams));
							size.rgrc0.Top += 1;
							size.rgrc0.Left += 1;
							size.rgrc0.Right -= 1;
							size.rgrc0.Bottom -= 1;
							Marshal.StructureToPtr(size, m.LParam, false);
						}
						else
							Debug.WriteLine("WM_NCCALCSIZE fCalcValidRects = false");
						break;					
					case Msgs.WM_NCPAINT :
						FlagsDCX flags =  FlagsDCX.DCX_CACHE | FlagsDCX.DCX_CLIPSIBLINGS | FlagsDCX.DCX_WINDOW | FlagsDCX.DCX_VALIDATE;
						IntPtr dc = NativeMethods.GetDCEx(this.Handle, m.WParam, flags);
                        if (dc != IntPtr.Zero)
                        {
                            try
                            {
                                using (Graphics g = Graphics.FromHdc(dc))
                                {
                                    Rectangle rectRegion = Rectangle.Empty;
                                    rectRegion = new Rectangle(0, 0, this.Size.Width - 1, this.Size.Height - 1);
                                    g.DrawRectangle(Pens.Black, rectRegion);
                                }
                            }
                            finally
                            {
                                NativeMethods.ReleaseDC(this.Handle, dc);
                            }
                        }
						m.Result = IntPtr.Zero;
						break;
					/*
					case Msgs.WM_GETDLGCODE :
						m.Result = new IntPtr((int)(DialogCodes.DLGC_WANTTAB | DialogCodes.DLGC_WANTARROWS));
						break;
						*/
				}
			}
			catch
			{
                throw;
			}
		}


		/// <summary>
		/// renvoi le texte selectionner
		/// </summary>
		public override string SelectedText
		{
			get
			{
				if (this.FInComposition)
				{
					return this.FOldText;
				}
				return base.SelectedText;
			}
			set
			{
				this.FOldText = value;
				base.SelectedText = value;
			}
		}

		/// <summary>
		/// renvoi le text du richeTextBoxou l'ancien text mémorisé avant le demarrage
		/// de la composition
		/// </summary>
		public override string Text
		{
			get
			{
				if (!this.FInComposition)
				{
					this.FOldText = base.Text;
				}
				return this.FOldText;
			}
			set
			{
				this.FOldText = value;
				base.Text = value;
			}
		}

		/// <summary>
		/// zone de l'edition
		/// </summary>
		public new Rectangle Bounds
		{
			get
			{
				return base.Bounds;
			}
			set
			{
				base.Bounds = value;
                //FBounds = value;
			}
		}
	}
}
