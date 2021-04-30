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
    public partial class FORM_FIREBASE : Form
    {
        public FORM_FIREBASE()
        {
            InitializeComponent();
        }

        private void FORM_FIREBASE_Load(object sender, EventArgs e)
        {

            CRUD_BIS.LOGICA.TAM_DT Formato1 = new CRUD_BIS.LOGICA.TAM_DT();

            Formato1.CentrarControl(this.Pnl_Header3);

        }



    }
}
