// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbUser.cs" company="">
//   
// </copyright>
// <summary>
//   The db user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Updraft.Data.Entity
{
	/// <summary>
	/// The db user.
	/// </summary>
	public class DbUser
	{
		/// <summary>
		/// Gets or sets the oedo id.
		/// </summary>
		[Key]
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the watcher last event id.
		/// </summary>
		public string Name { get; set; }
	}
}