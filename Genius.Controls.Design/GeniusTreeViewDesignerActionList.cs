using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel;
using Genius.Controls.TreeView;
using System.Windows.Forms;

namespace Genius.Controls.Design
{
    /// <summary>
    /// inspiré de http://msdn.microsoft.com/msdnmag/issues/05/07/DesignerActions/default.aspx
    /// </summary>
    internal class GeniusTreeViewDesignerActionList : DesignerActionList
    {
        public GeniusTreeViewDesignerActionList(IComponent component)
            : base(component)
        {
            this.AutoShow = true;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            // Create list to store designer action items
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();
            // Dock/Undock designer action method item
            actionItems.Add(
              new DesignerActionMethodItem(
                this,
                "ToggleDockStyle",
                GetDockStyleText(),
                "Design",
                "Dock or undock this control in it's parent container.",
                true));
            actionItems.Add(  new DesignerActionTextItem("Header", "Header"));

           actionItems.Add(
              new DesignerActionPropertyItem("UseColumns", "UseColumns", "Header"));

            actionItems.Add(
              new DesignerActionPropertyItem("ShowHeader", "ShowHeader", "Header"));
            
            actionItems.Add(
              new DesignerActionPropertyItem("HeaderHeight", "HeaderHeight", "Header"));

            actionItems.Add(
              new DesignerActionTextItem("Images", "Images"));
            actionItems.Add(
              new DesignerActionPropertyItem("ImageList", "ImageList", "Images"));
            actionItems.Add(
              new DesignerActionPropertyItem("ImageStateList", "ImageStateList", "Images"));
            return actionItems;
        }

        /// <summary>
        /// utilise par DesignerActionMethodItem(...,"ToggleDockStyle", ...)
        /// </summary>
        public void ToggleDockStyle()
        {
            if (this.TreeView.Dock != DockStyle.Fill)
            {
                SetProperty("Dock", DockStyle.Fill);
            }
            else
            {
                SetProperty("Dock", DockStyle.None);
            }
        }

        public bool UseColumns
        {
            get
            {
                return GetProperty<bool>("UseColumns");
            }
            set
            {
                SetProperty("UseColumns", value);
            }
        }

        public bool ShowHeader
        {
            get
            {
                return GetProperty<bool>("ShowHeader");
            }
            set
            {
                SetProperty("ShowHeader", value);
            }
        }

        public ImageList ImageList
        {
            get
            {
                return GetProperty<ImageList>("ImageList");
            }
            set
            {
                SetProperty("ImageList", value);
            }
        }

        public ImageList ImageStateList
        {
            get
            {
                return GetProperty<ImageList>("ImageStateList");
            }
            set
            {
                SetProperty("ImageStateList", value);
            }
        }

        public int HeaderHeight
        {
            get
            {
                return GetProperty<int>("HeaderHeight");
            }
            set
            {
                SetProperty("HeaderHeight", value);
            }
        }

        private void SetProperty(string propertyName, object value)
        {
            PropertyDescriptor property = TypeDescriptor.GetProperties(this.Component)[propertyName];
            property.SetValue(this.Component, value);
        }

        private T GetProperty<T>(string propertyName)
        {
            PropertyDescriptor property = TypeDescriptor.GetProperties(this.Component)[propertyName];
            return (T)property.GetValue(this.Component);
        }

        private string GetDockStyleText()
        {
            if (this.TreeView.Dock == DockStyle.Fill)
            {
                return "Undock in parent container";
            }
            else
            {
                return "Dock in parent container";
            }
        }

        private Control TreeView
        {
            get { return (Control)this.Component; }
        }

        private GeniusTreeViewDesigner Designer
        {
            get
            {
                IDesignerHost designerHost = (IDesignerHost)this.TreeView.Site.Container;
                return (GeniusTreeViewDesigner)designerHost.GetDesigner(this.TreeView);
            }
        }

    }
}
