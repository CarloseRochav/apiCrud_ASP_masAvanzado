using ApiRestCrudAlfa.Models;
using System;
using System.Collections.Generic;

namespace ApiRestCrudAlfa.EmployeeData
{
    public interface IEmployeeData //ES importante convertir la interface es "PUBLIC"
    {
        List<Employee> GetEmployees();//Definicion de metodo de tipo List 

        //Metodo para obtener un empleado

        Employee GetEmployee(Guid id);

        //Agregar Empleado
        Employee AddEmployee(Employee employee);

        //Eliminar empleado
        void DeleteEmployee(Employee employee);

        //Actualizar empleado

        Employee EditEmployee(Employee employee);
    }
}
