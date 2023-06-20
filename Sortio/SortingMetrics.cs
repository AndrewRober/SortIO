namespace Sortio
{
    /// <summary>
    /// Class for holding sorting performance metrics.
    /// </summary>
    public class SortingMetrics
    {
        /// <summary>
        /// The elapsed time of the sorting operation.
        /// </summary>
        public long ElapsedTime { get; set; }

        /// <summary>
        /// The number of comparisons performed during the sorting operation.
        /// </summary>
        public long Comparisons { get; set; }

        /// <summary>
        /// The number of swaps performed during the sorting operation.
        /// </summary>
        public long Swaps { get; set; }
    }
}