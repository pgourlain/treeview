using System;
using System.Collections;
using System.Collections.Specialized;
using System.Threading;
using Genius.Controls.TreeView;

namespace DemoTreeView.UserControls
{
	/// <summary>
	/// Summary description for TestHeader.
	/// </summary>
	public class TestHeader : System.Windows.Forms.UserControl
	{
		private static ArrayList FRandom = new ArrayList();

		private Genius.Controls.TreeView.GeniusTreeView gtv;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne2;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne3;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne4;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne5;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne6;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne7;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne8;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne9;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne10;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		public TestHeader()
		{
			new Thread(new ThreadStart(CalculRandom)).Start();
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			// TODO: Add any initialization after the InitializeComponent call
			gtv.BeginUpdate();
			try
			{
				for (int i =0; i < 10; i++)
				{
					INode aParent = gtv.Add(null, i.ToString(), new NodeData(i));
					for (int j = 0; j < 10; j++)
					{
						int value = j < 5 ? i : i+1;
						gtv.Add(aParent, value.ToString(), new NodeData(value));
					}
				}
			}
			finally
			{
				gtv.EndUpdate();
			}
			gtv.FullRowSelect = false;
			Genius.Controls.TreeView.Colors.Themes.GeniusTreeViewTheme(gtv.Colors);
			int[] aDisplays = new int[]{0,1};
			SortDirection[] aDirections = new SortDirection[]{SortDirection.Ascending, SortDirection.Descending};
			gtv.SortTree(aDisplays, aDirections);
		}

	private void CalculRandom()
		{
			IDictionary dico = new Hashtable();
			lock(FRandom)
			{
				Random r = new Random();
				while (FRandom.Count < 10000)
				{
					int random = r.Next(100000);
					if (!dico.Contains(random))
					{
						dico.Add(random, random);
						FRandom.Add(random);
					}
				}
			}
		}

		private static int RandomNumber()
		{
			if (FRandom.Count == 0)
				Thread.Sleep(100);
			
			int Result = (int)FRandom[0];
			FRandom.RemoveAt(0);
			return 	Result;
		}

		class Moto
		{
			public Moto(string aMarque, int aCylindrée, string aModele)
			{
				Marque = aMarque;
				Cylindrée = aCylindrée;
				Modele = aModele;
			}

			public string Marque;
			public int Cylindrée;
			public string Modele;
 
			public object this[int index]
			{
				get
				{
					switch (index)
					{
						default :
						case 0 :
							return Marque;
						case 1 :
							return Modele;
						case 2 :
							return Cylindrée;
					}
				}
			}
		}

