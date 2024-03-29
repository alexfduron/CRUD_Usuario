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
    public class AFD_DatePicker : DateTimePicker
    {

        //Campos
        //->Apariencia
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.PaleVioletRed;
        private int borderSize = 0;

        //->Otros Valores
        private bool droppedDown = false;
                private Image calendarIcon = Properties.Resources.calendario_blanco;
        private RectangleF iconButtonArea;
        private const int calendarIconWidth = 34;
        private const int arrowIconWidth = 17;


        //Propiedades
        [Description("Modifica el color del fondo")]
        [Category("AFD Code Advance")]
        public Color SkinColor
        {
            get { return skinColor; }
            set
            {
                skinColor = value;
                //Summary: gets the Hue-Saturation-Brightness (HSB) 
                //brightness value for this System.Drawing.Color structure.
                //
                //Returns: The brightness range from 0.0 through 1.0, 
                //where 0.0 represents black and 1.0 represents white.
                if (skinColor.GetBrightness() >= 0.8F)
                {
                    calendarIcon = Properties.Resources.calendario_negro;
                }
                else
                {
                    calendarIcon = Properties.Resources.calendario_blanco;
                }
                this.Invalidate();
            }
        }

        [Description("Modifica el color del texto")]
        [Category("AFD Code Advance")]
        public Color TextColor
        {
            get { return textColor; }
            set { textColor = value; this.Invalidate(); }
        }

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

        //Constructor
        public AFD_DatePicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new Size(0,35);
            this.Font = new Font(this.Font.Name, 9.5F);
        }

        //metodo de anulacion
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics graphics = this.CreateGraphics())
            using (Pen penBorder = new Pen(borderColor, borderSize))
            using (SolidBrush skinBrush = new SolidBrush(skinColor))
            using (SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat textFormat = new StringFormat())
            {
                RectangleF clientArea = new RectangleF(0, 0, this.Width - 0.5F, this.Height - 0.5F);
                RectangleF iconArea = new RectangleF(clientArea.Width - GetIconButtonWidth(), 0, GetIconButtonWidth(), clientArea.Height);
                penBorder.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;

                //Draw surface
                graphics.FillRectangle(skinBrush, clientArea);

                //Draw text
                graphics.DrawString("  " + this.Text, this.Font, textBrush, clientArea, textFormat);

                //Draw open calendar icon highlight
                if(droppedDown == true)
                {
                    graphics.FillRectangle(openIconBrush, iconArea);
                }

                //Draw border
                if(borderSize >= 1)
                {
                    graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
                }

                //Draw icon
                graphics.DrawImage(calendarIcon, this.Width - GetIconButtonWidth() - 9, (this.Height - calendarIcon.Height) / 2);
            }
        }

        //Metodo privado

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(this.Width - iconWidth, 0, iconWidth, this.Height);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (iconButtonArea.Contains(e.Location))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private int GetIconButtonWidth()
        {
            int textWidth = TextRenderer.MeasureText(this.Text, this.Font).Width;
            if(textWidth <= this.Width - (calendarIconWidth + 20))
            {
                return calendarIconWidth;
            }
            else
            {
                return arrowIconWidth;
            }
        }



    }
}
