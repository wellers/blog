using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult NotFound()
        {
            return View("Error");
        }
    }
}
