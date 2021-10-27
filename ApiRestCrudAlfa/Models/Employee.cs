using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//Importante importar librera para Datos
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCrudAlfa.Models
{   
    //Modelo de empleado
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Excede los 50 caracteres de longitud")]
        public string Name { get; set; }
    }
}
