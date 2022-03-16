using StudentManagementDomainLayer.Models;
using StudentManagementServiceLayer.Views;
using System.Collections.Generic;


namespace StudentManagementServiceLayer.Services
{
    public interface IStudentMarksService
    {
        IList<StudentMarks> GetStudentMarksList();

        StudentMarks SearchStudentMarks(int stuId);

        ResponseModel SaveStudentMarks(StudentMarks stuMarks);
    }
}
