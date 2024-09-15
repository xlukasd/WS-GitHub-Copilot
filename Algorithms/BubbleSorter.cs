namespace Algorithms
{
    public static class BubbleSorter
    {
        /// <summary>
        /// Sorts the collection of integers using the bubble sort algorithm.
        /// </summary>
        /// <param name="elements">The collection of integers to be sorted.</param>
        /// <returns>An immutable list of integers in sorted order.</returns>
        public static IReadOnlyList<int> Sort(ICollection<int> elements)
        {
            int[] array = new int[elements.Count];
            elements.CopyTo(array, 0);

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }

            return array;
        }
    }
}
