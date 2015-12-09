// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbCost.cs" company="">
//   
// </copyright>
// <summary>
//   The db cost.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Updraft.Data.Entity
{
	/// <summary>
	/// The db cost.
	/// </summary>
	public class DbCost
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		[Key]
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
	}
}