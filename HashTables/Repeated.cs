namespace HTables
{
    public class Repeated
    {
        public char FindRepeatedChar(string input)
        {
            var charSet = new HashSet<char>();
            foreach (var c in input)
            {
                if (charSet.Contains(c)) return c;
                charSet.Add(c);
            }

            return char.MinValue;
        }
    }
}