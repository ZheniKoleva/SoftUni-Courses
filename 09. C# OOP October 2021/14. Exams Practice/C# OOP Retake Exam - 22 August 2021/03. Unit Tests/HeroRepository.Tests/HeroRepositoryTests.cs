using System;
using System.Collections.Generic;

using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    private Hero firstHero;

    private Hero secondHero;


    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
        firstHero = new Hero("Pesho", 15);
        secondHero = new Hero("Gosho", 5);
    }


    [Test]
    public void ConstructorShouldInitialiseCollectionOfHeroes()
    {
        Assert.IsNotNull(heroRepository.Heroes);
    }


    [Test]
    public void CreateMethodShouldThrowExceptionForNullHero()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null),
            "Hero is null");
    }

    [Test]
    public void CreateMethodShouldThrowExceptionForExistingHero()
    {
        heroRepository.Create(firstHero);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(firstHero),
            $"Hero with name {firstHero.Name} already exists");
    }

    [Test]
    public void CreateMethodShouldAddHeroCorrectly()
    {
        heroRepository.Create(firstHero);

        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateMethodShouldReturnCorrectOutput()
    {
        string expected = $"Successfully added hero {firstHero.Name} with level {firstHero.Level}";
        string actual = heroRepository.Create(firstHero);

        Assert.AreEqual(expected, actual);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void RemoveMethodShouldThrowExceptionForNullHero(string name)
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(name),
             "Name cannot be null");
    }


    [Test]
    public void RemoveMethodShouldReturnTrue()
    {
        heroRepository.Create(firstHero);

        bool isRemoved = heroRepository.Remove(firstHero.Name);
        int heroCount = heroRepository.Heroes.Count;

        Assert.IsTrue(isRemoved);
        Assert.AreEqual(0, heroCount);
    }

    [Test]
    public void RemoveMethodShouldReturnFalseForUnexistingHero()
    {
        heroRepository.Create(firstHero);

        bool isRemoved = heroRepository.Remove("Gosho");

        Assert.IsFalse(isRemoved);
    }

    [Test]
    public void GetHeroWithHighestLevelShoulWorksCorrectly()
    {
        heroRepository.Create(firstHero);
        heroRepository.Create(secondHero);

        Hero actual = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(firstHero, actual);
    }

    [Test]
    public void GetHeroShouldWorksCorrectly()
    {
        heroRepository.Create(firstHero);
        heroRepository.Create(secondHero);

        Hero actual = heroRepository.GetHero(firstHero.Name);

        Assert.AreEqual(firstHero, actual);
    }

    [Test]
    public void GetHeroShouldReturnNullForUnexostingHero()
    {
        heroRepository.Create(firstHero);
        heroRepository.Create(secondHero);

        Hero actual = heroRepository.GetHero("Ivan");

        Assert.IsNull(actual);
    }

    [Test]
    public void HeroesShouldReturnCollection()
    {
        heroRepository.Create(firstHero);
        heroRepository.Create(secondHero);

        IReadOnlyCollection<Hero> expected = new List<Hero>() { firstHero, secondHero };
        IReadOnlyCollection<Hero> actual = heroRepository.Heroes;

        CollectionAssert.AreEqual(expected, actual);
    }
}



