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
    public class ConexionLogueo
    {
        MySqlConnection cn;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public void conectar()
        {
            ConexionGeneral nuevo = new ConexionGeneral();
            cn = nuevo.FUNCION();
        }

        public int Validar(string user, string password)
        {
            int aux = 0;
            try
            {
                cn.Open();
                string query = "Select * from logueo";
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   if (user == (string)dr["user"] && password == (string)dr["password"])
                   {
                    aux = 1;
                   }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudieron recuperar los datos."+ex.ToString());
            }
            cn.Close();
            return aux;
        }
    }
}
