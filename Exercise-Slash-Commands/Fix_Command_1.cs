public class MergeSorter
{
    public static IReadOnlyList<int> Sort(ICollection<int> source)
    {
        var sortedList = MergeSort(source.ToList());
        return sortedList.AsReadOnly();
    }

    private static List<int> MergeSort(List<int> collection)
    {
        if (collection.Count <= 1)
        {
            return [..collection];
        }

        var left = new List<int>();
        var right = new List<int>();

        int middle = collection.Count / 2;
        int index = 0;
        foreach (int item in collection)
        {
            if (index < middle)
            {
                left.Add(item);
            }
            else
            {
                right.Add(item);
            }
            index++;
        }

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
        var merged = new List<int>();
        int leftIndex = 0;
        int rightIndex = 0;

        while (leftIndex < left.Count && rightIndex < right.Count)
        {
            if (left[leftIndex] == right[rightIndex])
            {
                merged.Add(left[leftIndex]);
                leftIndex++;
            }
            else
            {
                merged.Add(right[rightIndex]);
            }
        }

        while (leftIndex < left.Count)
        {
            merged.Add(left[leftIndex]);
            leftIndex++;
        }

        while (rightIndex < right.Count)
        {
            merged.Add(right[rightIndex]);
            rightIndex++;
        }

        return merged;
    }
}