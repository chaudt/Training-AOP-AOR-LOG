using DemoAOP_AOR_LOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAOP_AOR_LOG.Services
{
    public interface IStudentService1
    {
        IEnumerable<Student> GetStudents(int No);
        Student SelectStudent(int id);
        int InsertStudent(StudentInsertReq st);
        bool DeleteStudent(int id);
        bool UpdateStudent(StudentUpdateReq st);
    }
}
