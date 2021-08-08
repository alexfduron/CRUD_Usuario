using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//importamos las librerias para modificar el control
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace CRUD_BIS.CONTROLS
{
    public class AFD_ToggleButton : CheckBox
    {

        //Campos
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;
        private int borderSize = 3;
        private int spaceSize = 3;

        //Propiedades
        [Description("Modifica el color del fondo al esta activo")]
        [Category("AFD Code Advance")]
        public Color OnBlackColor
        {
            get { return onBackColor; }
            set { onBackColor = value; this.Invalidate(); }
        }

        [Description("Modifica el color del circulo al esta activo")]
        [Category("AFD Code Advance")]
        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set { onToggleColor = value; this.Invalidate(); }
        }

        [Description("Modifica el color del fondo al esta inactivo")]
        [Category("AFD Code Advance")]
        public Color OffBackColor
        {
            get { return offBackColor; }
            set { offBackColor = value; this.Invalidate(); }
        }

        [Description("Modifica el color del circulo al esta inactivo")]
        [Category("AFD Code Advance")]
        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set { offToggleColor = value; this.Invalidate(); }
        }

        [Description("Modifica el texto del control")]
        [Category("AFD Code Advance")]
        public override string Text
        {
            get { return base.Text; }
            set { }
        }

        [Description("Modifica el estilo del control")]
        [Category("AFD Code Advance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get { return solidStyle; }
            set { solidStyle = value; this.Invalidate(); }
        }

        [Description("Modifica el ancho del borde")]
        [Category("AFD Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; this.Invalidate(); }
        }

        [Description("Modifica el espacio entre el borde y el boton")]
        [Category("AFD Code Advance")]
        public int SpaceSize
        {
            get { return spaceSize; }
            set { spaceSize = value; this.Invalidate(); }
        }

        //Constructor
        public AFD_ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }

        //Metodo
        private GraphicsPath GetFigurePath()
        {
            int ArcSize = this.Height;
            Rectangle LeftArc = new Rectangle(borderSize / 2, borderSize / 2, ArcSize - borderSize, ArcSize - borderSize);
            Rectangle RightArc = new Rectangle(this.Width - ArcSize + borderSize / 2, borderSize / 2, ArcSize - borderSize, ArcSize - borderSize);

            GraphicsPath Path = new GraphicsPath();
            Path.StartFigure();
            Path.AddArc(LeftArc, 90, 180);
            Path.AddArc(RightArc, 270, 180);
            Path.CloseFigure();

            return Path;
        }

        private GraphicsPath GetFigurePath2(RectangleF rect, float radius)
        {

            GraphicsPath Path = new GraphicsPath();
            Path.StartFigure();
            Path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            Path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            Path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            Path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            Path.CloseFigure();

            return Path;

        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);//new
            
            int ToggleSize = this.Height - 2 * spaceSize - 2 * borderSize;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height); //new
            using (GraphicsPath pathSurface = GetFigurePath2(rectSurface, this.Height)) //new
            this.Region = new Region(pathSurface); //new

            if (this.Checked == true) //Turn ON the control
            {
                //Draw the Control surface
                if (solidStyle == true)
                {
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(onBackColor, borderSize), GetFigurePath());
                }
                //Draw the Toggle button
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), 
                    new Rectangle(this.Width - this.Height + spaceSize + borderSize, borderSize + spaceSize, ToggleSize, ToggleSize));
            }
            else //Turn OFF the control
            {
                //Draw the Control surface
                if (solidStyle == true)
                {
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(offBackColor, borderSize), GetFigurePath());
                }
                //Draw the Toggle button
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                    new Rectangle(borderSize + spaceSize, borderSize + spaceSize, ToggleSize, ToggleSize));
            }
            
        }


        //agregar fijar tamaño maximo y minimo al toggle button
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.DesignMode == true)
            {
                if(this.Height >= this.Width)
                {
                    this.Height = this.Width;
                }

                if(this.Width <= this.Height)
                {
                    this.Width = this.Height;
                }

                if(this.Height <= borderSize * 2 + spaceSize * 2 + 2)
                {
                    this.Height = borderSize * 2 + spaceSize * 2 + 5;
                }
            }
        }




    }
}
