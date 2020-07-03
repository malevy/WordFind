using WordFind.Models.Trie;
using WordFind.Sources.WordList;

namespace WordFind.Drivers
{
    public class TrieTreeFactory
    {
        public static Tree From(IWordListSource source)
        {
            var tree = new Tree();
            foreach (var word in source.Words())
            {
                tree.Insert(word);
            }

            return tree;

        }
    }
}