using System;
using System.Runtime.InteropServices;

namespace Genius.Controls.Diagnostics
{
	/// <summary>
	/// classe pour effectuer des mesures de performances
	/// </summary>
	public class Counter
	{
		private Int64 FDebut;
		private Int64 FFin;
		private Int64 FFreq;

		[DllImport("kernel32.dll")]
		static extern bool QueryPerformanceCounter(ref Int64 counter);
		[DllImport("kernel32.dll")]
		static extern bool QueryPerformanceFrequency(ref Int64 lpFrequency);

		/// <summary>
		/// constructeur par défaut
		/// </summary>
		public Counter()
		{
		}

		/// <summary>
		/// demarre le compteur
		/// </summary>
		public void Start()
		{
			QueryPerformanceFrequency(ref FFreq);
			QueryPerformanceCounter(ref FDebut);
		}

		/// <summary>
		/// stoppe le compteur
		/// </summary>
		public void Stop()
		{
			QueryPerformanceCounter(ref FFin);			
		}

		/// <summary>
		/// renvoi le temps en ms
		/// </summary>
		/// <returns></returns>
		public Int64 Elapse()
		{
			return ((FFin - FDebut)*1000) / FFreq;	
		}

		/// <summary>
		/// renvoi le temps en ms avec des decimales
		/// </summary>
		/// <returns></returns>
		public double ElapseD()
		{
			return (((FFin - FDebut)*100000) / FFreq) / 100.0;	
		}
	}
}
