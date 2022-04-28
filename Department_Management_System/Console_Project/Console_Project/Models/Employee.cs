using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Models
{
    class Employee 
    {
        private static int _count = 1000;
        public string No { get; set; } //iscilere verilen nomre
        public string Fullname { get; set; }

        private string _position;
        public string Position
        {
            get => _position;
            set
            {
                while (value.Length <=2)
                {
                    Console.WriteLine("Minimum 2 herfden ibaret olsun");
                    value = Console.ReadLine();
                }
                _position = value;
            }
        }

        private int _salary;
        public int Salary
        {
            get => _salary;
            set
            {
                while (value < 250)
                {
                    Console.WriteLine("Iscinin maasi 250-den asagi ola bilmez");
                    value = int.Parse(Console.ReadLine());
                }
                _salary = value;

            }

        }

        public string DepartmentName { get; set; } //iscinin elave olundugu departmentin adi
        public Employee(string departmentname,string fullname, int salary, string position)
        {

            Fullname = fullname.Trim().ToUpper();
            Salary = salary;
            Position = position.Trim().ToUpper();
            DepartmentName = departmentname.Trim().ToUpper();
            _count++;

            No = $"{char.ToUpper(DepartmentName[0]) + "" + char.ToUpper(DepartmentName[1])}{_count}";   // asagidaki kimi de etmek olar
         // No = $"{DepartmentName.Substring(0, 2).ToUpper()}{_count}";

        }
        public override string ToString()
        {
            return $"Departmentin adi: {DepartmentName}\nIscinin nomresi: {No}\nAdi : {Fullname}\nVezifesi: {Position}\nMaasi: {Salary}\n ";
        }

    }
}
