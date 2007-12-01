using System;
using System.Collections;
using System.Windows.Forms;

namespace Genius.Controls.TreeView
{
	enum KindTimer {Edit = 0, DragExpand, Scroll, Search, Hint}
	/// <summary>
	/// class de gestion des timers
	/// </summary>
	class Timers
	{
		private IDictionary FTimers;
		private IDictionary FTimersData;
		/// <summary>
		/// constructeur
		/// </summary>
		public Timers()
		{
			FTimers = new System.Collections.Specialized.HybridDictionary();
			FTimersData = new System.Collections.Specialized.HybridDictionary();
			foreach (string kind in Enum.GetNames(typeof(KindTimer)))
			{
				FTimers[kind] = new Timer();
				((Timer)FTimers[kind]).Interval = 700;
			}
			Timer(KindTimer.Search).Interval = 1500;
			Timer(KindTimer.Hint).Interval = 500;
		}

		/// <summary>
		/// renvoi un timer pour un <see cref="KindTimer"/>
		/// </summary>
		/// <param name="aKind"></param>
		/// <returns></returns>
		private Timer Timer(KindTimer aKind)
		{
			return ((Timer)FTimers[aKind.ToString()]);
		}
		
		private void SetTimerData(KindTimer timer, object aData)
		{
			FTimersData[timer.ToString()] = aData;			
		}

		public int this[KindTimer aKind]
		{
			get
			{
				return Timer(aKind).Interval;
			}
			set
			{
				Timer(aKind).Interval = value;
			}
		}

		/// <summary>
		/// démarre un timer de type <see cref="KindTimer"/>
		/// </summary>
		/// <param name="aTimer"></param>
		public void Start(KindTimer aTimer)
		{
			Start(aTimer, null);
		}

		public void Start(KindTimer aTimer, object aUserData)
		{
			if (!Timer(aTimer).Enabled)
			{
				System.Diagnostics.Debug.WriteLine("StartTimer :" + aTimer.ToString());
				SetTimerData(aTimer, aUserData);
				Timer(aTimer).Start();
			}
			else
				System.Diagnostics.Debug.WriteLine(" Timer :" + aTimer.ToString() + " already started !");
		}

		/// <summary>
		/// arrête un Timer de type <see cref="KindTimer"/>
		/// </summary>
		/// <param name="aTimer"></param>
		public void Stop(KindTimer aTimer)
		{
			SetTimerData(aTimer, null);
			Timer(aTimer).Stop();
			//System.Diagnostics.Debug.WriteLine("StopTimer :" + aTimer.ToString());
		}

		/// <summary>
		/// arrête tous les timers
		/// </summary>
		public void StopAll()
		{
			foreach (string kind in Enum.GetNames(typeof(KindTimer)))
			{
				FTimersData[kind] = null;
				((Timer)FTimers[kind]).Stop();
			}
		}

		public object GetTimerData(KindTimer aKind)
		{
			return FTimersData[aKind.ToString()];
		}

		public bool IsStarted(KindTimer aKind)
		{
			return Timer(aKind).Enabled;
		}

		/// <summary>
		/// begin edit demander
		/// </summary>
		public event EventHandler OnBeginEdit
		{
			add
			{
				Timer(KindTimer.Edit).Tick += value;
			}
			remove
			{
				Timer(KindTimer.Edit).Tick -= value;
			}
		}

		/// <summary>
		/// expand pendant le drag
		/// </summary>
		public event EventHandler OnBeginDragExpand
		{
			add
			{
				Timer(KindTimer.DragExpand).Tick += value;
			}
			remove
			{
				Timer(KindTimer.DragExpand).Tick -= value;
			}
		}

		/// <summary>
		/// begin scroll demander
		/// </summary>
		public event EventHandler OnBeginScroll
		{
			add
			{
				Timer(KindTimer.Scroll).Tick += value;
			}
			remove
			{
				Timer(KindTimer.Scroll).Tick -= value;
			}
		}

		/// <summary>
		/// endsearch demander
		/// </summary>
		public event EventHandler OnEndSearch
		{
			add
			{
				Timer(KindTimer.Search).Tick += value;				
			}
			remove
			{
				Timer(KindTimer.Search).Tick -= value;								
			}
		}

		/// <summary>
		/// begin hint demander
		/// </summary>
		public event EventHandler OnBeginHint
		{
			add
			{
				Timer(KindTimer.Hint).Tick += value;
			}
			remove
			{
				Timer(KindTimer.Hint).Tick -= value;				
			}
		}

	}
}
