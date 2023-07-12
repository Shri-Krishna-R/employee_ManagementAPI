using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using employee_ManagementAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace employee_ManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Employee obj = new Employee();
        [HttpGet]
        [Route("/list")]
        public IActionResult GetEmployees()
        {
            return Ok(obj.GetAllEmployees());
        }
        [HttpGet]
        [Route("/byid/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var result = obj.GetEmployeeByID(id);               
                
                    return Ok(result);
                
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet]
        [Route("/byname/{name}")]
        public IActionResult GetEmployeeByName(string name)
        {
            try
            {
                var result = obj.GetEmployeeByName(name);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet]
        [Route("/total")]
        public IActionResult GetEmployeeTotal()
        {
            try
            {
                var result = obj.GetTotalEmployees();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        [Route("/bystate/{name}")]
        public IActionResult GetEmployeeState(bool state)
        {
            try
            {
                var result = obj.GetPermenantEmployee(state);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }


        [HttpPost]
        [Route("/add")]
        public IActionResult AddEmployee ([FromBody]Employee employee)
        {
            try
            {
                var result = obj.AddEmployee(employee);
                return Accepted("Employee added");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("/update")]
        public IActionResult UpdateEmployee([FromBody] Employee id)
        {
            try
            {
                var result = obj.UpdateEmployee(id);
                return Accepted("Employee updated");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var result = obj.DeleteEmployee(id);

                return Ok("employee deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }
}
