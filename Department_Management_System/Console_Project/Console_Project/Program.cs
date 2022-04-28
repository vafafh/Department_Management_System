using Console_Project.Models;
using Console_Project.Services;
using System;

namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("------------ WELCOME------------\n");
            HumanReseourceManager humanReseourceManager = new HumanReseourceManager();

            do
            {
                Console.WriteLine("1. Department yarat");
                Console.WriteLine("2. Department uzerinde deyisiklik et");
                Console.WriteLine("3. Departament siyahisini goster");
                Console.WriteLine("4. Isci elave et");
                Console.WriteLine("5. Isci uzerinde deyisiklik et");
                Console.WriteLine("6. Iscilerin siyahisini goster");
                Console.WriteLine("7. Departmentden iscini sil");
                Console.WriteLine("8. Departmentdeki iscilerin siyahisini goster");
                Console.WriteLine("9. Cixis et\n\n");
                Console.WriteLine("Secim edin");

                string choose = Console.ReadLine();
                int chooseNum;

                while (!int.TryParse(choose, out chooseNum) || chooseNum < 1 || chooseNum > 9)
                {
                    Console.WriteLine("Duzgun secim et");
                    choose = Console.ReadLine();
                }
              
                Console.Clear();

                switch (chooseNum)
                {
                    case 1:
                        AddDepartment(ref humanReseourceManager);
                        break;
                    case 2:
                        EditDepartments(ref humanReseourceManager);
                        break;
                    case 3:
                        ShowAllDepartment(ref humanReseourceManager);
                        break;
                    case 4:
                        AddEmployee(ref humanReseourceManager);
                        break;
                    case 5:
                        EditEmployee(ref humanReseourceManager);
                        break;
                    case 6:
                        ShowAllEmployee(ref humanReseourceManager);
                        break;
                    case 7:
                        RemoveEmployee(ref humanReseourceManager);
                        break;
                    case 8:
                        ShowAllEmployeeByDepartment(ref humanReseourceManager);
                        break;
                    case 9:
                        return;
                }


            } while (true);
        }

        static void AddDepartment(ref HumanReseourceManager humanResourceManager)
        {

            Console.WriteLine("Departmentin adini daxil edin");
            string departmentname = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Duzgun daxil edin");
                departmentname = Console.ReadLine();
            }

            Console.WriteLine("Isci sayini daxil edin");
            string limit = Console.ReadLine();
            int workerlimit;

            while (!int.TryParse(limit, out workerlimit))
            {
                Console.WriteLine("Duzgun daxil edin");
                limit = Console.ReadLine();
            }

            Console.WriteLine("Isciler ucun ayrilmis ayliq maasi daxil edin");
            string salary = Console.ReadLine();
            int salarylimit;

            while (!int.TryParse(salary, out salarylimit))
            {
                Console.WriteLine("Duzgun daxil edin");
                salary = Console.ReadLine();
            }

            humanResourceManager.AddDepartment(departmentname, workerlimit, salarylimit);


        }

        static void EditDepartments(ref HumanReseourceManager humanReseourceManager)
        {

            if (humanReseourceManager.Departments.Length > 0)
            {
                Console.WriteLine("Department siyahisi");
                foreach (Department department in humanReseourceManager.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Once department yaradin");
                return;
            }

            Console.WriteLine("Deyisiklik etmek istediyiniz departmentin adini daxil edin");
            string departmentname = Console.ReadLine();


            while (string.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Duzgun daxil edin");
                departmentname = Console.ReadLine();
            }

            Console.WriteLine("Departmentin yeni adini daxil edin");
            string newdepartmentname = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newdepartmentname))
            {
                Console.WriteLine("Duzgun daxil edin");
                newdepartmentname = Console.ReadLine();
            }
           
            humanReseourceManager.EditDepartments(departmentname, newdepartmentname);

        }

        static void ShowAllDepartment(ref HumanReseourceManager humanReseourceManager)
        {
            if (humanReseourceManager.Departments.Length > 0)
            {

                foreach (Department department in humanReseourceManager.Departments)
                {
                    Console.WriteLine(department);
                    Console.WriteLine("=======================================================================");
                }
            }
            else
            {
                Console.WriteLine("Department yoxdur");
                return;
            }
        }

        static void AddEmployee(ref HumanReseourceManager humanReseourceManager)
        {
            if (humanReseourceManager.Departments.Length > 0)
            {
                Console.WriteLine("Departmentlerin siyahisi");
                foreach (Department department in humanReseourceManager.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Once department yaradin");
                return;
            }

            Console.WriteLine("Iscini elave etmek isdediyniz departmentin adini daxil edin");
            string departmentname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Duzgun department adi daxil et:");
                departmentname = Console.ReadLine();
            }
            Console.WriteLine("Iscinin adini daxil edin");
            string fullname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Duzgun ad daxil edin:");
                fullname = Console.ReadLine();
            }

            Console.WriteLine("Maasi daxil edin");
            string maas = Console.ReadLine();
            int salary;

            while (!int.TryParse(maas, out salary))
            {
                Console.WriteLine("Maasi duzgun duzgun daxil et");
                maas = Console.ReadLine();
            }

            Console.WriteLine("Iscinin vezifesini daxil edin");
            string position = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(position))
            {
                Console.WriteLine("Duzgun ad daxil edin:");
                position = Console.ReadLine();
            }

            humanReseourceManager.AddEmployee(fullname, salary, position, departmentname);

        }     

        static void EditEmployee(ref HumanReseourceManager humanReseourceManager)
        {
  
                if (humanReseourceManager.Departments.Length > 0)
                {
                    Console.WriteLine("Departmentlerin siyahisi");
                    foreach (Department department in humanReseourceManager.Departments)
                    {
                        Console.WriteLine(department);
                    }
                }
                else
                {
                Console.WriteLine("Once department yaradin");
                return;
                }

               Console.WriteLine("Iscinin nomresini daxil edin");
               string employeenum = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(employeenum))
                {
                Console.WriteLine("Duzgun daxil edin:");
                employeenum = Console.ReadLine();
                }

          
               Console.WriteLine("Yeni iscinin adini daxil edin");
               string fullname = Console.ReadLine();
               while (string.IsNullOrWhiteSpace(fullname))
               {
                  Console.WriteLine("Duzgun daxil edin");
                  fullname = Console.ReadLine();
               }
             
              Console.WriteLine("Yeni maasi daxil edin");
              string salary1 = Console.ReadLine();
              int salary;

              while (!int.TryParse(salary1, out salary))
              {
                  Console.WriteLine("Duzgun daxil edin");
                  salary1 = Console.ReadLine();
              }
              Console.WriteLine("Yeni vezifeni daxil edin");
              string position = Console.ReadLine();

              while (string.IsNullOrWhiteSpace(position))
              {
                  Console.WriteLine("Duzgun daxil edin:");
                  position = Console.ReadLine();
              }

              humanReseourceManager.EditEmploye(employeenum, fullname, salary, position);

        }

        static void RemoveEmployee(ref HumanReseourceManager humanReseourceManager)
        {
            if (humanReseourceManager.Departments.Length > 0)
            {
                Console.WriteLine("Department siyahisi");
                foreach (Department department in humanReseourceManager.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Once sisteme Department elave edin");
                return;
            }

            Console.WriteLine("Iscini silmek isdediyiniz departmentin adini daxil edin");
            string depname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(depname))
            {
                Console.WriteLine("Duzgun daxil edin");
                depname = Console.ReadLine();
            }
            Console.WriteLine("Silmek istediyiniz Iscinin nomresini daxil edin");
            string no = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(no))
            {
                Console.WriteLine("Duzgun isci nomresi daxil edin:");
                no = Console.ReadLine();
            }

            humanReseourceManager.RemoveEmployee(no, depname);
        }

        static void ShowAllEmployee(ref HumanReseourceManager humanReseourceManager)
        {
            if (humanReseourceManager.Departments.Length > 0)
            {
                Console.WriteLine("Iscilerin siyahisi\n");
                foreach (Department department in humanReseourceManager.Departments)
                {
                    if (department.Employees.Length > 0)
                    {
                        foreach (Employee employee in department.Employees)
                        {
                            Console.WriteLine(employee);
                        }
                    }
                    else
                    {

                        Console.WriteLine($"{department.Name} adli departmentde isci yoxdu");

                    }
                }
            }
            else
            {
                Console.WriteLine("Once department yaradin");
                return;
            }
        }

        static void ShowAllEmployeeByDepartment(ref HumanReseourceManager humanReseourceManager)
        {
            if (humanReseourceManager.Departments.Length > 0)
            {
                Console.WriteLine("Department siyahisi\n");
                foreach (Department department in humanReseourceManager.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Once department yaradin");
                return;
            }
               
           Console.WriteLine("Hansi departmentdeki iscileri gormek isteyirsinizse hemin departmentin adini qeyd edin");
           string departmentname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Duzgun department adi daxil edin");
                departmentname = Console.ReadLine();
            }

            foreach (Department department in humanReseourceManager.Departments)
            {
                if (department.Name.ToUpper() == departmentname.ToUpper().Trim())
                {
                    foreach (Employee employee in department.Employees)
                    {
                      
                        Console.WriteLine(employee);
                        
                    }
               
                Console.WriteLine("Bu departmentde isci yoxdu");
                }
                else
                {
                    Console.WriteLine("Bu adda department yoxdur");
                }
            }
           
             
        }
           
    }

  

}


