using System;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using Genius.Controls.GeniusTab;

namespace Genius.Controls.Design
{
	/// <summary>
	/// Summary description for HorizontalTabDesigner.
	/// </summary>
	public class HorizontalTabDesigner : ParentControlDesigner
	{
		private DesignerVerb removeVerb;
		private DesignerVerbCollection verbs;

		public HorizontalTabDesigner()
		{
		}
		#region méthodes privées
		private void OnRemove(object sender, EventArgs eevent)
		{
			HorizontalTabs tabs = (HorizontalTabs) base.Component;
			if ((tabs == null) || (tabs.Tabs.Count == 0))
			{
				return;
			}
			MemberDescriptor descriptor1 = TypeDescriptor.GetProperties(base.Component)["Controls"];
			HorizontalTab page1 = tabs.SelectedTab;
			IDesignerHost host1 = (IDesignerHost) this.GetService(typeof(IDesignerHost));
			if (host1 == null)
			{
				return;
			}
			DesignerTransaction transaction1 = null;
			try
			{
				try
				{
					transaction1 = host1.CreateTransaction("RemoveTabTransaction");
					base.RaiseComponentChanging(descriptor1);
				}
				catch (CheckoutException exception1)
				{
					if (exception1 != CheckoutException.Canceled)
					{
						throw exception1;
					}
					return;
				}
				host1.DestroyComponent(page1);
				base.RaiseComponentChanged(descriptor1, null, null);
			}
			finally
			{
				if (transaction1 != null)
				{
					transaction1.Commit();
				}
			}
		}
		private void OnAdd(object sender, EventArgs eevent)
		{
			HorizontalTabs tabs = (HorizontalTabs) base.Component;
			MemberDescriptor descriptor1 = TypeDescriptor.GetProperties(base.Component)["Controls"];
			IDesignerHost host1 = (IDesignerHost) this.GetService(typeof(IDesignerHost));
			if (host1 == null)
			{
				return;
			}
			DesignerTransaction transaction1 = null;
			try
			{
				try
				{
					transaction1 = host1.CreateTransaction("AddTabTransaction");
					base.RaiseComponentChanging(descriptor1);
				}
				catch (CheckoutException exception1)
				{
					if (exception1 != CheckoutException.Canceled)
					{
						throw exception1;
					}
					return;
				}
				HorizontalTab page1 = (HorizontalTab) host1.CreateComponent(typeof(HorizontalTab));
				string text1 = null;
				PropertyDescriptor descriptor2 = TypeDescriptor.GetProperties(page1)["Name"];
				if ((descriptor2 != null) && (descriptor2.PropertyType == typeof(string)))
				{
					text1 = (string) descriptor2.GetValue(page1);
				}
				if (text1 != null)
				{
					page1.Text = text1;
				}
				tabs.Controls.Add(page1);
				base.RaiseComponentChanged(descriptor1, null, null);
			}
			finally
			{
				if (transaction1 != null)
				{
					transaction1.Commit();
				}
			}
		}
		#endregion

		public override bool CanParent(System.Windows.Forms.Control control)
		{
			System.Windows.Forms.MessageBox.Show(control.ToString());
			return (control is HorizontalTab);
		}

		public override DesignerVerbCollection Verbs
		{
			get
			{
				if (this.verbs == null)
				{
					this.removeVerb = new DesignerVerb("Remove Tab", new EventHandler(this.OnRemove));
					this.verbs = new DesignerVerbCollection();
					this.verbs.Add(new DesignerVerb("Add Tab", new EventHandler(this.OnAdd)));
					this.verbs.Add(this.removeVerb);
				}
				this.removeVerb.Enabled = this.Control.Controls.Count > 0;
				return this.verbs;
			}
		}
		protected override bool GetHitTest(System.Drawing.Point point)
		{
			ISelectionService selection = (ISelectionService) this.GetService(typeof(ISelectionService));
			if (selection != null && selection.SelectionCount == 1 && selection.GetComponentSelected(this.Component))
			{
				HorizontalTabs tabs =  this.Component as HorizontalTabs;
				if (tabs != null)
				{
					point = tabs.PointToClient(point);
					return tabs.GetTabOnPoint(point) != null;
				}
			}
			return base.GetHitTest (point);
		}

	}
}
