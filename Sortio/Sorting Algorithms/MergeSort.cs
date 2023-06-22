namespace Sortio
{
    /// <summary>
    /// MergeSort is a divide-and-conquer sorting algorithm that works by recursively dividing
    /// the input collection into two equal halves, sorting each half, and then merging the
    /// sorted halves back together. The key step is the merge operation, which combines two
    /// sorted arrays into a single sorted array efficiently.
    ///
    /// The algorithm has a time complexity of O(n*log(n)) for both average and worst-case
    /// scenarios, making it an efficient choice for sorting large datasets. MergeSort is a
    /// stable sort, meaning that the relative order of equal elements remains unchanged.
    /// Additionally, MergeSort can be parallelized effectively, further improving its
    /// performance on multi-core systems.
    ///
    /// MergeSort is well-suited for sorting linked lists, as it requires only O(log(n))
    /// additional space for recursive calls (compared to O(n) for arrays). However, it is
    /// less efficient for small lists or arrays compared to some other algorithms, like
    /// QuickSort or Insertion Sort, due to its higher overhead.
    ///
    /// In summary, MergeSort is a reliable and efficient sorting algorithm, especially
    /// suitable for large datasets, linked lists, and cases where stability is required.
    /// </summary>
    public class MergeSort<T> : ISorter<T> where T : IComparable<T>
    {
        private IComparer<T> _comparer;

        /// <summary>
        /// Sorts the entire list using the Merge Sort algorithm, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public void Sort(IList<T> list, IComparer<T> comparer = null, bool stable = true)
        {
            _comparer = comparer ?? Comparer<T>.Default;
            MergeSortInternal(list, 0, list.Count);
        }

        /// <summary>
        /// Sorts a range within the list using the Merge Sort algorithm, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list containing the range to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public void SortRange(IList<T> list, int startIndex, int count,
            IComparer<T> comparer = null, bool stable = true)
        {
            _comparer = comparer ?? Comparer<T>.Default;
            MergeSortInternal(list, startIndex, count);
        }

        /// <summary>
        /// Sorts the entire list in parallel using the Merge Sort algorithm, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public void ParallelSort(IList<T> list, IComparer<T> comparer = null, bool stable = true)
        {
            _comparer = comparer ?? Comparer<T>.Default;
            ParallelMergeSortInternal(list, 0, list.Count);
        }

        /// <summary>
        /// Recursively sorts the list using the MergeSort algorithm.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        private void MergeSortInternal(IList<T> list, int startIndex, int count)
        {
            if (count <= 1) return;

            int midIndex = startIndex + count / 2;
            int leftCount = midIndex - startIndex;
            int rightCount = count - leftCount;

            MergeSortInternal(list, startIndex, leftCount);
            MergeSortInternal(list, midIndex, rightCount);

            Merge(list, startIndex, leftCount, midIndex, rightCount);
        }

        /// <summary>
        /// Merges two sorted sublists into a single sorted sublist.
        /// </summary>
        /// <param name="list">The list containing the sublists to be merged.</param>
        /// <param name="leftStart">The starting index of the left sublist.</param>
        /// <param name="leftCount">The number of elements in the left sublist.</param>
        /// <param name="rightStart">The starting index of the right sublist.</param>
        /// <param name="rightCount">The number of elements in the right sublist.</param>
        private void Merge(IList<T> list, int leftStart, int leftCount, int rightStart, int rightCount)
        {
            int totalElements = leftCount + rightCount;
            List<T> tempList = new List<T>(totalElements);

            int leftIndex = leftStart;
            int rightIndex = rightStart;

            while (leftIndex < leftStart + leftCount && rightIndex < rightStart + rightCount)
            {
                if (_comparer.Compare(list[leftIndex], list[rightIndex]) <= 0)
                    tempList.Add(list[leftIndex++]);
                else
                    tempList.Add(list[rightIndex++]);
            }

            while (leftIndex < leftStart + leftCount)
                tempList.Add(list[leftIndex++]);

            while (rightIndex < rightStart + rightCount)
                tempList.Add(list[rightIndex++]);

            for (int i = 0; i < totalElements; i++)
                list[leftStart + i] = tempList[i];
        }

        /// <summary>
        /// Recursively sorts the list in parallel using the MergeSort algorithm.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        private void ParallelMergeSortInternal(IList<T> list, int startIndex, int count)
        {
            if (count <= 1) return;

            int midIndex = startIndex + count / 2;
            int leftCount = midIndex - startIndex;
            int rightCount = count - leftCount;

            Parallel.Invoke(
                () => ParallelMergeSortInternal(list, startIndex, leftCount),
                () => ParallelMergeSortInternal(list, midIndex, rightCount)
            );

            Merge(list, startIndex, leftCount, midIndex, rightCount);
        }
    }
}