using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAOP_AOR_LOG.Models
{
    public class Student : StudentInformation
    {
        public int Id { get; set; }

    }

    public class StudentInformation
    {
        public string Name { get; set; }
        public double Avg { get; set; }
        public DateTime Birthday { get; set; }
    }
    public class StudentInsertReq : StudentInformation
    {

    }
    public class StudentUpdateReq : Student { }

    public class StudentUpdateReqValidation : AbstractValidator<StudentUpdateReq>
    {
        public StudentUpdateReqValidation()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("Student Id must greater than 0");
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Student Name not null or empty");
            RuleFor(p => p.Avg).GreaterThanOrEqualTo(0).WithMessage("Avg must greater than or equal 0");
        }
    }
}
