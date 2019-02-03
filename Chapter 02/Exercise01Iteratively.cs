namespace ctci.Chapter_02
{
    public class Exercise01Iteratively : Exercise01Base
    {
        protected override void RemoveDuplicates(Node<string> root)
        {
            for (var curr = root; curr != null; curr = curr.Next)
            {
                var prev = curr;
                for(var toCheck = curr.Next; toCheck != null; prev = toCheck, toCheck = toCheck.Next)
                {
                    if(toCheck.Value == curr.Value)
                    {
                        prev.Next = toCheck.Next;
                    }
                }
            }
        }
    }
}
