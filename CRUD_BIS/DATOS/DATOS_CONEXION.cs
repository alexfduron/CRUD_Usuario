using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//hacemos referencia a las herramientas del SQL Server
using System.Data.SqlClient;
//hecmos referencia a la libreria de conexion
using System.Data;

namespace CRUD_BIS.DATOS
{
    internal static class DATOS_CONEXION
    {
        //el @ se usa para indicar que estamos utilizando caracteres
        public static SqlConnection CONEXION = new SqlConnection(
            @"Data Source=BISW_PRODUC19\SQLEXPRESS; " +
            "Initial Catalog=USUARIOBD; " + 
            "Integrated Security=true"
            );

        //creamos dos procedimientos para abrir y cerrar la conexion la SQL
        public static void ABRIR()
        {

            if(CONEXION.State == ConnectionState.Closed)
            {

                CONEXION.Open();

            }

        }

        public static void CERRAR()
        {

            if (CONEXION.State == ConnectionState.Open)
            {

                CONEXION.Close();

            }

        }

    }
}
