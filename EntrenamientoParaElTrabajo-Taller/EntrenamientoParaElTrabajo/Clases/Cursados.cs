using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Cursados
    {
        public int IDBeneficiario { get; set; }
        public int IDCursos { get; set; }

        public Cursados()
        {

        }

        public Cursados(int _idbeneficiario, int _idcurso)
        {
            IDBeneficiario = _idbeneficiario;
            IDCursos = _idcurso;
        }

        public override string ToString()
        {
            return "    IDBeneficiario: " + IDBeneficiario + "\n    IDCurso: " + IDCursos;
        }
    }
}
