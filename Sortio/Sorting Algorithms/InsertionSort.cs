namespace Sortio
{
    /// <summary>
    /// InsertionSort is a simple comparison-based sorting algorithm that works by dividing the input
    /// collection into a sorted and unsorted region. The algorithm repeatedly takes the first element
    /// in the unsorted region and inserts it into its correct position in the sorted region.
    ///
    /// The algorithm has a worst-case and average time complexity of O(n^2), making it inefficient
    /// for large datasets. However, InsertionSort performs well for small lists or collections that
    /// are already partially sorted. It is also an in-place sort, meaning it doesn't require
    /// additional memory for sorting, aside from a small constant amount of temporary storage for
    /// inserting elements.
    ///
    /// InsertionSort is a stable sort, ensuring that the relative order of equal elements remains
    /// unchanged. This can be an important property in some applications. However, due to its
    /// quadratic time complexity, it is not well-suited for parallelization, limiting its
    /// performance on multi-core systems.
    ///
    /// While InsertionSort is simple to understand and implement, it is generally not the best
    /// choice for sorting large datasets, and more efficient algorithms like QuickSort,
    /// MergeSort, or HeapSort should be considered in those cases.
    ///
    /// In summary, InsertionSort is a straightforward and stable sorting algorithm but has limited
    /// efficiency, making it suitable for small datasets or partially sorted collections where
    /// simplicity and stability are prioritized.
    /// </summary>
    public class InsertionSort<T> : ISorter<T>
    {
        /// <summary>
        /// Sorts the entire list using the specified comparer and stability option (if the algorithm supports it).
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: Insertion sort is always stable.</param>
        public void Sort(IList<T> list, IComparer<T> comparer = null, bool stable = false)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (comparer == null)
                comparer = Comparer<T>.Default;

            for (int i = 1; i < list.Count; i++)
            {
                T currentElement = list[i];
                int j = i - 1;

                while (j >= 0 && comparer.Compare(list[j], currentElement) > 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = currentElement;
            }
        }

        /// <summary>
        /// Sorts a range within the list using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list containing the range to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: Insertion sort is always stable.</param>
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

            for (int i = startIndex + 1; i < endIndex; i++)
            {
                T temp = list[i];
                int j = i - 1;
                while (j >= startIndex && comparer.Compare(list[j], temp) > 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = temp;
            }
        }

        /// <summary>
        /// Throws NotSupportedException. Insertion sort is not well-suited for parallelization.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: Insertion sort is always stable.</param>
        /// <exception cref="NotSupportedException">Always throws NotSupportedException.</exception>
        public void ParallelSort(IList<T> list, IComparer<T> comparer = null, bool stable = false) => 
            throw new NotSupportedException("Insertion sort is not well-suited for parallelization.");
    }
}