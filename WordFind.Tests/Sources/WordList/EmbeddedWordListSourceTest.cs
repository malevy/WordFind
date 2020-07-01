using System.Linq;
using NUnit.Framework;
using WordFind.Sources.WordList;

namespace WordFind.Tests.Sources.WordList
{
    [TestFixture]
    public class EmbeddedWordListSourceTest
    {

        [Test]
        public void CanReadWordList()
        {
            var wordListSource = new EmbeddedWordListSource();
            wordListSource.Load();
            Assert.That(wordListSource.Words().Count(), Is.GreaterThan(0));


        }

        [Test]
        public void The10thWordIs_aaliis()
        {
            var wordListSource = new EmbeddedWordListSource();
            wordListSource.Load();
            var actual = wordListSource.Words().Skip(9).Take(1).First();
            Assert.That(actual, Is.EqualTo("aaliis"));
        } 

    }
}