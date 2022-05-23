using NUnit.Framework;
using System.Linq;

namespace Tests
{    
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase(1, 3)]
        [TestCase(1, 16)]
        [TestCase(1, 7)]
        public void ConstructorShouldAddElementsCorrectly(int start, int count)
        {
            int[] inputData = Enumerable.Range(start, count).ToArray();

            Database db = new Database(inputData);

            Assert.AreEqual(count, db.Count);
        }

        [Test]
        [TestCase(1,5)]
        [TestCase(1,16)]
        [TestCase(1,9)]
        public void FetchShouldWorkCorrectly(int start, int count)
        {
            int[] inputData = Enumerable.Range(start,count).ToArray();

            Database db = new Database(inputData);

            int[] actual = db.Fetch();

            CollectionAssert.AreEqual(inputData, actual);
        }       

        [Test]
        [TestCase(1, 55)]
        [TestCase(1, 17)]
        public void DatabaseShouldThrowsExceptionIfElementsAreAbove16(int start, int count)
        {
            int[] inputData = Enumerable.Range(start, count).ToArray();           

            Assert.That(() => { new Database(inputData); }, Throws.InvalidOperationException);           
        }

        [Test]
        public void EmptyDatabaseShouldThrowsExceptionIfRemoveElement()
        {
            Database db = new Database();

            Assert.That(() => { db.Remove(); }, Throws.InvalidOperationException);           
        }

        [Test]
        [TestCase(1, 5, 3, 2)]
        [TestCase(1, 16, 16, 0)]
        [TestCase(1, 13, 8, 5)]
        public void RemoveElementsFromDatabaseShouldWorkCorrectly(int start, int count, int ToRemove, int resultCount)
        {
            int[] inputData = Enumerable.Range(start, count).ToArray(); ;

            Database db = new Database(inputData);

            for (int i = 0; i < ToRemove; i++)
            {
                db.Remove();
            }          

            Assert.AreEqual(resultCount, db.Count);
        }

    }
}