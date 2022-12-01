using TripAdministrations;
using NUnit.Framework;
using System.Diagnostics;

class Test_01
{
    private TripAdministrator tripAdministrations;

    private Company c1 = new Company("a", 2);
    private Company c2 = new Company("b", 1);
    private Company c3 = new Company("c", 1);
    private Company c4 = new Company("d", 2);

    private Trip t1 = new Trip("a", 1, Transportation.NONE, 1);
    private Trip t2 = new Trip("b", 1, Transportation.BUS, 1);
    private Trip t3 = new Trip("c", 1, Transportation.BUS, 1);
    private Trip t4 = new Trip("d", 1, Transportation.BUS, 1);

    [SetUp]
    public void Setup()
    {
        this.tripAdministrations = new TripAdministrator();
    }

    [Test]
    public void TestAddCompany()
    {
        this.tripAdministrations.AddCompany(c1);
        Assert.True(this.tripAdministrations.Exist(c1));
    }

        [Test]
    public void TestExistForNotAddedCompany()
    {
        this.tripAdministrations.AddCompany(c2);
        Assert.False(this.tripAdministrations.Exist(c1));
    }

        [Test]
    public void TestExistTripForNotAddedTrip()
    {
        Assert.False(this.tripAdministrations.Exist(t1));
    }

        [Test]
    public void TestExistTripForAdded()
    {
        this.tripAdministrations.AddCompany(c1);
        this.tripAdministrations.AddTrip(c1, t1);
        Assert.True(this.tripAdministrations.Exist(t1));
    }

        [Test]
    public void TestAddCompanyPerf()
    {
        for (int i = 0; i < 10000; i++)
        {
            this.tripAdministrations.AddCompany(new Company(i.ToString(), i));
        }

        Stopwatch sw = new Stopwatch();
        sw.Start();
        this.tripAdministrations.AddCompany(c1);
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

}