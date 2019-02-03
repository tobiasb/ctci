using FluentAssertions;
using NUnit.Framework;

namespace ctci.Chapter_01
{
    public class Exercise09
    {
        [TestCase("waterbottle", "erbottlewat")]
        [TestCase("waterwell", "wellwater")]
        public void should_be_substring(string s1, string s2)
        {
            IsSubstringWithRotation(s1, s2).Should().BeTrue();
        }

        [TestCase("hello", "hell")]
        [TestCase("hello", "lloh")]
        public void should_not_be_substring(string s1, string s2)
        {
            IsSubstringWithRotation(s1, s2).Should().BeFalse();
        }

        private bool IsSubstringWithRotation(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            for(int iS2 = 0; iS2 < s1.Length; iS2++)
            {
                if(s1[0] == s2[iS2])
                {
                    var isSame = true;

                    for(int iS1 = 1; iS1 < s1.Length; iS1++)
                    {
                        if(s1[iS1] != s2[(iS1 + iS2) % s1.Length])
                        {
                            isSame = false;
                            continue;
                        }
                    }

                    if(isSame)
                        return true;
                }
                    
            }

            return false;
        }
    }
}
