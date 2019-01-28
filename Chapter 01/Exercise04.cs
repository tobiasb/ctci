using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ctci.Chapter_01
{
    public class Exercise04
    {
        [TestCase("Tact Coa")]
        [TestCase("aabb aa")]
        [TestCase("abcdabcdx")]
        public void should_be_true(string input)
        {
            IsPalindromePermutation(input).Should().BeTrue();
        }

        [TestCase("hello world")]
        [TestCase("abcdabcdxy")]
        public void should_be_false(string input)
        {
            IsPalindromePermutation(input).Should().BeFalse();
        }

        private bool IsPalindromePermutation(string input)
        {
            var charHistogram = GetHistogram(input.ToLower());

            bool hasHadUnevenNumOccurence = false;

            foreach(var kvp in charHistogram)
            {
                if(kvp.Value % 2 == 1)
                {
                    if (hasHadUnevenNumOccurence)
                        return false;

                    hasHadUnevenNumOccurence = true;
                }
            }

            return true;
        }

        private Dictionary<char, int> GetHistogram(string input)
        {
            var histogram = new Dictionary<char, int>();

            for(int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar < 'a' || 'z' < currentChar)
                    continue;

                if (!histogram.ContainsKey(currentChar))
                    histogram.Add(currentChar, 0);

                histogram[currentChar]++;
            }

            return histogram;
        }
    }
}
