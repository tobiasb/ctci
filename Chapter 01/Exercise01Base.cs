using FluentAssertions;
using NUnit.Framework;

namespace ctci.Chapter_01
{
    public abstract class Exercise01Base
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

        protected abstract bool HasUniqueCharacters(string input);
    }
}