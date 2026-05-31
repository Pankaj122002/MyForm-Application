using Microsoft.AspNetCore.Mvc;
using MyFormApp.Models;
using System.Text.Json;

namespace MyFormApp.Controllers
{
    public class FormController : Controller
    {
        // GET: /Form/InputForm
        [HttpGet]
        public IActionResult InputForm()
        {
            return View(new UserFormModel());
        }

        // POST: /Form/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(UserFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("InputForm", model);
            }

            // Store validated data in TempData (survives one redirect - PRG pattern)
            TempData["FormData"] = JsonSerializer.Serialize(model);

            return RedirectToAction("Summary");
        }

        // GET: /Form/Summary
        [HttpGet]
        public IActionResult Summary()
        {
            var formDataJson = TempData["FormData"] as string;

            if (string.IsNullOrEmpty(formDataJson))
            {
                // No data found — user navigated directly, redirect to form
                return RedirectToAction("InputForm");
            }

            var model = JsonSerializer.Deserialize<UserFormModel>(formDataJson);

            if (model == null)
            {
                return RedirectToAction("InputForm");
            }

            return View(model);
        }
    }
}
