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
        /// <param name="metrics">Output sorting metrics, such as elapsed time, number of comparisons, and swaps.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        void Sort(IList<T> list, out SortingMetrics metrics, IComparer<T> comparer = null, bool stable = false);

        /// <summary>
        /// Sorts a range within the list using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list containing the range to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="metrics">Output sorting metrics, such as elapsed time, number of comparisons, and swaps.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        void SortRange(IList<T> list, int startIndex, int count, out SortingMetrics metrics,
            IComparer<T> comparer = null, bool stable = false);

        /// <summary>
        /// Sorts the entire list in parallel using the specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="metrics">Output sorting metrics, such as elapsed time, number of comparisons, and swaps.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        void ParallelSort(IList<T> list, out SortingMetrics metrics, IComparer<T> comparer = null, bool stable = false);
    }

    /// <summary>
    /// Implementation of the Merge Sort algorithm.
    /// </summary>
    public class MergeSort<T> : ISorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the entire list using the Merge Sort algorithm, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="metrics">Output sorting metrics, such as elapsed time, number of comparisons, and swaps.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public void Sort(IList<T> list, out SortingMetrics metrics, IComparer<T> comparer = null, bool stable = false)
        {
            // Merge Sort implementation
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sorts a range within the list using the Merge Sort algorithm, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list containing the range to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="metrics">Output sorting metrics, such as elapsed time, number of comparisons, and swaps.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public void SortRange(IList<T> list, int startIndex, int count, out SortingMetrics metrics, IComparer<T> comparer = null, bool stable = false)
        {
            // Merge Sort Range implementation
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sorts the entire list in parallel using the Merge Sort algorithm, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="metrics">Output sorting metrics, such as elapsed time, number of comparisons, and swaps.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public void ParallelSort(IList<T> list, out SortingMetrics metrics, IComparer<T> comparer = null, bool stable = false)
        {
            // Parallel Merge Sort implementation
            throw new NotImplementedException();
        }
    }
}