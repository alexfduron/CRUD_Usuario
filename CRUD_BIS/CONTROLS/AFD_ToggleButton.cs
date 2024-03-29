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

namespace CRUD_BIS.CONTROLS
{

    public enum TextPosition2
    {
        Inside,
        Center,
        None
    }


    public class AFD_ToggleButton : CheckBox
    {

        //Campos
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color onForeColor = Color.Black;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private Color offForeColor = Color.Black;
        private bool solidStyle = true;
        private int borderSize = 3;
        private int spaceSize = 3;
        private TextPosition2 showValue = TextPosition2.None;
        private string onSymbol = "ON";
        private string offSymbol = "OFF";

        //Propiedades
        [Description("Modifica el color del fondo al estar activo")]
        [Category("AFD Code Advance")]
        public Color OnBlackColor
        {
            get { return onBackColor; }
            set { onBackColor = value; this.Invalidate(); }
        }

        [Description("Modifica el color del circulo al estar activo")]
        [Category("AFD Code Advance")]
        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set { onToggleColor = value; this.Invalidate(); }
        }

        [Description("Modifica el color del texto al estar activo")]
        [Category("AFD Code Advance")]
        public Color OnForeColor
        {
            get { return onForeColor; }
            set { onForeColor = value; this.Invalidate(); }
        }

        [Description("Agrega un simbolo al texto al estar activo")]
        [Category("AFD Code Advance")]
        public string OnSymbol
        {
            get { return onSymbol; }
            set { onSymbol = value; this.Invalidate(); }
        }

        [Description("Modifica el color del fondo al estar inactivo")]
        [Category("AFD Code Advance")]
        public Color OffBackColor
        {
            get { return offBackColor; }
            set { offBackColor = value; this.Invalidate(); }
        }

        [Description("Modifica el color del circulo al estar inactivo")]
        [Category("AFD Code Advance")]
        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set { offToggleColor = value; this.Invalidate(); }
        }

        [Description("Modifica el color del texto al estar inactivo")]
        [Category("AFD Code Advance")]
        public Color OffForeColor
        {
            get { return offForeColor; }
            set { offForeColor = value; this.Invalidate(); }
        }

        [Description("Agrega un simbolo al texto al estar inactivo")]
        [Category("AFD Code Advance")]
        public string OffSymbol
        {
            get { return offSymbol; }
            set { offSymbol = value; this.Invalidate(); }
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

        [Description("Modifica la posicion del texto")]
        [Category("AFD Code Advance")]
        public TextPosition2 ShowValue
        {
            get { return showValue; }
            set { showValue = value; this.Invalidate(); }
        }

        [Description("Modifica la fuente")]
        [Category("AFD Code Advance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        [Description("Modifica el color de la fuente")]
        [Category("AFD Code Advance")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }


        //Constructor
        public AFD_ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
            this.Font = new Font(this.Font.FontFamily, 12F);
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

            Graphics graph = pevent.Graphics;

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
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath2(rectSurface, this.Height));
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(onBackColor, borderSize), GetFigurePath());
                }
                //Draw the Toggle button
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), 
                    new Rectangle(this.Width - this.Height + spaceSize + borderSize, borderSize + spaceSize, ToggleSize, ToggleSize));
                //Draw text
                if (showValue != TextPosition2.None)
                {
                    DrawValueText(graph, this.Width - this.Height + spaceSize + borderSize, borderSize + spaceSize, onSymbol);
                }
            }
            else //Turn OFF the control
            {
                //Draw the Control surface
                if (solidStyle == true)
                {
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath2(rectSurface, this.Height));
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(offBackColor, borderSize), GetFigurePath());
                }
                //Draw the Toggle button
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                    new Rectangle(borderSize + spaceSize, borderSize + spaceSize, ToggleSize, ToggleSize));
                //Draw text
                if (showValue != TextPosition2.None)
                {
                    DrawValueText(graph, spaceSize + borderSize, borderSize + spaceSize, offSymbol);
                }
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


        //Paint value text
        private void DrawValueText(Graphics graph, int X, int Y, string text)
        {

            //Campos
            var textSize = TextRenderer.MeasureText(text, this.Font);
            var rectText = new Rectangle(0, 0, textSize.Width, textSize.Height);
            int ToggleSize = this.Height - 2 * spaceSize - 2 * borderSize;

            
            using (var brushTexton = new SolidBrush(onForeColor))
            using (var brushTextoff = new SolidBrush(offForeColor))
            using (var brushTextBack = new SolidBrush(Color.Transparent))
            using (var textFormat = new StringFormat())
                {
                    switch (showValue)
                    {
                        case TextPosition2.Center:
                            rectText.X = X - ((rectText.Width - ToggleSize) / 2);
                            rectText.Y = Y - ((rectText.Height - ToggleSize) / 2);
                            textFormat.Alignment = StringAlignment.Center;
                            break;

                        case TextPosition2.Inside:
                            if (this.Checked == true)
                            {
                                rectText.X = X - (X - borderSize + rectText.Width) / 2;
                                rectText.Y = Y - ((rectText.Height - ToggleSize) / 2);
                                textFormat.Alignment = StringAlignment.Center;
                                break;
                            }
                            else
                            {
                                rectText.X = (X + ToggleSize) + (this.Width - borderSize - X - ToggleSize - rectText.Width) / 2;
                                rectText.Y = Y - ((rectText.Height - ToggleSize) / 2);
                                textFormat.Alignment = StringAlignment.Center;
                                break;
                            }

                    }

                    //Painting
                    graph.FillRectangle(brushTextBack, rectText);
                if (this.Checked == true)
                {
                    graph.DrawString(text, this.Font, brushTexton, rectText, textFormat);
                }
                else
                {
                    graph.DrawString(text, this.Font, brushTextoff, rectText, textFormat);
                }

                }

        }



    }
}
