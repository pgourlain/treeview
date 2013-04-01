using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Genius.Controls.Diagnostics
{
	/// <summary>
	/// classe pour effectuer des mesures de performances
	/// </summary>
	public class Counter
	{
        Stopwatch watch;

		/// <summary>
		/// constructeur par défaut
		/// </summary>
		public Counter()
		{
            watch = new Stopwatch();
		}

		/// <summary>
		/// demarre le compteur
		/// </summary>
		public void Start()
		{
            watch.Start();
		}

		/// <summary>
		/// stoppe le compteur
		/// </summary>
		public void Stop()
		{
            watch.Stop();
		}

		/// <summary>
		/// renvoi le temps en ms
		/// </summary>
		/// <returns></returns>
		public Int64 Elapse()
		{
            return watch.ElapsedMilliseconds;
		}

		/// <summary>
		/// renvoi le temps en ms avec des decimales
		/// </summary>
		/// <returns></returns>
		public double ElapseD()
		{
            return watch.ElapsedMilliseconds;
		}
	}
}
