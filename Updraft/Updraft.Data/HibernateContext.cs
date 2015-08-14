// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HibernateContext.cs" company="">
//   
// </copyright>
// <summary>
//   Универсальный БД контекст.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;

using FluentNHibernate.Cfg;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

#endregion

namespace Updraft.Data.Settings
{
	/// <summary>
	/// Универсальный БД контекст.
	/// </summary>
	public class HibernateContext : IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HibernateContext"/> class. 
		/// Конструктор контекста.
		/// </summary>
		public HibernateContext()
		{
			_sessionFactory = CreateSessionFactory();
		}

		#region Public Properties

		/// <summary>
		/// Создание сессии для обращения к БД.
		/// </summary>
		public ISession OpenSession
		{
			get
			{
				return _session ?? (_session = _sessionFactory.OpenSession());
			}
		}

		#endregion

		/// <summary>
		/// Убиваем сессию.
		/// </summary>
		public void Dispose()
		{
			_sessionFactory.Close();
			_sessionFactory.Dispose();
		}

		/// <summary>
		/// Создание сессии, если признак первого запуска = true тогда производим контроль и приведение к формату схему БД.
		/// </summary>
		/// <returns>
		/// The <see cref="ISessionFactory"/>.
		/// </returns>
		private static ISessionFactory CreateSessionFactory()
		{
			var config = new Configuration().Configure("hibernate.cfg.xml");
			var f = Fluently.Configure(config);
			f.Mappings(m => m.FluentMappings.Add<CostMap>());

			if (_isFirstRun)
			{
				var schemaUpdate = new SchemaUpdate(config);
				f.ExposeConfiguration(
					delegate
						{
							try
							{
								schemaUpdate.Execute(false, true);
							}
							catch (Exception ex)
							{
								Logger.NLogger.Error(ex.Message);
							}
						});
				_isFirstRun = false;
			}

			return f.BuildSessionFactory();
		}

		#region PRIVATE FIELDS

		/// <summary>
		/// Признак первого запуска.
		/// </summary>
		private static bool _isFirstRun = true;

		/// <summary>
		/// Gets or sets the session factory.
		/// </summary>
		private readonly ISessionFactory _sessionFactory;

		/// <summary>
		/// Текущая сессия.
		/// </summary>
		private ISession _session;

		#endregion
	}
}