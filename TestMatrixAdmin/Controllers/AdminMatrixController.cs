using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using TestMatrixAdmin.Models;

namespace TestMatrixAdmin.Controllers
{
    public class AdminMatrixController : Controller
    {
        public IActionResult Index()
        {
            return View(new Section1());
        }

        public IActionResult FormWizard()
        {
            //la vista se llema formsView
            return View("MatrixAdmin/FormWizard/FormsView");
        }

        [HttpPost]
        public IActionResult SubmitForm(Section1 model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Success");
            }

            return View("Index", model);
        }



        [HttpPost]
        public IActionResult SubmitSection1(Section1 model)
        {
            bool isRegisteredUser = CheckIfUserIsRegistered(model.IdNumber);
            model.IsRegisteredUser = isRegisteredUser;

            if (ModelState.IsValid)
            {
                return Json(new { success = true });
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, errors = errors });
            }
        }

        private bool CheckIfUserIsRegistered(string idNumber)
        {

            return idNumber == "1111111111";
        }




        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Section1()
        {
            return PartialView("MatrixAdmin/FormWizard/Section1/_Section1");
        }


        public IActionResult FormWizardPartial()
        {

            return PartialView("MatrixAdmin/FormWizard/_FormWizard");
        }

        // New user partial
        public IActionResult NewUserPartial()
        {
            var isRegisteredUser = TempData["IsRegisteredUser"] as bool? ?? false;
            var model = new Section1
            {
                IsRegisteredUser = isRegisteredUser
            };

            return PartialView("MatrixAdmin/FormWizard/Section1/_NewUser", model);
        }

        // Registered user partial
        public IActionResult RegisteredUserPartial()
        {
            var isRegisteredUser = TempData["IsRegisteredUser"] as bool? ?? false;
            var model = new Section1
            {
                IsRegisteredUser = isRegisteredUser
            };

            return PartialView("MatrixAdmin/FormWizard/Section1/_RegisteredUser", model);
        }


        [HttpPost]
        public JsonResult CheckCedula(string cedula)
        {
            // Verifica si la cédula ingresada es igual a "1111111111"
            bool isUserRegistered = cedula == "1111111111";
            TempData["IsRegisteredUser"] = isUserRegistered; 
            return Json(new { isUserRegistered = isUserRegistered });
        }

        [HttpPost]
        public JsonResult CheckFingerPrint(string cedula, string fingerprint)
        {
            // PARA EL NUEMRO DE CEDULA 1111111111 EL CODIGO DE HUELLA ES 1234567890 ES TRUE
            bool isFingerPrintValid = cedula != "1111111111" && fingerprint == "1234567890";
            return Json(new { isFingerPrintValid = isFingerPrintValid });
        }




    }
}
