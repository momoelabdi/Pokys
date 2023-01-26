
using Microsoft.AspNetCore.Mvc;
using Pokys.Models;
using Pokys.Data;
using Pokys.Models.Domain;
namespace Pokys.Controllers
{
  public class EmployeesController : Controller
  {
  private readonly MVCDemoDbContext mvcDemoDbContext;
    public EmployeesController(MVCDemoDbContext mvcDemoDbContext)
    {
      this.mvcDemoDbContext = mvcDemoDbContext;
    }

    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
    {
      var employee = new Employee()
      {
        Id = Guid.NewGuid(),
        Name = addEmployeeRequest.Name,
        Email = addEmployeeRequest.Email,
        Salary = addEmployeeRequest.Salary,
        Departement = addEmployeeRequest.Departement,
        DateOfBirth = addEmployeeRequest.DateOfBirth
      };
      await mvcDemoDbContext.Employees.AddAsync(employee);
      await mvcDemoDbContext.SaveChangesAsync();
      return RedirectToAction("Add");
    }

  }

}
