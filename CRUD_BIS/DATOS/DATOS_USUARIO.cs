using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//hacemos referencia al SQL
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

        public bool Insertar(LOGICA_USUARIO dt)
        {

            try
            {



            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

    }
}
