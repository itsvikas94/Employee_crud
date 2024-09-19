using FirstProject.Context;
using FirstProject.Models;

namespace FirstProject.Repository
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public SqlEmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        

        public void AddEmployee(Employee emp)
        {
           _employeeDbContext.Employees.Add(emp);
            _employeeDbContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employeeDbContext.Employees.First(value => value.Id == id);
            _employeeDbContext.Remove(employee);
            _employeeDbContext.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeDbContext.Employees.First(value => value.Id == id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeDbContext.Employees.ToList();
        }

        public void UpdateEmployee(Employee emp)
        {
            var employee = _employeeDbContext.Employees.First(value => value.Id == emp.Id);
            employee.Name = emp.Name;
            employee.Salary = emp.Salary;
            employee.City = emp.City;
            _employeeDbContext.Employees.Update(employee);
            _employeeDbContext.SaveChanges();
        }
    }
}
