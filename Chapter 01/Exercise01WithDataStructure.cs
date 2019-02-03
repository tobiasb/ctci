using System.Collections.Generic;

namespace ctci.Chapter_01
{
    public class Exercise01WithDataStructure : Exercise01Base
    {
        protected override bool HasUniqueCharacters(string input)
        {
            HashSet<char> chars = new HashSet<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (chars.Contains(input[i]))
                {
                    return false;
                }
                chars.Add(input[i]);
            }

            return true;
        }
    }
}
