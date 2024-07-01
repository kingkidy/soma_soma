using Microsoft.AspNetCore.Mvc;

namespace thesoma.Controllers
{
    public class StudentProfileController : Controller
    {
        public IActionResult StudentProfile()
        {
            return View();
        }
    }
}
