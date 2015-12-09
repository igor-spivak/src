// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetStorage.cs" company="">
//   
// </copyright>
// <summary>
//   The storage context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

#endregion

namespace Updraft.Data.Entity
{
	/// <summary>
	/// The storage context.
	/// </summary>
	public sealed class BudgetStorage : DbContext
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="BudgetStorage"/>.
		/// </summary>
		public BudgetStorage()
			: base(
				new SQLiteConnection
					{
						ConnectionString =
							new SQLiteConnectionStringBuilder
								{
									// Избегаем блокировок одновременного чтения разными потоками, чтения и записи.
									// Уровень изоляции, позволяющий читать во время записи.
									// Нет такого параметра в строке соединения.
									DefaultIsolationLevel = IsolationLevel.ReadUncommitted, 
									JournalMode = SQLiteJournalModeEnum.Wal, 
									SyncMode = SynchronizationModes.Normal, 

									// Возможность обновлять данные для таблиц с первичным ключом guid-типа.
									BinaryGUID = false, 

									// #if DEBUG
									// 						ConnectionString = "Data Source=C:\\EDI_Connectors\\Korus\\Storage.sqlite3;"
									// #else
									// TODO: Дублирование кода. Оставить 1 вариант.
									// ConnectionString = "Data Source=C:\\EDI_Connectors\\Korus\\Storage.sqlite3;Synchronous=Normal;Journal Mode=WAL;BinaryGUID=False;"
									ConnectionString =
										$"Data Source={AppDomain.CurrentDomain.BaseDirectory}Storage.sqlite;Synchronous=Normal;Journal Mode=WAL;BinaryGUID=False;"

									// #endif
								}.ConnectionString
					}, 
				true)
		{
			Database.SetInitializer<BudgetStorage>(null);
		}

		/// <summary>
		/// Gets or sets the en company sets.
		/// </summary>
		public DbSet<DbCost> Costs { get; set; }

		/// <summary>
		/// Gets or sets the en document title sets.
		/// </summary>
		public DbSet<DbTarget> Targets { get; set; }

		/// <summary>
		/// Gets or sets the en user sets.
		/// </summary>
		public DbSet<DbUser> Users { get; set; }

		/// <summary>
		/// Получить возможность использования ObjectContext.
		/// </summary>
		private ObjectContext ThisObjectContext => ((IObjectContextAdapter)this).ObjectContext;

		/// <summary>
		/// The on model creating.
		/// </summary>
		/// <param name="modelBuilder">
		/// The model builder.
		/// </param>
		/// <exception cref="UnintentionalCodeFirstException">
		/// </exception>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

			modelBuilder.Entity<DbCost>().ToTable("Costs");
			modelBuilder.Entity<DbTarget>().ToTable("Targets");
			modelBuilder.Entity<DbUser>().ToTable("Users");
		}

		/// <summary>
		/// </summary>
		/// <param name="entry">
		/// </param>
		public void Detach(object entry)
		{
			ThisObjectContext.Detach(entry);
		}

		/// <summary>
		/// Вернуть строку соединения.
		/// </summary>
		/// <returns>Строка соединения с БД</returns>
		public string GetConnectionString()
		{
			return Database?.Connection?.ConnectionString;
		}
	}
}