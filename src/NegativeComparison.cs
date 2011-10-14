using NUnit.Framework;

namespace TestExtensions
{
    public class NegativeComparison : IComparision
    {
        private readonly object actual;

        public NegativeComparison(object actual)
        {
            this.actual = actual;
        }

        public void GreaterThan(object expected)
        {
            Assert.That(actual, Is.Not.GreaterThan(expected));
        }

        public void EqualTo(object expected)
        {
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        public void OfSize(int size)
        {
            Assert.That(actual, Has.Count.Not.EqualTo(size));
        }

        public void Null()
        {
            Assert.IsNotNull(actual);
        }
    }
}