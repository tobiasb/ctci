using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Exercise01
    {
        [TestCase("")]
        [TestCase("abcdefg")]
        [TestCase("aAbBcCdD")]
        public void should_be_unique(string input)
        {
            HasUniqueCharacters(input).Should().BeTrue();
        }

        [TestCase("abcxx")]
        [TestCase("xabcx")]
        [TestCase("abcdefgg")]
        public void should_not_be_unique(string input)
        {
            HasUniqueCharacters(input).Should().BeFalse();
        }

        private bool HasUniqueCharacters(string input)
        {
            return HasUniqueCharactersPlain(input);
        }

        private bool HasUniqueCharactersPlain(string input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                for(int j = i+1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                        return false;
                }
            }

            return true;
        }

        private bool HasUniqueCharactersWithSet(string input)
        {
            HashSet<char> chars = new HashSet<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (chars.Contains(input[i]))
                {
                    return false;
                }
                chars.Add(input[i]);
            }

            return true;
        }
    }
}