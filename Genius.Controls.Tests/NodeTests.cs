using System;
using Genius.Controls.TreeView.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Genius.Controls.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void NodeEnumeration()
        {
            Node n = new Node();
            Assert.AreEqual(0, n.GetNodes().Count());
            Assert.AreEqual(0, n.GetNodes(true).Count());
        }


        [TestMethod]
        public void Add1000Nodes()
        {
            Nodes tree = new Nodes();

            for (int i = 0; i < 1000; i++)
            {
                tree.InternalAdd(null, null);
            }

            Assert.AreEqual(1000, tree.Count);
            Assert.AreEqual(1000, tree.TotalCount);
        }

        private void FillTree(Nodes tree)
        {
            for (int i = 0; i < 1000; i++)
            {
                var n = tree.InternalAdd(null, null);
                n.Text = string.Format("{0}", i);
            }

            foreach (var item in tree.GetNodes())
            {
                for (int i = 0; i < 1000; i++)
                {
                    var n = tree.InternalAdd((Node)item, null);
                    n.Text = string.Format("{0}.{1}", item.Text, i);
                }
            }            
        }

        [TestMethod]
        public void Add1000under1000Nodes()
        {
            Nodes tree = new Nodes();

            for (int i = 0; i < 1000; i++)
            {
                tree.InternalAdd(null, null);
            }

            foreach (var item in tree.GetNodes())
            {
                for (int i = 0; i < 1000; i++)
                {
                    tree.InternalAdd((Node)item, null);
                }
            }

            Assert.AreEqual(1000, tree.Count);
            Assert.AreEqual(1000 + 1000 * 1000, tree.TotalCount);
        }

        [TestMethod]
        public void NextNodeTest()
        {
            Nodes tree = new Nodes();
            FillTree(tree);

            var f = tree.RootNode.FirstChild;
            var n = Node.NextNode(f);
            Assert.AreEqual(0, n.Index);
            Assert.AreEqual("0.0", n.Text);
        }

        [TestMethod]
        public void NextSiblingNodeTest()
        {
            Nodes tree = new Nodes();
            FillTree(tree);

            var f = tree.RootNode.FirstChild;
            var n = Node.NextSiblingNode(f);
            Assert.AreEqual(1, n.Index);
            Assert.AreEqual("1", n.Text);
        }
    }
}
