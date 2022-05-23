namespace _02.LowestCommonAncestor.Tests
{
    using NUnit.Framework;

    public class LCATests
    {
        private IAbstractBinaryTree<int> _binaryTree;

        [SetUp] 
        public void Setup() 
        { 
            this._binaryTree = new BinaryTree<int>(
                12,
                new BinaryTree<int>(
                    5,
                    new BinaryTree<int>(1, null, null),
                    new BinaryTree<int>(8, null, null)
                ),
                new BinaryTree<int>(
                    19,
                    new BinaryTree<int>(16, null, null),
                    new BinaryTree<int>(23,
                        new BinaryTree<int>(21, null, null),
                        new BinaryTree<int>(30, null, null)
                    )
                )
            ); 
        } 
 
        [Test] 
        public void TestCommonAncestorWorksCorrectly() 
        { 
            Assert.AreEqual(19, this._binaryTree.FindLowestCommonAncestor(16, 21)); 
        }
    }
}