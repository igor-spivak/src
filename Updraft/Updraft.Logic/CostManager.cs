// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CostManager.cs" company="">
//   
// </copyright>
// <summary>
//   The cost manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using Updraft.Data.Entity;

#endregion

namespace Updraft.Logic
{
	/// <summary>
	/// The cost manager.
	/// </summary>
	public class CostManager
	{
		/// <summary>
		/// The get data.
		/// </summary>
		public void GetData()
		{
			var flag = false;
			using (var db = new CostRepository())
			{
				flag = db.CheckDatabaseAccessibility();
			}
		}
	}
}