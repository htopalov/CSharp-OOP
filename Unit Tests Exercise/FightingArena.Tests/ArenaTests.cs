using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.IsNotNull(arena);
        }
        [Test]
        public void Arena_Count_Correct()
        {
            Assert.AreEqual(arena.Warriors.Count, arena.Count);
        }
        [Test]
        public void Test_Enrolling_Works_Correctly()
        {
            arena.Enroll(new Warrior("Ivan", 12, 100));
            Assert.That(arena.Count, Is.EqualTo(1));
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_When_Enrolling_Warrior_Second_Time()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var firstWarrior = new Warrior("Stamat", 10, 100);
                arena.Enroll(firstWarrior);
                var secondWarrior = new Warrior("Stamat", 12, 13);
                arena.Enroll(secondWarrior);
            });
            Assert.AreEqual(ex.Message, "Warrior is already enrolled for the fights!");
        }
        [Test]
        public void Test_Attack_Works_Correctly()
        {
            var firstWarrior = new Warrior("Kolio", 10, 100);
            arena.Enroll(firstWarrior);
            var secondWarrior = new Warrior("Stamat", 12, 100);
            arena.Enroll(secondWarrior);
            arena.Fight(firstWarrior.Name, secondWarrior.Name);
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_When_First_Warrior_Is_Not_Enrolled()
        {
            var firstWarrior = new Warrior("Kolio", 10, 100);
            var secondWarrior = new Warrior("Stamat", 12, 100);
            arena.Enroll(secondWarrior);
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(firstWarrior.Name, secondWarrior.Name);
            });
            Assert.AreEqual(ex.Message, $"There is no fighter with name {firstWarrior.Name} enrolled for the fights!");
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_When_Second_Warrior_Is_Not_Enrolled()
        {
            var firstWarrior = new Warrior("Kolio", 10, 100);
            arena.Enroll(firstWarrior);
            var secondWarrior = new Warrior("Stamat", 12, 100);
            var ex = Assert.Throws<InvalidOperationException>(() =>
             {
                 arena.Fight(firstWarrior.Name, secondWarrior.Name);
             });
            Assert.AreEqual(ex.Message, $"There is no fighter with name {secondWarrior.Name} enrolled for the fights!");
        }
    }
}
