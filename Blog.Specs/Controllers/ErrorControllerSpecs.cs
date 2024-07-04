using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Controllers;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Blog.Specs.Controllers
{
	[Subject("ErrorController")]
	public class ErrorControllerSpecs
	{
		protected static ActionResult Result;
		protected static Mock<ControllerContext> ControllerContext;
		protected static Mock<HttpResponseBase> HttpResponse;
		protected static ErrorController Controller;

		Establish context = () =>
		{
			ControllerContext = new Mock<ControllerContext>();
			HttpResponse = new Mock<HttpResponseBase>();
			ControllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(HttpResponse.Object);
			Controller = new ErrorController
			{
				ControllerContext = ControllerContext.Object
			};
		};
	}

	public class when_invalid_page_is_requested : ErrorControllerSpecs
	{
		Because of = () => Result = Controller.NotFound();

		It should_set_status_code_to_404 = () => HttpResponse.VerifySet(hr => hr.StatusCode = (int)HttpStatusCode.NotFound);
	}

	public class when_a_server_error_is_triggered : ErrorControllerSpecs
	{
		Because of = () => Result = Controller.ServerError();

		It should_set_status_code_to_500 = () => HttpResponse.VerifySet(hr => hr.StatusCode = (int)HttpStatusCode.InternalServerError);
	}
}
