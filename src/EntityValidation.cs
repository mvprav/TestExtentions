using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace TestExtensions
{
    public class EntityValidation
    {
        private readonly IEnumerable<DbEntityValidationResult> actual;

        public EntityValidation(IEnumerable<DbEntityValidationResult> actual)
        {
            this.actual = actual;
        }

        public ErrorMessageValidation HaveError(string errorMessage)
        {
            return new ErrorMessageValidation(errorMessage, (IEnumerable<DbEntityValidationResult>)actual);
        }
    }
}