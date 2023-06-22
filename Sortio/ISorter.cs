namespace Sortio
{
    /// <summary>
    /// Interface for sorting algorithms in the library.
    /// </summary>
    public interface ISorter<T>
    {
        /// <summary>
        /// Sorts the entire list using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        void Sort(IList<T> list, IComparer<T> comparer = null, bool stable = false);

        /// <summary>
        /// Sorts a range within the list using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list containing the range to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        void SortRange(IList<T> list, int startIndex, int count,
            IComparer<T> comparer = null, bool stable = false);

        /// <summary>
        /// Sorts the entire list in parallel using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        void ParallelSort(IList<T> list, IComparer<T> comparer = null, bool stable = false);
    }
}