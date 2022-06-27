using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiUriBody.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeOrganizationController : ControllerBase
    {
        static List<EmployeeOrganization> employeeOraganizations = new List<EmployeeOrganization>();

        [HttpGet]
        public ActionResult GetEmployeeOrganization()
        {
            if (employeeOraganizations == null)
            {
                return Ok("List is Empty");
            }
            else
            {
                var employeeOrgObj = JsonConvert.SerializeObject(employeeOraganizations);
                return Ok(employeeOrgObj);
            }
        }
        [HttpGet]
        public ActionResult GetEmployeeOrganization([System.Web.Http.FromUri] int id)
        {
            var employeeOrganizationObj = employeeOraganizations.Where(x => x.Id == id).FirstOrDefault();
            if (employeeOrganizationObj == null)
            {
                return Ok("Employee not exixts");
            }
            else
            {
                var employeeOrgObj = JsonConvert.SerializeObject(employeeOrganizationObj);
                return Ok(employeeOrgObj);
            }
        }
        //update
        [HttpPut]
        public ActionResult PutEmployeeOrganization([System.Web.Http.FromBody] int id, EmployeeOrganization UpdateEmployeeOrganization)
        {
            if (id != UpdateEmployeeOrganization.Id)
            {
                return BadRequest();
            }
            else
            {
                var employeeOrganizationObj = employeeOraganizations.Where(emp => emp.Id == id).FirstOrDefault();
                if (employeeOrganizationObj == null)
                {
                    return BadRequest();
                }
                else
                {
                    employeeOraganizations.Remove(employeeOrganizationObj);
                    employeeOraganizations.Add(UpdateEmployeeOrganization);
                    var employeeObj = JsonConvert.SerializeObject(employeeOraganizations);
                    return Ok(employeeObj);
                }
            }
        }
        //new add
        [HttpPost]
        public ActionResult PostEmployeeOrganization([System.Web.Http.FromBody] EmployeeOrganization employeeOraganization)
        {
            if (employeeOraganization == null)
            {
                return BadRequest();
            }
            else
            {
                employeeOraganizations.Add(employeeOraganization);
                var employeeObj = JsonConvert.SerializeObject(employeeOraganizations);
                return Ok(employeeObj);
            }
        }

        [HttpDelete]
        public ActionResult DeleteemployeeOraganizationanization([System.Web.Http.FromUri] int id)
        {
            var employeeOraganization = employeeOraganizations.Where(emp => emp.Id == id).FirstOrDefault();
            if (employeeOraganization == null)
            {
                return NotFound();
            }
            else
            {
                employeeOraganizations.Remove(employeeOraganization);
                var employeeObj = JsonConvert.SerializeObject(employeeOraganizations);
                return Ok(employeeObj);
            }

        }
    }
}
