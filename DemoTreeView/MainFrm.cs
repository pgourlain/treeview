using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Genius.Controls;

namespace DemoTreeView
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new TabbedDemo().Show();
        }

        private void autoSizeColumnUC1_Load(object sender, EventArgs e)
        {

        }
    }
}
