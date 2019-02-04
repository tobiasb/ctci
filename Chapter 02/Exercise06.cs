using FluentAssertions;
using NUnit.Framework;

namespace ctci.Chapter_02
{
    public class Exercise06
    {
        [TestCase("abba")]
        [TestCase("tacocat")]
        public void should_be_palindrome(string input)
        {
            var root = StringNode.From(input);

            IsPalindrome(root).Should().BeTrue();
        }
        
        [TestCase("abcd")]
        [TestCase("tacocato")]
        public void should_not_be_palindrome(string input)
        {
            var root = StringNode.From(input);

            IsPalindrome(root).Should().BeFalse();
        }

        private bool IsPalindrome(Node<string> root)
        {
            //assuming singly linked list and no trivial string solution

            Node<string> prev = null;
            Node<string> newEnd = null;
            for(var curr = root; curr != null; curr = curr.Next)
            {
                newEnd = new StringNode(curr.Value);
                newEnd.Next = prev;
                prev = newEnd;
            }

            for(Node<string> leftSide = root, rightSide = newEnd; leftSide != null; leftSide = leftSide.Next, rightSide = rightSide.Next)
            {
                if(leftSide.Value != rightSide.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
