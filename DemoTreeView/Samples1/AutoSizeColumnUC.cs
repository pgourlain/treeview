using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DemoTreeView.Samples1
{
    public partial class AutoSizeColumnUC : UserControl
    {
        public AutoSizeColumnUC()
        {
            InitializeComponent();
        }

        private void AutoSizeColumnUC_Load(object sender, EventArgs e)
        {
            for (int i =0; i < 100;i++)
                gtvAutoSizeColumn.Add(null, null);
        }

        private void gtvAutoSizeColumn_OnGetNodeText(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeTextEventArgs e)
        {
            if (e.DisplayColumn == 2)
            {
                e.Text = "ce texte est un exemple d'un texte suffisamment long pour être 'wrapper'";
            }
            else if (e.DisplayColumn == 3)
            {
                e.Text = e.Node.Index.ToString();
            }
        }
    }
}
