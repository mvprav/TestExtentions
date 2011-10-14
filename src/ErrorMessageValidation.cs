using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace TestExtensions
{
    public class ErrorMessageValidation
    {
        private readonly string errorMessage;
        private readonly ICollection<DbEntityValidationResult> errorCollection;

        public ErrorMessageValidation(string errorMessage, IEnumerable<DbEntityValidationResult> errorCollection)
        {
            this.errorMessage = errorMessage;
            this.errorCollection = new List<DbEntityValidationResult>(errorCollection);
        }

        public void For<T>(Expression<Func<T, object>> propertyExpression)
        {
            MemberExpression body = (MemberExpression) propertyExpression.Body;
            var propertyName = body.Member.Name;
            bool contains = false;
            foreach (var entityValidationResult in errorCollection)
            {
                DbValidationError dbValidationError =
                    entityValidationResult.ValidationErrors.SingleOrDefault(
                        x => x.ErrorMessage.Equals(errorMessage) && x.PropertyName.Equals(propertyName));
                if (dbValidationError != null)
                {
                    contains = true;
                    break;
                }
            }
            Assert.IsTrue(contains,
                          string.Format(
                              "Validation error collection does not contain error, with message : \"{0}\" for Property \"{1}\"",
                              errorMessage, propertyName));
        }

        public void ForValidationSummary()
        {
            bool contains = false;
            foreach (var entityValidationResult in errorCollection)
            {
                DbValidationError dbValidationError =
                    entityValidationResult.ValidationErrors.SingleOrDefault(x => x.ErrorMessage.Equals(errorMessage));
                if (dbValidationError != null)
                {
                    contains = true;
                    break;
                }
            }
            Assert.IsTrue(contains,
                          string.Format("Validation error collection does not contain error, with message : \"{0}\"",
                                        errorMessage));
        }
    }
}