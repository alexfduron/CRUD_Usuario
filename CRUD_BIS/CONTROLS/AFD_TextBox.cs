using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//importamos las librerias para modificar el control
//using System.Windows.Forms;
//using System.Drawing;
using System.Drawing.Drawing2D;
//using System.ComponentModel;

namespace CRUD_BIS.CONTROLS
{
    public partial class AFD_TextBox : UserControl
    {

        //Campos
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle = false;


        //Constructor
        public AFD_TextBox()
        {
            InitializeComponent();
        }


        //Propiedades
        [Description("Modifica el color del borde")]
        [Category("AFD Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }

        [Description("Modifica el tamaño del borde")]
        [Category("AFD Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; this.Invalidate(); }
        }

        [Description("Agrega una linea y eliminando el borde")]
        [Category("AFD Code Advance")]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set { underlinedStyle = value; this.Invalidate(); }
        }

        [Description("Oculta el texto al cambiarlo por signos")]
        [Category("AFD Code Advance")]
        public bool PasswordChar
        {
            get { return this.textBox1.UseSystemPasswordChar; }
            set { this.textBox1.UseSystemPasswordChar = value; }
        }

        [Description("Permite agrear mas lineas de texto")]
        [Category("AFD Code Advance")]
        public bool Multiline
        {
            get { return this.textBox1.Multiline; }
            set { this.textBox1.Multiline = value; }
        }

        [Description("Modifica el color del fondo")]
        [Category("AFD Code Advance")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; this.textBox1.BackColor = value; }
        }

        [Description("Modifica el color del texto")]
        [Category("AFD Code Advance")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; this.textBox1.ForeColor = value; }
        }

        [Description("Modifica la fuente del texto")]
        [Category("AFD Code Advance")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                this.textBox1.Font = value;
                if(this.DesignMode == true)
                {
                    UpdateControlHeight();
                }
            }
        }

        [Description("Modifica el texto")]
        [Category("AFD Code Advance")]
        public string Texts
        {
            get { return this.textBox1.Text; }
            set { this.textBox1.Text = value; }
        }



        //metodos
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            //Draw border
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;

                if(underlinedStyle == true)
                {
                    //line style
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                }
                else
                {
                    //normal style
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }

            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode == true)
            {
                UpdateControlHeight();
            }
        }

        private void UpdateControlHeight()
        {
            if(this.textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                this.textBox1.Multiline = true;
                this.textBox1.MinimumSize = new Size(0, txtHeight);
                this.textBox1.Multiline = false;

                this.Height = this.textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

    }
}