		class NodeData
		{
			private static string[] Marques = {"Honda", "Suzuki", "Triumph", "Yamaha", "Ducati"};
			private static string[] Cylindrées = {"600", "800", "1000"};
			private static string[][] Motos ={new string[]{"VFR"},new string[]{} };
			public int FRoot;
			public int[] FColumns = new int[5];
			public NodeData(int aRoot)
			{
				FRoot = aRoot;
				for (int i = 0; i < 5; i++)
				{
					FColumns[i] = RandomNumber();
					//Thread.Sleep(1);
				}
			}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TestHeader));
			this.gtv = new Genius.Controls.TreeView.GeniusTreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.geniusTreeViewColonne1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne4 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne5 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne6 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne7 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne8 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne9 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne10 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.SuspendLayout();
			// GeniusTreeView By Pierrick Gourlain
			// 
			// gtv
			// 
			this.gtv.Alignment = System.Drawing.StringAlignment.Near;
			this.gtv.AutoSort = false;
			this.gtv.BackColor = System.Drawing.SystemColors.Window;
			this.gtv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gtv.Colors.FocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.gtv.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.gtv.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F, System.Drawing.Drawing2D.DashStyle.Solid);
			this.gtv.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.UnFocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.gtv.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOptions.ShowGridLines;
			this.gtv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gtv.ElapsedHint = 500;
			this.gtv.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtv.Header.ImageList = this.imageList1;
			this.gtv.Header.MainColumnIndex = 0;
			this.gtv.Header.SortImageAlignment = Genius.Controls.TreeView.ImageSortAlignment.BottomRight;
			this.gtv.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
																									  this.geniusTreeViewColonne1,
																									  this.geniusTreeViewColonne2,
																									  this.geniusTreeViewColonne3,
																									  this.geniusTreeViewColonne4,
																									  this.geniusTreeViewColonne5,
																									  this.geniusTreeViewColonne6,
																									  this.geniusTreeViewColonne7,
																									  this.geniusTreeViewColonne8,
																									  this.geniusTreeViewColonne9,
																									  this.geniusTreeViewColonne10});
			this.gtv.HeaderHeight = 100;
			this.gtv.KeysGridMode = false;
			this.gtv.Location = new System.Drawing.Point(0, 0);
			this.gtv.Name = "gtv";
			this.gtv.ShowHeader = true;
			this.gtv.Size = new System.Drawing.Size(392, 256);
			this.gtv.TabIndex = 0;
			this.gtv.Text = "geniusTreeView1";
			this.gtv.UseColumns = true;
			this.gtv.OnGetNodeValue += new Genius.Controls.TreeView.OnGetNodeValueForComparisonDelegate(this.gtv_OnGetNodeValue);
			this.gtv.OnGetNodeText += new Genius.Controls.TreeView.OnGetNodeTextDelegate(this.gtv_OnGetNodeText);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// geniusTreeViewColonne1
			// 
			this.geniusTreeViewColonne1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.ImageIndex = 0;
			this.geniusTreeViewColonne1.Text = "Colonne 1";
			// 
			// geniusTreeViewColonne2
			// 
			this.geniusTreeViewColonne2.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne2.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne2.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.ImageAlignment = Genius.Controls.TreeView.ImageAlignment.Top;
			this.geniusTreeViewColonne2.ImageIndex = 1;
			this.geniusTreeViewColonne2.Text = "Colonne 2";
			this.geniusTreeViewColonne2.TextOrientation = 90F;
			// 
			// geniusTreeViewColonne3
			// 
			this.geniusTreeViewColonne3.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne3.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne3.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.ImageAlignment = Genius.Controls.TreeView.ImageAlignment.Right;
			this.geniusTreeViewColonne3.ImageIndex = 2;
			this.geniusTreeViewColonne3.Text = "Colonne 3";
			this.geniusTreeViewColonne3.TextOrientation = 180F;
			// 
			// geniusTreeViewColonne4
			// 
			this.geniusTreeViewColonne4.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne4.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne4.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.ImageAlignment = Genius.Controls.TreeView.ImageAlignment.Bottom;
			this.geniusTreeViewColonne4.ImageIndex = 3;
			this.geniusTreeViewColonne4.Text = "Colonne 4";
			this.geniusTreeViewColonne4.TextOrientation = 270F;
			// 
			// geniusTreeViewColonne5
			// 
			this.geniusTreeViewColonne5.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne5.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne5.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne5.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne5.ImageIndex = 4;
			this.geniusTreeViewColonne5.Text = "Colonne 5";
			this.geniusTreeViewColonne5.TextOrientation = -45F;
			// 
			// geniusTreeViewColonne6
			// 
			this.geniusTreeViewColonne6.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne6.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne6.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne6.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne6.ImageIndex = 5;
			this.geniusTreeViewColonne6.Text = "Colonne 6";
			// 
			// geniusTreeViewColonne7
			// 
			this.geniusTreeViewColonne7.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne7.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne7.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne7.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne7.Text = "Colonne 6";
			// 
			// geniusTreeViewColonne8
			// 
			this.geniusTreeViewColonne8.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne8.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne8.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne8.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne8.Text = "Colonne 7";
			// 
			// geniusTreeViewColonne9
			// 
			this.geniusTreeViewColonne9.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne9.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne9.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne9.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne9.Text = "Colonne 8";
			// 
			// geniusTreeViewColonne10
			// 
			this.geniusTreeViewColonne10.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne10.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne10.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne10.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne10.Text = "Colonne 9";
			// 
			// TestHeader
			// 
			this.Controls.Add(this.gtv);
			this.Name = "TestHeader";
			this.Size = new System.Drawing.Size(392, 256);
			this.ResumeLayout(false);

		}
		#endregion

		private System.IComparable gtv_OnGetNodeValue(Genius.Controls.TreeView.INode A, int aDisplayColumn)
		{
			if (aDisplayColumn == 0)
				return ((NodeData)A.Data).FRoot;
			if (aDisplayColumn < 6)
				return ((NodeData)A.Data).FColumns[aDisplayColumn-1];
			return null;
		}

		private void gtv_OnGetNodeText(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeTextEventArgs e)
		{
			if (e.DisplayColumn > 0 && e.DisplayColumn < 6)
			{
				e.Text = ((NodeData)e.Node.Data).FColumns[e.DisplayColumn-1].ToString();
			}
		}
	}
}
