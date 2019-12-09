using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Clases;


namespace Conexiones
{
    public class ConexionGeneral
    { 
       MySqlConnection cn;

       public MySqlConnection FUNCION()
       {
          try
            {
                string server = "localhost";
                string database = "tallerf";
                string uid = "root";
                string password = "bd2020";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                cn = new MySqlConnection(connectionString);
                cn.Open();
                Console.WriteLine("Conectado");
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo conectar con la base de datos" + ex.ToString());
                cn.Close();
            }
            return cn;
           
        }

    }
}