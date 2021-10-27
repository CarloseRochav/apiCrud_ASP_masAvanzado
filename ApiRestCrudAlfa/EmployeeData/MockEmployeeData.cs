using ApiRestCrudAlfa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCrudAlfa.EmployeeData { 

    public class MockEmployeeData : IEmployeeData//Debe eredar para poder modificar los metodos que definio
    //; USAR LA OPCION DE IMPLEMENTAR INTERFAZ
    {

        //CONTROLADOR
        private List<Employee> employees = new List<Employee>()//Crea un CONTROLADOR privado //Lista de employees
        {
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Employee One"
            },

            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Employee Two"
            }
        };

    //Definicion de metodos

    public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existEmployee = GetEmployee(employee.Id);
            existEmployee.Name = employee.Name;
            return existEmployee;
        }

        public Employee GetEmployee(Guid id)//IMplementacion usuario
        {
            return employees.SingleOrDefault(x => x.Id == id); //Single or Default
        }

        public List<Employee> GetEmployees()//Implementacion que llama al controlador
        {
            return employees;
        }
    }
}
