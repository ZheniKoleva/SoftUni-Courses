using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int TAKE_ATTACK = 10;

    private const int ALIVE_DUMMY_HEALTH = 100;

    private const int ALIVE_DUMMY_EXPERIENCE = 20;

    private const int DEAD_DUMMY_HEALTH = 0;

    private const int DEAD_DUMMY_EXPERIENCE = 30;

    private Dummy aliveDummy;

    private Dummy deadDummy;


    [SetUp]
    public void TestInit()
    {
        aliveDummy = new Dummy(ALIVE_DUMMY_HEALTH, ALIVE_DUMMY_EXPERIENCE);
        deadDummy = new Dummy(DEAD_DUMMY_HEALTH, DEAD_DUMMY_EXPERIENCE);
    }


    [Test]
    public void DummyLosesHealthIfAttacked()
    {    
        aliveDummy.TakeAttack(TAKE_ATTACK);

        Assert.That(aliveDummy.Health, Is.EqualTo(90), "Dummy health doesn't change after attack");        
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {    
        Assert.That(() => { deadDummy.TakeAttack(TAKE_ATTACK); }, Throws.InvalidOperationException);
    }

    [Test]
    public void DeadDummyCanGiveExperience()
    {
        Assert.That(deadDummy.GiveExperience(), Is.EqualTo(30));              
    }

    [Test]
    public void AliveDummyCannotGiveExperience()
    {    
        aliveDummy.TakeAttack(TAKE_ATTACK);

        Assert.That(() => { aliveDummy.GiveExperience(); }, Throws.InvalidOperationException);
    }


}
