using Moq;
using NUnit.Framework;
using Skeleton.Contracts;

[TestFixture]
public class HeroTests
{
    [Test]
    public void Target_Gives_Experiance_When_Dead()
    {
        Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
        Mock<ITarget> mockTarget = new Mock<ITarget>();
        mockTarget.Setup(d => d.IsDead()).Returns(true);
        mockTarget.Setup(e => e.GiveExperience()).Returns(100);
        mockTarget.Setup(h => h.Health).Returns(0);
        Hero hero = new Hero("Ivan", mockWeapon.Object);
        hero.Attack(mockTarget.Object);
        Assert.AreEqual(hero.Experience, 100);
        
    }
}