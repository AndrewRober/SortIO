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
        public void Sort(IList<T> list, IComparer<T> comparer = null, bool stable = false)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (comparer == null)
                comparer = Comparer<T>.Default;

            int n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (comparer.Compare(list[j], list[minIndex]) < 0)
                        minIndex = j;

                if (minIndex != i)
                {
                    T temp = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = temp;
                }
            }
        }

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


    /// <summary>
    /// QuickSort is a comparison-based sorting algorithm that works by selecting a 'pivot' element
    /// from the input collection and partitioning the other elements into two groups: those less than
    /// the pivot and those greater than the pivot. The process is then recursively applied to the two
    /// groups, effectively sorting the entire collection.
    ///
    /// QuickSort has an average-case time complexity of O(n * log(n)), making it an efficient choice for
    /// most practical sorting applications. However, the worst-case time complexity is O(n^2), which
    /// occurs when the pivot selection strategy consistently chooses the smallest or largest element
    /// as the pivot. To mitigate this, a good pivot selection strategy is crucial.
    ///
    /// QuickSort is an in-place sort, meaning it doesn't require additional memory for sorting, aside
    /// from a small amount of storage for recursive function calls. It is not a stable sort, so the
    /// relative order of equal elements may change during the sorting process.
    ///
    /// In summary, QuickSort is an efficient comparison-based sorting algorithm suitable for most
    /// practical applications where simplicity and speed are prioritized.
    /// </summary>
    public class QuickSort<T> : ISorter<T>
    {
        /// <summary>
        /// Sorts the entire list using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: QuickSort is not stable.</param>
        public void Sort(IList<T> list, IComparer<T> comparer = null, bool stable = false)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (comparer == null)
                comparer = Comparer<T>.Default;

            QuickSortRecursive(list, 0, list.Count - 1, comparer);
        }

        private void QuickSortRecursive(IList<T> list, int startIndex, int endIndex, IComparer<T> comparer)
        {
            if (startIndex < endIndex)
            {
                int pivotIndex = Partition(list, startIndex, endIndex, comparer);
                QuickSortRecursive(list, startIndex, pivotIndex - 1, comparer);
                QuickSortRecursive(list, pivotIndex + 1, endIndex, comparer);
            }
        }

        private int Partition(IList<T> list, int startIndex, int endIndex, IComparer<T> comparer)
        {
            // Choose pivot (in this case, choosing the last element as pivot)
            T pivot = list[endIndex];

            int i = startIndex - 1;
            for (int j = startIndex; j < endIndex; j++)
            {
                if (comparer.Compare(list[j], pivot) < 0)
                {
                    i++;
                    Swap(list, i, j);
                }
            }
            Swap(list, i + 1, endIndex);

            return i + 1;
        }

        private void Swap(IList<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        /// <summary>
        /// Sorts a range within the list using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list containing the range to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: QuickSort is not stable.</param>
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

            QuickSortRecursive(list, startIndex, startIndex + count - 1, comparer);
        }

        /// <summary>
        /// Sorts the entire list in parallel using the specified comparer and stability option.
        /// Note: Parallel sorting is not implemented for QuickSort in this example.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. Ifnull, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false). Note: QuickSort is not stable.</param>
        public void ParallelSort(IList<T> list, int parallelThreshold = 1000, IComparer<T> comparer = null, bool stable = false)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (comparer == null)
                comparer = Comparer<T>.Default;

            ParallelQuickSortRecursive(list, 0, list.Count - 1, comparer, parallelThreshold);
        }

        /// <summary>
        /// Recursively sorts the specified range of the list using the QuickSort algorithm in parallel.
        /// The parallelism is determined based on the provided parallelThreshold.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="endIndex">The ending index of the range to sort.</param>
        /// <param name="comparer">The comparer used to compare elements.</param>
        /// <param name="parallelThreshold">The threshold to determine when to switch between sequential and parallel sorting.</param>
        private void ParallelQuickSortRecursive(IList<T> list, int startIndex, int endIndex, IComparer<T> comparer, int parallelThreshold)
        {
            if (startIndex < endIndex)
            {
                int pivotIndex = Partition(list, startIndex, endIndex, comparer);

                if (endIndex - startIndex + 1 > parallelThreshold)
                {
                    Parallel.Invoke(
                        () => ParallelQuickSortRecursive(list, startIndex, pivotIndex - 1, comparer, parallelThreshold),
                        () => ParallelQuickSortRecursive(list, pivotIndex + 1, endIndex, comparer, parallelThreshold)
                    );
                }
                else
                {
                    ParallelQuickSortRecursive(list, startIndex, pivotIndex - 1, comparer, parallelThreshold);
                    ParallelQuickSortRecursive(list, pivotIndex + 1, endIndex, comparer, parallelThreshold);
                }
            }
        }
    }
}