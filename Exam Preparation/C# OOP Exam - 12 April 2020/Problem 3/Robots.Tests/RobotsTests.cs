namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private RobotManager manager;
        private Robot robot;

        [SetUp]
        public void SetUp()
        {
            this.manager = new RobotManager(5);
            this.robot = new Robot("Name", 100);
        }
        [Test]
        public void CheckIfConstructorWorks()
        {
            Assert.IsNotNull(manager);
        }
        [Test]
        public void CheckIfCapacityPropertyThrowsExceptionWhenIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager rmanager = new RobotManager(-10);
            });
        }
        [Test]
        public void CheckIfAddCommandWorksCorrectly()
        {
            manager.Add(robot);
            Assert.AreEqual(manager.Count, 1);
        }
        [Test]
        public void CheckIfAddCommandThrowsExceptionWhenRobotExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot);
                manager.Add(robot);
            });
        }
        [Test]
        public void CheckIfAddCommandThrowsExceptionWhenCapacityNotEnough()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    manager.Add(new Robot($"robot {i}", 100 + i));
                }
            });
        }
        [Test]
        public void CheckIfRemoveRobotMethodWorksCorrectly()
        {
            manager.Add(robot);
            manager.Remove("Name");
            Assert.AreEqual(manager.Count, 0);
        }
        [Test]
        public void CheckIfRemoveRobotMethodThrowsExceptionWhenRobotNotExisting()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove("Terminator");
            });
        }
        [Test]
        public void CheckIfWorkMethodThrowsExceptionWhenRobotNotExisting()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("T-100", "Dig", 15);
            });
        }
        [Test]
        public void CheckIfWorkMethodThrowsExceptionWhenRobotBatteryNotEnoughToWork()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("Name", "Dig", 150);
            });
        }
        [Test]
        public void CheckIfWorkMethodWorksCorrectly()
        {
            manager.Add(robot);
            manager.Work("Name", "Dig", 15);
            Assert.AreEqual(robot.Battery, 85);
        }
        [Test]
        public void CheckIfChargeMethodThrowsExceptionWhenRobotMissing()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge("T1000");
            });
        }
        [Test]
        public void CheckIfChargeMethodWorksCorrectly()
        {
            manager.Add(robot);
            manager.Work("Name", "Dig", 50);
            manager.Charge("Name");
            Assert.AreEqual(robot.Battery, 100);
        }
    }
}
