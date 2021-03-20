using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;
    private const int axeDurabilitiAfterAttack = 9;
    [SetUp]
    public void SetUp()
    {
        this.axe = new Axe(10, 10);
        this.dummy = new Dummy(500, 100);
    }
    [Test]
    public void Weapon_Should_Loose_Durablility_After_Attack()
    {
        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(axeDurabilitiAfterAttack), "Axe Durability doesn't change after attack.");
    }
    [Test]
    public void Attack_With_Broken_Axe_Throws_Exception()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            while (true)
            {
                axe.Attack(dummy);
            }
        });
        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }
}