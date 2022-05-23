// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
   
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;

		[SetUp]
		public void SetUp()
		{ 
			stage = new Stage();		
		}

		[Test]
	    public void ConstructorShouldInitializeSongAndPerformerCollections()
	    {
			Assert.IsNotNull(stage);
		}

		[Test]
		public void AddPerformerShouldThrowExceptionForNullPerformer()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null),
				"Can not be null!");
		}

		[Test]
		public void AddPerformerShouldThrowExceptionIfPerformerAgeLessThan18()
		{
			Performer performer = new Performer("Pesho", "Goshev", 15);

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer),
				"You can only add performers that are at least 18.");
		}

		[Test]
		public void AddPerformerShouldWorksCorrectly()
		{
			Performer performer = new Performer("Pesho", "Goshev", 25);
			stage.AddPerformer(performer);

			Assert.AreEqual(1, stage.Performers.Count);
		}

		[Test]
		public void PerformersPropertyShouldWorksCorrectly()
		{
			Performer performer = new Performer("Pesho", "Goshev", 25);
			Performer performer2 = new Performer("Tosho", "Peshev", 32);
			stage.AddPerformer(performer);
			stage.AddPerformer(performer2);

			IReadOnlyCollection<Performer> expected = new List<Performer> { performer, performer2 };

			CollectionAssert.AreEqual(expected, stage.Performers);
		}

		[Test]
		public void AddSongShouldThrowExceptionForNullPerformer()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null),
				"Can not be null!");
		}

		[Test]
		public void AddSongShouldThrowExceptionIfSongDurationLessThan1Minute()
		{
			Song song = new Song("Zaichenceto bqlo", new TimeSpan(0, 0, 43));

			Assert.Throws<ArgumentException>(() => stage.AddSong(song),
				"You can only add songs that are longer than 1 minute.");
		}

		[Test]
		public void AddSongToPerformerShouldThrowExceptionIfSongIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Pesho"),
				"Can not be null!");
		}

		[Test]
		public void AddSongToPerformerShouldThrowExceptionIfPerformerIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("zaichenceto bqlo", null),
				"Can not be null!");
		}

		[Test]
		public void AddSongToPerformerShouldThrowExceptionForUnexistingPerformer()
		{
			Performer performer = new Performer("Pesho", "Goshev", 25);
			Song song = new Song("Zaichenceto bqlo", new TimeSpan(0, 2, 43));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("zaichenceto bqlo", "Gosho"),
				"There is no performer with this name.");
		}

		[Test]
		public void AddSongToPerformerShouldThrowExceptionForUnexistingSong()
		{
			Performer performer = new Performer("Pesho", "Goshev", 25);
			Song song = new Song("Zaichenceto bqlo", new TimeSpan(0, 2, 43));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("tih bql dunav", "Pesho"),
				"There is no song with this name.");
		}


		[Test]
		public void AddSongToPerformerShouldWorksCorrectly()
		{
			Performer performer = new Performer("Pesho", "Goshev", 25);
			Song song = new Song("Zaichenceto bqlo", new TimeSpan(0, 2, 43));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			stage.AddSongToPerformer(song.Name, performer.FullName);

			Song actual = stage.Performers.First().SongList[0];

			Assert.AreEqual(song, actual);			
		}

		[Test]
		public void AddSongToPerformerShouldReturnCorrectString()
		{
			Performer performer = new Performer("Pesho", "Goshev", 25);
			Song song = new Song("Zaichenceto bqlo", new TimeSpan(0, 2, 43));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			string actual = stage.AddSongToPerformer(song.Name, performer.FullName);

			string expected = $"{song} will be performed by {performer.FullName}";

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PlayShouldReturnCorrectString()
		{
			Performer performer = new Performer("Pesho", "Goshev", 25);
			Song song = new Song("Zaichenceto bqlo", new TimeSpan(0, 2, 43));
			Song song2 = new Song("tih bql vunav", new TimeSpan(0, 3, 15));

			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSong(song2);

			stage.AddSongToPerformer(song.Name, performer.FullName);
			stage.AddSongToPerformer(song2.Name, performer.FullName);

			string expected = $"1 performers played 2 songs";
			string actual = stage.Play();

			Assert.AreEqual(expected, actual);
		}

	}
}