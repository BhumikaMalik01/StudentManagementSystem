using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementServiceLayer.Services;
using System;

namespace StudentManagementSystemAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMarksController : ControllerBase
    {
        private readonly IStudentMarksService _stuService;
        public StudentMarksController(IStudentMarksService appContext)
        {
            _stuService = appContext;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllStudentsMarks()
        {
            try
            {
                var studentMarks = _stuService.GetStudentMarksList();

                if (studentMarks == null) return NotFound();

                return Ok(studentMarks);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }
    }
}
