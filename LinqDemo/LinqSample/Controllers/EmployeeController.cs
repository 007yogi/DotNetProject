using LinqSample.EFData;
using LinqSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace LinqSample.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _context;
        public EmployeeController(ApplicationContext context)
        {
            _context = context;
        }

        /*public void WithOutLinq()
        {
            Employee[] empArr = { 
                new Employee(){EmployeeId = 1, EmployeeName = "Abc"},
                new Employee(){EmployeeId = 2, EmployeeName = "Xyz"},
                new Employee(){EmployeeId = 3, EmployeeName = "Pqr"}
            };

            Employee[] emp = new Employee[5];
            int i = 0;
            foreach(Employee item in empArr)
            {
                if(item.EmployeeName == "Abc")
                {
                    emp[i] = item;
                    i++;
                }
            }
        }*/

        public IEnumerable<Employee> Index()
        {
            /*Employee[] empArr =
            {
                new Employee(){EmployeeId = 1, EmployeeName="ABC"},
                new Employee(){EmployeeId = 2, EmployeeName="XYZ"},
                new Employee(){EmployeeId = 3, EmployeeName="ABC"},
            };
            Employee[] emp = empArr.Where(x => x.EmployeeName == "ABC").ToArray();
            return emp;*/

            Employee[] empArr = { };
            List<Employee> empList = new List<Employee>();
            
            empList = _context.employees.Where(x => x.Department == "IT").ToList();
            //var empName = _context.employees.Where(x => x.EmployeeName =="Jack").FirstOrDefault();
            return empList;
        }        
    }
}
