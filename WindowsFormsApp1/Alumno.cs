using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeAlumnos
{
    public class Alumno
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string curso { get; set; }
        public string direccion { get; set; }

        public Alumno() { }

        public Alumno(int id, string nombre, int edad, string curso, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.edad = edad;
            this.curso = curso;
            this.direccion = direccion;

        }
    }
}
