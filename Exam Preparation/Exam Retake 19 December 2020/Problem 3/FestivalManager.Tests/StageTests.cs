// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class StageTests
    {
		private List<Song> songs;
		private List<Performer> performers;
		private TimeSpan span;
		private Stage stage;
		private Performer performer;
		private Song song;
		[SetUp]
		public void SetUp()
        {
			this.songs = new List<Song>();
			this.performers = new List<Performer>();
			this.stage = new Stage();
			performer = new Performer("Bastun", "Batunov", 23);
			span = new TimeSpan(0 ,3, 15);
			song = new Song("beli ptici", span);

        }

		[Test]
	    public void TestIfConstructorWorksCorrectly()
	    {
			Assert.IsNotNull(songs);
			Assert.IsNotNull(performers);
		}
		[Test]
		public void CheckIfAddPerformerWorksCorrectly()
        {
			performers.Add(performer);
			Assert.That(performers.Count, Is.EqualTo(1));
        }
		[Test]
		public void CheckThrowsExceptionIfUnder18()
        { 
			Assert.Throws<ArgumentException>(() =>
			{
				var performer1 = new Performer("Ivan", "Ivanov", 14);
				stage.AddPerformer(performer1);
			});
        }
		[Test]
		public void ValidateNullValueExceptionWhenAdd()
        {
			Performer performer = null;
			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddPerformer(performer);
			});
        }
		[Test]
		public void AddSongWorksCorrectly()
        {
			songs.Add(song);
			Assert.AreEqual(songs.Count, 1);
        }
		[Test]
		public void AddSongThrowsArgumenNullException()
        {
			Song song = null;
			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSong(song);
			});
		}
		[Test]
		public void AddSongThrowsExceptionForLength()
        {
			span = new TimeSpan(0, 0, 15);
			song = new Song("beli ptici", span);
			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSong(song);
			});
		}
		[Test]
		public void AddsSongToPerformerThrowsExceptionsForNulls()
        {
			performer = new Performer(null, null, 23);
			span = new TimeSpan(0, 0, 15);
			song = new Song(null, span);
			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSongToPerformer(song.Name, performer.FullName);
			});
		}
		[Test]
		public void AddSongToPerformerWorksCorrectly()
        {
			span = new TimeSpan(0, 1, 15);
			song = new Song("beli ptici", span);
			var performer = new Performer("Ivan", "Ivanov", 44);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer("beli ptici", "Ivan Ivanov");
			Assert.AreEqual(performer.SongList.Count, 1);
		}
        [Test]
        public void AddSongToPerformerReturnsCorrectly()
        {
            span = new TimeSpan(0, 1, 15);
            song = new Song("beli ptici", span);
            var performer = new Performer("Ivan", "Ivanov", 44);
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("beli ptici", "Ivan Ivanov");
            Assert.AreEqual(stage.AddSongToPerformer("beli ptici", "Ivan Ivanov"), $"{song} will be performed by Ivan Ivanov");
        }
        [Test]
		public void PlayWorksCorrectly()
        {
			span = new TimeSpan(0, 1, 15);
			song = new Song("beli ptici", span);
			var song2 = new Song("beli pici", span);
			var song3 = new Song("beli oblaci", span);
			var performer = new Performer("Gosho", "Ivanov", 44);
			var performer2 = new Performer("Ivan", "Ivanov", 44);
			var performer3 = new Performer("Pesho", "Ivanov", 44);
			stage.AddPerformer(performer);
			stage.AddPerformer(performer2);
			stage.AddPerformer(performer3);
			stage.AddSong(song);
			stage.AddSong(song2);
			stage.AddSong(song3);
			stage.AddSongToPerformer("beli ptici", "Gosho Ivanov");
			stage.AddSongToPerformer("beli oblaci", "Ivan Ivanov");
			stage.AddSongToPerformer("beli pici", "Pesho Ivanov");
			Assert.That(stage.Play(), Is.EqualTo("3 performers played 3 songs"));

		}
	}
}