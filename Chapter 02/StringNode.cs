namespace ctci.Chapter_02
{
    public class StringNode : Node<string>
    {
        public StringNode(string val)
        {
            Value = val;
        }

        public string Serialize()
        {
            if (Next == null)
            {
                return Value;
            }

            return Value + (Next as StringNode).Serialize();
        }

        public override string ToString()
        {
            return Value;
        }

        public static StringNode From(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            var newNode = new StringNode(input[0].ToString());
            newNode.Next = From(input.Substring(1));

            return newNode;
        }
    }
}
