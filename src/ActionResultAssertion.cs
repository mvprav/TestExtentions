using System.Web.Mvc;
using NUnit.Framework;

namespace TestExtensions
{
    public class ActionResultAssertion
    {
        private readonly ActionResult actionResult;

        public ActionResultAssertion(ActionResult actionResult)
        {
            this.actionResult = actionResult;
        }

        public void Render(string viewName)
        {
            ((ViewResult) actionResult).ViewName.Should().Be().EqualTo(viewName);
        }

        public void RedirectTo(string redirectUrl)
        {
            var redirectResult = actionResult as RedirectResult;
            if (redirectResult == null)
                Assert.Fail("Expected a RedirectResult.");
            redirectResult.Url.Should().Be().EqualTo(redirectUrl);
        }

        public void RedirectTo(string expectedAction,string expectedController)
        {
            var redirectResult = actionResult as RedirectToRouteResult;
            var actualAction = redirectResult.RouteValues["action"] as string;
            var actualController = redirectResult.RouteValues["controller"] as string;
            Assert.That(actualAction,Is.EqualTo(expectedAction));
            Assert.That(actualController,Is.EqualTo(expectedController));
        }

        public ActionResultModelAssertion Have()
        {
            return new ActionResultModelAssertion(actionResult);
        }
    }
}