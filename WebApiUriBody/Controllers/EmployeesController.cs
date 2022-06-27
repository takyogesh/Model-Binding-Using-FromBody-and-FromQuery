using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiUriBody.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
      
       static List<Employee> employees =new List<Employee>();

        [HttpGet]
        public ActionResult GetEmployee()
        {
          if (employees == null)
          {
                return Ok("List is Empty");
          }
          else
            {
                var employeeObj = JsonConvert.SerializeObject(employees);
                return Ok(employeeObj);
            }
        }
        [HttpGet]
        public ActionResult GetEmployee([System.Web.Http.FromUri]int id)
        {
            var employee = employees.Where(x => x.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return Ok("Employee not exixts");
            }
            else
            {
                var employeeObj = JsonConvert.SerializeObject(employees);
                return Ok(employeeObj);
            }
        }
        //update
        [HttpPut]
        public ActionResult PutEmployee([System.Web.Http.FromBody]int id, Employee UpdateEmployee)
        {
            if (id != UpdateEmployee.Id)
            {
                return BadRequest();
            }
            else
            {
                var employee=employees.Where(emp=>emp.Id==id).FirstOrDefault();
                if (employee == null)
                {
                    return BadRequest();
                }
                else
                {
                    employees.Remove(employee);
                    employees.Add(UpdateEmployee);
                    var employeeObj = JsonConvert.SerializeObject(employees);
                    return Ok(employeeObj);
                }
            }
        }
        //new add
        [HttpPost]
        public ActionResult PostEmployee([System.Web.Http.FromBody]Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            else
            {
                employees.Add(employee);
                var employeeObj = JsonConvert.SerializeObject(employees);
                return Ok(employeeObj);
            }
        }

        [HttpDelete]
        public ActionResult DeleteEmployee([System.Web.Http.FromUri]int id)
        {
            var employee =employees.Where(emp=> emp.Id==id).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                employees.Remove(employee);
                var employeeObj = JsonConvert.SerializeObject(employees);
                return Ok(employeeObj);
            }
            
        }
      
    }
}
