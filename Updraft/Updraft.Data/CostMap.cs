using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;

namespace Updraft.Data
{

	public class CostMap : ClassMap<Cost>
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса.
		/// </summary>
		public CostMap()
		{
			Id(x => x.Id);
			//Id(x => x.Id).GeneratedBy.Custom<CustomIdentityGenerator>(p => p.AddParam("Id", Guid.NewGuid()));
			Map(x => x.Description).Length(50);
			Map(x => x.Category).Length(30);
			Map(x => x.Amount).Not.Nullable();
			Map(x => x.Timestamp).Not.Nullable();
			Map(x => x.Account).Length(10);
		}
	}
}
