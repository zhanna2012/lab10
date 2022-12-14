using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(new FormData());
    }

    [HttpPost]
    public IActionResult Index([FromForm] FormData form)
    {
        if (form.ConsultationDate < DateTime.Now)
        {
            ModelState.AddModelError(nameof(FormData.ConsultationDate), "Consultation should be in future");
            return View(form);
        }

        if (form.LanguageConsulstation == "Основи" && form.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
        {
            ModelState.AddModelError(nameof(FormData.LanguageConsulstation), "Language consulatation for 'Основи' can't be on Monday");
            return View(form);
        }

        if (!ModelState.IsValid)
        {
            return View(form);
        }

        return RedirectToAction(nameof(FormCreated));
    }

    public IActionResult FormCreated() => View();
}
