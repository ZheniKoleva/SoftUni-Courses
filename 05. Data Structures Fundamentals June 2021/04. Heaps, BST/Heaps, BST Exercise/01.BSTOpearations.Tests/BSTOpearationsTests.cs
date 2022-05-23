namespace _01.BSTOpearations.Tests
{
    using NUnit.Framework;
    using _01.BSTOperations;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System;

    public class Tests
    {
        private IAbstractBinarySearchTree<int> _bst;

        [SetUp]
        public void InitializeBST()
        {
            this._bst = new BinarySearchTree<int>();
            this._bst.Insert(12);
            this._bst.Insert(21);
            this._bst.Insert(5);
            this._bst.Insert(1);
            this._bst.Insert(8);
            this._bst.Insert(18);
            this._bst.Insert(23);
        }


        [Test]
        public void TestLeftSideBST()
        {
            var root = this._bst.Root;
            var left = root.LeftChild;
            var left_left = left.LeftChild;
            var left_right = left.RightChild;

            Assert.AreEqual(12, root.Value);
            Assert.AreEqual(5, left.Value);
            Assert.AreEqual(1, left_left.Value);
            Assert.AreEqual(8, left_right.Value);
        }

        [Test]
        public void TestRightSideBST()
        {
            var root = this._bst.Root;
            var right = root.RightChild;
            var right_left = right.LeftChild;
            var right_right = right.RightChild;

            Assert.AreEqual(12, root.Value);
            Assert.AreEqual(21, right.Value);
            Assert.AreEqual(18, right_left.Value);
            Assert.AreEqual(23, right_right.Value);
        }

        [Test]
        public void TestSearchCheckReturnedTreeStructure()
        {
            var searched = this._bst.Search(5);
            var root = searched.Root;
            var left = root.LeftChild;
            var right = root.RightChild;

            Assert.AreEqual(5, root.Value);
            Assert.AreEqual(1, left.Value);
            Assert.AreEqual(8, right.Value);
        }

        [Test]
        public void TestSearchCheckReturnedTreeStructureWithOnlyLeftNode()
        {
            this._bst.Insert(-2);
            var searched = this._bst.Search(1);
            var root = searched.Root;
            var left = root.LeftChild;
            var right = root.RightChild;

            Assert.AreEqual(1, root.Value);
            Assert.AreEqual(-2, left.Value);
            Assert.AreEqual(null, right);
        }

        [Test]
        public void TestContainsCheckReturnedTrue()
        {
            Assert.IsTrue(this._bst.Contains(5));
        }

        [Test]
        public void TestContainsCheckReturnedFalse()
        {
            Assert.IsFalse(this._bst.Contains(77));
        }

        [Test]
        public void TestEachInOrderWorksCorrectly()
        {
            StringBuilder result = new StringBuilder();
            this._bst.EachInOrder((el) => result.Append($"{el}, "));

            StringAssert.AreEqualIgnoringCase("1, 5, 8, 12, 18, 21, 23, ", result.ToString());
        }

        [Test]
        public void TestRangeWorksCorrectlyWithElements()
        {
            int[] expected = { 1, 5, 8, 12, 18 };
            List<int> actual = this._bst.Range(1, 18)
                .OrderBy(el => el)
                .ToList();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }


        [Test]
        public void TestRangeWorksCorrectlyWithNoElementsFound()
        {
            var actual = this._bst.Range(25, 70);

            Assert.IsEmpty(actual);
        }

        [Test]
        public void TestDeleteMinWorksCorrectlyWithOne()
        {
            this._bst.DeleteMin();

            Assert.IsFalse(this._bst.Contains(1));
        }

        [Test]
        public void TestDeleteMinWorksCorrectlyWithTwoDeletions()
        {
            this._bst.DeleteMin();
            this._bst.DeleteMin();

            Assert.IsFalse(this._bst.Contains(1));
            Assert.IsFalse(this._bst.Contains(5));
            Assert.AreEqual(8, this._bst.Root.LeftChild.Value);
        }

        [Test]
        public void TestDeleteMinThrowsExceptionOnEmptyCollection()
        {
            var myBst = new BinarySearchTree<int>();

            Assert.Throws<InvalidOperationException>(() => myBst.DeleteMin());
        }

        [Test]
        public void TestDeleteMaxWorksCorrectlyWithOne()
        {
            this._bst.DeleteMax();

            Assert.IsFalse(this._bst.Contains(23));
        }

        [Test]
        public void TestDeleteMaxWorksCorrectlyWithTwoDeletions()
        {
            this._bst.DeleteMax();
            this._bst.DeleteMax();

            Assert.IsFalse(this._bst.Contains(23));
            Assert.IsFalse(this._bst.Contains(21));
            Assert.AreEqual(18, this._bst.Root.RightChild.Value);
        }

        [Test]
        public void TestDeleteMaxThrowsExceptionOnEmptyCollection()
        {
            var myBst = new BinarySearchTree<int>();

            Assert.Throws<InvalidOperationException>(() => myBst.DeleteMax());
        }

        [Test]
        public void TestCountWorksCorreclyAfterInsert()
        {
            Assert.AreEqual(7, this._bst.Count);
        }


        [Test]
        public void TestCountWorksCorreclyAfterDeleteMin()
        {
            this._bst.DeleteMin();

            Assert.AreEqual(6, this._bst.Count);
        }

        [Test]
        public void TestCountWorksCorreclyAfterDeleteMax()
        {
            this._bst.DeleteMax();

            Assert.AreEqual(6, this._bst.Count);
        }

        [Test]
        public void TestRankShouldReturnZero()
        {
            int actualRank = this._bst.GetRank(0);

            Assert.AreEqual(0, actualRank);
        }

        [Test]
        public void TestRankShouldReturnCorrectValue()
        {
            int actualRank = this._bst.GetRank(19);

            Assert.AreEqual(5, actualRank);
        }
    }
}