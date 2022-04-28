using Console_Project.Interfaces;
using Console_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Services
{
    class HumanReseourceManager : IHumanResourceManager
    {

        private Department[] _departments;
        public Department[] Departments => _departments;

        public HumanReseourceManager()
        {

            _departments = new Department[0];
        }
        public void AddDepartment(string name, int workerlimit, int salarylimit)
        {

            foreach (Department department in _departments)
            {
                //  Tutaq ki "Books" adinda departamentimiz var.Yeniden "B o o k s" adinda departament elave etmeye calissaq bu adda departamentin oldugu bildirisini cixardacaq.
                string[] checkname = name.ToUpper().Split(' '); //her bosluqdan bir olan deyeri yigir string tipinden olan arraya.
                string checktrim = "";

                for (int i = 0; i < checkname.Length; i++)
                {
                    checktrim += checkname[i]; // burada ise arrayin elementlerini cemleyirik.Yeni birlesdiririk.
                }

                if (department.Name == checktrim) //birlesdirikden sonra yoxlayiriq ki bu adda departamentimiz var ya yoxdu.
                {
                    Console.WriteLine("Bu adda department var\n\n"); 
                    return; //varsa eger bildirisi cixardib metoddan cixiriq.
                }

            }
            //Yoxdusa da _departments arrayimize yeni departamenti elave edirik.
         
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = new Department(name, workerlimit, salarylimit); //bu hisseni asagidaki kimi de yaza bilerik.  
            //Department department1=new Department(name, workerlimit, salarylimit);
            //_departments[_departments.Length - 1] = department1;
            Console.WriteLine("Ugurla elave etdiniz\n\n");
        }
        public void EditDepartments(string departmentname, string newdepartmentname)
        {


            foreach (Department department in _departments)
            {
                if (department.Name == departmentname.Trim().ToUpper()) // evvelce daxil etdiyimiz adda departament varmi deye yoxlayiriq.Varsa eger kecirik kod blokuna
                {
                   

                        department.Name = newdepartmentname.Trim().ToUpper();  // yeni daxil etdiyimiz department adini assign edirik.Adini deyisdiririk.

                        foreach (Employee employee in department.Employees)
                        {
                            employee.DepartmentName = department.Name;
                            employee.No = employee.No.Replace(employee.No[0], char.ToUpper(newdepartmentname[0]));
                            employee.No = employee.No.Replace(employee.No[1], char.ToUpper(newdepartmentname[1]));  // asagidaki kimi de yaza bilerik.Eslinde 2 setr kod yazmaqdansa o cur yazmaq daha yaxsidir.Sadece ilk aglima gelen birinci yazdigim oldu :))
                            //employee.No = employee.No.Replace(employee.No.Substring(0, 2), newdepartmentname.ToUpper().Substring(0, 2));
                        }
                        Console.WriteLine("Ugurla deyisdirildi");
                        return;


                    
                  

                }
            }
            Console.WriteLine("Daxil etdiyiniz adda department yoxdur");

        }
       
        public void AddEmployee(string fullname, int salary, string position, string departmentname)
        {
            Department department = null;

            foreach (Department item in _departments)
            {
                if (item.Name == departmentname.Trim().ToUpper())
                {
                    department = item;
                }
            }

            if (department != null)
            {
                int employeeCount = 0;
                foreach (Employee employee in department.Employees)
                {
                    if (employee != null)
                    {
                        employeeCount++;
                    }
                }

                if (employeeCount < department.WorkerLimit)
                {
                    if (((department.CalcSalaryAverage() * employeeCount) + salary) <= department.SalaryLimit)
                    {
                        Employee employee = new Employee(departmentname, fullname, salary, position);
                        department.AddEmployee(employee);
                        Console.WriteLine("Ugurla elave edildi");
                        return;
                    }
                    else Console.WriteLine("Yeni isci ucun ayirdiginiz maas ayliq maas limitini kecir");
                    return;
                }
                else Console.WriteLine("Limiti kecdiyi ucun yeni isci elave ede bilmerik");
                return;

            }
            Console.WriteLine("Daxil edilen adda Departament tapilmadi"); 

        }
        public void EditEmploye(string no, string fullname, int salary, string position)
        {
            Department newdepartment = null;
            Employee newemployee = null;

            foreach (Department department in _departments)
            {


                if (department != null)
                {
                    foreach (Employee employee in department.Employees)
                    {
                        if (employee != null && employee.No.ToUpper() == no.Trim().ToUpper())
                        {
                            employee.Fullname = fullname.Trim().ToLower();
                            newemployee = employee;
                            newdepartment = department;


                        }
                    }


                }
            }

            if (newemployee != null)
            {
                int employeeCount = 0;
                foreach (Employee employee in newdepartment.Employees)
                {
                    if (employee != null)
                    {
                        employeeCount++;
                    }

                }
                int oldsalary = newemployee.Salary;
                newemployee.Position = position;
                newemployee.Salary = salary;

                if ((((newdepartment.CalcSalaryAverage() * employeeCount) - newemployee.Salary) + salary) > newdepartment.SalaryLimit)
                {
                    newemployee.Salary = oldsalary;
                    Console.WriteLine("Yeni maas limiti asir");
                    return;
                }
            }



        }

           
        public Department[] GetDepartments()
        {
            Department[] departments = new Department[0];

            foreach (Department department in _departments)
            {
                if (department != null)
                {
                    Array.Resize(ref departments, departments.Length + 1);
                    departments[departments.Length - 1] = department;
                }
                else 
                { 
                    Console.WriteLine("Department yoxdur");
                }
            }

            return departments;
        }
        public void RemoveEmployee(string employeenumber, string departmentname)
        {

            foreach (Department department in _departments)
            {
                
               if (department.Name == departmentname.Trim().ToUpper())
               {
                    for (int i = 0; i < department.Employees.Length; i++)
                    {
                        if (department.Employees[i].No.ToUpper() == employeenumber.Trim().ToUpper())
                        {
                            department.Employees[i] = null;
                            department.Employees[i] = department.Employees[department.Employees.Length - 1];

                            Array.Resize(ref department.Employees, department.Employees.Length - 1);
                            Console.WriteLine("Isci departmentden silindi");
                            return;

                        }
                        else
                        {
                             Console.WriteLine("Silmek istediyiniz isci tapilmadi");
                            
                        }
                    }
               }
               else
               {
                    Console.WriteLine("Bu adda department tapilmadi");
                    return;
               }
               
            }
            Console.WriteLine("Bu departmentde isci yoxdur");

         
        }
      

      
    }
}

