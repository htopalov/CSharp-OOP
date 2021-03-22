using NUnit.Framework;
using Database;
using System;
using System.Reflection;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        private int[] param;
        [SetUp]
        public void Setup()
        {
            this.param = new int[] { 1, 4 };
            this.database = new Database(param);
        }
        [Test]
        public void Test_If_Constructor_Works()
        {
            Assert.IsNotNull(database);
        }
        [Test]
        public void Test_Count()
        {
            Assert.AreEqual(database.Count, 2);
        }
        [Test]
        public void Test_If_Add_Works_Correctly()
        {
            database.Add(5);
            Assert.AreEqual(database.Count, 3);
        }
        [Test]
        public void Test_If_Add_Throws_Exception_When_Exceeding_Capacity()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    database.Add(i);
                }
            });
            Assert.AreEqual(ex.Message, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void Test_If_Remove_Works_Correctly()
        {
            database.Remove();
            Assert.AreEqual(database.Count, 1);
        }
        [Test]
        public void Test_If_Remove_Throws_Exception_When_DB_Is_Empty()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    database.Remove();
                }
            });
            Assert.AreEqual(ex.Message, "The collection is empty!");
        }
        [Test]
        public void Test_If_Fetch_Wokrs_Correctly()
        {
            int[] returnArray = database.Fetch();
            Assert.AreEqual(database.Count, returnArray.Length);
        }

    }
}