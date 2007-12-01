using System;
using System.Collections;
using System.IO;

namespace DemoTreeView.UC1
{
	public enum GroupBy {None, Name, Size, Type, Date};
	/// <summary>
	/// Summary description for VistaItem.
	/// </summary>
	public abstract class VistaItem 
	{
		protected string FText;
		public VistaItem(string aText)
		{
			FText = aText;
		}

		public abstract string Name {get;}
		public abstract DateTime Date {get;}
		public abstract string FileType {get;}

		public abstract Int64 Size { get; }
	}

	public class VistaItemFS : VistaItem
	{
		internal DateTime FDate;
		internal string FName;
		internal string FType;
		internal Int64 FSize;

		public VistaItemFS(string aText) : base(aText)
		{
			FDate = DateTime.MinValue;
			FName = null;
			FType = null;
			FSize = -1;
		}
		#region class interne
		class FSComparer : IComparer
		{
			GroupBy FSortBy;

			public FSComparer(GroupBy aSortBy)
			{
				FSortBy = aSortBy;
			}
			#region IComparer Members

			public int Compare(object x, object y)
			{
				VistaItem a = x as VistaItem;
				VistaItem b = y as VistaItem;

				switch (FSortBy)
				{
					case GroupBy.Name :
						return a.Name.CompareTo(b.Name);
					case GroupBy.Date :
						return a.Date.CompareTo(b.Date);
					case GroupBy.Type :
						return a.FileType.CompareTo(b.FileType);
				}
				return 0;
			}

			#endregion

		}

		#endregion

		public override DateTime Date
		{
			get
			{
				if (FDate == DateTime.MinValue)
					FDate = File.GetLastAccessTime(FText);
				return FDate;
			}
		}
		public override string Name
		{
			get
			{
				if (FName == null)
					FName = Path.GetFileName(FText);
				return FName;
			}
		}
		public override string FileType
		{
			get
			{
				if (FType == null)
					FType = Path.GetExtension(FText);
				return FType;
			}
		}
		public override Int64 Size 
		{ 
			get
			{
				if (FSize == -1)
				{
					FileInfo fi = new FileInfo(FText);
					FSize = fi.Length;
				}
				return FSize;
			} 
		}


		public static IEnumerable EnumereFS(string aPath, GroupBy aGroupBy)
		{
			ArrayList Result = new ArrayList();
			foreach (string sDir in Directory.GetDirectories(aPath))
			{
				Result.Add(new VistaFolder(sDir));
			}
			foreach (string sFile in Directory.GetFiles(aPath, "*.*"))
			{
				Result.Add(new VistaItemFS(sFile));
			}
			if (aGroupBy != GroupBy.None)
				GroupEnumerationBy(Result, aGroupBy);

			return Result;
		}

		private static void GroupEnumerationBy(ArrayList result, GroupBy by)
		{
			if (by == GroupBy.Name)
			{
				ArrayList a = new ArrayList();
				VistaGroup g = new VistaGroup("A-H");
				a.Add(g);
				AddToGroup(g.FChilds, by, result, "a", "i");
				g = new VistaGroup("I-P");
				a.Add(g);
				AddToGroup(g.FChilds, by, result, "i", "q");
				g = new VistaGroup("Q-Z");
				a.Add(g);
				AddToGroup(g.FChilds, by, result, "q", "z");
				g = new VistaGroup("_others");
				a.Add(g);
				g.FChilds.AddRange(result.ToArray());
				result.Clear();
				result.AddRange(a.ToArray());
			}
			else if (by == GroupBy.Type)
			{
				IDictionary dico = new Hashtable();
				foreach (VistaItemFS item in result)
				{
					string fileType = item.FileType;
					if (fileType != null && fileType.StartsWith("."))
						fileType = fileType.Substring(1);
					VistaGroup group = dico[fileType] as VistaGroup;
					if (group == null)
					{
						group = new VistaGroup(fileType);
						dico[fileType] = group;
					}
					group.FChilds.Add(item);
				}
				result.Clear();
				result.AddRange(dico.Values);
			}
		}

		private static void AddToGroup(ArrayList childs, GroupBy by, ArrayList aSrc, IComparable min, IComparable max)
		{
			if (by == GroupBy.Name)
			{
				int i = 0;
				while (i < aSrc.Count )
				{
					VistaItem aItem = aSrc[i] as VistaItem;
					string aName = aItem.Name.ToLower();
					if (aName.CompareTo(min) >= 0 && aName.CompareTo(max) < 0)
					{
						childs.Add(aItem);
						aSrc.RemoveAt(i);
						i--;
					}
					i++;
				}
			}
		}
	}

	public class VistaFolder : VistaItemFS
	{
		public VistaFolder(string aText): base (aText)
		{
			
		}

		public override string Name
		{
			get
			{
				return base.Name;
			}
		}
		public override string FileType
		{
			get
			{
				return "Folder";
			}
		}
		public override Int64 Size
		{
			get
			{
				return -1;
			}
		}

	}

	public class VistaGroup : VistaItem, IEnumerable
	{
		internal ArrayList FChilds;
		public VistaGroup(string aText) : base (aText)
		{		
			FChilds = new ArrayList();
		}



		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return FChilds.GetEnumerator();
		}

		public override string Name
		{
			get
			{
				return String.Format("{0} ({1})" , FText, FChilds.Count);
			}
		}


		public override DateTime Date
		{
			get
			{
				return DateTime.MinValue;
			}
		}

		public override string FileType
		{
			get
			{
				return FText;
			}
		}

		public override Int64 Size
		{
			get
			{
				return -1;
			}
		}


		#endregion
	}
}
