using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlConnection conexion;
        private static SqlCommand comando;
        #endregion

        #region Cosntructor
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inserta en la base de datos el paquete que se le pasa
        /// </summary>
        /// <param name="p">Paquete a guardar en la base de datos</param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                comando.CommandText = "INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES('" + p.DireccionEntrega + "','" + p.TrackingID + "', 'Jakubek Gabriel')";
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(comando.Connection.State == ConnectionState.Open)
                {
                    comando.Connection.Close();
                }
            }
            return retorno;
        }
        #endregion
    }
}
