using System.Web.Mvc;

namespace TestExtensions
{
    public class ActionResultModelAssertion
    {
        private readonly ActionResult actionResult;

        public ActionResultModelAssertion(ActionResult actionResult)
        {
            this.actionResult = actionResult;
        }

        public ModelAssertion Model()
        {
            return new ModelAssertion(actionResult);
        }

        public void ViewData(string key, string value)
        {
           ((ViewResult)actionResult).ViewData[key].Should().Be().EqualTo(value);
        }
    }
}