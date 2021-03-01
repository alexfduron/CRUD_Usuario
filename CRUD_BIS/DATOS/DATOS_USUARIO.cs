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
//hacemos referencia a los datos
using System.Data;

namespace CRUD_BIS.DATOS
{
    class DATOS_USUARIO
    {

        private SqlCommand Cmd = new SqlCommand();

        private int ID_Usuario_4;

        //aqui tenemos parametros de entrada, por lo que se llama a la capa de Logica
        public bool Insertar_Usuario(CRUD_BIS.LOGICA.LOGICA_USUARIO Dt)
        {

            try
            {

                CRUD_BIS.DATOS.DATOS_CONEXION.ABRIR();

                Cmd = new SqlCommand("Insertar_Usuario", CRUD_BIS.DATOS.DATOS_CONEXION.CONEXION);

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

                CRUD_BIS.DATOS.DATOS_CONEXION.CERRAR();

            }

        }

        //aqui no tenemos parametros de entrada
        public DataTable Mostrar_Usuario()
        {

            try
            {

                CRUD_BIS.DATOS.DATOS_CONEXION.ABRIR();

                Cmd = new SqlCommand("Mostrar_Usuario", CRUD_BIS.DATOS.DATOS_CONEXION.CONEXION);

                if(Cmd.ExecuteNonQuery() != 0)
                {

                    DataTable Dt = new DataTable();

                    SqlDataAdapter Da = new SqlDataAdapter(Cmd);

                    Da.Fill(Dt);

                    return Dt;

                }else
                {

                    return null;

                }

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

                return null;

            }
            finally
            {

                CRUD_BIS.DATOS.DATOS_CONEXION.CERRAR();

            }

        }

    }
}
