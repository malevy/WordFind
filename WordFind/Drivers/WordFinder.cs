using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordFind.Models.Trie;

namespace WordFind.Drivers
{
    public class WordFinder
    {

        private readonly Tree _tree;

        public WordFinder(Tree tree)
        {
            _tree = tree;
        }

        /// <summary>
        /// find all the words using the given set of letters
        /// </summary>
        /// <param name="letters"></param>
        /// <returns></returns>
        public IList<string> FindAllWords(string letters)
        {
            return PrefixSearch("", _tree.Get, letters.ToList()).Result;
        }

        private Task<List<string>> PrefixSearch(string prefix, Func<char, Node> searcher, List<char> lettersLeftToSearch)
        {
            var countOfLetters = lettersLeftToSearch.Count;
            var activeSearchesByLetter = new Dictionary<char, Task<List<string>>>();
            var foundWords = new List<string>();

            // fan out
            for (var index = 0; index < countOfLetters; index++)
            {
                var charToFind= lettersLeftToSearch[index];
                var charNode = searcher.Invoke(charToFind);
                if (null == charNode) continue;
                if (activeSearchesByLetter.ContainsKey(charToFind)) continue;

                var newPrefix = prefix + charToFind;
                
                if (charNode.IsEndOfWord)
                {
                    foundWords.Add(newPrefix);
                }

                var remainingLetters = new List<char>(lettersLeftToSearch);
                remainingLetters.RemoveAt(index);

                activeSearchesByLetter.Add(charToFind, PrefixSearch(newPrefix, charNode.Get, remainingLetters));
            }

            // collect
            activeSearchesByLetter.Add('_', Task.FromResult(foundWords));

            List<string> Reducer(Task<List<string>[]> t) => new List<string>(t.Result.SelectMany(s => s));

            return Task.WhenAll(activeSearchesByLetter.Values)
                .ContinueWith(Reducer);
        }

    }
}