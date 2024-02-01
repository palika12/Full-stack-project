using EmployeeDetailsWebAPI.Data;
using EmployeeDetailsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EmployeeDetailsWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeDetailsController : Controller
    {
        private EmployeeCRUDappDbContext _employeeCRUDappDbContext;
        public EmployeeDetailsController(EmployeeCRUDappDbContext employeeCRUDappDbContext)
        {
                 this._employeeCRUDappDbContext = employeeCRUDappDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeCRUDappDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.id = Guid.NewGuid();
            await _employeeCRUDappDbContext.Employees.AddAsync(employeeRequest);
            await _employeeCRUDappDbContext.SaveChangesAsync();
            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute]Guid id)
        {
            var employee = await _employeeCRUDappDbContext.Employees.FirstOrDefaultAsync(x => x.id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id , Employee updateEmployeeRequest)
        {
            var employee = await _employeeCRUDappDbContext.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            employee.name = updateEmployeeRequest.name;
            employee.email = updateEmployeeRequest.email;
            employee.phonenumber = updateEmployeeRequest.phonenumber;
            employee.salary = updateEmployeeRequest.salary;
            employee.department = updateEmployeeRequest.department;

             await _employeeCRUDappDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _employeeCRUDappDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _employeeCRUDappDbContext.Employees.Remove(employee);
            await _employeeCRUDappDbContext.SaveChangesAsync(true);
            return Ok(employee);
        }
    }
}
