using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;

namespace Genius.Controls.Design
{
    public class GeniusTreeViewDesigner : ControlDesigner
    {
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // Create action list collection
                DesignerActionListCollection actionLists = new DesignerActionListCollection();

                // Add custom action list
                actionLists.Add(new GeniusTreeViewDesignerActionList(this.Component));

                // Return to the designer action service
                return actionLists;
            }
        }
    }
}
