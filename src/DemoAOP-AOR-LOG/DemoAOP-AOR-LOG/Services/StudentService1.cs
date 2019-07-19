using Autofac.Extras.DynamicProxy;
using AutoMapper;
using DemoAOP_AOR_LOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAOP_AOR_LOG.Services
{
    [Intercept("log-calls")]
    public class StudentService1 : IStudentService1
    {
        private readonly IMapper _mapper;
        public StudentService1(IMapper mapper)
        {
            _mapper = mapper;


        }
        private static List<Student> _students = new List<Student>();
        public bool DeleteStudent(int id)
        {
            try
            {
                var students = _students;
                if (!students.Any()) return false;

                var st = students.Where(p => p.Id == id).FirstOrDefault();
                if (st is null) return false;

                var flag = students.Remove(st);
                _students = students;
                return flag;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("StudentServiceLog.log", ex.ToString());
            }
            return false;

        }

        public IEnumerable<Student> GetStudents(int No)
        {
            try
            {
                var students = _students;
                if (!students.Any()) return Enumerable.Empty<Student>();

                return students;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("StudentServiceLog.log", ex.ToString());
            }
            return Enumerable.Empty<Student>();
        }

        public int InsertStudent(StudentInsertReq st)
        {
            try
            {
                var students = _students;
                var maxId = 1;
                if (students.Any())
                {
                    maxId = students.Max(p => p.Id) + 1;
                }

                var studentInfo = _mapper.Map<Student>(st);
                studentInfo.Id = maxId;

                students.Add(studentInfo);
                _students = students;

                return maxId;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("StudentServiceLog.log", ex.ToString());
            }
            return -1;
        }

        public Student SelectStudent(int id)
        {
            try
            {
                var students = _students;
                if (!students.Any()) return null;

                var st = students.Where(p => p.Id == id).FirstOrDefault();
                return st;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("StudentServiceLog.log", ex.ToString());
            }
            return null;
        }

        public bool UpdateStudent(StudentUpdateReq req)
        {
            try
            {
                var students = _students;
                if (!students.Any()) return false;

                var st = students.Where(p => p.Id == req.Id).FirstOrDefault();
                if (st is null) return false;

                var studentUpdate = _mapper.Map<Student>(req);
                students.Remove(st);
                students.Add(studentUpdate);

                return true;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("StudentServiceLog.log", ex.ToString());
            }
            return false;
        }
    }
}
