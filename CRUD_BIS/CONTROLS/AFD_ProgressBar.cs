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

    public enum TextPosition
    {
        Left,
        Right,
        Center,
        Sliding,
        None
    }

    public class AFD_ProgressBar : ProgressBar
    {

        //Campos
        private Color channelColor = Color.LightSteelBlue;
        private Color sliderColor = Color.RoyalBlue;
        private Color foreBackColor = Color.White;
        private int channelHeight = 10;
        private int sliderHeight = 10;
        private TextPosition showValue = TextPosition.Right;

        private bool paintedBack = false;
        private bool stopPainting = false;
        private bool showMaximun = false;
        private string symbolBefore = "";
        private string symbolAfter = "";

        

        //Constructor
        public AFD_ProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.ForeColor = Color.Black;
            this.Size = new Size(250, 40);
            this.Font = new Font(this.Font.FontFamily, 12F);
        }


        //Propiedades
        [Description("Modifica el color del canal")]
        [Category("AFD Code Advance")]
        public Color ChannelColor
        {
            get { return channelColor; }
            set { channelColor = value; this.Invalidate(); }
        }

        [Description("Modifica el color del deslizador")]
        [Category("AFD Code Advance")]
        public Color SliderColor
        {
            get { return sliderColor; }
            set { sliderColor = value; this.Invalidate(); }
        }

        [Description("Modifica el color del fondo")]
        [Category("AFD Code Advance")]
        public Color ForeBackColor
        {
            get { return foreBackColor; }
            set { foreBackColor = value; this.Invalidate(); }
        }

        [Description("Modifica el tamaño del canal")]
        [Category("AFD Code Advance")]
        public int ChannelHeight
        {
            get { return channelHeight; }
            set { channelHeight = value; this.Invalidate(); }
        }

        [Description("Modifica el tamaño del deslizador")]
        [Category("AFD Code Advance")]
        public int SliderHeight
        {
            get { return sliderHeight; }
            set { sliderHeight = value; this.Invalidate(); }
        }

        [Description("Modifica la posicion del texto")]
        [Category("AFD Code Advance")]
        public TextPosition ShowValue
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

        [Description("Agrega un simbolo antes del texto")]
        [Category("AFD Code Advance")]
        public string SymbolBefore
        {
            get { return symbolBefore; }
            set { symbolBefore = value; this.Invalidate(); }
        }

        [Description("Agrega un simbolo despues del texto")]
        [Category("AFD Code Advance")]
        public string SymbolAfter
        {
            get { return symbolAfter; }
            set { symbolAfter = value; this.Invalidate(); }
        }

        [Description("Agrega el valor maximo despues del texto")]
        [Category("AFD Code Advance")]
        public bool ShowMaximun
        {
            get { return showMaximun; }
            set { showMaximun = value; this.Invalidate(); }
        }


        //Paint the background and channel
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if(stopPainting == false)
            {
                if(paintedBack == false)
                {
                    //Campos
                    Graphics graph = pevent.Graphics;
                    Rectangle rectChannel = new Rectangle(0, 0, this.Width, ChannelHeight);

                    using(var brushChannel = new SolidBrush(channelColor))
                    {
                        if(channelHeight >= sliderHeight)
                        {
                            rectChannel.Y = this.Height - channelHeight;
                        }
                        else
                        {
                            rectChannel.Y = this.Height - ((channelHeight + sliderHeight) / 2);
                        }

                        //Painting
                        graph.Clear(this.Parent.BackColor); //Surface
                        graph.FillRectangle(brushChannel, rectChannel); //Channel

                        //Stop painting the background and channel
                        if(this.DesignMode == false)
                        {
                            paintedBack = true;
                        }

                    }
                }

                //Reset painting the background and channel
                if (this.Value == this.Maximum || this.Value == this.Minimum)
                {
                    paintedBack = false;
                }
            }

        }

        //Paint the slider
        protected override void OnPaint(PaintEventArgs e)
        {
            if(stopPainting == false)
            {
                //Campos
                Graphics graph = e.Graphics;
                double scaleFactor = (((double)(this.Value - this.Minimum)) / ((double)(this.Maximum - this.Minimum)));
                int sliderWidth = (int)(this.Width * scaleFactor);
                Rectangle rectSlicer = new Rectangle(0, 0, sliderWidth, sliderHeight);
                using (var brushSlicer = new SolidBrush(sliderColor))
                {
                    if(sliderHeight >= channelHeight)
                    {
                        rectSlicer.Y = this.Height - sliderHeight;
                    }
                    else
                    {
                        rectSlicer.Y = this.Height - ((sliderHeight + channelHeight) / 2);
                    }

                    //Painting
                    if(sliderWidth > 1) //Slider
                    {
                        graph.FillRectangle(brushSlicer, rectSlicer);
                    }

                    if (showValue != TextPosition.None) //Text
                    {
                        DrawValueText(graph, sliderWidth, rectSlicer);
                    }

                }
            }

            if(this.Value == this.Maximum)
            {
                stopPainting = true;
            }
            else
            {
                stopPainting = false;
            }

        }


        //Paint value text
        private void DrawValueText(Graphics graph, int sliderWidth, Rectangle rectSlicer)
        {

            //Campos
            string text = symbolBefore + this.Value.ToString() + symbolAfter;
            if(showMaximun == true)
            {
                text = text + "/" + symbolBefore + this.Maximum.ToString() + symbolAfter;
            }
            var textSize = TextRenderer.MeasureText(text, this.Font);
            var rectText = new Rectangle(0, 0, textSize.Width, textSize.Height + 2);

            using (var brushText = new SolidBrush(this.ForeColor))
            using (var brushTextBack = new SolidBrush(foreBackColor))
            using(var textFormat = new StringFormat())
            {
                switch (showValue)
                {
                    case TextPosition.Left:
                        rectText.X = 0;
                        textFormat.Alignment = StringAlignment.Center;
                        break;

                    case TextPosition.Right:
                        rectText.X = this.Width - textSize.Width;
                        textFormat.Alignment = StringAlignment.Center;
                        break;

                    case TextPosition.Center:
                        rectText.X = (this.Width - textSize.Width) / 2;
                        textFormat.Alignment = StringAlignment.Center;
                        break;

                    case TextPosition.Sliding:
                        rectText.X = sliderWidth - textSize.Width;
                        textFormat.Alignment = StringAlignment.Center;
                        //Clear previus text surface
                        using(var brushClear = new SolidBrush(this.Parent.BackColor))
                        {
                            var rect = rectSlicer;
                            rect.Y = rectText.Y;
                            rect.Height = rectText.Height;
                            graph.FillRectangle(brushClear, rect);
                        }
                        break;

                }

                //Painting
                graph.FillRectangle(brushTextBack, rectText);
                graph.DrawString(text, this.Font, brushText, rectText, textFormat);

            }

        }


        






    }
}
