using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//importamos las librerias para modificar el control
using System.Windows.Forms;
using System.ComponentModel;

namespace CRUD_BIS.CONTROLS
{
    class AFD_Button2 : Button
    {

        private bool Gigante = true;

        [Description("Dice si el control se pone gigante")]
        [Category("Cosas_Gigantes")]
        [DefaultValue(true)]

        public bool _Gigante
        {
            get { return Gigante; }
            set { Gigante = value; }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (Gigante == true)
            {
                this.Size = new System.Drawing.Size(150, 150);
            }
            base.OnMouseEnter(e);
        }

    }
}
