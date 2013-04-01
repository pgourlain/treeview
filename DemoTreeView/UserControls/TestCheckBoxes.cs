using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Genius.Controls.TreeView;

namespace DemoTreeView.UserControls
{
    public partial class TestCheckBoxes : System.Windows.Forms.UserControl
    {
        public TestCheckBoxes()
        {
            InitializeComponent();
        }

        private void TestCheckBoxes_Load(object sender, EventArgs e)
        {
            gtv.BeginUpdate();
            try
            {
                INode n= gtv.Add(null, "Honda", null);
                gtv.Add(n, "VFR 800", null);
                gtv.Add(n, "CBR 1000", null);
                gtv.Add(n, "CBR XX", null);
                gtv.Add(n, "VTR 1000", null);
                n = gtv.Add(null, "Suzuki", null);
                gtv.Add(n, "Bandit 1200", null);
                gtv.Add(n, "SV 650", null);

                n = gtv.Add(null, "Ducati", null);
                gtv.Add(n, "749", null);
                gtv.Add(n, "999R", null);
                gtv.ExpandAll();
            }
            finally
            {
                gtv.EndUpdate();
            }
        }

        private void gtv_OnInitNode(GeniusTreeView Sender, NodeEventArgs e)
        {
            e.Node.State |= NodeState.HasCheck;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gtv.IndependantCheckboxes = checkBox1.Checked;
        }

        private void gtv_OnItemMouseEnter(GeniusTreeView Sender, NodeCellMouseEventArgs e)
        {
            textBox1.AppendText(string.Format("gtv_OnItemMouseEnter({0})\r\n", e.Node.Text));
        }

        private void gtv_OnItemMouseLeave(GeniusTreeView Sender, NodeCellMouseEventArgs e)
        {
            textBox1.AppendText(string.Format("gtv_OnItemMouseLeave({0})\r\n" ,e.Node.Text));
        }
    }
}
