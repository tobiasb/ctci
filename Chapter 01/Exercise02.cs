
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ctci.Chapter_01
{
    public class Exercise02
    {
        [TestCase("abcde", "edcab")]
        [TestCase("abc", "abc")]
        [TestCase("abbcdee", "babcede")]
        public void should_be_permutation(string s1, string s2)
        {
            IsPermutation(s1, s2).Should().BeTrue();
        }

        [TestCase("abc", "def")]
        [TestCase("abcc", "abc")]
        [TestCase("abcc", "abcd")]
        public void should_not_be_permutation(string s1, string s2)
        {
            IsPermutation(s1, s2).Should().BeFalse();
        }

        private bool IsPermutation(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            Dictionary<char, int> occurencesS1 = GetOccurences(s1);
            Dictionary<char, int> occurencesS2 = GetOccurences(s2);

            if (occurencesS1.Keys.Count != occurencesS2.Keys.Count)
                return false;

            foreach(KeyValuePair<char, int> kvp1 in occurencesS1)
            {
                if (!occurencesS2.ContainsKey(kvp1.Key) || occurencesS2[kvp1.Key] != kvp1.Value)
                    return false;
            }

            return true;
        }

        private Dictionary<char, int> GetOccurences(string input)
        {
            Dictionary<char, int> occurences = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (!occurences.ContainsKey(currentChar))
                {
                    occurences.Add(currentChar, 0);
                }

                occurences[currentChar]++;
            }

            return occurences;
        }
    }
}
