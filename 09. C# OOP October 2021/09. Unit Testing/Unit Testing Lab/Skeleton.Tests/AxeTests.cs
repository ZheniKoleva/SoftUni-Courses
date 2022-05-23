using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AXE_ATTACK = 10;

    private const int AXE_DURABILITY = 10;

    private const int BROKEN_AXE_DURABILITY = 0;    

    private const int DUMMY_HEALTH = 10;

    private const int DUMMY_EXPERIENCE = 10;

    private Axe axe;

    private Axe brokenAxe;

    private Dummy dummy;


    [SetUp]
    public void TestInit()
    {
        axe = new Axe(AXE_ATTACK, AXE_DURABILITY);
        brokenAxe = new Axe(AXE_ATTACK, BROKEN_AXE_DURABILITY);
        dummy = new Dummy(DUMMY_HEALTH, DUMMY_EXPERIENCE);
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        axe.Attack(dummy);
        
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack");
    }

    [Test]
    public void AttackWithBrokenWeaponThrowsInvalidOperationException()
    {
        Assert.That(() => brokenAxe.Attack(dummy), Throws.InvalidOperationException);
    }
}