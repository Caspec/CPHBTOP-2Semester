using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ListX listEmpty;
        private ListX listFilled;

       public void SetUp()
        {
            listEmpty = new ListX();
            listFilled = new ListX();

            listFilled.Add("add1");
            listFilled.Add("add2");
            listFilled.Add("add3");
            listFilled.Add("add4");
            listFilled.Add("add5");
        }

        // Test for 5 in total length
        [TestMethod]
        public void TestLength5()
        {
            SetUp();

            Assert.AreEqual(5, listFilled.Length());
        }

        // Test for listEmpty is empty
        [TestMethod]
        public void TestLengthEmpty()
        {
            SetUp();

            Assert.AreEqual(0, listEmpty.Length());
        }

        // Test for listFilled with add 1 to it
        [TestMethod]
        public void TestAdd1()
        {
            SetUp();

            listFilled.Add("add6");

            Assert.AreEqual(6, listFilled.Length());
        }

        // Test for listFilled with add within an index
        [TestMethod]
        public void TestAddWithIndex()
        {
            SetUp();
            listFilled.Add(1, "add6");
            Assert.AreEqual("add6", listFilled.Get(1));
        }

        // Test for listFilled remove one
        [TestMethod]
        public void TestRemoveOne()
        {
            SetUp();
            listFilled.Remove(0);
            Assert.AreEqual(4, listFilled.Length());
        }

        // Test for listFilled with add within an index
        [TestMethod]
        public void TestGet()
        {
            SetUp();
            Assert.AreEqual("add1", listFilled.Get(0));
        }

        [TestMethod]
        public void TestConstructor()
        {
            ListX x = new ListX();
            Assert.AreEqual(x, x);
        }

        [TestMethod]
        public void TestLength()
        {
            ListX x = new ListX();
            var length = x.Length();
            Assert.AreEqual(0, length);
        }

        [TestMethod]
        public void TestAdd()
        {
            ListX x = new ListX();

    
        }
    }
}
