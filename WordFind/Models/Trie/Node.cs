using System.Collections.Concurrent;

namespace WordFind.Models.Trie
{
    public class Node
    {
        
        private readonly ConcurrentDictionary<char, Node> _nodes = new ConcurrentDictionary<char, Node>();

        public bool IsEndOfWord
        {
            get;
            private set;
        }

        public Node Append(char value)
        {
            return this._nodes.GetOrAdd(value, v => new Node());
        }

        public Node Get(char value)
        {
            return this._nodes.TryGetValue(value, out var n) ? n : null;
        }

        public void MarkAsEndOfWord()
        {
            this.IsEndOfWord = true;
        }
    }
}