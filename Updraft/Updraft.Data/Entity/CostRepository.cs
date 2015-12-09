using System;
using System.Linq;

namespace Updraft.Data.Entity
{
	public class CostRepository : Repository
	{
		/// <summary>
		/// Объект блокировки доступа к таблице.
		/// </summary>
		private static object _locker = new object();

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="CostRepository"/>.
		/// </summary>
		public CostRepository() : base(new BudgetStorage())
		{
		}

		/// <summary>
		/// Проверка доступности всех таблиц в базе. Нестрогая проверка на соотвествие нужной структуре.
		/// </summary>
		/// <returns></returns>
		public bool CheckDatabaseAccessibility()
		{
			var result = false;
			try
			{
				var anyCost = Context.Costs.FirstOrDefault();
				var anyUser = Context.Users.FirstOrDefault();
				var anyTarget = Context.Targets.FirstOrDefault();

				result = anyCost != null || anyUser != null || anyTarget != null;
			}
			catch (Exception e)
			{
				Logger.NLogger.Error(e);
			}
			return result;
		}
	}
}