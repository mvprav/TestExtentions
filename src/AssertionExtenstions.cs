using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace TestExtensions
{
    public static class AssertionExtenstions
    {
        public static Assertions Should(this object actual)
        {
            return new Assertions(actual);
        }

        public static ActionResultAssertion Should(this ActionResult actionResult)
        {
            return new ActionResultAssertion(actionResult);
        }

        public static EntityValidation Should(this IEnumerable<DbEntityValidationResult> enumerable)
        {
            return new EntityValidation(enumerable);
        }
    }
}