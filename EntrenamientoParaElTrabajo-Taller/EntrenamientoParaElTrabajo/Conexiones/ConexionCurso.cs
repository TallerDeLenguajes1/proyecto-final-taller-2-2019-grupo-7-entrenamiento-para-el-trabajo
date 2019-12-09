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
    public class ConexionCurso
    {
        MySqlConnection cn;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public void conectar()
        {
            ConexionGeneral nuevo = new ConexionGeneral();
            cn = nuevo.FUNCION();
        }

        public string insertarCurso(Curso curso)
        {
            string salida = "Se Ingreso Correctamente";
            try
            {
                cn.Open();

                string query = "Insert into Cursos(NombreC, Tematica) values (@_NombreC, @_Tematica)";
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_NombreC", curso.Nombre);
                cmd.Parameters.AddWithValue("@_Tematica", curso.Tematica);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                salida = "No se ingreso los datos: " + ex.ToString();
            }
            return salida;
        }


        public string eliminarCurso(int id)
        {
            string salida = "Se Borro Correctamente";
            try
            {
                cn.Open();
                string query = "delete from Cursos where IDCurso=" + id;
                cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                salida = "No se pudo borrar : " + ex.ToString();
            }
            return salida;
        }



        public string actualizarCurso(Curso curso)
        {
            string salida = "Se Actualizo Correctamente";
            try
            {
                cn.Open();
                string query = "update cursos set NombreC = @_NombreC, Tematica= @_Tematica where IDCurso=" + curso.IDCurso;
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_NombreC", curso.Nombre);
                cmd.Parameters.AddWithValue("@_Tematica", curso.Tematica);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se pudo Actualizar : " + ex.ToString();
            }
            cn.Close();
            return salida;
        }

        public List<Curso> RetornarCurso(string nombre)
        {
            List<Curso> ListaAUX = new List<Curso>();
            try
            {
                cn.Open();
                string query = "Select * from Cursos where NombreC = " + nombre;
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Curso aux = new Curso();
                    aux.IDCurso = (int)dr["IDCurso"];
                    aux.Nombre = (string)dr["NombreC"];
                    aux.Tematica = (string)dr["Tematica"];
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

        public List<Curso> RetornarTablaCurso()
        {
            List<Curso> ListaAUX = new List<Curso>();
            try
            {
                cn.Open();
                string query = "Select * from Cursos";
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Curso aux = new Curso();
                    aux.IDCurso = (int)dr["IDCurso"];
                    aux.Nombre = (string)dr["NombreC"];
                    aux.Tematica = (string)dr["Tematica"];
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