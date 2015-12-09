using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Updraft.Data.Entity
{
	/// <summary>
	/// Класс для доступа к таблице Users.
	/// </summary>
	public class UserRepository : Repository
	{
		/// <summary>
		/// Объект блокировки доступа к таблице.
		/// </summary>
		private static object _locker = new object();

		/// <summary>
		/// Строка соединения.
		/// </summary>
		public string Connection => Context?.GetConnectionString();

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="UserRepository"/>.
		/// </summary>
		public UserRepository() : base(new BudgetStorage())
		{
		}

		/// <summary>
		/// Получить всех пользователей.
		/// </summary>
		/// <returns>Все пользователи таблицы.</returns>
		public IEnumerable<DbUser> AllUsers()
		{
			return GetUsers();
		}

		/// <summary>
		/// Добавить сущность, если её нет.
		/// </summary>
		/// <param name="user">Сущность для добавления.</param>
		public void AddIfNotExist(DbUser user)
		{
			lock (_locker)
			{
				try
				{
					var exist = GetUsers().Any(s => s.Id.Equals(user.Id));
					if (!exist)
					{
						using (var scope = new TransactionScope(
							TransactionScopeOption.Suppress,
							new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
						{
							Context.Users.Add(user);
							SaveChanges();
							scope.Complete();
						}
					}
				}
				catch (Exception e)
				{
					Logger.NLogger.Error(e);
				}
			}
		}

		/// <summary>
		/// Обновить сущность, если она существует.
		/// </summary>
		/// <param name="user">Сущность для обновления.</param>
		public void UpdateIfExist(DbUser user)
		{
			lock (_locker)
			{
				try
				{
					var existed = GetUsers().FirstOrDefault(s => s.Id.Equals(user.Id));
					if (existed != null)
					{
						using (var scope = new TransactionScope(
							TransactionScopeOption.Suppress,
							new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
						{
							Context.Users.Add(user);

							SaveChanges();
							scope.Complete();
						}
					}
				}
				catch (Exception e)
				{
					Logger.NLogger.Error(e);
				}
			}
		}

		/// <summary>
		/// Получить всех пользователей.
		/// </summary>
		/// <returns>
		/// Множество всех пользвателей типа <see cref="T:IEnumerable"/>.
		/// </returns>
		private IEnumerable<DbUser> GetUsers()
		{
			lock (_locker)
			{
				try
				{
					return from a in Context.Users select a;
				}
				catch (Exception e)
				{
					Logger.NLogger.Error(e);
					return new List<DbUser>();
				}
			}
		}

		
	}
}