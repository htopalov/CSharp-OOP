using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior firstWarrior;
        private Warrior secondWarrior;
        private const string warriorName = "Pesho";
        private const int damage = 10;
        private const int attackHp = 30;
        private const int negativeDamage = -1;
        private const int zeroDamage = 0;
        private const int negativeHP = -21;

        [SetUp]
        public void Setup()
        {
            this.firstWarrior = new Warrior(warriorName, damage, attackHp);
            this.secondWarrior = new Warrior("Ivan", 12, 200);
        }

        [Test]
        public void Test_If_Warrior_Data_Set_Correctly()
        {
            Assert.AreEqual(warriorName, firstWarrior.Name);
            Assert.AreEqual(damage, firstWarrior.Damage);
            Assert.AreEqual(attackHp, firstWarrior.HP);
        }

        [Test]
        public void Test_If_Exception_Is_Thrown_When_Name_Is_Empty_Or_Null()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                firstWarrior = new Warrior(string.Empty, damage, attackHp);
                var secondWarrior = new Warrior(null, damage, attackHp);
                var emptyNameWarrior = new Warrior(" ", damage, attackHp);
            });
            Assert.AreEqual(ex.Message, "Name should not be empty or whitespace!");
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_When_Damage_Is_Zero_Or_Negative()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                firstWarrior = new Warrior(warriorName, zeroDamage, attackHp);
                firstWarrior = new Warrior(warriorName, negativeDamage, attackHp);
            });
            Assert.AreEqual(ex.Message, "Damage value should be positive!");
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_If_HP_Is_Negative()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                firstWarrior = new Warrior(warriorName, damage, negativeHP);
            });
            Assert.AreEqual(ex.Message, "HP should not be negative!");
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_If_First_Warrior_HP_Is_Equal_Or_Less_Than_30()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                firstWarrior.Attack(secondWarrior);
            });
            Assert.AreEqual(ex.Message, "Your HP is too low in order to attack other warriors!");
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_If_Second_Warrior_HP_Is_Equal_Or_Less_Than_30()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var firstWarrior = new Warrior(warriorName, damage, 50);
                var secondWarrior = new Warrior(warriorName, damage, 30);
                firstWarrior.Attack(secondWarrior);
            });
            Assert.AreEqual(ex.Message, $"Enemy HP must be greater than {attackHp} in order to attack him!");
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_If_Enemy_Is_Stronger()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var warrior = new Warrior("sdfjsdof", 10, 40);
                var warrior2 = new Warrior("sdfsdfsd", 200, 40);
                warrior.Attack(warrior2);
            });
            Assert.AreEqual(ex.Message, "You are trying to attack too strong enemy");
        }
        [Test]
        public void Test_If_Attack_Is_Working_Correctly()
        {
            var warrior = new Warrior("sdfjsdof", 100, 400);
            var warrior2 = new Warrior("sdfsdfsd", 50, 40);
            warrior.Attack(warrior2);
            int result = 350;
            Assert.That(result, Is.EqualTo(warrior.HP));
        }
        [Test]
        public void Test_If_Attack_Kills_Enemy()
        {
            var warrior = new Warrior("sdfjsdof", 100, 400);
            var warrior2 = new Warrior("sdfsdfsd", 50, 40);
            warrior.Attack(warrior2);
            Assert.AreEqual(warrior2.HP, 0);
        }
        [Test]
        public void Test_If_Attack_Deals_Damage_To_Enemy_Without_Killing_Him()
        {
            var warrior = new Warrior("sdfjsdof", 100, 400);
            var warrior2 = new Warrior("sdfsdfsd", 50, 400);
            warrior.Attack(warrior2);
            Assert.AreEqual(warrior2.HP, 300);
        }
    }
}