using FluentAssertions;
using NUnit.Framework;

namespace ctci.Chapter_01
{
    public class Exercise05
    {
        [TestCase("pale", "ple")]
        [TestCase("pales", "pale")]
        [TestCase("pale", "bale")]
        public void should_be_one_away(string s1, string s2)
        {
            AreOneAway(s1, s2).Should().BeTrue();
        }

        [TestCase("pale", "bake")]
        [TestCase("p", "bake")]
        [TestCase("pa", "bake")]
        [TestCase("bake", "p")]
        [TestCase("bake", "pa")]
        public void should_not_be_one_away(string s1, string s2)
        {
            AreOneAway(s1, s2).Should().BeFalse();
        }

        private bool AreOneAway(string s1, string s2)
        {
            var shorter = s1.Length > s2.Length ? s2 : s1;
            var longer = s1.Length > s2.Length ? s1 : s2;

            int i = 0, j = 0;
            var numDifferences = 0;

            while(i < shorter.Length || j < longer.Length)
            {
                if(i >= shorter.Length || j >= longer.Length || shorter[i] != longer[j])
                {
                    if (numDifferences >= 1)
                        return false;
                    numDifferences++;

                    if(longer.Length != shorter.Length)
                        j++;
                }

                i++;
                j++;
            }

            return true;
        }
    }
}
