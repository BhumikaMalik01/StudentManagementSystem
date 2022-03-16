using System;
using System.Collections.Generic;
using StudentManagementDomainLayer.Models;
using StudentManagementServiceLayer.Views;

namespace StudentManagementServiceLayer.Services
{
    public interface IStudentService
    {
        IList<Student> GetStudentList();

        Student SearchStudent(int empid);

        ResponseModel SaveStudent(Student stu);
    }
}
