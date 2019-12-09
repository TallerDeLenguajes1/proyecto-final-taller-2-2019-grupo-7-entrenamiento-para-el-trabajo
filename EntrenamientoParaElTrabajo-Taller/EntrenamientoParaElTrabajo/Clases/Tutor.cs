using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Tutor
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Reparticion { get; set; }
        public int DNIT { get; set; }
        public int Codigo { get; set; }
        public Tutor()
        {

        }

        public Tutor(string _Nombre, string _apellido, int _DNIT, string _reparticion)
        {
            Nombre = _Nombre;
            Apellido = _apellido;
            DNIT = _DNIT;
            Reparticion = _reparticion;
        }

        public Tutor(int _codigo, string _Nombre, string _apellido, int _DNIT, string _reparticion)
        {
            Codigo = _codigo;
        }

        public override string ToString()
        {
            return "    Nombre: " + Nombre + "\n    Apellido: " + Apellido + "\n    DNI: " + DNIT + "\n    Reparticion " + Reparticion;
        }
       
    }
}

