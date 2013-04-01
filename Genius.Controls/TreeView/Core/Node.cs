using System;
using System.Collections;
using System.Collections.Generic;
using Genius.Controls.TreeView.Core;

namespace Genius.Controls.TreeView.Core
{
    internal delegate void NodeDelegate(Node aNode);
    /// <summary>
    /// Summary description for Node.
    /// </summary>
    internal class Node : INode, INodeEnumerable, IEnumerable
    {
        internal bool InInitNode;
        internal int TotalHeight;
        internal int Width;
        internal int TotalCheck;
        internal int TotalChecked;
        internal int TotalCount;
        internal int TotalSignaled;
        internal Node Parent,
            PrevSibling,
            NextSibling,
            FirstChild,
            LastChild;
        internal NodeState State;

        public int Height;
        public int Index;
        public int ImageIndex;
        public int ImageStateIndex;
        public int ChildCount;
        public object Data;
        public string Text;

        public Node()
        {
            this.ImageStateIndex = -1;
            this.ImageIndex = -1;
        }

        #region méthodes privées
        private Nodes Nodes
        {
            get
            {
                Node n = this;
                while (n.Parent != null)
                {
                    n = n.Parent;
                }
                if (n is Root)
                    return ((Root)n).Nodes;
                return null;
            }
        }

        private void InvalidateNode()
        {
            if (InInitNode)
                return;
            Nodes tv = Nodes;

            if (tv != null)
            {
                this.Width = 0;
                tv.InvalidateNode(this);
            }
        }

        private void Invalidate()
        {
            if (InInitNode)
                return;
            Nodes tv = Nodes;

            if (tv != null)
                tv.InvalidateNode(null);
        }

        private void UpdateTotalHeight(int nb)
        {
            this.TotalHeight += nb;
            if (InInitNode)
                return;

            UpdateTotalTotalHeight(this.Parent, nb);
        }

        #endregion

        #region INode Members
        int INode.Height
        {
            get
            {
                return this.Height;
            }
            set
            {
                if (this.Height != value)
                {
                    if (value < 5)
                        value = 5;
                    int diff = value - this.Height;
                    this.Height = value;
                    UpdateTotalHeight(diff);
                    InvalidateNode();
                }
            }
        }

        int INode.Index
        {
            get
            {
                return this.Index;
            }
        }

        int INode.ImageIndex
        {
            get
            {
                return this.ImageIndex;
            }
            set
            {
                if (this.ImageIndex != value)
                {
                    this.ImageIndex = value;
                    InvalidateNode();
                }
            }
        }

        int INode.ImageStateIndex
        {
            get
            {
                return this.ImageStateIndex;
            }
            set
            {
                if (this.ImageStateIndex != value)
                {
                    this.ImageStateIndex = value;
                    InvalidateNode();
                }
            }
        }

        object INode.Data
        {
            get
            {
                return this.Data;
            }
            set
            {
                this.Data = value;
            }
        }

        string INode.Text
        {
            get
            {
                return this.Text;
            }
            set
            {
                if (this.Text != value)
                {
                    this.Text = value;
                    InvalidateNode();
                }
            }
        }

        NodeState INode.State
        {
            get
            {
                return this.State;
            }
            set
            {
                NodeState old = this.State;
                //je n'autorise pas la modification de Selected
                value = value & ~NodeState.Selected;
                if (!InInitNode)
                    value = value & ~NodeState.Visible;
                if (this.State != value)
                {
                    bool oldVisible = Set.Contains(old, NodeState.Visible);
                    int check = InInitNode ? 0 : (Set.Contains(value, NodeState.HasCheck) ? 1 : 0) -
                        (Set.Contains(old, NodeState.HasCheck) ? 1 : 0);
                    int aChecked = InInitNode ? 0 : (Set.Contains(value, NodeState.Checked) ? 1 : 0) -
                        (Set.Contains(old, NodeState.Checked) ? 1 : 0);
                    int signaled = InInitNode ? 0 : (Set.Contains(value, NodeState.Signaled) ? 1 : 0) -
                        (Set.Contains(old, NodeState.Signaled) ? 1 : 0);

                    this.State = value | (this.State & NodeState.Selected) | (InInitNode ? 0 : this.State & NodeState.Visible);
                    //les variables des parents sont mis à jours que si le noeud est visible
                    if (oldVisible && IsVisible)
                    {
                        if (check != 0)
                            UpdateTotalCheck(this.Parent, check);
                        if (aChecked != 0)
                            UpdateTotalCheckedCount(this.Parent, aChecked, Nodes.ChecksAreIndependant);
                        if (signaled != 0)
                            UpdateTotalSignaledCount(this.Parent, signaled);
                    }
                    if (signaled != 0)
                        Invalidate();
                    else
                        InvalidateNode();
                }
            }
        }

