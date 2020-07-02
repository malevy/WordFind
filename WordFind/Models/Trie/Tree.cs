using System;
using System.Linq;
using WordFind.Sources.WordList;

namespace WordFind.Models.Trie
{
    /// <summary>
    /// Root node of the tree
    /// </summary>
    public class Tree
    {

        private readonly Node root = new Node();

        /// <summary>
        /// Add the given word to the tree
        /// </summary>
        /// <param name="word"></param>
        public void Insert(string word)
        {
            var node = word.ToCharArray()
                .Aggregate(root, (current, letter) => current.Append(letter));
            node.MarkAsEndOfWord();
        }

        /// <summary>
        /// does the tree contain the given word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Contains(string word)
        {
            var node = root;
            foreach (var letter in word.ToCharArray())
            {
                node = node.Get(letter);
                if (null == node) return false;
            }

            return node.IsEndOfWord;
        }

        public Node Get(char value) => root.Get(value);

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