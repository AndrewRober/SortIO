using Sortio;

using TestProject.TestingObjects;

namespace TestProject
{
    /// <summary>
    /// This test class is designed to test the MergeSort implementation for various scenarios.
    /// The tests cover cases such as empty lists, single elements, duplicate elements, and negative values.
    /// Additionally, we test the stability of the MergeSort algorithm using custom objects.
    /// </summary>
    [TestFixture]
    public class MergeSortTests
    {
        private MergeSort<int> _mergeSort;
        private MergeSort<CustomObject> _mergeSort2;

        [SetUp]
        public void Setup()
        {
            _mergeSort = new MergeSort<int>();
            _mergeSort2 = new MergeSort<CustomObject>();
        }

        /// <summary>
        /// Test sorting an empty list. The result should be an empty list with zero comparisons and swaps.
        /// </summary>
        [Test]
        public void Test_EmptyList()
        {
            List<int> list = new List<int>();
            _mergeSort.Sort(list);

            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Test sorting a list with a single element. The result should be a list with the same element, and zero comparisons and swaps.
        /// </summary>
        [Test]
        public void Test_SingleElement()
        {
            List<int> list = new List<int> { 1 };
            _mergeSort.Sort(list);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(1, list[0]);
        }

        /// <summary>
        /// Test sorting a list with duplicate elements. The result should be a sorted list with duplicate elements in their correct order.
        /// </summary>
        [Test]
        public void Test_DuplicateElements()
        {
            List<int> list = new List<int> { 5, 3, 5, 1, 5 };
            _mergeSort.Sort(list);

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(5, list[2]);
            Assert.AreEqual(5, list[3]);
            Assert.AreEqual(5, list[4]);
        }

        /// <summary>
        /// Test sorting a list with negative values. The result should be a sorted list with negative values in their correct order.
        /// </summary>
        [Test]
        public void Test_NegativeValues()
        {
            List<int> list = new List<int> { -5, 3, 0, -1, 5 };
            _mergeSort.Sort(list);

            Assert.AreEqual(-5, list[0]);
            Assert.AreEqual(-1, list[1]);
            Assert.AreEqual(0, list[2]);
            Assert.AreEqual(3, list[3]);
            Assert.AreEqual(5, list[4]);
            Assert.AreEqual(5, list.Count);
        }


        /// <summary>
        /// Test the stability of the MergeSort algorithm using custom objects with unique IDs and equal values.
        /// The result should be a sorted list with the original order of equal elements preserved.
        /// </summary>
        [Test]
        public void Test_MergeSortStability()
        {
            List<CustomObject> list = new List<CustomObject>
            {
                new CustomObject(1, 5),
                new CustomObject(2, 3),
                new CustomObject(3, 5),
                new CustomObject(4, 1),
                new CustomObject(5, 5)
            };

            _mergeSort2.Sort(list);

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(4, list[0].Id);
            Assert.AreEqual(2, list[1].Id);
            Assert.AreEqual(1, list[2].Id);
            Assert.AreEqual(3, list[3].Id);
            Assert.AreEqual(5, list[4].Id);
        }
    }
}