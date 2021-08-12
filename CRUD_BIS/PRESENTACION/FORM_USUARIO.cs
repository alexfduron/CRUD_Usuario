using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CRUD_BIS.PRESENTACION
{
    public partial class FORM_USUARIO : Form
    {
        public FORM_USUARIO()
        {
            InitializeComponent();
            Progress = 0;
            this.afD_TextBox1.Texts = "1";
        }

        int ID_Usuario;
        private int Progress;

        private void FORM_USUARIO_Load(object sender, EventArgs e)
        {

            this.pnl_Menu2.Visible = false;

            this.pnl_Menu2.Dock = DockStyle.Fill;

            this.DGV_Listado.Dock = DockStyle.Fill;



            Mostrar_Usuario();

        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {

            Buscar_Usuario();

        }

        private void Buscar_Usuario()
        {

            DataTable Dt;

            CRUD_BIS.DATOS.DATOS_USUARIO Duser = new CRUD_BIS.DATOS.DATOS_USUARIO();

            Dt = Duser.Buscar_Usuario(this.txt_Buscar.Text);

            this.DGV_Listado.DataSource = Dt;

            CRUD_BIS.LOGICA.TAM_DT Formato1 = new CRUD_BIS.LOGICA.TAM_DT();

            Formato1.MultiLinea(this.DGV_Listado);

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {

            this.pnl_Menu2.Visible = true;

            this.lbl_Titulo.Text = "AGREGAR USUARIO";

            this.tableLayoutPanel1.Controls.Remove(this.btn_GuardarCambio);

            this.tableLayoutPanel1.Controls.Add(this.btn_Guardar, 4, 0);

            this.pic_Foto.Image = CRUD_BIS.Properties.Resources.Foto_Aqui_2;

            this.txt_Nombre.Clear();

            this.txt_Pass.Clear();

            this.txt_Nombre.Focus();

            CRUD_BIS.LOGICA.TAM_DT Diseño = new CRUD_BIS.LOGICA.TAM_DT();

            Diseño.CentrarTopControl(this.pnl_Menu1);

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {

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

                    Mostrar_Usuario();

                    this.lbl_Titulo.Text = "VER USUARIO";

                    this.pnl_Menu2.Visible = false;

                }
                else
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

            CRUD_BIS.DATOS.DATOS_USUARIO Duser = new CRUD_BIS.DATOS.DATOS_USUARIO();

            Dt.Nombre_3 = this.txt_Nombre.Text;

            Dt.Pass_3 = this.txt_Pass.Text;

            System.IO.MemoryStream Ms = new System.IO.MemoryStream();

            this.pic_Foto.Image.Save(Ms, this.pic_Foto.Image.RawFormat);

            Dt.Icono_3 = Ms.GetBuffer();

            Dt.Estado_3 = "ACTIVO";

            if(Duser.Insertar_Usuario(Dt) == true)
            {

                MessageBox.Show("Usuario Registrado", "Registro Correcto...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void Mostrar_Usuario()
        {

            DataTable Dt;

            CRUD_BIS.DATOS.DATOS_USUARIO ShowUser = new CRUD_BIS.DATOS.DATOS_USUARIO();

            Dt = ShowUser.Mostrar_Usuario();

            this.DGV_Listado.DataSource = Dt;

            CRUD_BIS.LOGICA.TAM_DT Formato1 = new CRUD_BIS.LOGICA.TAM_DT();

            Formato1.MultiLinea(this.DGV_Listado);

        }

        private void Eliminar_Usuario()
        {

            CRUD_BIS.LOGICA.LOGICA_USUARIO Dt = new CRUD_BIS.LOGICA.LOGICA_USUARIO();

            CRUD_BIS.DATOS.DATOS_USUARIO Duser = new CRUD_BIS.DATOS.DATOS_USUARIO();

            Dt.ID_Usuario_3 = ID_Usuario;

            if (Duser.Eliminar_Usuario(Dt) == true)
            {

                MessageBox.Show("Usuario Eliminado", "Eliminacion Correcta...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void DGV_Listado_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            ID_Usuario = Convert.ToInt32(this.DGV_Listado.SelectedCells[2].Value.ToString());

            if (e.ColumnIndex == this.DGV_Listado.Columns["Borrar"].Index)
            {

                DialogResult Resp;

                Resp = MessageBox.Show("¿Desea eliminar este registro?", "Eliminado registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(Resp == DialogResult.OK)
                {

                    Eliminar_Usuario();

                    Mostrar_Usuario();

                }

            }

                if (e.ColumnIndex == this.DGV_Listado.Columns["Editar"].Index)
            {
                
                this.txt_Nombre.Text = this.DGV_Listado.SelectedCells[3].Value.ToString();

                this.txt_Pass.Text = this.DGV_Listado.SelectedCells[4].Value.ToString();

                this.pic_Foto.BackgroundImage = null;

                byte[] b = (byte[])this.DGV_Listado.SelectedCells[5].Value;

                MemoryStream Ms = new MemoryStream(b);

                this.pic_Foto.Image = Image.FromStream(Ms);


                this.pnl_Menu2.Visible = true;

                this.lbl_Titulo.Text = "MODIFICAR USUARIO";

                this.tableLayoutPanel1.Controls.Remove(this.btn_Guardar);

                this.tableLayoutPanel1.Controls.Add(this.btn_GuardarCambio, 4, 0);

                CRUD_BIS.LOGICA.TAM_DT Diseño = new CRUD_BIS.LOGICA.TAM_DT();

                Diseño.CentrarTopControl(this.pnl_Menu1);

            }

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {

            this.pnl_Menu2.Visible = false;

            this.lbl_Titulo.Text = "VER USUARIO";

            this.pic_Foto.Image = CRUD_BIS.Properties.Resources.Foto_Aqui_2;

        }

        private void btn_GuardarCambio_Click(object sender, EventArgs e)
        {

            Editar_Usuario();

            Mostrar_Usuario();

            this.lbl_Titulo.Text = "VER USUARIO";

            this.pnl_Menu2.Visible = false;

        }

        private void Editar_Usuario()
        {

            CRUD_BIS.LOGICA.LOGICA_USUARIO Dt = new CRUD_BIS.LOGICA.LOGICA_USUARIO();

            CRUD_BIS.DATOS.DATOS_USUARIO Duser = new CRUD_BIS.DATOS.DATOS_USUARIO();

            Dt.ID_Usuario_3 = ID_Usuario;

            Dt.Nombre_3 = this.txt_Nombre.Text;

            Dt.Pass_3 = this.txt_Pass.Text;

            System.IO.MemoryStream Ms = new System.IO.MemoryStream();

            this.pic_Foto.Image.Save(Ms, this.pic_Foto.Image.RawFormat);

            Dt.Icono_3 = Ms.GetBuffer();

            Dt.Estado_3 = "ACTIVO";

            if (Duser.Editar_Usuario(Dt) == true)
            {

                MessageBox.Show("Usuario Modificado", "Registro Correcto...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void afD_Button31_Click(object sender, EventArgs e)
        {
            this.afD_Button31.Activado = !this.afD_Button31.Activado;

            this.afD_ProgressBar1.Value = 10;
            this.timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("3");
            Progress++;
            MessageBox.Show(Progress.ToString());
            if (this.afD_ProgressBar1.Value < this.afD_ProgressBar1.Maximum)
            {
                Progress = Progress + 10;
                this.afD_ProgressBar1.Value = Progress;
            }
            if (this.afD_ProgressBar1.Value == this.afD_ProgressBar1.Maximum)
            {
                this.timer1.Enabled = false;
            }

            this.progressBar1.Value += 10;
            //this.progressBar1.Increment(10);
            /*
            if (this.progressBar1.Value < this.progressBar1.Maximum)
            {
                this.progressBar1.Value = this.progressBar1.Value + 1;
            }
            */
            if(this.progressBar1.Value == this.progressBar1.Maximum)
            {
                this.timer1.Stop();
                MessageBox.Show("Welcome...");
            }

            //MessageBox.Show("4");

        }

        private void afD_Button2_Click(object sender, EventArgs e)
        {
            this.afD_ProgressBar1.Value = 20;
            this.timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.afD_ProgressBar1.Value = 0;
            this.progressBar1.Value = 0;
            //Progress = 20;
            //this.progressBar1.Value = Progress;
            //MessageBox.Show("1");
            this.timer1.Enabled = true;
            //MessageBox.Show("2");
        }

        private void FORM_USUARIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer1.Enabled = false;
        }
    }
}
