using AttendanceManagementAppService;
using AttendanceManagementModels;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceControl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceAppService _appService;

        public AttendanceController()
        {
            _appService = new AttendanceAppService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_appService.GetAttendance());
        }

        [HttpPost]
        public IActionResult Add([FromBody] AttendanceItems item)
        {
            if (item == null)
                return BadRequest();

            _appService.AddRecord(
                item.StudentName,
                item.Day,
                item.Status);

            return Ok(item);
        }

        [HttpPut]
        public IActionResult Update([FromBody] AttendanceItems item)
        {
            if (item == null)
                return BadRequest();

            _appService.UpdateRecord(
                item.StudentName,
                item.Day,
                item.Status);

            return NoContent();
        }

        [HttpDelete("{studentName}")]
        public IActionResult Delete(string studentName)
        {
            _appService.DeleteRecord(studentName);

            return NoContent();
        }
    }
}