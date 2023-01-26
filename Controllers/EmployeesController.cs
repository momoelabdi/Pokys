
using Microsoft.AspNetCore.Mvc;
using Pokys.Models;
using Pokys.Data;
using Pokys.Models.Domain;
using Microsoft.EntityFrameworkCore;
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
    public async Task<IActionResult> Index()
    {
      var employees = await mvcDemoDbContext.Employees.ToListAsync();
      return View(employees);
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
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> View(Guid id)
    {
      var employee = await mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

      if (employee != null)
      {
        var viewModel = new UpdateEmployeeViewModel()
        {
          Id = employee.Id,
          Name = employee.Name,
          Email = employee.Email,
          Salary = employee.Salary,
          Departement = employee.Departement,
          DateOfBirth = employee.DateOfBirth
        };
        return await Task.Run(() => View("View", viewModel));
      }
      return View("index");
    }
    [HttpPost]
    public async Task<IActionResult> View(UpdateEmployeeViewModel model)
    {
      var employee = await mvcDemoDbContext.Employees.FindAsync(model.Id);
        if (employee != null)
        {
            employee.Name = model.Name;
            employee.Email = model.Email;
            employee.Salary = model.Salary;
            employee.Departement = model.Departement;
            employee.DateOfBirth = model.DateOfBirth;
            await mvcDemoDbContext.SaveChangesAsync();

          return RedirectToAction("Index");
        }
        return View("index");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
    {
      var employee = await mvcDemoDbContext.Employees.FindAsync(model.Id);
      if (employee != null)
      {
        mvcDemoDbContext.Employees.Remove(employee);
        await mvcDemoDbContext.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return RedirectToAction("Index");
    }



  }

}
