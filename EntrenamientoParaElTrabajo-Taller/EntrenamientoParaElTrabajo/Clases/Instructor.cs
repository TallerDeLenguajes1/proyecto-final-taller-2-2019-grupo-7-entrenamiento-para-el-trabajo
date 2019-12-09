using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Instructor
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Reparticion { get; set; }
        public int DNII { get; set; }
        public int Codigo { get; set; }

        public Instructor()
        {

        }

        public Instructor(string _Nombre, string _apellido, int _DNII, string _reparticion)
        {
            Nombre = _Nombre;
            Apellido = _apellido;
            DNII = _DNII;
            Reparticion = _reparticion;
        }

        public Instructor(int _codigo, string _Nombre, string _apellido, int _DNIT, string _reparticion)
        {
            Codigo = _codigo;
        }

        public override string ToString()
        {
            return "    Nombre: " + Nombre + "\n    Apellido: " + Apellido + "\n    DNI: " + DNII + "\n    Reparticion " + Reparticion;
        }

    }
}

