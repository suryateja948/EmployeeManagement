using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.DataAccessProviders.Interfaces;
using EmployeeManagement.Model;
using EmployeeManagement.Util;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Controllers
{
    
    public class EmployeeDAPController : ControllerBase
    {
        private IEmployeeDAP _dataAccessProvider;
        public EmployeeDAPController(IEmployeeDAP dataAccessProvider )
        {
            _dataAccessProvider = dataAccessProvider;
            
        }


        [HttpPost]
        [Route("api/[controller]/AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeClass model)
        {
            try
            {
                
                return Ok(await _dataAccessProvider.AddEmployee(model));
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }
        }



        [HttpPost]
        [Route("api/[controller]/AddBranch")]
        public async Task<IActionResult> AddBranch([FromBody] BranchClass model)
        {
            try
            {

                return Ok(await _dataAccessProvider.AddBranch(model));
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }
        }

        [HttpPost]
        [Route("api/[controller]/AddMarks")]
        public async Task<IActionResult> AddMarks([FromBody] MarksClass model)
        {
            try
            {

                return Ok(await _dataAccessProvider.AddMarks(model));
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }
        }

        [HttpPost]
        [Route("api/[controller]/AddSubjects")]
        public async Task<IActionResult> AddSubjects([FromBody] SubjectsClass model)
        {
            try
            {

                return Ok(await _dataAccessProvider.AddSubjects(model));
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }
        }

        [HttpPost]
        [Route("api/[controller]/AddBranchSubjects")]
        public async Task<IActionResult> AddBranchSubjects([FromBody] BranchSubjectsClass model)
        {
            try
            {

                return Ok(await _dataAccessProvider.AddBranchSubjects(model));
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                
                return Ok(await _dataAccessProvider.GetEmployees());
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpGet]
        [Route("api/[controller]/GetBranch")]
        public async Task<IActionResult> GetBranch()
        {
            try
            {
                return Ok(await _dataAccessProvider.GetBranch());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpGet]
        [Route("api/[controller]/GetMarks")]
        public async Task<IActionResult> GetMarks()
        {
            try
            {
                return Ok(await _dataAccessProvider.GetMarks());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpGet]
        [Route("api/[controller]/GetSubjects")]
        public async Task<IActionResult> GetSubjects()
        {
            try
            {
                return Ok(await _dataAccessProvider.GetSubjects());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpGet]
        [Route("api/[controller]/GetBranchSubjects")]
        public async Task<IActionResult> GetBranchSubjects()
        {
            try
            {
                return Ok(await _dataAccessProvider.GetBranchSubjects());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpPost]
        [Route("api/[controller]/UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeClass model)
        {
            try
            { 
                return Ok(await _dataAccessProvider.UpdateEmployee(model));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpPost]
        [Route("api/[controller]/UpdateBranch")]
        public async Task<IActionResult> UpdateBranch([FromBody] BranchClass model)
        {
            try
            {
                return Ok(await _dataAccessProvider.UpdateBranch(model));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpPost]
        [Route("api/[controller]/UpdateMarks")]
        public async Task<IActionResult> UpdateMarks([FromBody] MarksClass model)
        {
            try
            {
                return Ok(await _dataAccessProvider.UpdateMarks(model));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpPost]
        [Route("api/[controller]/UpdateSubjects")]
        public async Task<IActionResult> UpdateSubjects([FromBody] SubjectsClass model)
        {
            try
            {
                return Ok(await _dataAccessProvider.UpdateSubjects(model));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpPost]
        [Route("api/[controller]/UpdateBranchSubjects")]
        public async Task<IActionResult> UpdateBranchSubjects([FromBody] BranchSubjectsClass model)
        {
            try
            {
                return Ok(await _dataAccessProvider.UpdateBranchSubjects(model));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }
        [HttpDelete]
        [Route("api/[controller]/DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                
                return Ok(await _dataAccessProvider.DeleteEmployee(id));
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteBranch/{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            try
            {

                return Ok(await _dataAccessProvider.DeleteBranch(id));
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteMarks/{id}")]
        public async Task<IActionResult> DeleteMarks(int id)
        {
            try
            {

                return Ok(await _dataAccessProvider.DeleteMarks(id));
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteSubjects/{id}")]
        public async Task<IActionResult> DeleteSubjects(int id)
        {
            try
            {

                return Ok(await _dataAccessProvider.DeleteSubjects(id));
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteBranchSubjects/{id}")]
        public async Task<IActionResult> DeleteBranchSubjects(int id)
        {
            try
            {

                return Ok(await _dataAccessProvider.DeleteBranchSubjects(id));
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetMarksBySubjects")]
        public async Task<IActionResult> GetMarksBySubjects()
        {
            try
            {

                return Ok(await _dataAccessProvider.GetMarksBySubjects());
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpGet]
        [Route("api/[controller]/GetMarksByBranch")]
        public async Task<IActionResult> GetMarksByBranch()
        {
            try
            {

                return Ok(await _dataAccessProvider.GetMarksByBranch());
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpGet]
        [Route("api/[controller]/GetLeastMarksBySubjects")]
        public async Task<IActionResult> GetLeastMarksBySubjects()
        {
            try
            {

                return Ok(await _dataAccessProvider.GetLeastMarksBySubjects());
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }
        [HttpGet]
        [Route("api/[controller]/GetTopMarksByBranch")]
        public async Task<IActionResult> GetTopMarksByBranch()
        {
            try
            {

                return Ok(await _dataAccessProvider.GetTopMarksByBranch());
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

        [HttpGet]
        [Route("api/[controller]/GetLeastMarksByBranch")]
        public async Task<IActionResult> GetLeastMarksByBranch()
        {
            try
            {

                return Ok(await _dataAccessProvider.GetLeastMarksByBranch());
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseData(false, (ex.InnerException == null ? ex.Message : ex.InnerException.Message), 500));
            }

        }

    }
}
