using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagementDomainLayer.Models;
using StudentManagementServiceLayer.Services;
using System;
using System.Threading.Tasks;

namespace StudentManagementSystemAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _stuService;
        private readonly ILogger<StudentController> _Logger;
        public StudentController(IStudentService appContext, ILogger<StudentController> Logger)
        {
            _Logger = Logger;
            _stuService = appContext;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllStudents()
        {
            _Logger.LogInformation("student endpoint starts");
            var student = await _stuService.GetStudentList();
            try
            {

                if (student == null) return NotFound();

                _Logger.LogInformation("student endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            return Ok(student);
        }


        [HttpDelete]

        [Route("[action]")]
        public IActionResult DeleteStudentByEmpId(int stuid)
        {
            _Logger.LogInformation("student endpoint starts");

            try
            {

                var responseModel = _stuService.DeleteStudent(stuid);
                if (responseModel == null) return NotFound();
                _Logger.LogInformation("student endpoint completed");

                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("[action]/stuid")]
        public ActionResult SearcStudentById(int stuid)
        {
            _Logger.LogInformation("student endpoint starts");
            Student stu;
            try
            {
                stu = _stuService.SearchStudent(stuid);

                _Logger.LogInformation("student endpoint completed");
            }

            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest("Not Found");
            }
            return Ok(stu);
        }


        //[HttpPost]
        //[Route("[action]")]
        //public IActionResult AddStudentById(Student StudentData)
        //{

        //    try
        //    {

        //        var responseModel = _stuService.AddStudent(StudentData);

        //        if (responseModel == null) return NotFound();

        //        return Ok(responseModel);

        //    }

        //    catch (Exception ex)
        //    {

        //        return BadRequest();
        //    }

        //}


        //[HttpPut(nameof(AddStudentById))]
        [HttpPost(nameof(AddStudentById))]
        public ActionResult AddStudentById(Student stu)
        {
            _Logger.LogInformation("student endpoint starts");
            try
            {

                _stuService.AddStudent(stu);

                _Logger.LogInformation("student endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
            }
            return Ok("Student Added");
        }


        [HttpPut(nameof(UpdateStudentDetail))]
        public ActionResult UpdateStudentDetail(Student stu)
        {
            _stuService.UpdateStudent(stu);
            return Ok("Student Updated");
        }



        //[HttpPut]
        //public ActionResult EditStudent(int stuId, Student stu)
        //{
        //    try
        //    {
        //        var student = from c in db.Student
        //                      where c.CustomerID == stuId
        //                      select c;

        //        stu.StudentID = stuId;
        //        _stuService.UpdateStudent(stu);
        //        return Ok(student);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest("Not Found");
        //    }
        //}
    }
}
