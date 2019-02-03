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
    }
}
