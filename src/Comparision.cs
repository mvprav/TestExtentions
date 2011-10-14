using System;
using NUnit.Framework;

namespace TestExtensions
{
    public class Comparision : IComparision
    {
        private readonly object actual;

        public Comparision(object actual)
        {
            this.actual = actual;
        }

        public void GreaterThan(object expected)
        {
            Assert.That(actual, Is.GreaterThan(expected));
        }

        public void EqualTo(object expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }

        public void OfSize(int size)
        {
            Assert.That(actual, Has.Count.EqualTo(size));
        }

        public void Null()
        {
            Assert.IsNull(actual);
        }

        public void True()
        {
            Assert.AreEqual(actual,true);
        }

        public void Empty()
        {
            Assert.IsEmpty((string) actual);
        }
    }
}