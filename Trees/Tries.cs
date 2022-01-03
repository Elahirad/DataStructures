using System.Collections;
using System.Text;

namespace Trees
{
    public class Trie
    {
        private class TrieNode
        {
            public char Value { get; set; }
            private Dictionary<char, TrieNode> _dict;
            public bool IsEndOfWord { get; set; }

            public TrieNode(char value)
            {
                this.Value = value;
                this._dict = new Dictionary<char, TrieNode>();
                this.IsEndOfWord = false;
            }

            public char[] GetKeys()
            {
                return this._dict.Keys.ToArray<char>();
            }
            public bool HasAnyChild()
            {
                return this._dict.Keys.ToList<char>().Count > 0;
            }
            public bool HasChild(char key)
            {
                if (this._dict.ContainsKey(key)) return true;
                return false;
            }

            public TrieNode GetChild(char key)
            {
                if (HasChild(key)) return this._dict[key];
                return null;
            }

            public void SetChild(char key, TrieNode value)
            {
                this._dict[key] = value;
            }

            public void RemoveChild(char key)
            {
                this._dict.Remove(key);
            }
        }

        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode(' ');
        }

        public void Insert(string item)
        {
            var buffer = _root;
            foreach (var ch in item)
            {
                if (!buffer.HasChild(ch)) buffer.SetChild(ch, new TrieNode(ch));

                buffer = buffer.GetChild(ch);
            }
            buffer.IsEndOfWord = true;
        }

        public bool Contains(string item)
        {
            if (item == null) return false;
            var buffer = _root;
            foreach (var ch in item)
            {
                if (buffer.HasChild(ch))
                    buffer = buffer.GetChild(ch);
                else return false;
            }
            return buffer.IsEndOfWord;
        }

        public void Remove(string item)
        {
            if (!Contains(item)) return;
            Remove(_root, item, 0);
        }

        private void Remove(TrieNode root, string item, int index)
        {
            if (index == item.Length)
            {
                root.IsEndOfWord = false;
                return;
            }
            var child = root.GetChild(item[index]);
            Remove(child, item, index + 1);
            if (!child.HasAnyChild() && !child.IsEndOfWord)
                root.RemoveChild(child.Value);
        }
        public List<string> FindWords(string prefix)
        {
            var results = new List<string>();
            FindWords(prefix, results, SetBuffer(prefix));
            return results;
        }

        private void FindWords(string prefix, List<string> wordList, TrieNode buffer)
        {
            if (buffer == null) return;
            foreach (var childKey in buffer.GetKeys())
            {
                var child = buffer.GetChild(childKey);
                var childValue = buffer.GetChild(childKey).Value;
                var newPrefix = prefix + childValue;
                if (child.IsEndOfWord) wordList.Add(newPrefix);
                FindWords(newPrefix, wordList, child);
            }

        }

        private TrieNode? SetBuffer(string prefix)
        {
            if (prefix == null) return null;
            var buffer = _root;
            foreach (var ch in prefix)
            {
                if (!buffer.HasChild(ch)) return null;
                buffer = buffer.GetChild(ch);
            }
            return buffer;
        }
    }
}