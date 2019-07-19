using DemoAOP_AOR_LOG.Models;
using DemoAOP_AOR_LOG.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoAOP_AOR_LOG.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService1 _studentService;
        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="studentService"></param>
        public StudentsController(IStudentService1 studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Delete Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/v1/Student/{id}")]
        public IActionResult Delete(int id)
        {
            var isSuccess = _studentService.DeleteStudent(id);
            var msg = isSuccess ? "Delete is successfull" : "Delete is failure";
            return Ok(msg);
        }

        /// <summary>
        /// Insert Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/Student")]
        public IActionResult Insert(StudentInsertReq student)
        {
            var id = _studentService.InsertStudent(student);
            var msg = id > 0 ? $"Insert StudentId={id} is successfull" : "insert is failure";
            return Ok(msg);
        }

        /// <summary>
        /// Update Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/Student/Update")]
        public IActionResult Update(StudentUpdateReq student)
        {
            #region Check validate
            //if (student.Id <= 0)
            //    return Ok("Student Id must greathan 0");
            //if (string.IsNullOrEmpty(student.Name))
            //    return Ok("Student Name not null or empty");
            //if (student.Avg < 0)
            //    return Ok("Avg must greathan or equal 0");
            #endregion

            var flag = _studentService.UpdateStudent(student);
            var msg = flag ? "Update is successfull" : "Update is failure";
            return Ok(msg);
        }

        /// <summary>
        /// Get all student
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Student/{no}/GetAlls")]
        public IActionResult GetAlls(int no)
        {
            var res = _studentService.GetStudents(no);
            return Ok(res);
        }

        /// <summary>
        /// Select Student by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Student/{id}")]
        public IActionResult Select(int id)
        {
            var res = _studentService.SelectStudent(id);
            return Ok(res);
        }
    }
}