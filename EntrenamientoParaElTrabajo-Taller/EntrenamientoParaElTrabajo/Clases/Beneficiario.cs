using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Beneficiario
    {

        public int IDBeneficiario { get; set; }
        public int IDContrato { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Email { get; set; }
        public int CUIL { get; set; }
        public string Escolaridad { get; set; }

        public Beneficiario()
        {
            IDContrato = 0;
        }

        public Beneficiario(int _idContrato, string _nombre, string _apellido, int _dni, string _email, int _cuil, string _escolaridad)
        {
            IDContrato = _idContrato;
            Nombre = _nombre;
            Apellido = _apellido;
            DNI = _dni;
            Email = _email;
            CUIL = _cuil;
            Escolaridad = _escolaridad;
        }
        public override string ToString()
        {
            string aux;

            if (IDContrato < 1)
            {
                aux = "    IDBeneficiario: " + IDBeneficiario +
                   "\n    Nombre: " + Nombre +
                   "\n    Apellido: " + Apellido +
                   "\n    DNI: " + DNI +
                   "\n    Email: " + Email +
                   "\n    CUIL: " + CUIL +
                   "\n    Escolaridad: " + Escolaridad;
            }
            else
            {
                aux = "    IDBeneficiario: " + IDBeneficiario +
                   "\n    Nombre: " + Nombre +
                   "\n    Apellido: " + Apellido +
                   "\n    DNI: " + DNI +
                   "\n    Email: " + Email +
                   "\n    CUIL: " + CUIL +
                   "\n    Escolaridad: " + Escolaridad +
                   "\n    IDContrato: " + IDContrato;
            }

            return aux;
        }
    }
}
