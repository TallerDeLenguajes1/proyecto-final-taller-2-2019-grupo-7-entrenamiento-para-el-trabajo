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
    public class ConexionContrato
    {
        MySqlConnection cn;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public void conectar()
        {
            ConexionGeneral nuevo = new ConexionGeneral();
            cn = nuevo.FUNCION();
        }

        public string insertarContrato(Contrato c)
        {
            string salida = "Se Ingreso Correctamente";
            try
            {
                cn.Open();
                string query = "Insert into contrato(FechaInicio,FechaFin,Cargo,Empresa) values (@_Fecha_Ingreso,@_Fecha_Salida,@_Cargo,@_Empresa)";
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_Fecha_Ingreso", c.Fecha_Inicio);
                cmd.Parameters.AddWithValue("@_Fecha_Salida", c.Fecha_Fin);
                cmd.Parameters.AddWithValue("@_Cargo", c.Cargo);
                cmd.Parameters.AddWithValue("@_Empresa", c.Empresa);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se ingreso los datos: " + ex.ToString();
            }
            cn.Close();
            return salida;
        }


        public string eliminarContrato(int id)
        {
            string salida = "Se Borro Correctamente";
            try
            {
                cn.Open();
                string query = "delete from contrato where IDContrato=" + id;
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

        public string actualizarContrato(Contrato cont)
        {
            string salida = "Se Actualizo Correctamente";
            try
            {
                cn.Open();
                string query = "update contrato set FechaInicio = @_Fecha_Inicio, FechaFin = @_Fecha_Fin, Cargo = @_Cargo, Empresa = @_Empresa where IDContrato =" + cont.IDContrato;
                cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@_Fecha_Inicio", cont.Fecha_Inicio);
                cmd.Parameters.AddWithValue("@_Fecha_Fin", cont.Fecha_Fin);
                cmd.Parameters.AddWithValue("@_Cargo", cont.Cargo);
                cmd.Parameters.AddWithValue("@_Empresa", cont.Empresa);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se pudo Actualizar : " + ex.ToString();
            }
            cn.Close();
            return salida;
        }

        public List<Contrato> RetornarContrato(string emp)
        {
            List<Contrato> ListaAUX = new List<Contrato>();
            try
            {
                cn.Open();
                string query = "Select * from contrato where Empresa= " + emp;
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Contrato aux = new Contrato();
                    aux.IDContrato = (int)dr["IDContrato"];
                    aux.Fecha_Inicio = (DateTime)dr["FechaInicio"];
                    aux.Fecha_Fin = (DateTime)dr["FechaFin"];
                    aux.Cargo = (string)dr["Cargo"];
                    aux.Empresa = (string)dr["Empresa"];
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

        public List<Contrato> RetornarTablaContrato()
        {
            List<Contrato> ListaAUX = new List<Contrato>();
            try
            {
                cn.Open();
                string query = "Select * from Contrato";
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Contrato aux = new Contrato();
                    aux.IDContrato = (int)dr["IDContrato"];
                    aux.Fecha_Inicio = (DateTime)dr["FechaInicio"];
                    aux.Fecha_Fin = (DateTime)dr["FechaFin"];
                    aux.Cargo = (string)dr["Cargo"];
                    aux.Empresa = (string)dr["Empresa"];
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
