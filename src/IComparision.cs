namespace TestExtensions
{
    public interface IComparision
    {
        void GreaterThan(object expected);
        void EqualTo(object expected);
        void OfSize(int size);
        void Null();
    }
}