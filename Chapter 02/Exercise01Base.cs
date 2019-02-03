using FluentAssertions;
using NUnit.Framework;

namespace ctci.Chapter_02
{
    public abstract class Exercise01Base
    {
        [Test]
        public void when_there_are_no_duplicates()
        {
            StringNode root = new StringNode("a");
            root.AppendToTail(new StringNode("b"));
            root.AppendToTail(new StringNode("c"));
            root.AppendToTail(new StringNode("d"));
            root.AppendToTail(new StringNode("e"));

            RemoveDuplicates(root);

            root.Length.Should().Be(5);
            root.Serialize().Should().Be("abcde");
        }

        [Test]
        public void when_there_is_one_duplicate_at_the_end()
        {
            StringNode root = new StringNode("a");
            root.AppendToTail(new StringNode("b"));
            root.AppendToTail(new StringNode("c"));
            root.AppendToTail(new StringNode("b"));

            RemoveDuplicates(root);

            root.Length.Should().Be(3);
            root.Serialize().Should().Be("abc");
        }

        [Test]
        public void when_there_is_one_duplicate_in_the_middle()
        {
            StringNode root = new StringNode("a");
            root.AppendToTail(new StringNode("b"));
            root.AppendToTail(new StringNode("a"));
            root.AppendToTail(new StringNode("c"));

            RemoveDuplicates(root);

            root.Length.Should().Be(3);
            root.Serialize().Should().Be("abc");
        }

        protected abstract void RemoveDuplicates(Node<string> root);
    }
}
