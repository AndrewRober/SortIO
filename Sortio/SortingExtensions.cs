namespace Sortio
{
    /// <summary>
    /// Extension methods for sorting lists using the specified sorter.
    /// </summary>
    public static class SortingExtensions
    {
        /// <summary>
        /// Sorts the entire list using the specified sorter, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="sorter">The sorter to be used for sorting operations.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public static void Sort<T>(this IList<T> list, ISorter<T> sorter,
            IComparer<T> comparer = null, bool stable = false) => 
            new SortingStrategy<T>(sorter).Sort(list, comparer, stable);

        /// <summary>
        /// Sorts a range within the list using the specified sorter, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list containing the range to be sorted.</param>
        /// <param name="sorter">The sorter to be used for sorting operations.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public static void SortRange<T>(this IList<T> list, ISorter<T> sorter,
            int startIndex, int count, IComparer<T> comparer = null, bool stable = false) => 
            new SortingStrategy<T>(sorter).SortRange(list, startIndex, count, comparer, stable);

        /// <summary>
        /// Sorts the entire list in parallel using the specified sorter, with a specified comparer and stability option.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="sorter">The sorter to be used for sorting operations.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public static void ParallelSort<T>(this IList<T> list, ISorter<T> sorter,
            IComparer<T> comparer = null, bool stable = false) => 
            new SortingStrategy<T>(sorter).ParallelSort(list, comparer, stable);

        /// <summary>
        /// Sorts the entire enumerable using the specified sorter, with a specified comparer and stability option.
        /// </summary>
        /// <param name="enumerable">The enumerable to be sorted.</param>
        /// <param name="sorter">The sorter to be used for sorting operations.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> enumerable, ISorter<T> sorter,
            IComparer<T> comparer = null, bool stable = false)
        {
            // Convert the enumerable to a list
            var list = enumerable.ToList();

            // Call the Sort method on the list using the sorter
            new SortingStrategy<T>(sorter).Sort(list, comparer, stable);

            // Return the sorted list (implicitly converted to IEnumerable<T>)
            return list;
        }

        /// <summary>
        /// Sorts a range within the enumerable using the specified sorter, with a specified comparer and stability option.
        /// </summary>
        /// <param name="enumerable">The enumerable containing the range to be sorted.</param>
        /// <param name="sorter">The sorter to be used for sorting operations.</param>
        /// <param name="startIndex">The starting index of the range to sort.</param>
        /// <param name="count">The number of elements in the range to sort.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public static IEnumerable<T> SortRange<T>(this IEnumerable<T> enumerable, ISorter<T> sorter,
            int startIndex, int count, IComparer<T> comparer = null, bool stable = false)
        {
            // Convert the enumerable to a list
            var list = enumerable.ToList();

            // Call the SortRange method on the list using the sorter
            new SortingStrategy<T>(sorter).SortRange(list, startIndex, count, comparer, stable);

            // Return the sorted list (implicitly converted to IEnumerable<T>)
            return list;
        }

        /// <summary>
        /// Sorts the entire enumerable in parallel using the specified sorter, with a specified comparer and stability option.
        /// </summary>
        /// <param name="enumerable">The enumerable to be sorted.</param>
        /// <param name="sorter">The sorter to be used for sorting operations.</param>
        /// <param name="comparer">Custom comparer for comparing elements. If null, default comparer is used.</param>
        /// <param name="stable">Whether the sort should be stable (true) or not (false).</param>
        public static IEnumerable<T> ParallelSort<T>(this IEnumerable<T> enumerable, ISorter<T> sorter,
            IComparer<T> comparer = null, bool stable = false)
        {
            // Convert the enumerable to a list
            var list = enumerable.ToList();

            // Call the ParallelSort method on the list using the sorter
            new SortingStrategy<T>(sorter).ParallelSort(list, comparer, stable);

            // Return the sorted list (implicitly converted to IEnumerable<T>)
            return list;
        }
    }
}