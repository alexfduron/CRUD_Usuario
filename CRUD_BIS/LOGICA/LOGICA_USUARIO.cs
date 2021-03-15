using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

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

            get { return ID_Usuario_2; }

            set { ID_Usuario_2 = value; }

        }

        public string Nombre_3
        {

            get { return Nombre_2; }

            set { Nombre_2 = value; }

        }

        public string Pass_3
        {

            get { return Pass_2; }

            set { Pass_2 = value; }

        }

        public byte[] Icono_3
        {

            get { return Icono_2; }

            set { Icono_2 = value; }

        }

        public string Estado_3
        {

            get { return Estado_2; }

            set { Estado_2 = value; }

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



    class TAM_DT
    {
        
        public void MultiLinea(DataGridView Lista)
        {

            Lista.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Lista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            Lista.DefaultCellStyle.BackColor = Color.Black;

            Lista.DefaultCellStyle.Font = new Font("Consolas", 20, FontStyle.Regular);

            Lista.DefaultCellStyle.ForeColor = Color.White;

            for (int k = 0; k < Lista.Rows.Count; k++)
            {
                Lista.Rows[k].Height = 50;
            }



            Lista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            Lista.ColumnHeadersHeight = 50;

            Lista.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Lista.EnableHeadersVisualStyles = false;

            DataGridViewCellStyle Estilo_Cabecera = new DataGridViewCellStyle();

            Estilo_Cabecera.BackColor = Color.Black;

            Estilo_Cabecera.ForeColor = Color.White;

            Estilo_Cabecera.Font = new Font("Consolas", 20, FontStyle.Bold);

            Lista.ColumnHeadersDefaultCellStyle = Estilo_Cabecera;



            Lista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Lista.BackgroundColor = Color.Black;

            Lista.BorderStyle = BorderStyle.Fixed3D;

            Lista.Dock = DockStyle.Fill;

            Lista.MultiSelect = false;

        }

        public void CentrarControl(object xControl)
        {

            Control yControl = xControl as Control;

            yControl.Top = (yControl.Parent.ClientSize.Height - yControl.Height) / 2;

            yControl.Left = (yControl.Parent.ClientSize.Width - yControl.Width) / 2;
            
        }

        public void CentrarTopControl(object xControl)
        {

            Control yControl = xControl as Control;

            yControl.Top = 0;

            yControl.Left = (yControl.Parent.ClientSize.Width - yControl.Width) / 2;

        }

        public void CentrarBottomControl(object xControl)
        {

            Control yControl = xControl as Control;

            yControl.Top = yControl.Parent.ClientSize.Height - yControl.Height;

            yControl.Left = (yControl.Parent.ClientSize.Width - yControl.Width) / 2;

        }

        public void CentrarLeftControl(object xControl)
        {

            Control yControl = xControl as Control;

            yControl.Top = (yControl.Parent.ClientSize.Height - yControl.Height) / 2;

            yControl.Left = 0;
    
        }

        public void CentrarRightControl(object xControl)
        {

            Control yControl = xControl as Control;

            yControl.Top = (yControl.Parent.ClientSize.Height - yControl.Height) / 2;

            yControl.Left = yControl.Parent.ClientSize.Width - yControl.Width;

        }

    }

}
