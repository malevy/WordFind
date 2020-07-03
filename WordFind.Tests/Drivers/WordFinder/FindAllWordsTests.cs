using NUnit.Framework;
using WordFind.Models.Trie;

namespace WordFind.Tests.Drivers.WordFinder
{
    [TestFixture]
    public class FindAllWordsTests
    {
        private readonly Tree _tree;
        private readonly WordFind.Drivers.WordFinder _finder;


        public FindAllWordsTests()
        {
            _tree = new Tree();
            _tree.Insert("boy");
            _tree.Insert("toy");
            _tree.Insert("goat");

            _finder = new WordFind.Drivers.WordFinder(_tree);
        }

        [Test]
        public void WhenTheSequenceIsAWord_ItIsFound()
        {
            var foundWords = _finder.FindAllWords("boy");
            Assert.That(foundWords, Contains.Item("boy"));
        }

        [Test]
        public void WhenTheSequenceIsScrambledButContainsAKnownWord_ItIsFound()
        {
            var foundWords = _finder.FindAllWords("yob");
            Assert.That(foundWords, Contains.Item("boy"));

        }

        [Test]
        public void WhenTheSequenceContainsMultipleWords_TheyAreFound()
        {
            var foundWords = _finder.FindAllWords("ytob");
            Assert.That(foundWords, Contains.Item("boy"));
            Assert.That(foundWords, Contains.Item("toy"));
        }

        [Test]
        public void WhenTheSequenceContainsExtraLetters_TheWordsAreStillFound()
        {
            var foundWords = _finder.FindAllWords("ytobwxyz");
            Assert.That(foundWords, Contains.Item("boy"));
            Assert.That(foundWords, Contains.Item("toy"));
        }

        [Test]
        public void NoIncompleteWordsAreCaptured()
        {
            var foundWords = _finder.FindAllWords("ytob");
            Assert.That(foundWords.Count, Is.EqualTo(2));
        }


    }
}