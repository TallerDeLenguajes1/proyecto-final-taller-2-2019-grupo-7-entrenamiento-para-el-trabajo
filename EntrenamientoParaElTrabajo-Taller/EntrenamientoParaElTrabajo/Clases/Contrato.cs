using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Contrato
    {
        public int IDContrato { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string Cargo { get; set; }
        public float Sueldo { get; set; }
        public string Empresa { get; set; }

        public Contrato() 
        { 
        
        }

        public Contrato(DateTime _fechaIngreso, DateTime _fechaSalida, string _cargo, float _sueldo, string _empresa)
        {
            Fecha_Inicio = _fechaIngreso;
            Fecha_Fin = _fechaIngreso;
            Cargo = _cargo;
            Sueldo = _sueldo;
            Empresa = _empresa;
        }

        public Contrato(int _idcontrato, DateTime _fechaIngreso, DateTime _fechaSalida, string _cargo, float _sueldo, string _empresa)
        {
            IDContrato = _idcontrato;
        }

        public override string ToString()
        {
            return "    Fecha Ingreso: " + Fecha_Inicio + "\n    Fecha Salida: " + Fecha_Fin + "\n    Cargo " + Cargo + "\n    Empresa: " + Empresa + "\n";
        }
    }
}
