
using Microsoft.AspNetCore.Mvc;

namespace Pokys.Controllers
{
  public class EmployeesController : Controller
  {

    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }

  }

}
