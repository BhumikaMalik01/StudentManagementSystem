using System;
using System.Collections.Generic;
using StudentManagementDomainLayer.Models;
using StudentManagementRepositoryLayer;
using StudentManagementServiceLayer.Views;

namespace StudentManagementServiceLayer.Services
{
    public class StudentMarksService : IStudentMarksService
    {
        private readonly ApplicationContext _appContext;
        public StudentMarksService(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public IList<StudentMarks> GetStudentMarksList()
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel SaveStudentMarks(StudentMarks stuMarks)
        {
            throw new System.NotImplementedException();
        }

        public StudentMarks SearchStudentMarks(int stuId)
        {
            throw new System.NotImplementedException();
        }
    }
}
