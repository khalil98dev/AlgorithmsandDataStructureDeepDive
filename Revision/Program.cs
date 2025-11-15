using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Revision
{

public class Program
{
    static void Main(string[] args)
    {
            Student st1 = new Student(12,"khalil");
            Employee emp1 = new Employee(1,"khalil b",1500.5m,27);
            Employee emp2 = new Employee(1,"khalil b",1500.5m,27);
            Employee emp3 = new Employee(1,"Ines b",500,24);

          


            Console.WriteLine(emp1 == emp2);
            Console.WriteLine(emp3 > emp1);
            Console.WriteLine(emp3 < emp1);
            Console.WriteLine(emp3 == emp1);
            Console.WriteLine(emp2 == emp1);
            Console.WriteLine(emp2.Equals(emp1));

            Console.ReadLine(); 
    }
}

}

namespace Revision
{
   public class Employee
    {
 
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public short Age { get; set; }

        public Employee(int employeeID, string name, decimal salary, short age)
        {
            EmployeeID = employeeID;
            Name = name;
            Salary = salary;
            Age = age;
        }

        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is Employee))
                return false;

            var emp = (Employee)obj;

            //return this.EmployeeID == emp.EmployeeID && this.Name == emp.Name && this.Salary == emp.Salary && this.Age == emp.Age;
            return this.GetHashCode() == emp.GetHashCode();
        }


        static public bool operator == (Employee left, Employee right)
        {
            return left.Equals(right);
        }

        static public bool operator !=(Employee left, Employee right)
        {
            return left.Equals(right);
        }

        static public bool operator >(Employee left, Employee right) => left.Salary > right.Salary;

        static public bool operator <(Employee left, Employee right) => left.Salary < right.Salary;


        public override int GetHashCode()
        {
            int hash = 17; 

            hash = hash * 23 + EmployeeID.GetHashCode();
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + Salary.GetHashCode();
            hash = hash * 23 + Age.GetHashCode();

            return hash;
        }

    }

    public class Student
    {
     
        public Student(int studentID, string name)
        {
            StudentID = studentID;
            Name = name;
        }

        public int StudentID { get; private set; }

        public string Name { get; private set; }


    }
}