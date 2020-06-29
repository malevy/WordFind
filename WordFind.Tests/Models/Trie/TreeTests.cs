using NUnit.Framework;
using WordFind.Models.Trie;

namespace WordFind.Tests.Models.Trie
{
    [TestFixture]
    public class TreeTests
    {
        private readonly Tree _tree;

        public TreeTests()
        {
            this._tree = new Tree();
            this._tree.Insert("dog");
        }

        [Test]
        public void CanFindTheWord()
        {
            Assert.That(_tree.Contains("dog"), Is.True);
        }

        [Test]
        public void CanGetTheNodeForD()
        {
            var dNode = _tree.Get('d');
            Assert.That(dNode, Is.Not.Null);
        }
    }
}