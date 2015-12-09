using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Updraft.Data.Entity;

namespace Updraft.Logic
{
	public class Cost
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		public long Value { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the target id.
		/// </summary>
		public byte TargetId { get; set; }

		/// <summary>
		/// Gets or sets the user id.
		/// </summary>
		public byte UserId { get; set; }

		/// <summary>
		/// Возвращает трату для объекта из базы.
		/// </summary>
		/// <param name="cost"></param>
		/// <returns></returns>
		public static Cost CreateFromEntity(DbCost cost)
		{
			return new Cost
			{
				Id = cost.Id,
				Value = cost.Value,
				Description = cost.Description,
				UserId = cost.UserId,
				TargetId = cost.TargetId
			};
		}
	}
}
