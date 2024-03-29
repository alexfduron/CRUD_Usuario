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
    class AFD_Button2 : Button
    {

        //Variables

        Color clr1, clr2;
        private Color color1 = Color.DodgerBlue;
        private Color color2 = Color.MidnightBlue;
        private Color m_hovercolor1 = Color.Turquoise;
        private Color m_hovercolor2 = Color.DarkSlateGray;
        private int color1Transparent = 250;
        private int color2Transparent = 250;
        private Color clickcolor1 = Color.Yellow;
        private Color clickcolor2 = Color.Red;
        private int angle = 90;
        private int textX = 100;
        private int textY = 25;
        private String text = "";

        //Campos

        public Color buttonborder_1 = Color.FromArgb(220, 220, 220);
        public Color buttonborder_2 = Color.FromArgb(150, 150, 150);
        public Boolean showButtonText = true;
        public int borderWidth = 2;
        public Color borderColor = Color.Transparent;

        public enum ButtonsShapes
        {
            Rect,
            RoundRect,
            Circle
        }

        //Propiedades

        ButtonsShapes buttonShape;

        [Description("Modifica la forma del boton")]
        [Category("AFD Code Advance")]
        [DefaultValue("Rect")]

        public ButtonsShapes ButtonShape
        {
            get { return buttonShape; }
            set
            {
                buttonShape = value; this.Invalidate();
            }
        }

        [Description("Modifica el texto del boton")]
        [Category("AFD Code Advance")]

        public String ButtonText
        {
            get { return text; }
            set { text = value; this.Invalidate(); }
        }

        [Description("Modifica el ancho del borde")]
        [Category("AFD Code Advance")]

        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; this.Invalidate(); }
        }

        void SetBorderColor(Color bdrColor)
        {
            int red = bdrColor.R - 40;
            int green = bdrColor.G - 40;
            int blue = bdrColor.B - 40;

            if (red < 0)
            {
                red = 0;
            }
            if (green < 0)
            {
                green = 0;
            }
            if (blue < 0)
            {
                blue = 0;
            }

            buttonborder_1 = Color.FromArgb(red, green, blue);
            buttonborder_2 = bdrColor;
        }

        [Description("Cambia el color del borde")]
        [Category("AFD Code Advance")]

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                if (borderColor == Color.Transparent)
                {
                    buttonborder_1 = Color.FromArgb(220, 220, 220);
                    buttonborder_2 = Color.FromArgb(150, 150, 150);
                }
                else
                {
                    SetBorderColor(borderColor);
                }

            }
        }

        [Description("Cambia el primer color")]
        [Category("AFD Code Advance")]

        public Color StartColor
        {
            get { return color1; }
            set { color1 = value; this.Invalidate(); }
        }

        [Description("Cambia el segundo color")]
        [Category("AFD Code Advance")]

        public Color EndColor
        {
            get { return color2; }
            set { color2 = value; this.Invalidate(); }
        }

        [Description("Cambia el primer color al pasar el cursor")]
        [Category("AFD Code Advance")]

        public Color MouseHoverColor1
        {
            get { return m_hovercolor1; }
            set { m_hovercolor1 = value; this.Invalidate(); }
        }

        [Description("Cambia el segundo color al pasar el cursor")]
        [Category("AFD Code Advance")]

        public Color MouseHoverColor2
        {
            get { return m_hovercolor2; }
            set { m_hovercolor2 = value; this.Invalidate(); }
        }

        [Description("Cambia el primer color al dar click")]
        [Category("AFD Code Advance")]

        public Color MouseClickColor1
        {
            get { return clickcolor1; }
            set { clickcolor1 = value; this.Invalidate(); }
        }

        [Description("Cambia el segundo color al dar click")]
        [Category("AFD Code Advance")]

        public Color MouseClickColor2
        {
            get { return clickcolor2; }
            set { clickcolor2 = value; this.Invalidate(); }
        }

        [Description("Modifica la transparencia del primer color")]
        [Category("AFD Code Advance")]

        public int Transparent1
        {
            get { return color1Transparent; }
            set
            {
                color1Transparent = value;
                if (color1Transparent > 255)
                {
                    color1Transparent = 255;
                    this.Invalidate();
                }
                else
                    this.Invalidate();
            }
        }

        [Description("Modifica la transparencia del segundo color")]
        [Category("AFD Code Advance")]

        public int Transparent2
        {
            get { return color2Transparent; }
            set
            {
                color2Transparent = value;
                if (color2Transparent > 255)
                {
                    color2Transparent = 255;
                    this.Invalidate();
                }
                else
                    this.Invalidate();
            }
        }

        [Description("Modifica el angulo del color")]
        [Category("AFD Code Advance")]

        public int GradientAngle
        {
            get { return angle; }
            set { angle = value; this.Invalidate(); }
        }

        [Description("Modifica la ubicacion del texto horizontalmente")]
        [Category("AFD Code Advance")]

        public int TextLocation_X
        {
            get { return textX; }
            set { textX = value; this.Invalidate(); }
        }

        [Description("Modifica la ubicacion del texto verticalmente")]
        [Category("AFD Code Advance")]

        public int TextLocation_Y
        {
            get { return textY; }
            set { textY = value; this.Invalidate(); }
        }

        [Description("Cambia la aparicion del texto en el boton")]
        [Category("AFD Code Advance")]

        public Boolean ShowButtontext
        {
            get { return showButtonText; }
            set { showButtonText = value; this.Invalidate(); }
        }


        //Constructor
        public AFD_Button2()
        {
            this.Size = new Size(100, 40);
            this.BackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            text = this.Text;
        }


        //Metodos 

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            clr1 = color1;
            clr2 = color2;
            color1 = m_hovercolor1;
            color2 = m_hovercolor2;
        }
        
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            color1 = clr1;
            color2 = clr2;
            SetBorderColor(borderColor);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            color1 = clickcolor1;
            color2 = clickcolor2;

            int red = borderColor.R - 40;
            int green = borderColor.G - 40;
            int blue = borderColor.B - 40;

            if (red < 0)
            {
                red = 0;
            }
            if (green < 0)
            {
                green = 0;
            }
            if (blue < 0)
            {
                blue = 0;
            }

            buttonborder_2 = Color.FromArgb(red, green, blue);
            buttonborder_1 = borderColor;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            OnMouseLeave(mevent);
            color1 = clr1;
            color2 = clr2;
            SetBorderColor(borderColor);
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            color1 = clr1;
            color2 = clr2;
            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            textX = (int)((this.Width / 3) - 1);
            textY = (int)((this.Height / 3) + 5);
        }




        //draw circular button function  
        void DrawCircularButton(Graphics g)
        {
            Color c1 = Color.FromArgb(color1Transparent, color1);
            Color c2 = Color.FromArgb(color2Transparent, color2);


            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, c1, c2, angle);
            g.FillEllipse(b, 5, 5, this.Width - 10, this.Height - 10);


            for (int i = 0; i < borderWidth; i++)
            {
                g.DrawArc(new Pen(new SolidBrush(buttonborder_1)), 5 + i, 5, this.Width - 10, this.Height - 10, 120, 180);
                g.DrawArc(new Pen(new SolidBrush(buttonborder_2)), 5, 5, this.Width - (10 + i), this.Height - 10, 300, 180);
            }




            if (showButtonText == true)
            {
                Point p = new Point(textX, textY);
                SolidBrush frcolor = new SolidBrush(this.ForeColor);
                g.DrawString(text, this.Font, frcolor, p);
            }

            b.Dispose();
        }

        //draw rectangular button function  
        void DrawRectangularButton(Graphics g)
        {
            Color c1 = Color.FromArgb(color1Transparent, color1);
            Color c2 = Color.FromArgb(color2Transparent, color2);


            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, c1, c2, angle);
            g.FillRectangle(b, 0, 0, this.Width, this.Height);


            for (int i = 0; i < borderWidth; i++)
            {
                g.DrawLine(new Pen(new SolidBrush(buttonborder_1)), this.Width - i, 0, this.Width - i, this.Height);
                g.DrawLine(new Pen(new SolidBrush(buttonborder_1)), 0, this.Height - i, this.Width, this.Height - i);

                g.DrawLine(new Pen(new SolidBrush(buttonborder_2)), 0 + i, 0, 0 + i, this.Height);
                g.DrawLine(new Pen(new SolidBrush(buttonborder_2)), 0, 0 + i, this.Width, i);
            }



            if (showButtonText == true)
            {
                Point p = new Point(textX, textY);
                SolidBrush frcolor = new SolidBrush(this.ForeColor);
                g.DrawString(text, this.Font, frcolor, p);
            }

            b.Dispose();
        }


        //draw round rectangular button function  
        void DrawRoundRectangularButton(Graphics g)
        {
            Color c1 = Color.FromArgb(color1Transparent, color1);
            Color c2 = Color.FromArgb(color2Transparent, color2);


            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, c1, c2, angle);

            Region region = new System.Drawing.Region(new Rectangle(5, 5, this.Width, this.Height));

            GraphicsPath grp = new GraphicsPath();
            grp.AddArc(5, 5, 40, 40, 180, 90);
            grp.AddLine(25, 5, this.Width - 25, 5);
            grp.AddArc(this.Width - 45, 5, 40, 40, 270, 90);
            grp.AddLine(this.Width - 5, 25, this.Width - 5, this.Height - 25);
            grp.AddArc(this.Width - 45, this.Height - 45, 40, 40, 0, 90);
            grp.AddLine(25, this.Height - 5, this.Width - 25, this.Height - 5);
            grp.AddArc(5, this.Height - 45, 40, 40, 90, 90);
            grp.AddLine(5, 25, 5, this.Height - 25);

            region.Intersect(grp);

            g.FillRegion(b, region);

            for (int i = 0; i < borderWidth; i++)
            {
                g.DrawArc(new Pen(buttonborder_1), 5 + i, 5 + i, 40, 40, 180, 90);
                g.DrawLine(new Pen(buttonborder_1), 25, 5 + i, this.Width - 25, 5 + i);
                g.DrawArc(new Pen(buttonborder_1), this.Width - 45 - i, 5 + i, 40, 40, 270, 90);
                g.DrawLine(new Pen(buttonborder_1), 5 + i, 25, 5 + i, this.Height - 25);


                g.DrawLine(new Pen(buttonborder_2), this.Width - 5 - i, 25, this.Width - 5 - i, this.Height - 25);
                g.DrawArc(new Pen(buttonborder_2), this.Width - 45 - i, this.Height - 45 - i, 40, 40, 0, 90);
                g.DrawLine(new Pen(buttonborder_2), 25, this.Height - 5 - i, this.Width - 25, this.Height - 5 - i);
                g.DrawArc(new Pen(buttonborder_2), 5 + i, this.Height - 45 - i, 40, 40, 90, 90);

            }



            if (showButtonText == true)
            {
                Point p = new Point(textX, textY);
                SolidBrush frcolor = new SolidBrush(this.ForeColor);
                g.DrawString(text, this.Font, frcolor, p);
            }

            b.Dispose();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            switch (buttonShape)
            {
                case ButtonsShapes.Circle:
                    this.DrawCircularButton(e.Graphics);
                    break;

                case ButtonsShapes.Rect:
                    this.DrawRectangularButton(e.Graphics);
                    break;

                case ButtonsShapes.RoundRect:
                    this.DrawRoundRectangularButton(e.Graphics);
                    break;
            }

        }

    }
}
