// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataLayerTests.cs" company="">
//   
// </copyright>
// <summary>
//   The data layer tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Updraft.Data;

#endregion

namespace Updraft.Test
{
	/// <summary>
	/// The data layer tests.
	/// </summary>
	[TestClass]
	public class DataLayerTests
	{
		/// <summary>
		/// Gets the target.
		/// </summary>
		internal TestAnything Target { get; private set; }

		/// <summary>
		/// The init.
		/// </summary>
		[TestInitialize]
		internal void Init()
		{
		}

		[TestMethod]
		public void GetCostsTest()
		{
			using (var target = new DataStorage())
			{
				var costs = target.GetCosts();

				Assert.IsNotNull(costs);
				Assert.IsTrue(costs.Count > 0);
			}
		}

		/// <summary>
		/// The test method 1.
		/// </summary>
		[TestMethod]
		public void TestMethod1()
		{
			Target = new TestAnything();
			var testParam = "initial";
			var s = Target.GetSomeStr(testParam);
		}

		/// <summary>
		/// The method to examine.
		/// </summary>
		[TestMethod]
		public void MethodToExamine()
		{
			Target = new TestAnything();
			var myP = new Point(10, 10) { Name = "initial" };

			Target.TryModifyParam2(myP);
		}

		/// <summary>
		/// The method to examine 2.
		/// </summary>
		[TestMethod]
		public void MethodToExamine2()
		{
			Target = new TestAnything();
			var myP = new Point(10, 10) { Name = "initial" };

			Target.TryModifyParam3(ref myP);
		}

		/// <summary>
		/// The natural.
		/// </summary>
		/// <returns>
		/// The <see cref="Func"/>.
		/// </returns>
		public static Func<int> Natural()
		{
			return () =>
				{
					var seed = 0;
					var result = seed++;
					return result;
				};
		}

		/// <summary>
		/// The test delegates.
		/// </summary>
		[TestMethod]
		public void TestDelegates()
		{
			var natural = Natural();
			var z1 = natural();
			Console.WriteLine(z1);

			var z2 = natural();
			Console.WriteLine(z2);
		}
	}
}