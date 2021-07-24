using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_BIS.CONTROLS
{
    public partial class AFD_Button3 : Control
    {

        //Campos
        private bool presionado = false;
        private bool activado = false;


        //Constructor
        public AFD_Button3()
        {
            InitializeComponent();
        }


        //Propiedades
        [Description("Dice si el control esta activado")]
        [Category("AFD Code Advance")]
        [DefaultValue(false)]

        public bool Activado
        {
            get { return activado; }
            set
            {
                activado = value;
                this.Invalidate();    // se usa para redibujar el control y se muestre el cambi al usuario
            }
        }

        [Description("Muestra el texto en el control")]
        [Category("AFD Code Advance")]


        //agregamos un 'new' a la propiedad text
        //para obtener una version propia y colocar el codigo que necesitamos
        //de esta forma, mostramos los cambios en el momento de la edicion del control
        //en este caso, nos permite agregar this.Invalidate()
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; this.Invalidate(); }
        }


        //Metodos
        protected override void OnPaint(PaintEventArgs pe)
        {
            //base.OnPaint(pe);
            Graphics g = pe.Graphics;

            //Obtenemos el rectangulo que representa el area del control
            Rectangle rect = ClientRectangle;
            rect.Width--;
            rect.Height--;

            //Colocamos el color de fondo, en este caso el mismo que el del Padre
            g.FillRectangle(new SolidBrush(Parent.BackColor), ClientRectangle);

            //Colocamos el color de fondo que vamos a usar
            Color miColor;
            if(presionado == true)
            {
                miColor = Color.Blue;
            }
            else
            {
                miColor = Color.Orange;
            }

            g.FillEllipse(new SolidBrush(miColor), rect);


            //Colocamos el tecto a desplegar
            Font fuente = new Font("Arial", (float)rect.Height * 0.5f, FontStyle.Regular);

            //Damos formato a la fuente
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;

            g.DrawString(Text, fuente, Brushes.Black, new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height), formato);

            //Dibujamos info de la otra propiedad
            if(activado == true)
            {
                g.FillEllipse(Brushes.Red, new Rectangle(rect.Left, rect.Top, 10, 10));
            }
            else
            {
                g.FillEllipse(Brushes.Gray, new Rectangle(rect.Left, rect.Top, 10, 10));
            }

        }


        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
            //se agrega para evitar el efecto de parpadeo cuando se este dibujando el control
        }


        //ahora trabajamos la parte del Click
        protected override void OnMouseDown(MouseEventArgs e)
        {
            //base.OnMouseDown(e);
            if(e.Button == MouseButtons.Left)
            {
                presionado = true;
            }
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            //base.OnMouseUp(e);
            if(e.Button == MouseButtons.Left)
            {
                presionado = false;
            }
            this.Invalidate();
        }


    }
}
