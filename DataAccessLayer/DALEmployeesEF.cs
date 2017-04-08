using DataAccessLayer.Model;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            using (var db = new EmployeesEntities())
            {
                db.Employees.Add(emp);
                db.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var db = new EmployeesEntities())
            {
                db.Employees.Remove(db.Employees.Find(id));
                db.SaveChanges();
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (var db = new EmployeesEntities())
            {
                Employee oEmpleado = db.Employees.Find(emp.Id);
                oEmpleado = emp;
                db.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (var db = new EmployeesEntities())
            {
                return (from Employee in db.Employees select Employee).ToList();
                //return db.Employees.ToList();
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var db = new EmployeesEntities())
            {
                //return (from Employee in db.Employees where Employee.Id == id select new Employee);
                return db.Employees.Find(id);
            }
        }
    }
}
