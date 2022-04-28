using Console_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }
        void AddDepartment(string name, int workerlimit, int salarylimit);
        void EditDepartments(string departmentname,string newdepartmentname);   
        void AddEmployee(string fullname, int salary, string position, string departmentname);
        Department[] GetDepartments();
        void EditEmploye(string no,string fullname, int salary, string position);
        void RemoveEmployee(string departmentname,string studentno);
        
    }
}
