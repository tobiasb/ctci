namespace ctci.Chapter_01
{
    public class Exercise01Iteratively : Exercise01Base
    {
        protected override bool HasUniqueCharacters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                        return false;
                }
            }

            return true;
        }
    }
}
