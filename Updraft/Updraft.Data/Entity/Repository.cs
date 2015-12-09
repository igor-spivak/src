using System;

namespace Updraft.Data.Entity
{
	/// <summary>
	/// The repository.
	/// </summary>
	public class Repository : IDisposable
	{
		/// <summary>
		/// The Context.
		/// </summary>
		protected readonly BudgetStorage Context;

		/// <summary>
		/// The disposed.
		/// </summary>
		private bool disposed;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="Repository"/>.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		public Repository(BudgetStorage context)
		{
			Context = context;
		}

		/// <summary>
		/// The dispose.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// The dispose.
		/// </summary>
		/// <param name="disposing">
		/// The disposing.
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Context.Dispose();
				}
			}

			disposed = true;
		}

		/// <summary>
		/// The save changes.
		/// </summary>
		public void SaveChanges()
		{
			Context.SaveChanges();
		}
	}
}
