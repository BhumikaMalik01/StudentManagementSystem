using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementDomainLayer.Models;
using StudentManagementRepositoryLayer;
using StudentManagementServiceLayer.Views;

namespace StudentManagementServiceLayer.Services
{
    public class StudentMarksService : IStudentMarksService
    {
        public ApplicationContext _appContext;
        public StudentMarksService(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        //public StudentMarks AddStudentMarks(int stuId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IList<StudentMarks>> GetStudentMarksList()
        {
            IList<StudentMarks> studMarks;

            try
            {
                await Task.Delay(1000);
                studMarks = _appContext.Set<StudentMarks>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return studMarks;
        }


        public void AddStudentMarks(StudentMarks stuMarks)
        {
            _appContext.Add<StudentMarks>(stuMarks);
            _appContext.SaveChanges();
        }




        public void UpdateStudentMarks(StudentMarks stuMarks)
        {
            _appContext.Update<StudentMarks>(stuMarks);
            _appContext.SaveChanges();
        }

        public StudentMarks SearchStudentMarks(int sem)
        {
            StudentMarks stud;

            try
            {
                stud = _appContext.Find<StudentMarks>(sem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stud;
        }
    }
}
