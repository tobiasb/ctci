using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ctci.Chapter_02
{
    public class Exercise02
    {
        [Test]
        public void should_return_kth_last_elements()
        {
            StringNode root = new StringNode("a");
            root.AppendToTail(new StringNode("b"));
            root.AppendToTail(new StringNode("c"));
            root.AppendToTail(new StringNode("d"));
            root.AppendToTail(new StringNode("e"));
            root.AppendToTail(new StringNode("f"));
            root.AppendToTail(new StringNode("g"));

            GetLastK(root, 4).Serialize().Should().Be("defg");
            GetLastK(root, 5).Serialize().Should().Be("cdefg");
            GetLastK(root, 6).Serialize().Should().Be("bcdefg");
        }

        [Test]
        public void should_return_last_element()
        {
            StringNode root = new StringNode("a");
            root.AppendToTail(new StringNode("b"));
            root.AppendToTail(new StringNode("c"));
            root.AppendToTail(new StringNode("d"));
            root.AppendToTail(new StringNode("e"));
            root.AppendToTail(new StringNode("f"));
            root.AppendToTail(new StringNode("g"));

            GetLastK(root, 1).Serialize().Should().Be("g");
        }

        private StringNode GetLastK(StringNode root, int k)
        {
            var lengthsToNode = new Dictionary<int, Node<string>>();

            GetLength(root, lengthsToNode);

            return lengthsToNode[k] as StringNode;
        }

        private int GetLength(Node<string> node, Dictionary<int, Node<string>> lengthsToNode)
        {
            if (node == null) return 0;

            var length = 1 + GetLength(node.Next, lengthsToNode);
            lengthsToNode[length] = node;

            return length;
        }
    }
}
