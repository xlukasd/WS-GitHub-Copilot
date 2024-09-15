namespace Algorithms
{
    public class ElementSearch
    {
        public bool ContainsElement(ICollection<int> collection, int element)
        {
            return collection.Any(t => t == element);
        }

        public bool SortedListContainsElement(IReadOnlyList<int> sortedList, int element)
        {
            int left = 0;
            int right = sortedList.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedList[mid] == element)
                {
                    return true;
                }

                if (sortedList[mid] < element)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }
    }
}
