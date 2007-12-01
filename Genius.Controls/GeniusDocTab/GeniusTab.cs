using System;
#if VS2005
using System.Collections.Generic;
#endif
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Genius.Controls.DocTabs
{
	/// <summary>
	/// Tab
	/// </summary>
#if VS2003
	[DesignTimeVisible(false)]
	[ToolboxItem(false)]
#endif
	public class GeniusTab :
#if VS2003
		Component,
#endif
		IDisposable
    {
		private static Color FDefaultColor;
        private string FText;
        private Color FColor;
        private GraphicsPath FPath;
        private GraphicsPath FPathOffset;
		private object FTag;

		internal GeniusDocTab DocTabs;

		static GeniusTab()
		{
			FDefaultColor = Color.FromArgb(247, 246, 239);
		}

		/// <summary>
		/// constructeur par défaut
		/// </summary>
        public GeniusTab()
        {
            FColor = FDefaultColor;
        }

		/// <summary>
		/// Text du Doc
		/// </summary>
        public string Text
        {
            get
            {
                return FText;
            }
            set
            {
				if (FText != value)
				{
					FText = value;
					Path = null;
					if (DocTabs != null)
						DocTabs.Invalidate();
				}
            }
        }

        /// <summary>
        /// //TODO: à remplacer par GeniusBrush
        /// </summary>
        public Color Color
        {
            get { return FColor; }
            set
            {
				if (FColor != value)
				{
					FColor = value;
					if (DocTabs != null)
						DocTabs.Invalidate();
				}
            }
        }

		/// <summary>
		/// tag associé à ce tab
		/// </summary>
		public object Tag
		{
			get
			{
				return FTag;
			}
			set
			{
				FTag = value;
			}
		}

        #region internal
        internal GraphicsPath Path
        {
            get { return FPath; }
            set 
            {
                if (FPath != null)
                    FPath.Dispose();
                FPath = value;
            }
        }

        internal GraphicsPath PathOffset
        {
            get { return FPathOffset; }
            set
            {
                if (FPathOffset != null)
                    FPathOffset.Dispose();
                FPathOffset = value;
            }
        }

        internal float Width
        {
            get
            {
                if (Path != null)
                    return Path.GetBounds().Width;
                return -1;
            }
        }

        internal bool PointIsIn(int x, int y)
        {
            if (FPathOffset != null)
                return FPathOffset.IsVisible(x, y);
            return false;
        }

        #endregion

        #region IDisposable Members
		/// <summary>
		/// dispose
		/// </summary>
#if VS2003 
		new 
#endif 
		public void Dispose()
        {
            Path = null;
            PathOffset = null;
        }

        #endregion
}
}
