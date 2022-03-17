using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagementDomainLayer.Models;
using StudentManagementServiceLayer.Views;

namespace StudentManagementServiceLayer.Services
{
    public interface IStudentService
    {
        Task<IList<Student>> GetStudentList();

        Student SearchStudent(int stuId);

        public void AddStudent(Student stu);

        ResponseModel DeleteStudent(int stuId);

        void UpdateStudent(Student stu);

        void EditStudent(Student stu);
    }
}