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

            

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {

            this.txt_Buscar.Clear();

            this.txt_Buscar.Focus();

        }
    }
}
