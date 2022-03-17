using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementDomainLayer.Models;
using StudentManagementServiceLayer.Services;
using System;

namespace StudentManagementSystemAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _stuService;
        public StudentController(IStudentService appContext)
        {
            _stuService = appContext;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllStudents()
        {
            try
            {
                var student = _stuService.GetStudentList();

                if (student == null) return NotFound();

                return Ok(student);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        [HttpDelete]

        [Route("[action]")]
        public IActionResult DeleteStudentByEmpId(int id)
        {

            try
            {
                var responseModel = _stuService.DeleteStudent(id);
                if (responseModel == null) return NotFound();
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("[action]/empid")]
        public Student SearcStudentById(int empid)
        {
            Student stu;
            try
            {
                stu = _stuService.SearchStudent(empid);
            }
            catch (Exception e)
            {
                throw e;
            }
            return stu;
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



        [HttpPut(nameof(AddStudentById))]
        public ActionResult AddStudentById(Student stu)
        {
            _stuService.AddStudent(stu);
            return Ok("Student Added");
        }


        [HttpPut(nameof(UpdateStudentDetail))]
        public ActionResult UpdateStudentDetail(Student stu)
        {
            _stuService.UpdateStudent(stu);
            return Ok("Student Updated");
        }


        //public ActionResult GetStudent()
        //{
        //    var stu = _stuService.GetStudentList();
        //    if(stu != null)
        //    {
        //        return Ok(stu);
        //    }
        //    return BadRequest("NotFound");
        //}
    }
}