        bool INode.IsSelected
        {
            get
            {
                return (this.State & NodeState.Selected) == NodeState.Selected;
            }
        }

        INode INode.First
        {
            get
            {
                return this.FirstChild;
            }
        }
        INode INode.Last
        {
            get
            {
                return this.LastChild;
            }
        }
        INode INode.NextVisible
        {
            get
            {
                return NextVisibleNode(this);
            }
        }

        INode INode.NextSibling
        {
            get
            {
                return this.NextSibling;
            }
        }

        INode INode.PrevSibling
        {
            get
            {
                return this.PrevSibling;
            }
        }

        INode INode.PrevVisible
        {
            get
            {
                return PrevVisibleNode(this);
            }
        }

        public int Count
        {
            get
            {
                return this.ChildCount;
            }
        }

        INodeEnumerable INode.Enumerable
        {
            get { return this; }
        }

        INode INode.Parent
        {
            get
            {
                return Parent;
            }
        }

        /// <summary>
        /// renoiv le index "ieme" noeud
        /// </summary>
        public INode this[int index]
        {
            get
            {
                if (index < 0 || index >= ChildCount)
                    throw new IndexOutOfRangeException("INode[index] index hors limite");
                Node Result = this.FirstChild;
                while (Result != null && index-- > 0)
                    Result = Result.NextSibling;
                return Result;
            }
        }


        #endregion

        bool INode.IsExpanded
        {
            get
            {
                return IsExpanded(this);
            }
        }
        int INode.Level
        {
            get
            {
                return GetNodeLevel(this);
            }
        }

        bool INode.IsChecked
        {
            get { return (this.State & NodeState.Checked) == NodeState.Checked; }
        }

        private static int CalcTopPosition(Node a)
        {
            int Result = 0;

            if (a.PrevSibling != null)
                do
                {
                    a = a.PrevSibling;
                    if (a.IsVisible)
                        Result += a.TotalHeight;
                }
                while (a.PrevSibling != null);

            if (!(a.Parent is Root))
            {
                Result += CalcTopPosition(a.Parent);
                Result += a.Parent.Height;
            }
            return Result;
        }

        internal int TopPosition
        {
            get
            {
                if (!IsFullyVisible(this))
                    return -1;
                return CalcTopPosition(this);
            }
        }


        #region méthodes interne
        internal bool IsChild(Node aNode)
        {
            Node tmp = Parent;
            while (tmp != null)
            {
                if (tmp == aNode)
                    return true;
                tmp = tmp.Parent;
            }
            return false;
        }

        public bool IsVisible
        {
            get
            {
                return Set.Contains(this.State, NodeState.Visible);
            }
        }

        internal Node[] Children
        {
            get
            {
                if (ChildCount > 0)
                {
                    Node[] Result = new Node[ChildCount];
                    Node n = this.FirstChild;
                    int i = 0;
                    while (n != null)
                    {
                        Result[i++] = n;
                        n = n.NextSibling;
                    }
                    return Result;
                }
                return null;
            }
        }

        internal Node Clone(bool deep)
        {
            Node Result = (Node)MemberwiseClone();
            if (Data != null && Data is ICloneable)
                Result.Data = ((ICloneable)Data).Clone();

            if (deep && ChildCount > 0)
            {
                Node[] children = Children;
                Node[] childrenCopy = new Node[children.Length];
                for (int i = 0; i < children.Length; i++)
                {
                    childrenCopy[i] = children[i].Clone(deep);
                    childrenCopy[i].Parent = Result;
                    if (i > 0)
                    {
                        childrenCopy[i].PrevSibling = childrenCopy[i - 1];
                        childrenCopy[i - 1].NextSibling = childrenCopy[i];
                    }
                }
                Result.FirstChild = childrenCopy[0];
                Result.LastChild = childrenCopy[childrenCopy.Length - 1];

            }
            return Result;
        }
        #endregion

