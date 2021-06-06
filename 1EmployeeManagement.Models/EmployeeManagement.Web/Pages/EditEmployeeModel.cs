using _1EmployeeManagement.Models;
using _1EmployeeManagement.Models.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeModel
    {
        internal string LastName;
        internal string PhotoPath;
        internal Department Department;
        internal int DepartmentId;
        internal Gender Gender;
        internal DateTime DateOfBrith;
        internal string Email;

        public class Employee
        {
            public int EmployeeId { get; set; }
            [Required(ErrorMessage = "FirstName is mandatory")]
            [MinLength(2)]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [EmailAddress]
            [EmailDomainValidator(AllowedDomain = "pragimtech.com",
               ErrorMessage = "Only ProdimTech.com is allower")]
            public string Email { get; set; }
            public string ConfirmEmail { get; set; }
            public DateTime DateOfBrith { get; set; }
            public Gender Gender { get; set; }
            public int DepartmentId { get; set; }
            public string PhotoPath { get; set; }
            public Department Department { get; set; }
        }

        public object EmployeeId { get; internal set; }
        public string FirstName { get; internal set; }
        public object ConfirmEmail { get; internal set; }
    }
}