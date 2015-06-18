using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Updraft.Data;

namespace Updraft.Test
{
    [TestClass]
    public class UnitTest1
    {
        internal TestAnything Target { get; private set; }
        [TestInitialize]
        internal void Init()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {

            Target = new TestAnything();
            var testParam = "initial";
            var s = Target.GetSomeStr(testParam);

        }

        [TestMethod]
        public void MethodToExamine()
        {
            Target = new TestAnything();
            var myP = new Point(10, 10) { Name = "initial" };

            Target.TryModifyParam2(myP);

        }

        [TestMethod]
        public void MethodToExamine2()
        {
            Target = new TestAnything();
            var myP = new Point(10, 10) { Name = "initial" };

            Target.TryModifyParam3(ref myP);

        }

        public static Func<int> Natural()
        {
            return () =>
            {
                int seed = 0;
                int result = seed++;
                return result;
            };
        }

        [TestMethod]
        public void TestDelegates()
        {
            Func<int> natural = Natural();
            int z1 = natural();
            Console.WriteLine(z1);

            int z2 = natural();
            Console.WriteLine(z2);
        }
    }
}
