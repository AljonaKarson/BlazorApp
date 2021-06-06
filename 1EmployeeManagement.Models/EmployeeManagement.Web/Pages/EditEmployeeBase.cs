﻿using _1EmployeeManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : CompomentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public string PageHeader { get; set; }
        public string PageHeaderText { get; private set; }
        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        public string DepartmentId { get; set; }
        [Parameter]
        public string Id { get; set; }
        public object EmployeeId { get; private set; }
        [Inject]
        public IMapper Mapper { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            if (employeeId != 0)
            {
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Create Employee";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBrith = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg"
                };
            }
            Departments = (await DepartmentService.GetDepartments()).ToList();
            Mapper.Map(Employee, EditEmployeeModel);
        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);

            Employee result = null;

            if (Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }
            if (result != null)
                NavigationManager.NavigateTo("/");
        }
    }
}






// EditEmployeeModel.EmployeeId = Employee.EmployeeId;
//EditEmployeeModel.FirstName = Employee.FirstName;
//EditEmployeeModel.LastName = Employee.LastName;
//EditEmployeeModel.Email = Employee.Email;
//EditEmployeeModel.ConfirmEmail = Employee.Eail;
//EditEmployeeModel.DateOfBrith = Employee.DateOfBrith;
//EditEmployeeModel.Gender = Employee.Gender;
//EditEmployeeModel.DepartmentId = Employee.DepartmentId;
//EditEmployeeModel.PhotoPath = Employee.PhotoPath;
//EditEmployeeModel.Department = Employee.Department;


