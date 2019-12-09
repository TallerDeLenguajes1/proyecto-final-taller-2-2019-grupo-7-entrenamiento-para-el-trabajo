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
    public class ConexionBeneficiario
    {
        MySqlConnection cn;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public void conectar()
        {
            ConexionGeneral nuevo = new ConexionGeneral();
            cn = nuevo.FUNCION();
        }

        public string insertarBeneficiario(Beneficiario b)
        {
            string salida = "Se Ingreso Correctamente";
            try
            {
                cn.Open();
                string query = "Insert into Beneficiario(Nombre, Apellido, DNIBeneficiario, Mail, CUIL, Escolaridad) values (@_Nombre, @_Apellido, @_DNIBeneficiario, @_Mail, @_CUIL, @_Escolaridad)";
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_Nombre", b.Nombre);
                cmd.Parameters.AddWithValue("@_Apellido", b.Apellido);
                cmd.Parameters.AddWithValue("@_DNIBeneficiario", b.DNI);
                cmd.Parameters.AddWithValue("@_Mail", b.Email);
                cmd.Parameters.AddWithValue("@_CUIL", b.CUIL);
                cmd.Parameters.AddWithValue("@_Escolaridad", b.Escolaridad);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se ingreso los datos: " + ex.ToString();
            }
            cn.Close();
            return salida;
        }
        public string insertarCursoAsistido(int idbeneficiario, int idcurso)
        {
            string salida = "Se Ingreso Correctamente";
            try
            {
                cn.Open();
                string query = "Insert into cursados (ID_CursosC, ID_Beneficiario) values (@_IDCurso, @_IDBeneficiario)";
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_IDCurso", idcurso);
                cmd.Parameters.AddWithValue("@_IDBeneficiario", idbeneficiario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se ingreso los datos: " + ex.ToString();
            }
            cn.Close();
            return salida;
        }

        public string insertarContratoRealizado(int idbeneficiario, int idcontrato)
        {
            string salida = "Se Ingreso Correctamente";
            try
            {
                cn.Open();
                string query = "UPDATE beneficiario set IDContrato = @_IDContrato WHERE IDBeneficiario=" + idbeneficiario;
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_IDContrato", idcontrato);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se ingreso los datos: " + ex.ToString();
            }
            cn.Close();
            return salida;
        }


        public string eliminarBeneficiario(int id)
        {
            string salida = "Se Borro Correctamente";
            try
            {
                cn.Open();
                string query = "delete from Beneficiario where IDBeneficiario=" + id;
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

        public string eliminarCursados(int idb, int idc)
        {
            string salida = "Se Borro Correctamente";
            try
            {
                cn.Open();
                string query = "delete from Cursados where ID_Beneficiario='" + idb + "'AND ID_CursosC=" + idc;
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

        public string eliminarContrato(int idb)
        {
            string salida = "Se Borro Correctamente";
            try
            {
                cn.Open();
                string query = "update Beneficiario set IDContrato= NULL WHERE IDBeneficiario=" + idb;
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

        public string actualizarBeneficiario(Beneficiario b)
        {
            string salida = "Se Actualizo Correctamente";
            try
            {
                cn.Open();
                string query = "update Beneficiario set Nombre = @_Nombre, Apellido = @_Apellido, DNIBeneficiario = @_DNIBeneficiario, Mail = @_Mail, CUIL = @_CUIL, Escolaridad = @_Escolaridad WHERE IDBeneficiario = " + b.IDBeneficiario;
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_Nombre", b.Nombre);
                cmd.Parameters.AddWithValue("@_Apellido", b.Apellido);
                cmd.Parameters.AddWithValue("@_DNIBeneficiario", b.DNI);
                cmd.Parameters.AddWithValue("@_Mail", b.Email);
                cmd.Parameters.AddWithValue("@_CUIL", b.CUIL);
                cmd.Parameters.AddWithValue("@_Escolaridad", b.Escolaridad);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se pudo Actualizar : " + ex.ToString();
            }
            cn.Close();
            return salida;
        }

        public List<Beneficiario> RetornarBeneficiario(string dni)
        {
            List<Beneficiario> ListaAUX = new List<Beneficiario>();
            try
            {
                cn.Open();
                string query = "Select * from Beneficiario where IDBeneficiario = " + dni;
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Beneficiario aux = new Beneficiario();
                    aux.IDBeneficiario = (int)dr["IDBeneficiario"];
                    if((int)dr["IDContrato"] >= 0)
                    {
                        aux.IDContrato = (int)dr["IDContrato"];
                    }     
                    aux.Nombre = (string)dr["Nombre"];
                    aux.Apellido = (string)dr["Apellido"];
                    aux.DNI = (int)dr["DNIBeneficiario"];
                    aux.Email = (string)dr["Mail"];
                    aux.CUIL = (int)dr["CUIL"];
                    aux.Escolaridad = (string)dr["Escolaridad"];
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

        public List<Beneficiario> RetornarTablaBeneficiario()
        {
            List<Beneficiario> ListaAUX = new List<Beneficiario>();
            try
            {
                cn.Open();
                string query = "Select * from Beneficiario";
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Beneficiario aux = new Beneficiario();
                    aux.IDBeneficiario = (int)dr["IDBeneficiario"];
                    int aux2;
                    if (int.TryParse(dr["IDContrato"].ToString(), out aux2))
                    {
                        aux.IDContrato = aux2;
                    }

                    aux.Nombre = (string)dr["Nombre"];
                    aux.Apellido = (string)dr["Apellido"];
                    aux.DNI = (int)dr["DNIBeneficiario"];
                    aux.Email = (string)dr["Mail"];
                    aux.CUIL = (int)dr["CUIL"];
                    aux.Escolaridad = (string)dr["Escolaridad"];
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

        public List<Cursados> RetornarTablaCursadosID(int idb)
        {
            List<Cursados> ListaAUX = new List<Cursados>();
            try
            {
                cn.Open();
                string query = "Select * from Cursados WHERE ID_Beneficiario=" + idb;
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cursados aux = new Cursados();
                    aux.IDBeneficiario = (int)dr["ID_Beneficiario"];
                    aux.IDCursos = (int)dr["ID_CursosC"];
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