﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//importamos las librerias para modificar el control
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

//iconos de Flaticon
//<div>Iconos diseñados por <a href="" title="srip">srip</a> from <a href="https://www.flaticon.es/" title="Flaticon">www.flaticon.es</a></div>
//<div>Iconos diseñados por <a href="" title="srip">srip</a> from <a href="https://www.flaticon.es/" title="Flaticon">www.flaticon.es</a></div>

namespace CRUD_BIS.CONTROLS
{
    public class AFD_Button : Button
    {

        //Campos
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.PaleVioletRed;

        //Propiedades
        [Description("Modifica el ancho del borde")]
        [Category("AFD Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; this.Invalidate(); }
        }

        [Description("Modifica el radio del borde")]
        [Category("AFD Code Advance")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (this.DesignMode == false)
                {
                    borderRadius = value;
                }
                else
                {
                    if (value <= this.Height)
                    {
                        borderRadius = value;
                    }
                    else
                    {
                        borderRadius = this.Height;
                    }
                }
                this.Invalidate();
            }
        }

        [Description("Modifica el color del borde")]
        [Category("AFD Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }

        [Description("Modifica el color del fondo")]
        [Category("AFD Code Advance")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Description("Modifica el color del texto")]
        [Category("AFD Code Advance")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        [Description("Modifica el tamaño del texto")]
        [Category("AFD Code Advance")]
        public int TextSize
        {
            get { return Convert.ToInt32(this.Font.Size); }
            set { this.Font = new Font(this.Font.FontFamily, value); }
        }
        

        //Constructor
        public AFD_Button()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            //FIXME: revisar el borderRadius que se fija en 40 cuando arranca el formulario
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
        }

        

        //Metodos
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {

            GraphicsPath Path = new GraphicsPath();
            Path.StartFigure();
            Path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            Path.AddArc(rect.Width-radius, rect.Y, radius, radius, 270, 90);
            Path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            Path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            Path.CloseFigure();

            return Path;

        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 1F, this.Height - 1F);

            if(borderRadius > 2) //Rounded button
            {
                using(GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using(GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using(Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using(Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                    //Button border
                    if(borderSize >= 1)
                    {
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                } 
            }
            else //Normal button
            {
                //Button Surface
                this.Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode == true)
            {
                this.Invalidate();
            }
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
            {
                borderRadius = this.Height;
            }
        }



    }
}
