using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private Axe axe;
    private Dummy dummy;
    private Dummy deadDummy;
    private const int xp = 100;
    private const int healthAfterAttack = 90;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(10, 20);
        dummy = new Dummy(100, 100);
        deadDummy = new Dummy(-1, 100);
    }
    [Test]
    public void Dummy_Loses_Health_If_Attacked()
    {
        dummy.TakeAttack(axe.AttackPoints);
        Assert.That(dummy.Health, Is.EqualTo(healthAfterAttack), "Dummy doesn't loose health after attack.");
    }
    [Test]
    public void Dead_Dummy_Throws_Exception_If_Attacked()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            deadDummy.TakeAttack(axe.AttackPoints);
        });
        Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
    }
    [Test]
    public void Alive_Dummy_Cant_Give_XP()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.GiveExperience();
        });
        Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
    }
    [Test]
    public void Dead_Dummy_Can_Give_XP()
    {
        Assert.That(deadDummy.GiveExperience(), Is.EqualTo(xp));
    }
}
