using NUnit.Framework;
//using ExtendedDatabase;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            people = new Person[]
            {
                new Person(13212,"Ivan"),
                new Person(56456,"Pesho"),
                new Person(56478,"Dragan")
            };
            database = new ExtendedDatabase(people);
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            Assert.IsNotNull(database);
        }
        [Test]
        public void Test_If_Count_Is_Correct()
        {
            Assert.AreEqual(database.Count, 3);
        }
        [Test]
        public void Test_If_Add_Works_Correctly()
        {
            Person person = new Person(7890867, "Vlado");
            database.Add(person);
            Assert.AreEqual(database.Count, 4);
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_When_Adding_More_People_Than_Capacity()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    database.Add(new Person(243 + i, $"{i}Jordan"));
                }
            });
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_When_Adding_Person_With_Same_Name()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(1234, "Grozdan"));
                database.Add(new Person(143534, "Grozdan"));
            });
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_When_Adding_Person_With_Same_Id()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(1234, "Grozdan"));
                database.Add(new Person(1234, "Pavkata"));
            });
        }
        [Test]
        public void Test_If_Remove_Works_Correctly()
        {
            database.Remove();
            Assert.AreEqual(database.Count, 2);
        }
        [Test]
        public void Test_If_Remove_Throws_Exception_When_DB_Empty()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    database.Remove();
                }
            });
        }
        [Test]
        public void Test_If_Find_By_Username_Works_Correctly()
        {
            var person = database.FindByUsername("Ivan");
            Assert.IsNotNull(person);
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_If__Username_Is_Null_Or_Empty()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
             {
                 database.FindByUsername(null);
                 database.FindByUsername(string.Empty);
                 database.FindByUsername("     ");
             });
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_When_Username_Missing_In_DB()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Kiro");
            });
        }
        [Test]
        public void Test_If_Find_By_Id_Works_Correctly()
        {
            var person = database.FindById(13212);
            Assert.IsNotNull(person);
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_Negative_Id()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var person = database.FindById(-214);
            });
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_When_Id_Missing_In_DB()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(23534675);
            });
        }
        [Test]
        public void Test_If_Constructor_Throws_Exception()
        {
            var persons = new Person[20];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"name{i}");
            }
            Assert.Throws<ArgumentException>(() =>
            {
                this.database = new ExtendedDatabase(persons);
            });
        }
    }
}