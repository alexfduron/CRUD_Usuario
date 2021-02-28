using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Threading.Tasks;

namespace CRUD_BIS.LOGICA
{
    class LOGICA_USUARIO
    {
        //Creamos las variables
        private int ID_Usuario_2;
        private string Nombre_2;
        private string Pass_2;
        private byte[] Icono_2;
        private string Estado_2;

        //Instanciamos las variables
        public int ID_Usuario_3
        {

            get { return ID_Usuario_3; }

            set { ID_Usuario_3 = value; }

        }

        public string Nombre_3
        {

            get { return Nombre_3; }

            set { Nombre_3 = value; }

        }

        public string Pass_3
        {

            get { return Pass_3; }

            set { Pass_3 = value; }

        }

        public byte[] Icono_3
        {

            get { return Icono_3; }

            set { Icono_3 = value; }

        }

        public string Estado_3
        {

            get { return Estado_3; }

            set { Estado_3 = value; }

        }

        //Cargamos los valores a las variables
        public LOGICA_USUARIO()
        {



        }

        public LOGICA_USUARIO(int ID_Usuario_2, string Nombre_2, string Pass_2, byte[] Icono_2, string Estado_2)
        {

            ID_Usuario_3 = ID_Usuario_2;

            Nombre_3 = Nombre_2;

            Pass_3 = Pass_2;

            Icono_3 = Icono_2;

            Estado_3 = Estado_2;

        }

    }
}
