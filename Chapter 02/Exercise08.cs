using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ctci.Chapter_02
{
    public class Exercise08
    {
        [TestCase("abcdefg")]
        public void should_return_null_when_no_loop(string input)
        {
            var root = StringNode.From(input);

            GetFirstNodeOfLoop(root).Should().BeNull();
        }

        [TestCase("abcdefg", "a")]
        public void should_return_first_node_in_loop(string input, string firstNodeStringValue)
        {
            var root = StringNode.From(input);
            root.AppendToTail(root);

            GetFirstNodeOfLoop(root).Value.Should().Be(firstNodeStringValue);
        }

        private Node<string> GetFirstNodeOfLoop(Node<string> root)
        {
            var nodeSet = new HashSet<Node<string>>();

            for(var curr = root; curr != null; curr = curr.Next)
            {
                if(nodeSet.Contains(curr))
                {
                    return curr;
                }

                nodeSet.Add(curr);
            }

            return null;
        }
    }
}
