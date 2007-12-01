using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Genius.Controls.TreeView;

namespace DemoTreeView.UC1
{
    public partial class demoIStringNodeProvider : System.Windows.Forms.UserControl
    {
        public demoIStringNodeProvider()
        {
            InitializeComponent();
        }

        private void demoIStringNodeProvider_Load(object sender, EventArgs e)
        {
            gtv.Add(null, "coucou", new MaData());
            gtv.Add(null, "coucou", new MaData());
            gtv.Add(null, "coucou", new MaData());
            timer1.Enabled = true;
        }

        private static int FNodeNumber = 0;
        public static string NodeText
        {
            get
            {
                return String.Format("Node {0}", FNodeNumber);
            }
        }

        class MaData : IStringNodeProvider
        {
            #region IStringNodeProvider Members

            public string GetText(int aDisplayColumn)
            {
                return NodeText;
            }

            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FNodeNumber++;
            gtv.Invalidate();
        }
}
}
