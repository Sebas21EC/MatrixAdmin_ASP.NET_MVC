using Microsoft.AspNetCore.Mvc;

namespace TestMatrixAdmin.Controllers
{
    public class AdminMatrixController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FormWizard()
        {
            //la vista se llema formsView
            return View("MatrixAdmin/FormWizard/FormsView");
        }


    }
}
