using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public delegate void ErrorEnSQL(string error);

    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;
        private static String connectionStr = @"Data Source=Nahuel-PC; " + "Initial Catalog =correo-sp-2017; Integrated Security = SSPI";


       // De surgir cualquier error con la carga de datos, se deberá lanzar una excepción tantas veces como sea
        //necesario hasta llegar a la vista(formulario). A través de un MessageBox informar lo ocurrido al
        //usuario de forma clara.De ser necesario, utilizar un evento para este fin.
        public static event ErrorEnSQL NoCargaEnBD;

        static PaqueteDAO()
        {
            conexion = new SqlConnection(connectionStr);
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        /// <summary>
        /// inserta los datos en sql
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool inserto = true;

            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                string instruccion = string.Format("insert into Paquetes (direccionEntrega, TrackingID, alumno) values ('{0}', '{1}', 'Fernandez.Luis')", p.DireccionEntrega, p.TrackingID);
                comando.CommandText = instruccion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                inserto = false;
                PaqueteDAO.NoCargaEnBD.Invoke(e.Message);
                throw e;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return inserto;
        }
    }
}
