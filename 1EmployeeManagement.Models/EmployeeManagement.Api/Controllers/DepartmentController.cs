﻿using _1EmployeeManagement.Models;
using EmployeeManagement.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace EmployeeManagement.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        [ApiController]
        public class DepartmentsController : ControllerBase 
        {
            private readonly IDepartmentRepository departmentRepository;

            public DepartmentsController(IDepartmentRepository departmentRepository)
            {
                this.departmentRepository = departmentRepository;
            }

            [HttpGet]
            public async Task<ActionResult> GetDepartments()
            {
                try
                {
                    return Ok(await departmentRepository.GetDepartment());
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error retrieving data from the database");
                }
            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult<Department>> GetDepartment(int id)
            {
                try
                {
                var result = (await departmentRepository.GetDepartment());

                if (result == null)
                    {
                        return NotFound();
                    }

                return (ActionResult<Department>)result;
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error retrieving data from the database");
                }
            }
        }
    }

