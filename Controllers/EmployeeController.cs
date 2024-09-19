using FirstProject.Models;
using FirstProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository =  employeeRepository;
        }

        public IActionResult Index()
        {
            List<Employee> employees = _employeeRepository.GetEmployees();
            return View(employees);
        }
        public IActionResult Create() 
        { 
        return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            try
            {
                _employeeRepository.AddEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var emp = _employeeRepository.GetEmployeeById(id);
            return View(emp);
        }

        public ActionResult Edit(int id) 
        { 
            var emp=_employeeRepository.GetEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(int id, Employee emp)
        {
            try
            {
                _employeeRepository.UpdateEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
