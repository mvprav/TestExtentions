namespace TestExtensions
{
    public class BeDsl
    {
        private readonly IComparision comparision;

        public BeDsl(IComparision comparision)
        {
            this.comparision = comparision;
        }

        public IComparision Be()
        {
            return comparision;
        }
    }
}