using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Models
{
    class Department 
    {
        private string _name;
        public string Name 
        {
            get => _name;
            set
            {
                while (value.Length < 2)
                {
                   Console.WriteLine("Departmentin adi minumum 2 herfden ibaret olmalidir");
                   value = Console.ReadLine();
                }
                _name = value.ToUpper();

            }
        }

        private int _workerlimit;
        public int WorkerLimit {
            get => _workerlimit;
            set
            {
                while (value < 1)
                {
                    Console.WriteLine("Departmentde minumum 1 isci olmalidir");
                    value = int.Parse(Console.ReadLine());
                }
                _workerlimit = value;
            }
        }

        private int _salarylimit;
        public int SalaryLimit {
            get => _salarylimit;
            set
            {
                while (value < 250*WorkerLimit)
                {
                    Console.WriteLine("Butun isciler ucun ayrilmis ayliq maas minumum " + 250*WorkerLimit+ " ola biler");
                    value = int.Parse(Console.ReadLine());
                }
                _salarylimit = value;

            }
        }


        public Employee[] Employees; // Departmentdeki iscileri gosterir
        public double CalcSalaryAverage()
        {
            double sumofsalary = 0;
            int count = 0;

            foreach (Employee employee in Employees)
            {
                 sumofsalary += employee.Salary;
                 count++;
                
            }
            if (sumofsalary > 0)
            {
                return sumofsalary / count;
            }
            else return 0;
             
        }

     
        public Department(string name, int workerlimit, int salarylimit)
        {
            Employees = new Employee[0];
            Name = name.Trim().ToUpper();
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;

        }
     
        public void AddEmployee(Employee employee)
        {
            if (Employees.Length < WorkerLimit)
            {
                Array.Resize(ref Employees, Employees.Length + 1);
                Employees[Employees.Length - 1] = employee;
            }
            else
            {
                Console.WriteLine("Departmende yer yoxdu");
            }
        }


        public override string ToString()
        {
            return $"Departmentin adi : {Name} | Iscilerin sayi: {WorkerLimit} | Iscilerin ayliq maaslarinin cemi : {SalaryLimit}";
        }


        




    }
}
