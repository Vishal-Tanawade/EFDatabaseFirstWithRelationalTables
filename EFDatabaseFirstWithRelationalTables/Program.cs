using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabaseFirstWithRelationalTables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GN22ADMDNF001Entities context= new GN22ADMDNF001Entities();

            //******************** Fetch Data****************************

            //Always use Var while reading data 
            var SelEmpWithDept = from e in context.Employees
                                 join d in context.Departments on e.DeptID equals d.DeptId
                                 select new { EmpID = e.EmpID, EmpName = e.EmpName, CourseDuration = e.CourseDuration, DeptID = e.DeptID, DeptName = d.DeptName, DeptLoc = d.DeptLoc }; // we are using here anonymous method bcz we don't having any class which could handle both combined attributes of dept and emp table
            Console.WriteLine("EmpID EmpName CourseDuration DeptID DeptName DeptLoc");
            foreach (var item in SelEmpWithDept)
            {
                Console.WriteLine(item.EmpID + " " + item.EmpName + " " + item.CourseDuration + " " + item.DeptID + " " + item.DeptName + " " + item.DeptLoc);
            }



            //below query not working
            //Console.WriteLine("Inner Join Using LINQ With Lambda");

            //var SelectEmpWithDept = context.Employees.Join(context.Departments, e => e.EmpID, d => d.DeptId, (e, d) => new
            //{ EmpID = e.EmpID, EmpName = e.EmpName, CourseDuration = e.CourseDuration, DeptID = e.DeptID, DeptName = d.DeptName, DeptLoc = d.DeptLoc });

            //foreach (var item in SelectEmpWithDept)
            //{
            //    Console.WriteLine(item.EmpID + " " + item.EmpName + " " + item.CourseDuration + " " + item.DeptID + " " + item.DeptName + " " + item.DeptLoc);
            //}



            Console.WriteLine("BY USING ID PROPERTIES");
            Department department = context.Departments.FirstOrDefault(d => d.DeptId == 1);
            Department d11 = context.Departments.Find(1);
            // we are not using where clause as it will return multiple values , FirstOrDefault will return single value
            Console.WriteLine(d11.DeptId + " <==>" + d11.DeptName);
            //use Iqueryable for database 

            IQueryable<Department> iquerable = context.Departments.Where(d1 => d1.DeptId == 1);  // it will compile code at c# , then Compile at Database then Filter record and then fetch ---- and it is part of LINQ

            IEnumerable<Department> ienumerable = context.Departments.Where(d2 => d2.DeptId == 1);  // it will compile code at c# , then Compile at Database then Fetch record to c# then filter it --- 
            Console.WriteLine("Using IQueryable");
            foreach (var item in iquerable)
            {
                Console.WriteLine(item.DeptId + " " + item.DeptName + " " + item.DeptLoc);
            }


            Console.WriteLine("Using IEnumerable");
            foreach (var item in ienumerable)
            {
                Console.WriteLine(item.DeptId + " " + item.DeptName + " " + item.DeptLoc);
            }


            //var r= context.Employees.Add(new Employee()
            //{
            //    EmpName = "Virat Kohli",
            //    DeptID = department.DeptId, // u can enter directly DeptID=5
            //    CourseDuration = 40
            //});
            //Console.WriteLine( "r============="+ r);
            //context.SaveChanges();



            Console.WriteLine("Add Employee BY USING NEVIGATION PROPERTIES EMPLOYEE.DEPARTMENT");
            //  Department dep = context.Departments.FirstOrDefault(d => d.DeptId == 1);
            //  context.Employees.Add(new Employee()
            //  {
            //      EmpName = "Rohit Sharma",
            //      Department = dep,    // HERE we enter direct dpt
            //      CourseDuration = 40

            //  });
            //context.SaveChanges();


            Console.WriteLine("BY USING NEVIGATION PROPERTIES DEPARTMENT.EMPLOYEE");


            Department dep1 = context.Departments.FirstOrDefault(d => d.DeptId == 1);

            dep1.Employees.Add(new Employee()
            {
                EmpName = "Aniket",
                CourseDuration = 40
            });

            context.SaveChanges();




            Console.Read();
        }
    }
}
