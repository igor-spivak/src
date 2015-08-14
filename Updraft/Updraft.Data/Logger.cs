// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="">
//   
// </copyright>
// <summary>
//   The logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using NLog;

#endregion

namespace Updraft.Data
{
	/// <summary>
	/// The logger.
	/// </summary>
	public class Logger
	{
		/// <summary>
		/// The n logger.
		/// </summary>
		public static NLog.Logger NLogger = LogManager.GetCurrentClassLogger();
	}
}