        #region méthodes statiques
        internal static void UpdateTotalTotalHeight(Node aNode, int nb)
        {
            if (nb == 0)
                return;
            while (aNode != null && Set.Contains(aNode.State, NodeState.Expanded))
            {
                aNode.TotalHeight += nb;
                if (Set.Contains(aNode.State, NodeState.Visible))
                    aNode = aNode.Parent;
                else
                    break;
            }
        }

        internal static void UpdateTotalCheck(Node aNode, int nb)
        {
            if (nb == 0)
                return;
            while (aNode != null)
            {
                aNode.TotalCheck += nb;
                if (Set.Contains(aNode.State, NodeState.Visible))
                    aNode = aNode.Parent;
                else
                    break;
            }
        }

        internal static void UpdateTotalCheckedCount(Node aNode, int nb, bool independant)
        {
            if (nb == 0)
                return;
            while (aNode != null)
            {
                aNode.TotalChecked += nb;
                if (!independant)
                {
                    if (aNode.TotalChecked == aNode.TotalCheck)
                        Set.Include(ref aNode.State, NodeState.Checked);
                    else
                        Set.Exclude(ref aNode.State, NodeState.Checked);
                }
                if (Set.Contains(aNode.State, NodeState.Visible))
                    aNode = aNode.Parent;
                else
                    break;
            }
        }

        internal static void UpdateTotalSignaledCount(Node aNode, int nb)
        {
            if (nb == 0)
                return;
            while (aNode != null)
            {
                aNode.TotalSignaled += nb;
                if (Set.Contains(aNode.State, NodeState.Visible))
                    aNode = aNode.Parent;
                else
                    break;
            }
        }

        internal static bool IsFullyVisible(Node aNode)
        {
            while (aNode != null && aNode.Parent != null)
            {
                if (!Set.Contains(aNode.Parent.State, NodeState.Expanded) ||
                    !Set.Contains(aNode.Parent.State, NodeState.Visible))
                    return false;
                aNode = aNode.Parent;
            }
            return true;
        }

        internal static Node LastVisibleNode(Node aParent)
        {
            Node Result = null;

            Result = aParent.LastChild;
            while (Result != null)
            {
                if (Set.Contains(Result.State, NodeState.Visible))
                {
                    if (Result.ChildCount > 0 && Set.Contains(Result.State, NodeState.Expanded))
                        return LastVisibleNode(Result);
                    else
                        return Result;
                }
                else
                    Result = Result.PrevSibling;
            }
            return Result;
        }

        internal static Node PrevVisibleNode(Node aNode)
        {
            if (aNode.PrevSibling != null)
            {
                aNode = aNode.PrevSibling;
                if (Set.Contains(aNode.State, NodeState.Visible))
                {
                    if (aNode.ChildCount > 0 && Set.Contains(aNode.State, NodeState.Expanded))
                        return LastVisibleNode(aNode);
                    return aNode;
                }
                else
                    return PrevVisibleNode(aNode);
            }
            else if (!(aNode.Parent is Root))
            {
                aNode = aNode.Parent;
                if (IsFullyVisible(aNode))
                    return aNode;
                else
                    return PrevVisibleNode(aNode);
            }
            return null;
        }

        internal static bool IsExpanded(Node aNode)
        {
            return Set.Contains(aNode.State, NodeState.Expanded);
        }

        internal static int GetNodeLevel(Node aNode)
        {
            int Result = 0;
            while (aNode != null)
            {
                Result++;
                aNode = aNode.Parent;
            }
            return Result - 1;
        }

        internal static Node NextVisibleNode(Node aNode)
        {
            if (aNode.ChildCount > 0 && Set.Contains(aNode.State, NodeState.Expanded) &&
                Set.Contains(aNode.State, NodeState.Visible))
            {
                if (aNode.FirstChild != null && Set.Contains(aNode.FirstChild.State, NodeState.Visible))
                    return aNode.FirstChild;
                return InternalNextVisibleNode(aNode.FirstChild);
            }
            else
                return InternalNextVisibleNode(aNode);
        }

