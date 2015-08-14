// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataStorage.cs" company="">
//   
// </copyright>
// <summary>
//   The class DataStorage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;


using Updraft.Data.Settings;


namespace Updraft.Data
{
	/// <summary>
	/// The class DataStorage.
	/// </summary>
	internal class DataStorage : IDisposable
	{
		private readonly HibernateContext DataContext;
		/// <summary>
		/// Initializes a new instance of the <see cref="T:DataStorage"/> class.
		/// </summary>
		public DataStorage()
		{
			Logger.NLogger.Info("Ctor of {0}", typeof(DataStorage));

			DataContext = new HibernateContext();
		}

		internal List<Cost> GetCosts()
		{
			return DataContext.OpenSession.QueryOver<Cost>().Where(s => s.Id != null).List<Cost>().ToList();
		}

		public void Dispose()
		{
			DataContext.Dispose();
		}
	}
}