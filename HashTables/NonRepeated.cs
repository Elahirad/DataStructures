namespace HTables
{
    public class NonRepeated
    {
        public char FindNonRepeatedChar(string input)
        {
            var chars = new Dictionary<char, int>();
            foreach (var c in input)
            {
                if (!chars.ContainsKey(c)) chars.Add(c, 1);
                else chars[c]++;
            }


            foreach (var c in input)
            {
                if (chars[c] == 1) return c;
            }
            return char.MinValue;
        }
    }
}