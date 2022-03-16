using StudentManagementDomainLayer.Models;
using StudentManagementRepositoryLayer;
using StudentManagementServiceLayer.Views;
using System;
using System.Collections.Generic;

namespace StudentManagementServiceLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationContext _appContext;
        public StudentService(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public IList<Student> GetStudentList()
        {
            throw new NotImplementedException();
        }

        public ResponseModel SaveStudent(Student stu)
        {
            throw new NotImplementedException();
        }

        public Student SearchStudent(int empid)
        {
            throw new NotImplementedException();
        }
    }
}
