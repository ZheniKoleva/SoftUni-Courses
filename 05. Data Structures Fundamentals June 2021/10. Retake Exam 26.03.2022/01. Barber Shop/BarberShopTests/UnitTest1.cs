using BarberShop;
using NUnit.Framework;
using System.Diagnostics;

public class Test_01
{
    private BarberShop.BarberShop barberShop;
    private Barber b1 = new Barber("a", 1, 1);
    private Barber b2 = new Barber("b", 2, 3);
    private Barber b3 = new Barber("c", 2, 2);

    private Client c1 = new Client("a", 1, Gender.MALE);
    private Client c2 = new Client("b", 1, Gender.FEMALE);
    private Client c3 = new Client("c", 2, Gender.FEMALE);
    private Client c4 = new Client("d", 6, Gender.FEMALE);
    private Client c5 = new Client("e", 5, Gender.FEMALE);

    [SetUp]
    public void Setup()
    {
        this.barberShop = new BarberShop.BarberShop();
    }

    [Test]
    public void TestAddBarber()
    {
        this.barberShop.AddBarber(b1);
        Assert.True(this.barberShop.Exist(b1));
    }

    [Test]
    public void TestClientExist()
    {
        this.barberShop.AddClient(c1);
        Assert.True(this.barberShop.Exist(c1));
    }

        [Test]
    public void TestClientNotExist()
    {
        this.barberShop.AddClient(c1);
        Assert.False(this.barberShop.Exist(c2));
    }

        [Test]
    public void TestClientExistNotAddingAnything()
    {
        Assert.False(this.barberShop.Exist(c1));
    }

    [Test]
    public void TestAddBarberPerf()
    {
        for (int i = 0; i < 10000; i++)
        {
            this.barberShop.AddBarber(new Barber(i.ToString(), i, i));
        }

        Stopwatch sw = new Stopwatch();
        sw.Start();
        this.barberShop.AddBarber(b1);
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

}
