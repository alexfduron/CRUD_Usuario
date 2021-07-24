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

        //Constructor
        public AFD_ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }

        //Metodo
        private GraphicsPath GetFigurePath()
        {
            int ArcSize = this.Height - 1;
            Rectangle LeftArc = new Rectangle(0, 0, ArcSize, ArcSize);
            Rectangle RightArc = new Rectangle(this.Width-ArcSize-2, 0, ArcSize, ArcSize);

            GraphicsPath Path = new GraphicsPath();
            Path.StartFigure();
            Path.AddArc(LeftArc, 90, 180);
            Path.AddArc(RightArc, 270, 180);
            Path.CloseFigure();

            return Path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int ToggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.Checked == true) //Turn ON the control
            {
                //Draw the Control surface
                if (solidStyle == true)
                {
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());
                }
                //Draw the Toggle button
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), 
                    new Rectangle(this.Width - this.Height + 1, 2, ToggleSize, ToggleSize));
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
                    pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());
                }
                //Draw the Toggle button
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                    new Rectangle(2, 2, ToggleSize, ToggleSize));
            }

        }


    }
}
