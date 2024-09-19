using FirstProject.Models;

namespace FirstProject.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        static List<Employee> _employees = new List<Employee>();
        static EmployeeRepository()
        {
            //method 1
            Employee obj = new Employee();
            obj.Id = 1;
            obj.Name = "Krishnkant";
            obj.Salary = 10000;
            obj.City = "Delhi";
            _employees.Add(obj);

            //method 2
            _employees.Add(new Employee() { Id = 2, Name = "Vikas", Salary = 15000, City = "Bareilly" });
            _employees.Add(new Employee() { Id = 3, Name = "Shahrukh", Salary = 12000, City = "Agra" });

        }
        public void AddEmployee(Employee emp)
        {
           _employees.Add(emp);
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employees.First(value => value.Id == id);
            _employees.Remove(employee);
        }

        public Employee GetEmployeeById(int id)
        {
           //Linq = Language Integrated Query
           var employee = _employees.First(value => value.Id == id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
           return _employees;
        }

        public void UpdateEmployee(Employee emp)
        {
            var employee = _employees.First(value => value.Id == emp.Id);
            employee.Name= emp.Name;
            employee.Salary= emp.Salary;
            employee.City= emp.City;
        }
    }
}
