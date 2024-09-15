using System.Collections.ObjectModel;
using Algorithms;
using Exercise_Testing.Help;

namespace Exercise_Testing
{
    public class ElementSearchFailingTest
    {
        private ElementSearch _testee;

        [SetUp]
        public void Setup()
        {
            _testee = new ElementSearch();
        }

        [Test]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, true)]
        [TestCase(6, new int[] { 1, 2, 3, 4, 5 }, false)]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, true)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, false)]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, false)]
        public void ElementSearchTest(int target, int[] array, bool expected)
        {
            bool result = _testee.ContainsElement(array, target);
            Assert.AreEqual(expected, result);
        }
    }
}