using FluentAssertions;
using NUnit.Framework;

namespace ctci.Chapter_01
{
    public class Exercise06
    {
        [TestCase("aabcccccaaa", "a2b1c5a3")]
        [TestCase("abcde", "abcde")]
        public void should_be(string original, string compressed)
        {
            Compress(original).Should().Be(compressed);
        }

        private string Compress(string original)
        {
            string compressed = "";
            int lastNewChar = 0;

            for(int i = 1; i <= original.Length; i++)
            {
                if(i == original.Length || original[i] != original[lastNewChar])
                {
                    compressed += original[lastNewChar] + (i - lastNewChar).ToString();

                    lastNewChar = i;
                }
            }

            if (compressed.Length <= original.Length)
                return compressed;

            return original;
        }
    }
}
