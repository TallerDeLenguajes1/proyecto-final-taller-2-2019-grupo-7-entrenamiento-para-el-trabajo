using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Curso
    {
        public int IDCurso { get; set; }
        public string Nombre { get; set; }
        public string Tematica { get; set; }
        public Curso() { }

        public Curso(string _nombre, string _tematica)
        {
            Nombre = _nombre;
            Tematica = _tematica;
        }

        public Curso(int _codigo, string _nombre, string _tematica)
        {
            IDCurso = _codigo;
            Nombre = _nombre;
            Tematica = _tematica;
        }

        public override string ToString()
        {
            return "     Nombre: " + Nombre + "\n     Tematica: " + Tematica;
        }
    }
}
