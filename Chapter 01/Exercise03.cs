using FluentAssertions;
using NUnit.Framework;

namespace ctci.Chapter_01
{
    public class Exercise03
    {
        [TestCase("TestWithOutSpaces            ", "TestWithOutSpaces")]
        [TestCase("Test With Spaces             ", "Test%20With%20Spaces")]
        [TestCase(" Test With Spaces            ", "%20Test%20With%20Spaces")]
        public void test(string input, string expected)
        {
            var inputAsCharArray = input.ToCharArray();
            Urlify(inputAsCharArray, input.TrimEnd().Length);
            new string(inputAsCharArray).Trim().Should().BeEquivalentTo(expected);
        }

        private void Urlify(char[] input, int contentLenght)
        {

            for(int i = 0; i < contentLenght;)
            {
                const string replacement = "%20";

                if(input[i] == ' ')
                {
                    Move(input, i + 1, contentLenght - 1 - i, 2);

                    for(int j = 0; j < replacement.Length; j++)
                    {
                        input[i + j] = replacement[j];
                    }
                    i += replacement.Length;
                    contentLenght += replacement.Length - 1;
                }
                else
                {
                    i++;
                }
            }
        }

        private void Move(char[] input, int start, int contentLengthRemaining, int offset)
        {
            for(int i = start + contentLengthRemaining + offset - 1; i >= start + offset; i--)
            {
                input[i] = input[i - offset];
            }
        }
    }
}
