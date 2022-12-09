using EmployeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Context context;
        List<Employee> employees = new List<Employee>();
        public EmployeeController(Context _context)
        {
            context = _context;
        }
        // api method to retuen list of items
        [HttpGet("Get")]
        public IActionResult Get()
        {
            List<Employee> employees = context.Employees.ToList();

            return Ok(employees);
        }

        // api method return one item by ID
        // route = api/TodoItems/id
        [HttpGet("GetById")]
        public ActionResult<Employee> GetById(int id)
        {
            var item = context.Employees.FirstOrDefault(a => a.Id == id);

            if (item == null)
                return NotFound();
            return Ok(item);
        }

        //[HttpGet]
        [HttpGet("FindByName")]
        public IActionResult FindByName(string name)
        {

            var item = context.Employees.FirstOrDefault(s => s.FirstName == name);
            if (item == null)
            {
                return BadRequest("Name Not Founded");
            }

            return Ok(item);
        }

        [HttpPost("Post")]
        // [ApiConventionType(typeof(DefaultApiConventions))]
        public ActionResult Post(Employee emp)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(emp);
                context.SaveChanges();
                return CreatedAtAction("GetById", emp.Id, employees);
            }
            return BadRequest(ModelState);
        }
        #region MyRegion

        //// route segment
        //[HttpPut("{id:int}")] //api/Employee/1
        //public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] Employee emp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee oldEmp = context.Employees.FirstOrDefault(s => s.Id == id);
        //        oldEmp.Name = emp.Name;
        //        oldEmp.Salary = emp.Salary;
        //        oldEmp.adress = emp.adress;
        //        context.SaveChanges();
        //        return StatusCode(StatusCodes.Status204NoContent, "Data Updated");
        //    }

        //    return BadRequest("Data Not Valid");

        //}


        //[HttpDelete("{id:int}")]
        //public IActionResult DeleteEmployee(int id)
        //{
        //    Employee oldemp = context.Employees.FirstOrDefault(s => s.Id == id);
        //    context.Employees.Remove(oldemp);
        //    context.SaveChanges();
        //    return StatusCode(StatusCodes.Status200OK, "Data Deleted");

        //}
        #endregion

    }
}
