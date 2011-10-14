using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace TestExtensions
{
    public class Assertions
    {
        private readonly object actual;

        public Assertions(object actual)
        {
            this.actual = actual;
        }

        public Comparision Be()
        {
            return new Comparision(actual);
        }

        public void Contain<T>(Func<T, bool> expression)
        {
            var enumerable = (ICollection<T>) actual;
            enumerable.SingleOrDefault(expression);
        }

        public ErrorMessageValidation HaveError(string errorMessage)
        {
            return new ErrorMessageValidation(errorMessage, (IEnumerable<DbEntityValidationResult>) actual);
        }

        public BeDsl Not()
        {
            return new BeDsl( new NegativeComparison(actual));
        }
    }
}