        private static Node InternalNextVisibleNode(Node aNode)
        {
            Node Result;
            if (aNode == null)
                return null;
            Result = aNode.NextSibling;
            if (Result != null)
            {
                if (Set.Contains(Result.State, NodeState.Visible))
                    return Result;
                else
                    return InternalNextVisibleNode(Result);
            }
            else if (aNode.Parent != null)
            {
                return InternalNextVisibleNode(aNode.Parent);
            }
            return null;
        }

        internal static Node NextSiblingVisibleNode(Node node)
        {
            Node Result;
            if (node == null)
                return null;
            Result = node.NextSibling;
            while (Result != null)
            {
                if (Set.Contains(Result.State, NodeState.Visible))
                    return Result;
                Result = Result.NextSibling;
            }
            return null;
        }

        internal static Node NextSiblingNode(Node node)
        {
            return node.NextSibling;
        }

        internal static Node PrevSiblingNode(Node node)
        {
            return node.PrevSibling;
        }

        INode INode.Find(string aText)
        {
            throw new NotImplementedException("Find");
        }

        INode INode.Find(object aData)
        {
            throw new NotImplementedException("Find");
        }
        #endregion

        #region INodeEnumerable Members

        public IEnumerable<INode> GetNodes()
        {
            return new NodeEnumerator(this, false);
        }

        public IEnumerable<INode> GetNodes(bool recurse)
        {
            return new NodeEnumerator(this, recurse);
        }

        public IEnumerable<INode> GetVisibleNodes(bool recurse)
        {
            return new NodeEnumerator(this, recurse, true);
        }

        public static Node NextNode(Node current, Node parentNode)      
        {           
            if (current != null)            
            {               
                if (current.ChildCount > 0)                 
                    return current.FirstChild;              
                if (current.NextSibling != null)                    
                    return current.NextSibling;             
                else                
                {                   
                    do                  
                    {                       
                        current = current.Parent;
                        // We have reach the parent node, do not continue
                        if (current == parentNode)                          
                            return null;                    
                    }                   
                    while (current != null && current.NextSibling == null);                 
                    if (current != null)                        
                        current = current.NextSibling;              
                }           
            }           
            return current;     
        }

        public static Node NextNode(Node current)
        {
            return NextNode(current, null);
            //if (current != null)
            //{
            //    if (current.ChildCount > 0)
            //        return current.FirstChild;
            //    if (current.NextSibling != null)
            //        return current.NextSibling;
            //    else
            //    {
            //        do
            //        {
            //            current = current.Parent;
            //        }
            //        while (current != null && current.NextSibling == null);
            //        if (current != null)
            //            current = current.NextSibling;
            //    }
            //}
            //return current;
        }

        internal static Node LastNode(Node aParent)
        {
            Node Result = null;

            Result = aParent.LastChild;
            while (Result != null)
            {
                if (Result.ChildCount > 0)
                    return LastNode(Result);
                else
                    return Result;
            }
            return Result;
        }

        public static Node PrevNode(Node aNode)
        {
            if (aNode.PrevSibling != null)
            {
                aNode = aNode.PrevSibling;
                if (aNode.ChildCount > 0)
                    return LastNode(aNode);
                return aNode;
            }
            else if (!(aNode.Parent is Root))
            {
                aNode = aNode.Parent;
                return aNode;
            }
            return null;
        }

        #endregion

        #region méthodes publiques
        public bool Selected
        {
            get
            {
                return Set.Contains(this.State, NodeState.Selected);
            }
        }
        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return new NodeEnumerator(this, false).GetEnumerator();
        }

        #endregion
    }

    internal class Root : Node
    {
        private Nodes FTree;

        public Root(Nodes tv)
            : base()
        {
            FTree = tv;
            this.State = NodeState.Visible | NodeState.Expanded;
        }

        public Nodes Nodes
        {
            get
            {
                return FTree;
            }
        }
    }

    internal enum NodeClick
    {
        Nothing
       ,
        ExpandButton
       ,
        CheckButton
       ,
        Image
       ,
        ImageState
       ,
        Text
       ,
        Column //futur use
       ,
        Flag	//futur use
    }
}
