namespace Sortio
{
    /// <summary>
    /// BubbleSort is a simple comparison-based sorting algorithm that works by repeatedly
    /// stepping through the input collection and swapping adjacent elements if they are in
    /// the wrong order. This process continues until no more swaps are needed, indicating
    /// that the collection is sorted.
    ///
    /// The algorithm has a worst-case and average time complexity of O(n^2), making it
    /// inefficient for large datasets. However, BubbleSort performs well for small lists or
    /// collections that are already partially sorted. It is also an in-place sort, meaning
    /// it doesn't require additional memory for sorting, aside from a small constant amount
    /// of temporary storage for swapping elements.
    ///
    /// BubbleSort is a stable sort, ensuring that the relative order of equal elements
    /// remains unchanged. This can be an important property in some applications. However,
    /// due to its quadratic time complexity, it is not well-suited for parallelization,
    /// limiting its performance on multi-core systems.
    ///
    /// While BubbleSort is simple to understand and implement, it is generally not the
    /// best choice for sorting large datasets, and more efficient algorithms like
    /// QuickSort, MergeSort, or HeapSort should be considered in those cases.
    ///
    /// In summary, BubbleSort is a straightforward and stable sorting algorithm but has
    /// limited efficiency, making it suitable for small datasets or partially sorted
    /// collections where simplicity and stability are prioritized.
    /// </summary>
    public class BubbleSort<T> : ISorter<T>
    {
        /// <summary>
        /// Sorts the entire list using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: Bubble sort is always stable.</param>
        public void Sort(IList<T> list, IComparer<T> comparer = null, bool stable = false)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (comparer == null)
                comparer = Comparer<T>.Default;

            bool swapped;
            int n = list.Count;

            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (comparer.Compare(list[i - 1], list[i]) > 0)
                    {
                        T temp = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = temp;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
        }

        /// <summary>
        /// Sorts a range within the list using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list containing the range to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: Bubble sort is always stable.</param>
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
                for (int j = startIndex; j < endIndex - i - 1; j++)
                {
                    if (comparer.Compare(list[j], list[j + 1]) > 0)
                    {
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the entire list in parallel using the specified comparer and stability option.
        /// Note: Parallel sorting is not implemented for BubbleSort as it is inefficient for this algorithm.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: Bubble sort is always stable.</param>
        public void ParallelSort(IList<T> list, IComparer<T> comparer = null, bool stable = false)
        {
            throw new NotImplementedException("Parallel sorting is not implemented for BubbleSort.");
        }
    }
}