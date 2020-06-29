using System.Diagnostics.Contracts;
using System.Xml;
using NUnit.Framework;
using WordFind.Models.Trie;

namespace WordFind.Tests.Models.Trie
{
    [TestFixture]
    public class NodeTests
    {

        [Test]
        public void WhenAttachingANode_ReturnTheNode()
        {
            var root = new Node();
            var newNode = root.Append('c');
            Assert.That(newNode, Is.Not.Null);
        }

        [Test]
        public void WhenGettingAnExistingNode_ReturnTheNode()
        {
            var root = new Node();
            var cNode = root.Append('c');
            var actual = root.Get('c');
            Assert.That(actual, Is.SameAs(cNode));
        }

        [Test]
        public void WhenGettingANonexistingNode_ReturnNull()
        {
            var root = new Node();
            var cNode = root.Get('c');
            Assert.That(cNode, Is.Null);
        }

    }
}