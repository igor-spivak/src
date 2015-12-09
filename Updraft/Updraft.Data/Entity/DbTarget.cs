// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbTarget.cs" company="">
//   
// </copyright>
// <summary>
//   The db target.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Updraft.Data.Entity
{
	/// <summary>
	/// The db target.
	/// </summary>
	public class DbTarget
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		[Key]
		public byte Id { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the category.
		/// </summary>
		public string Category { get; set; }
	}
}