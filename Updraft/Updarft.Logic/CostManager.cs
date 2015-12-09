// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CostManager.cs" company="">
//   
// </copyright>
// <summary>
//   The cost manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using Updraft.Data.Entity;

namespace Updarft.Logic
{
	/// <summary>
	/// The cost manager.
	/// </summary>
	public class CostManager
	{
		public void GetDataFromDb()
		{
			var result = new List<DbUser>();

			using (var db = new UserRepository())
			{
				result = db.AllUsers().ToList();
			}
		}
	}
}