using System.Collections;
namespace Trees
{
    public class ArrayTrie
    {
        private class TrieNode
        {
            private char _value;

            public TrieNode[] Children;

            public bool IsEnd;
            public TrieNode(char value)
            {
                _value = value;
                Children = new TrieNode[26];
                IsEnd = false;
            }
        }

        private TrieNode _root;

        public ArrayTrie()
        {
            _root = new TrieNode(' ');
        }

        public void Insert(string text)
        {
            var root = _root;
            foreach (var ch in text)
            {
                if (root.Children[ch - 97] == null)
                {
                    root.Children[ch - 97] = new TrieNode(ch);
                }
                root = root.Children[ch - 97];
            }
            root.IsEnd = true;
        }
    }
}