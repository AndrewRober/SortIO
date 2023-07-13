namespace Sortio
{
    /// <summary>
    /// SelectionSort is a simple comparison-based sorting algorithm that works by dividing
    /// the input collection into two parts: the sorted part and the unsorted part. At each step,
    /// the algorithm selects the smallest (or largest) element from the unsorted part and
    /// moves it to the end of the sorted part. This process continues until the entire
    /// collection is sorted.
    ///
    /// The algorithm has a worst-case and average time complexity of O(n^2), making it
    /// inefficient for large datasets. However, SelectionSort performs well for small lists and
    /// is easy to understand and implement.
    ///
    /// SelectionSort is an in-place sort, meaning it doesn't require additional memory for
    /// sorting, aside from a small constant amount of temporary storage for swapping elements.
    /// It is not a stable sort, so the relative order of equal elements may change during the sorting process.
    ///
    /// While SelectionSort is simple to understand and implement, it is generally not the
    /// best choice for sorting large datasets. More efficient algorithms like
    /// QuickSort, MergeSort, or HeapSort should be considered in those cases.
    ///
    /// In summary, SelectionSort is a straightforward sorting algorithm but has
    /// limited efficiency, making it suitable for small datasets where simplicity is prioritized.
    /// </summary>
    public class SelectionSort<T> : ISorter<T>
    {
        /// <summary>
        /// Sorts the entire list using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: Selection sort is not stable.</param>
        public void Sort(IList<T> list, IComparer<T> comparer = null, bool stable = false) =>
        SortRange(list, 0, list.Count, comparer, stable);

        /// <summary>
        /// Sorts a range within the list using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list containing the range to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: Selection sort is not stable.</param>
        public void SortRange(IList<T> list, int startIndex, int count, IComparer<T> comparer = null, bool stable = false)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (startIndex < 0 || startIndex >= list.Count)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (count < 0 || count > list.Count - startIndex)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (comparer == null)
                comparer = Comparer<T>.Default;

            int endIndex = startIndex + count;

            for (int i = startIndex; i < endIndex - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < endIndex; j++)
                {
                    if (comparer.Compare(list[j], list[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    T temp = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = temp;
                }
            }
        }

        /// <summary>
        /// Sorts the entire list in parallel using the specified comparer and stability option.
        /// Note: Parallel sorting is not implemented for SelectionSort as it is inefficient for this algorithm.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: Selection sort is not stable.</param>
        public void ParallelSort(IList<T> list, IComparer<T> comparer = null, bool stable = false)
        {
            throw new NotImplementedException("Parallel sorting is not implemented for SelectionSort.");
        }
    }
}