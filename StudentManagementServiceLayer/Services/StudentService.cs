using StudentManagementDomainLayer.Models;
using StudentManagementRepositoryLayer;
using StudentManagementServiceLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementServiceLayer.Services
{
    public class StudentService : IStudentService
    {
        public ApplicationContext _appContext;
        public StudentService(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public IList<Student> GetStudentList()
        {
            IList<Student> stud;

            try
            {

                stud = _appContext.Set<Student>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return stud;
        }


        public Student SearchStudent(int stuId)
        {
            Student stud;

            try
            {
                stud = _appContext.Find<Student>(stuId);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return stud;
        }



        public ResponseModel DeleteStudent(int empid)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var emp = SearchStudent(empid);
                _appContext.Remove<Student>(emp);

                _appContext.SaveChanges();
                model.ISuccess = true;
                model.Message = " Employee records removed succesfully";
            }

            catch (Exception ex)
            {
                model.ISuccess = false;
                model.Message = " Error:" + ex.Message;

            }
            return model;
        }

        public void UpdateStudent(Student stu)
        {
            _appContext.Update<Student>(stu);
            _appContext.SaveChanges();
        }


        public void AddStudent(Student stu)
        {
            _appContext.Add<Student>(stu);
            _appContext.SaveChanges();
        }

    }
}
