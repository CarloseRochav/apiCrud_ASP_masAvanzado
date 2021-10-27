using ApiRestCrudAlfa.EmployeeData;//Para poder usarla en esta clase
using ApiRestCrudAlfa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// - > Install EntityFramework ; Microsoft.Entityframework.sql & Microsoft.Entityframework.tools

namespace ApiRestCrudAlfa.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase //Para que un controlador de API se reconocido debe heredar de "ControlBase"
    {
        private IEmployeeData _employeeData;
        
        //Controlador que crea un objeto de IEmployeeData
        public EmployeesController(IEmployeeData employeeData)//COntrolador 
        {
            _employeeData = employeeData;//Asignacion del parametro
        }


        [HttpGet]//Uso de GET
        [Route("api/[controller]")]//Ruta / Endpoint
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees()); //REGRESA EMPOYEES - GET
        }


        //Obtener un solo empleado por medio de ID
        [HttpGet]//Uso de GET
        [Route("api/[controller]/{id}")]//Ruta || Endpoint
        public IActionResult GetEmployee(Guid id)
        {

            var employee = _employeeData.GetEmployee(id);

            if (employee!=null)
            {
                return Ok(employee);
            }

            return NotFound($"Empleado con id: {id} no fue encontrado"); //REGRESA EMPOYEES - GET
        }


        //Crear un nuevo empleado
        [HttpPost]//Uso de POST
        [Route("api/[controller]")]//Ruta || Endpoint
        public IActionResult GetEmployee(Employee employee)
        {

            _employeeData.AddEmployee(employee); //Agrego el employee al metodo de agregar

            return Created
                (
                HttpContext.Request.Scheme + "://"
                + HttpContext.Request.Host
                + HttpContext.Request.Path
                + "/" + employee.Id, employee
                );
        }

        //Eliminar un empleado
        [HttpDelete]//Uso de POST
        [Route("api/[controller]/{id}")]//Ruta || Endpoint
        public IActionResult DeleteEmployee(Guid id)
        {

            var employee =_employeeData.GetEmployee(id); //Agrego el employee al metodo de agregar

            if(employee != null)
            {
                _employeeData.DeleteEmployee(employee);//Eliminar empleado del modelo
                return Ok();
            }

            return NotFound($"Empleado con el id {id} no fue encontrado");
        }

        //Actualizar un empleado
        [HttpPatch]//Uso de PATCH
        [Route("api/[controller]/{id}")]//Ruta || Endpoint
        public IActionResult EditEmployee(Guid id,Employee employee)
        {

            var existEmployee = _employeeData.GetEmployee(id); //Agrego el employee al metodo de agregar

            if (existEmployee != null)
            {
                employee.Id = existEmployee.Id;
                _employeeData.EditEmployee(employee);
                return Ok();
            }

            return NotFound($"Empleado con el id {id} no fue encontrado");
        }
    }
}
