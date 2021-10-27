using ApiRestCrudAlfa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCrudAlfa.EmployeeData
{
    //Generacion implementacion con SQL SERVER
    public class SqlEmployeeData : IEmployeeData //Hereda de esta clase para implemnentar su interfaz
    {

        private EmployeeContext _employeeContext; //Variable || Attribute de tipo private

        public SqlEmployeeData(EmployeeContext employeeContext) // CONSTRUCTOR 
        {
            _employeeContext = employeeContext;
        }

        public Employee AddEmployee(Employee employee)//Agregar employee a la database
        {
            employee.Id = Guid.NewGuid();//Crear un id
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();

        }

        public Employee EditEmployee(Employee employee)
        {
            var existEmployee = _employeeContext.Employees.Find(employee.Id);
            if (existEmployee != null)
            {
                existEmployee.Name = employee.Name;
                _employeeContext.Employees.Update(existEmployee);
                _employeeContext.SaveChanges();//Guardar la base de datos
            }

            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            var employee=_employeeContext.Employees.Find(id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList(); //Basicamente retorna los empleados de la tabla Employees
        }
    }
}
