using StudentManagementDomainLayer.Models;
using StudentManagementRepositoryLayer;
using StudentManagementServiceLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementServiceLayer.Services
{
    public class StudentService : IStudentService
    {
        public ApplicationContext _appContext;
        public StudentService(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IList<Student>> GetStudentList()
        {
            IList<Student> stud;

            try
            {
                await Task.Delay(1000);
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
            //Student stud;
            //_appContext.
            //if(stu.StudentFirstName.Find<Student>())
            //{
            //    _appContext.Update<Student>(stu);
            //    _appContext.SaveChanges();
            //}

            //if
            
        }


        //public async Task<Student> EditStudent(int id, UpdateExpenseModel model)
        //{
        //    _appContext.FirstOrDefault(x => x.Id == id);

        //    if (expense == null)
        //    {
        //        throw new NotFoundException("Expense is not found");
        //    }

        //    expense.Amount = model.Amount;
        //    expense.Comment = model.Comment;
        //    expense.Description = model.Description;
        //    expense.Date = model.Date;

        //    //await _appContext.CommitAsync();
        //    return expense;
        //}




        public void AddStudent(Student stu)
        {
            _appContext.Add<Student>(stu);
            _appContext.SaveChanges();
        }

        public void EditStudent(Student stu)
        {
            throw new NotImplementedException();
        }
    }
}
