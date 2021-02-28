using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_BIS.PRESENTACION
{
    public partial class FORM_USUARIO : Form
    {
        public FORM_USUARIO()
        {
            InitializeComponent();
        }

        private void FORM_USUARIO_Load(object sender, EventArgs e)
        {

            this.pnl_Menu2.Visible = false;

        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {

            this.pnl_Menu2.Visible = true;

            this.tableLayoutPanel1.Controls.Remove(this.btn_GuardarCambio);

            this.txt_Nombre.Clear();

            this.txt_Pass.Clear();

            this.txt_Nombre.Focus();

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {

            //this.txt_Buscar.Clear();

            this.txt_Buscar.Focus();

        }

        private void btn_Borrar_Click(object sender, EventArgs e)
        {

            this.txt_Buscar.Clear();

            this.txt_Buscar.Focus();

        }

        private void pic_Foto_Click(object sender, EventArgs e)
        {

            this.OFD_Foto.InitialDirectory = "";

            this.OFD_Foto.Filter = "Imagenes|*.jpg;*.png;*.bmp";

            this.OFD_Foto.FilterIndex = 3;

            this.OFD_Foto.Title = "Cargador de Imagenes...";

            if(this.OFD_Foto.ShowDialog() == DialogResult.OK)
            {

                this.pic_Foto.BackgroundImage = null;

                this.pic_Foto.Image = new Bitmap(this.OFD_Foto.FileName);

            }

        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {

            if(this.txt_Nombre.Text != "")
            {

                if(this.txt_Pass.Text != "")
                {

                    Insertar_Usuario();

                }else
                {

                    MessageBox.Show("Ingrese una Contraseña", "Sin Contraseña...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }else
            {

                MessageBox.Show("Ingrese un Usuario", "Sin Usuario...", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Insertar_Usuario()
        {

            CRUD_BIS.LOGICA.LOGICA_USUARIO Dt = new CRUD_BIS.LOGICA.LOGICA_USUARIO();

            CRUD_BIS.DATOS.DATOS_USUARIO Fun = new CRUD_BIS.DATOS.DATOS_USUARIO();

            Dt.Nombre_3 = this.txt_Nombre.Text;

            Dt.Pass_3 = this.txt_Pass.Text;

            System.IO.MemoryStream Ms = new System.IO.MemoryStream();

            this.pic_Foto.Image.Save(Ms, this.pic_Foto.Image.RawFormat);

            Dt.Icono_3 = Ms.GetBuffer();

            Dt.Estado_3 = "ACTIVO";

            if(Fun.Insertar(Dt) == true)
            {

                MessageBox.Show("Usuario Registrado", "Registro Correcto...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

    }
}
