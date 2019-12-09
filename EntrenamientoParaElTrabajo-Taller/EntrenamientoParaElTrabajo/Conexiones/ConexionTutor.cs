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
    public class ConexionTutor
    {
       
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection cn;
        
        public void conectar()
        {
            ConexionGeneral nuevo = new ConexionGeneral();
            cn = nuevo.FUNCION();
        }

        public string insertarTutor(Tutor t)
        {            
            string salida = "Se Ingreso Correctame nte";
            try
            {
                cn.Open();
                string query = "Insert into tutor(Nombre, Apellido, DNIT, Reparticion) values (@_Nombre, @_Apellido, @_DNIT, @_Repartcion)";
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_Nombre", t.Nombre);
                cmd.Parameters.AddWithValue("@_Apellido", t.Apellido);
                cmd.Parameters.AddWithValue("@_DNIT", t.DNIT);
                cmd.Parameters.AddWithValue("@_Repartcion", t.Reparticion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se ingreso los datos: " + ex.ToString();
            }
            cn.Close();
            return salida;
        }


        public string eliminarTutor(int id)
        {
            string salida = "Se Borro Correctamente";
            try
            {
                cn.Open();
                string query = "delete from tutor where IDTutor=" + id;
                cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se pudo borrar : " + ex.ToString();
            }
            cn.Close();
            return salida;
        }

        public string actualizarTutor(Tutor aux)
        {
            string salida = "Se Actualizo Correctamente";
            try
            {
                cn.Open();

                string query = "UPDATE tutor SET Nombre = @_Nombre, Apellido = @_Apellido, Reparticion = @_Reparticion, DNIT =  @_DNIT WHERE IDTutor=" + aux.Codigo;
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_Apellido", aux.Apellido);
                cmd.Parameters.AddWithValue("@_Nombre", aux.Nombre);
                cmd.Parameters.AddWithValue("@_Reparticion", aux.Reparticion);
                cmd.Parameters.AddWithValue("@_DNIT", aux.DNIT);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se pudo Actualizar : " + ex.ToString();
            }
            cn.Close();
            return salida;
        }
        public List<Tutor> RetornarUsuarioTutor(int dni)
        {
            List<Tutor> ListaAUX = new List<Tutor>();
            try
            {
                cn.Open();
                string query = "Select * from tutor where DNIT = "+ dni;
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Tutor aux = new Tutor();
                    aux.Codigo = (int)dr["IDTutor"];
                    aux.Nombre = (string)dr["Nombre"];
                    aux.Apellido = (string)dr["Apellido"];
                    aux.DNIT = (int)dr["DNIT"];
                    aux.Reparticion = (string)dr["Reparticion"];
                    ListaAUX.Add(aux);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudieron traer los datos" + ex.ToString());
            }
            cn.Close();
            return ListaAUX;

        }
        public List<Tutor> RetornarTablaTutor()
        {
            List<Tutor> ListaAUX = new List<Tutor>();
            try
            {
                cn.Open();
                string query = "Select * from tutor";
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Tutor aux = new Tutor();
                    aux.Codigo = (int)dr["IDTutor"];
                    aux.Nombre = (string)dr["Nombre"];
                    aux.Apellido = (string)dr["Apellido"];
                    aux.DNIT = (int)dr["DNIT"];
                    aux.Reparticion = (string)dr["Reparticion"];
                    ListaAUX.Add(aux);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudieron traer los datos" + ex.ToString());
            }
            cn.Close();
            return ListaAUX;
        }


        public Tutor RetornarUsuarioTutorID(int id)
        {
            Tutor aux = new Tutor();
            try
            {
                cn.Open();
                string query = "Select * from tutor where IDInstructor = " + id;
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    aux.Codigo = (int)dr["IDTutor"];
                    aux.Nombre = (string)dr["Nombre"];
                    aux.Apellido = (string)dr["Apellido"];
                    aux.DNIT = (int)dr["DNIT"];
                    aux.Reparticion = (string)dr["Reparticion"];      
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudieron traer los datos" + ex.ToString());
            }
            cn.Close();
            return aux;
        }
    }
}
