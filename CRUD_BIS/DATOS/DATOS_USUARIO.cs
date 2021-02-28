using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//hacemos referencia a las herramientas del SQL Server
using System.Data.SqlClient;
//hacemos refereancia a la clase Logica_usuario
using CRUD_BIS.LOGICA;
//hacemos referencia a los mensajes
using System.Windows.Forms;

namespace CRUD_BIS.DATOS
{
    class DATOS_USUARIO
    {

        private SqlCommand Cmd = new SqlCommand();

        private int ID_Usuario_4;

        public bool Insertar(LOGICA_USUARIO Dt)
        {

            try
            {

                DATOS_CONEXION.ABRIR();

                Cmd = new SqlCommand("Insertar_Usuario", DATOS_CONEXION.CONEXION);

                Cmd.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@Nombre", Dt.Nombre_3);

                Cmd.Parameters.AddWithValue("@Pass", Dt.Pass_3);

                Cmd.Parameters.AddWithValue("@Imagen", Dt.Icono_3);

                Cmd.Parameters.AddWithValue("@Estado", Dt.Estado_3);

                if(Cmd.ExecuteNonQuery() != 0)
                {

                    return true;

                }else
                {

                    return false;

                }

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

                return false;

            }
            finally
            {

                DATOS_CONEXION.CERRAR();

            }

        }

    }
}
