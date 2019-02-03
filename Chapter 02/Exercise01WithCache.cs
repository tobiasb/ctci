using System.Collections.Generic;

namespace ctci.Chapter_02
{
    public class Exercise01WithCache : Exercise01Base
    {
        protected override void RemoveDuplicates(Node<string> root)
        {
            if (root.Next == null) return;

            var valueCache = new HashSet<string>();
            valueCache.Add(root.Value);

            var prev = root;
            var current = root.Next;
            while (current != null)
            {
                if (valueCache.Contains(current.Value))
                {
                    prev.Next = current.Next;
                }
                else
                {
                    valueCache.Add(current.Value);
                }

                prev = current ;
                current = current.Next;
            }
        }
    }
}
