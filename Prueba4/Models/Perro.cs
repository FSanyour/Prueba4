using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prueba4.Models {
    public class Perro {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su N° de registro")]
        [Display(Name = "id")]
        public int NumeroRegistro { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese su nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la edad de la mascota")]
        [Range(0, 15, ErrorMessage = "Ingrese edad de su mascota")]
        public int Edad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese tipo de raza")]
        public string Raza { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el tamaño de su mascota")]
        public float Tamaño { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese tipo de pelaje")]
        public string Pelaje { get; set; }

        [Display(Name = "Fecha de nacimineto")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public Perro() { }
        public Perro(int numRegistro, string nombre, int edad, string raza, float tamaño, string pelaje, DateTime fechaNacimiento) {
            NumeroRegistro = numRegistro;
            Nombre = nombre;
            Edad = edad;
            Raza = raza;
            Tamaño = tamaño;
            Pelaje = pelaje;
            FechaNacimiento = fechaNacimiento;
        }

    }
}