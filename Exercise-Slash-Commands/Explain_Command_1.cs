namespace Exercise_Slash_Commands
{
    public class Explain_Command_1
    {
        public static IReadOnlyList<int> Transform(ICollection<int> source)
        {
            var result = new List<int>(source);
            for (int i = 1; i < result.Count; i++)
            {
                int element = result[i];
                int j = i - 1;

                while (j >= 0 && result[j] > element)
                {
                    result[j + 1] = result[j];
                    j--;
                }

                result[j + 1] = element;
            }

            return result;
        }
    }
}
