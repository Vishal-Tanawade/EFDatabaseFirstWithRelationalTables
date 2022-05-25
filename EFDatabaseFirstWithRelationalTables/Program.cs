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

            var SelEmpWithDept = from e in context.Employees
                                 join d in context.Departments on e.DeptID equals d.DeptId
                                 select new { EmpID = e.EmpID, EmpName = e.EmpName, CourseDuration = e.CourseDuration, DeptID = e.DeptID, DeptName = d.DeptName, DeptLoc = d.DeptLoc }; // we are using here anonymous method bcz we don't having any class which could handle both combined attributes of dept and emp table
            Console.WriteLine("EmpID EmpName CourseDuration DeptID DeptName DeptLoc");
            foreach (var item in SelEmpWithDept)
            {
                Console.WriteLine(item.EmpID + " " + item.EmpName + " " + item.CourseDuration + " " + item.DeptID + " " + item.DeptName + " " + item.DeptLoc);
            }

            }
    }
}
