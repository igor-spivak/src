// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cost.cs" company="">
//   
// </copyright>
// <summary>
//   The cost.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;

#endregion

namespace Updraft.Data.NHibernate
{
	/// <summary>
	/// Сущность трата.
	/// </summary>
	public class Cost
	{
		#region Properties

		/// <summary>
		/// Идентификатор траты.
		/// </summary>
		public virtual Guid Id { get; set; }

		/// <summary>
		/// Дополнительное описание.
		/// </summary>
		public virtual string Description { get; set; }

		/// <summary>
		/// Категория.
		/// </summary>
		public virtual string Category { get; set; }

		/// <summary>
		/// Сумма.
		/// </summary>
		public virtual int Amount { get; set; }

		/// <summary>
		/// Дата совершения.
		/// </summary>
		public virtual DateTime Timestamp { get; set; }

		/// <summary>
		/// Кто совершил трату.
		/// </summary>
		public virtual string Account { get; set; }

		#endregion
	}
}