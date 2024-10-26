﻿namespace WMS.Api.Application.Commands.Employees
{
    public class UpdateEmployeeCommand
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public UpdateEmployeeCommand(string employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }
    }
}