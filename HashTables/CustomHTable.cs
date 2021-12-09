namespace HTables
{
    public class CustomHTable
    {
        private class KVPair
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }
        private LinkedList<KVPair>[] _arr;

        private int HashFunction(int key)
        {
            return key % _arr.Length;

        }

        private KVPair GetItem(int key)
        {
            foreach (var item in _arr[HashFunction(key)])
            {
                if (item.Key == key) return item;
            }
            return null;
        }
        public CustomHTable(int init_size)
        {
            _arr = new LinkedList<KVPair>[init_size];
        }

        public void Put(int key, string value)
        {
            int index = HashFunction(key);
            if (_arr[index] == null) _arr[index] = new LinkedList<KVPair>();
            var item = GetItem(key);
            if (item != null)
            {
                item.Value = value;
                return;
            }
            _arr[index].AddLast(new KVPair() { Key = key, Value = value });
        }

        public string Get(int key)
        {
            int index = HashFunction(key);
            if (_arr[index] == null) return "";
            return GetItem(key).Value;
        }

        public string Remove(int key)
        {
            int index = HashFunction(key);
            if (_arr[index] == null) return "";
            var item = GetItem(key);
            if (item != null)
            {
                _arr[index].Remove(item);
                return item.Value;
            }
            return null;
        }
    }
}