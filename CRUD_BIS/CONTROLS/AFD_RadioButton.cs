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
    public class AFD_RadioButton : RadioButton
    {

        //Campos
        private Color checkedColor = Color.MediumSlateBlue;
        private Color uncheckedColor = Color.Gray;
        private float rbBorderSize = 30;
        private float rbCheckSize = 20;

        

        //Propiedades
        [Category("Code Advance")]
        public Color CheckedColor
        {
            get { return checkedColor; }
            set { checkedColor = value; this.Invalidate(); }
        }

        [Category("Code Advance")]
        public Color UncheckedColor
        {
            get { return uncheckedColor; }
            set { uncheckedColor = value; this.Invalidate(); }
        }

        [Category("Code Advance")]
        public float BorderSize
        {
            get { return rbBorderSize; }
            set
            {

                /*
                Boolean isInWpfDesignerMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
                Boolean isInFormsDesignerMode = (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");

                if (isInWpfDesignerMode || isInFormsDesignerMode)
                {
                    // is in any designer mode
                    MessageBox.Show("DM");
                }
                else
                {
                    // not in designer mode
                    MessageBox.Show("NDM");
                }
                // show current mode
                MessageBox.Show(String.Format("DESIGNER CHECK:  WPF = {0}   Forms = {1}", isInWpfDesignerMode, isInFormsDesignerMode));
                */

                if (this.DesignMode == false)
                {
                    //rbBorderSize = value;
                    MessageBox.Show("No Design Model");
                }
                else
                {
                    MessageBox.Show("Design Model");
                    /*
                    if(value <= this.Height - 5)
                    {
                        rbBorderSize = value;
                    }
                    else
                    {
                        rbBorderSize = this.Height - 5;
                    }
                    */
                }
                //this.Width = TextRenderer.MeasureText(this.Text, this.Font).Width + Convert.ToInt32(rbBorderSize) + 10;
                //this.Invalidate(); 
            }
        }
        
        [Category("Code Advance")]
        public float CheckSize
        {
            get { return rbCheckSize; }
            set
            {
                if(value <= rbBorderSize)
                {
                    rbCheckSize = value;
                }
                else
                {
                    rbCheckSize = rbBorderSize;
                }
                this.Invalidate();
            }
        }

        //Constructor
        public AFD_RadioButton()
        {
            this.MinimumSize = new Size(0, 20);
            //this.Size = new Size(100, 20);
        }

        //Overriden method
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectRbBorder = new RectangleF()
            {
                X = 0.5F,
                Y = (this.Height - rbBorderSize) / 2, //Centro
                Width = rbBorderSize,
                Height = rbBorderSize
            };

            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2), //Centro
                Y = (this.Height - rbCheckSize) / 2, //Centro
                Width = rbCheckSize,
                Height = rbCheckSize
            };

            //Drawing control
            using (Pen penBorder = new Pen(CheckedColor, 1.6F))
            using (SolidBrush brushRbCheck = new SolidBrush(CheckedColor))
            using (SolidBrush brushText = new SolidBrush(this.ForeColor))
            {
                //Draw surface
                graphics.Clear(this.BackColor);

                //Draw radio button
                if (this.Checked == true)
                {
                    graphics.DrawEllipse(penBorder, rectRbBorder);   //Circle border
                    graphics.FillEllipse(brushRbCheck, rectRbCheck); //Circle radio check
                }
                else
                {
                    penBorder.Color = UncheckedColor;
                    graphics.DrawEllipse(penBorder, rectRbBorder);  //Circle border
                }

                //Draw text
                graphics.DrawString(this.Text, this.Font, brushText, rbBorderSize + 8, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);
                this.Width = TextRenderer.MeasureText(this.Text, this.Font).Width + Convert.ToInt32(rbBorderSize) + 10;
            }

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = TextRenderer.MeasureText(this.Text, this.Font).Width + Convert.ToInt32(rbBorderSize) + 10;
            this.MinimumSize = new Size(0, 20);
        }

    }
}
