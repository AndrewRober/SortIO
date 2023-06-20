namespace Sortio
{
    /// <summary>
    /// Class for managing sorting strategy and applying the chosen sorter.
    /// </summary>
    public class SortingStrategy<T>
    {
        /// <summary>
        /// The sorter used for sorting operations.
        /// </summary>
        private ISorter<T> _sorter;

        /// <summary>
        /// Initializes a new instance of the SortingStrategy class with the specified sorter.
        /// </summary>
        /// <param name="sorter">The sorter to be used for sorting operations.</param>
        public SortingStrategy(ISorter<T> sorter) => this._sorter = sorter;

        /// <summary>
        /// Sets a new sorter for sorting operations.
        /// </summary>
        /// <param name="sorter">The sorter to be used for sorting operations.</param>
        public void SetSorter(ISorter<T> sorter) => this._sorter = sorter;

        /// <summary>
        /// Sorts the entire list using the specified sorter, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="metrics">Output sorting metrics, such as elapsed time, number of comparisons, and swaps.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public void Sort(IList<T> list, out SortingMetrics metrics,
            IComparer<T> comparer = null, bool stable = false) => 
            _sorter.Sort(list, out metrics, comparer, stable);

        /// <summary>
        /// Sorts a range within the list using the specified sorter, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list containing the range to be sorted.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="metrics">Output sorting metrics, such as elapsed time, number of comparisons, and swaps.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public void SortRange(IList<T> list, int startIndex, int count,
            out SortingMetrics metrics, IComparer<T> comparer = null, bool stable = false) => 
            _sorter.SortRange(list, startIndex, count, out metrics, comparer, stable);

        /// <summary>
        /// Sorts the entire list in parallel using the specified sorter, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="metrics">Output sorting metrics, such as elapsed time, number of comparisons, and swaps.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public void ParallelSort(IList<T> list, out SortingMetrics metrics,
            IComparer<T> comparer = null, bool stable = false) => 
            _sorter.ParallelSort(list, out metrics, comparer, stable);
    }
}