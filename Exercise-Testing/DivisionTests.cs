using Algorithms;

namespace Exercise_Testing
{
    internal class DivisionTests
    {
        private Mathematics _testee;

        [SetUp]
        public void Setup()
        {
            _testee = new Mathematics();
        }

        [Test]
        public void Divide_ReturnsCorrectResult()
        {
            // Arrange
            int a = 10;
            int b = 2;
            double expected = 5.0;

            // Act
            double actual = _testee.Divide(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Divide_DivideByZeroThrowsException()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _testee.Divide(a, b));
        }
    }
}
