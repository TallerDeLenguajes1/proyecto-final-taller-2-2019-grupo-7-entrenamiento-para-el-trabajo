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
    public class ConexionInstructor
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection cn;

        public void conectar()
        {
            ConexionGeneral nuevo = new ConexionGeneral();
            cn = nuevo.FUNCION();
        }

        public string insertarInstructor(Instructor t)
        {
            string salida = "Se Ingreso Correctamente";
            try
            {
                cn.Open();
                string query = "Insert into instructor(Nombre, Apellido, DNII, Reparticion) values (@_Nombre, @_Apellido, @_DNII, @_Reparticion)";
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_Nombre", t.Nombre);
                cmd.Parameters.AddWithValue("@_Apellido", t.Apellido);
                cmd.Parameters.AddWithValue("@_DNII", t.DNII);
                cmd.Parameters.AddWithValue("@_Reparticion", t.Reparticion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se ingreso los datos: " + ex.ToString();
            }
            cn.Close();
            return salida;
        }  

        public string eliminarInstructor(int id)
        {
            string salida = "Se Borro Correctamente";
            try
            {
                cn.Open();
                string query = "delete from instructor where IDInstructor=" + id;
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

        public string actualizarInstructor(Instructor aux)
        {
            string salida = "Se Actualizo Correctamente";
            try
            {
                cn.Open();

                string query = "UPDATE instructor SET Nombre = @_Nombre, Apellido = @_Apellido, Reparticion = @_Reparticion, DNII = @_DNII where IDInstructor=" + aux.Codigo;
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_Apellido", aux.Apellido);
                cmd.Parameters.AddWithValue("@_Nombre", aux.Nombre);
                cmd.Parameters.AddWithValue("@_Reparticion", aux.Reparticion);
                cmd.Parameters.AddWithValue("@_DNII", aux.DNII);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se pudo Actualizar : " + ex.ToString();
            }
            cn.Close();
            return salida;
        }


        public List<Instructor> RetornarUsuarioInstructor(int dni)
        {
            List<Instructor> ListaAUX = new List<Instructor>();
            try
            {
                cn.Open();
                string query = "Select * from instructor where DNII = " + dni;
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Instructor aux = new Instructor();
                    aux.Codigo = (int)dr["IDInstructor"];
                    aux.Nombre = (string)dr["Nombre"];
                    aux.Apellido = (string)dr["Apellido"];
                    aux.DNII = (int)dr["DNII"];
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
        public List<Instructor> RetornarTablaInstructor()
        {
            List<Instructor> ListaAUX = new List<Instructor>();
            try
            {
                cn.Open();
                string query = "Select * from instructor";
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Instructor aux = new Instructor();
                    aux.Codigo = (int)dr["IDInstructor"];
                    aux.Nombre = (string)dr["Nombre"];
                    aux.Apellido = (string)dr["Apellido"];
                    aux.DNII = (int)dr["DNII"];
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

        public List<Instructor> RetornarUsuarioInstructorID(int id)
        {
            List<Instructor> ListaAUX = new List<Instructor>();
            try
            {
                cn.Open();
                string query = "Select * from instructor where IDInstructor = " + id;
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Instructor aux = new Instructor();
                    aux.Codigo = (int)dr["IDInstructor"];
                    aux.Nombre = (string)dr["Nombre"];
                    aux.Apellido = (string)dr["Apellido"];
                    aux.DNII = (int)dr["DNII"];
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

    }
}
