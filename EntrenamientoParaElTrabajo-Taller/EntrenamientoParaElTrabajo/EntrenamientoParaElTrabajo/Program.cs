using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Clases;
using Conexiones;

namespace EntrenamientoParaElTrabajo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //PRUEBA TUTOR

            //Declaracion de listas para Tutor.

            List<Tutor> ListadosDeTutores = new List<Tutor>();
            List<Tutor> ListadosDelUsuario = new List<Tutor>();

            //Conexion a la base de Datos.

            ConexionTutor C = new ConexionTutor();
            C.conectar();
            Console.ReadKey();

            //Creacion del objeto Tutor.

            //Tutor TutorNuevo = new Tutor("SergioFF", "GONZALESFF", 12344, "Prueba4");
            //Tutor TutorNuevo2 = new Tutor(25, "Daniel", "Fernandez", 22222, "Prueba22");
            //Console.WriteLine(TutorNuevo.ToString());
           // Console.ReadKey();

            //Ingresar Tutor a la Base de Datos.

           // Console.WriteLine(C.insertarTutor(TutorNuevo));
           // Console.ReadKey();
            
            //Eliminacion de un Tutor en la Base de Datos determinado por su ID.

            /*Console.WriteLine(C.eliminar(4));
            Console.ReadKey();*/

            //Actualizacion de un registro Tutor ya ingresado.

            /*Console.WriteLine(C.actualizar(TutorNuevo2));
            Console.ReadKey();*/

            //Recuperar registros de un usuario determinado por su DNI.

            /*ListadosDelUsuario = C.RetornarUsuario(2);

            //Listado de los registros del usuario recuperados anteriormente.

            Console.WriteLine("Listado del Usuario: \n");

            foreach (Tutor X in ListadosDelUsuario)
            {
                Console.WriteLine(X.getTutor());
            }
            Console.ReadKey();*/

            //Recuperacion de registros de todos los registros de la tabla Tutor.

            ListadosDeTutores = C.RetornarTablaTutor();

            //Listado de los registros de Tutores recuperados anteriormente.

            Console.WriteLine("Listado de Tutores: \n");

           foreach (Tutor X in ListadosDeTutores)
            {
                Console.WriteLine(X.getTutor());
                C.RetornarTablaTutor();
            }
            Console.ReadKey();

            //-----------------------------------------------------------------------------------------------------

            //PRUEBA INSTRUCTOR

            //Declaracion de listas para Tutor.

            List<Instructor> ListadosDeInstructores = new List<Instructor>();
            List<Instructor> ListadosDelUsuario2 = new List<Instructor>();
            
            //Conexion a la base de datos.

            ConexionInstructor C2 = new ConexionInstructor();
            C2.conectar();
            Console.ReadKey();

            //Creacion del objeto Instructor.
            Instructor InstructorNuevo = new Instructor("Martin", "Quintana", 33333555, "Prueba Instruc");
            Console.WriteLine("\n"+InstructorNuevo.ToString());
            Console.ReadKey();

            //Ingreso Instructor a la base de datos.

            Console.WriteLine(C2.insertarInstructor(InstructorNuevo));
            Console.ReadKey();

            //Eliminacion de un Instructor en la Base de Datos determinado por su ID.

            /*Console.WriteLine(C2.eliminar(5));
            Console.ReadKey();*/

            //Actualizacion de un registro Instructor ya ingresado.

            /*Console.WriteLine(C2.actualizar(InstructorNuevo));
            Console.ReadKey();*/

            //Recuperar registros de un usuario determinado por su DNI.

            /*ListadosDelUsuario = C.RetornarUsuario(2);

            //Listado de los registros del usuario recuperados anteriormente.

            Console.WriteLine("Listado del Usuario: \n");

            foreach (Tutor X in ListadosDelUsuario)
            {
                Console.WriteLine(X.getTutor());
            }
            Console.ReadKey();*/

            //Recuperacion de registros de todos los registros de la tabla Instructor.

            ListadosDeInstructores = C2.RetornarTablaInstructor();

            //Listado de los registros de Instructores recuperados anteriormente.

            Console.WriteLine("Listado de Instructores: \n");

            foreach (Instructor X in ListadosDeInstructores)
            {
                Console.WriteLine(X.getInstructor());
            }
            Console.ReadKey();

            //------------------------------------------------------------------------------

            //PRUEBA CONTRATO

            //Declaracion de listas para Contrato.

            List<Contrato> ListadosDeContratos = new List<Contrato>();
            List<Contrato> ListadosDelUsuario3 = new List<Contrato>();

        }
    }
}


