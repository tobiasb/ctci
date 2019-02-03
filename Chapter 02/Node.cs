namespace ctci.Chapter_02
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public void AppendToTail(Node<T> newNode)
        {
            if(Next == null)
            {
                Next = newNode;
            }
            else
            {
                Next.AppendToTail(newNode);
            }
        }

        public int Length
        {
            get
            {
                if (Next == null)
                    return 1;

                return 1 + Next.Length;
            }
        }
    }
}
