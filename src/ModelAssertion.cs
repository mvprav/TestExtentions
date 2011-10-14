using System;
using System.Web.Mvc;

namespace TestExtensions
{
    public class ModelAssertion
    {
        private readonly ActionResult actionResult;

        public ModelAssertion(ActionResult actionResult)
        {
            this.actionResult = actionResult;
        }

        public void OfType(Type type)
        {
            ((ViewResult)actionResult).Model.GetType().Should().Be().EqualTo(type);
        }

        public void WithValues<T>(Func<T, bool> func) where T:class 
        {
            var model = ((ViewResult) actionResult).Model as T;
            func.Invoke(model).Should().Be().True();
        }
    }
}