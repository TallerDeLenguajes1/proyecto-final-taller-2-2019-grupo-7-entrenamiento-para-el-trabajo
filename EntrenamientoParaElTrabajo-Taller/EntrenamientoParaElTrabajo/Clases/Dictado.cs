using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Dictado
    {
        public int IDDictado { get; set; }
        public DateTime Fecha { get; set; }
        public string Objetivos { get; set; }
        public int IDTutor { get; set; }
        public int IDInstructor { get; set; }
        public int IDCurso { get; set; }

        public Dictado() { }

        public Dictado(int _idTutor, int _idInstructor, DateTime _Fecha, string _objetivos , int _idCurso)
        {
            IDTutor = _idTutor;
            IDInstructor = _idInstructor;
            Fecha = _Fecha;
            Objetivos = _objetivos;
            IDCurso = _idCurso;
        }

        public Dictado(int _idDictado, DateTime _Fecha, string _objetivos, int _idTutor, int _idInstructor)
        {
            IDDictado = _idDictado;
            IDTutor = _idTutor;
            IDInstructor = _idInstructor;
            Fecha = _Fecha;
            Objetivos = _objetivos;
        }

        public override string ToString()
        {
            return "    Objetivos: " + Objetivos + "\n    Tutor Designado: " + IDTutor + "\n    Instructor Designado: " + IDInstructor + "\n    Fecha del Dictado: " + Fecha + "\n    IDCurso: " + IDCurso;
        }

    }
}
