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
    public class ConexionDictado
    {
        MySqlConnection cn;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public void conectar()
        {
            ConexionGeneral nuevo = new ConexionGeneral();
            cn = nuevo.FUNCION();
        }

        public string insertarDictado(Dictado dictado)
        {
            string salida = "Se Ingreso Correctamente";
            try
            {
                cn.Open();
                string query = "Insert into dictado (IDInstructor,IDTutor,FechaD,Objetivos,ID_Curso) values (@_IDInstructor,@_IDTutor,@_FechaD,@_Objetivos,@_idCurso)";
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_IDInstructor", dictado.IDInstructor);
                cmd.Parameters.AddWithValue("@_IDTutor", dictado.IDTutor);
                cmd.Parameters.AddWithValue("@_FechaD", dictado.Fecha);
                cmd.Parameters.AddWithValue("@_Objetivos", dictado.Objetivos);
                cmd.Parameters.AddWithValue("@_idCurso", dictado.IDCurso);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                salida = "No se ingreso los datos: " + ex.ToString();
            }
            return salida;
        }


        public string eliminarDictado(int id)
        {
            string salida = "Se Borro Correctamente";
            try
            {
                cn.Open();
                string query = "delete from dictado where IDDictado=" + id;
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



        public string actualizarDictado(Dictado dict)
        {
            string salida = "Se Actualizo Correctamente";
            try
            {
                
                cn.Open();
                string query = "update dictado set IDInstructor = @_IDInstructor, IDTutor = @_IDTutor, FechaD = @_FechaD, Objetivos = @_Objetivos, ID_Curso = @_IDCurso WHERE IDDictado =" + dict.IDDictado;
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_IDInstructor", dict.IDInstructor);
                cmd.Parameters.AddWithValue("@_IDTutor", dict.IDTutor);
                cmd.Parameters.AddWithValue("@_FechaD", dict.Fecha);
                cmd.Parameters.AddWithValue("@_Objetivos", dict.Objetivos);
                cmd.Parameters.AddWithValue("@_IDCurso", dict.IDCurso);
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
                salida = "No se pudo Actualizar : " + ex.ToString();
            }
            return salida;
        }

        public List<Dictado> RetornarDictados(int a)
        {
            List<Dictado> ListaAUX = new List<Dictado>();
            try
            {
                cn.Open();
                string query = "Select * from Dictado where IDInstructor = " + a;
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Dictado aux = new Dictado();
                    aux.IDDictado = (int)dr["IDDictado"];
                    aux.IDInstructor = (int)dr["IDInstructor"];
                    aux.IDTutor = (int)dr["IDTutor"];
                    aux.Fecha = (DateTime)dr["FechaD"];
                    aux.Objetivos = (string)dr["Objetivos"];
                    ListaAUX.Add(aux);
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudieron traer los datos" + ex.ToString());
            }
            return ListaAUX;

        }

        public List<Dictado> RetornarTablaDictado()
        {
            List<Dictado> ListaAUX = new List<Dictado>();
            try
            {
                cn.Open();
                string query = "Select * from Dictado";
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Dictado aux = new Dictado();
                    aux.IDDictado = (int)dr["IDDictado"];
                    aux.IDInstructor = (int)dr["IDInstructor"];
                    aux.IDTutor = (int)dr["IDTutor"];
                    aux.Fecha = (DateTime)dr["FechaD"];
                    aux.Objetivos = (string)dr["Objetivos"];
                    aux.IDCurso = (int)dr["ID_Curso"];
                    ListaAUX.Add(aux);
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudieron traer los datos" + ex.ToString());
            }
            return ListaAUX;

        }
    }
}
