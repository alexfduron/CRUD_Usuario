﻿using System;
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

    [DefaultEvent("_TextChanged")]

    public partial class AFD_TextBox : UserControl
    {

        //Campos
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private Color borderFocusColor = Color.HotPink;
        private int borderRadius = 0;

        private bool underlinedStyle = false;
        private bool isFocused = false;
        
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;

        //Constructor
        public AFD_TextBox()
        {
            InitializeComponent();
        }

        //Eventos
        public event EventHandler _TextChanged;


        //Propiedades
        [Description("Modifica el color del borde")]
        [Category("AFD Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }

        [Description("Modifica el radio del borde")]
        [Category("AFD Code Advance")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        [Description("Modifica el color del borde al estar activo")]
        [Category("AFD Code Advance")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        [Description("Modifica el tamaño del borde")]
        [Category("AFD Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value >= 0)
                {
                    borderSize = value;
                    this.Invalidate();
                }
            }
        }



        [Description("Habilita el color del borde al estar activo")]
        [Category("AFD Code Advance")]
        public bool IsFocused
        {
            get { return isFocused; }
            set { isFocused = value; this.Invalidate(); }
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
            get { return isPasswordChar; }
            set
            {
                isPasswordChar = value;
                this.textBox1.UseSystemPasswordChar = value;
            }
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
            get
            {
                if(isPlaceholder == true)
                {
                    return "";
                }
                else
                {
                    return this.textBox1.Text;
                }
            }
            set
            {

                this.textBox1.Text = value;
                SetPlaceholder();
            }
        }



        [Description("Modifica el color del marcador")]
        [Category("AFD Code Advance")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;
                if(isPlaceholder == true)
                {
                    this.textBox1.ForeColor = value;
                }
            }
        }

        [Description("Modifica el texto del marcador")]
        [Category("AFD Code Advance")]
        public string PlaceholderTexts
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                this.textBox1.Text = "";
                SetPlaceholder();
            }
        }


        //Metodos

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1) //Rounded textbox
            {
                //campos
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using(Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //Draw border
                    
                    this.Region = new Region(pathBorderSmooth);  //set the rounded region of usercontrol
                    //this.textBox1.Region = new Region(pathBorderSmooth);

                    if (borderRadius > 15)
                    {
                        SetTextBoxRoundedRegion();
                    }

                    graph.SmoothingMode = SmoothingMode.AntiAlias;

                    penBorder.Alignment = PenAlignment.Center;

                    if (isFocused == false)
                    {

                        if (underlinedStyle == true)
                        {
                            //line style
                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            graph.SmoothingMode = SmoothingMode.None;
                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        }
                        else
                        {
                            //normal style
                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            graph.DrawPath(penBorder, pathBorder);
                        }

                    }
                    else
                    {

                        penBorder.Color = borderFocusColor;

                        if (underlinedStyle == true)
                        {
                            //line style
                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            graph.SmoothingMode = SmoothingMode.None;
                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        }
                        else
                        {
                            //normal style
                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            graph.DrawPath(penBorder, pathBorder);
                        }

                    }

                    
                }

            }
            else   //Normal textbox
            {

                //Draw border
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = PenAlignment.Inset;

                    if (isFocused == false)
                    {

                        if (underlinedStyle == true)
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
                    else
                    {

                        penBorder.Color = borderFocusColor;

                        if (underlinedStyle == true)
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

            }

        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathText;
            if(Multiline == true)
            {
                pathText = GetFigurePath(this.textBox1.ClientRectangle, borderRadius - borderSize);
                this.textBox1.Region = new Region(pathText);
            }
            else
            {
                pathText = GetFigurePath(this.textBox1.ClientRectangle, borderSize * 2);
                this.textBox1.Region = new Region(pathText);
            }
        }


        private void SetPlaceholder()
        {
            if(string.IsNullOrWhiteSpace(this.textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                this.textBox1.Text = placeholderText;
                this.textBox1.ForeColor = placeholderColor;
                if(isPasswordChar == true)
                {
                    this.textBox1.UseSystemPasswordChar = false;
                }
            }
        }


        private void RemovePlaceholder()
        {
            if (isPlaceholder == true && placeholderText != "")
            {
                isPlaceholder = false;
                this.textBox1.Text = "";
                this.textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar == true)
                {
                    this.textBox1.UseSystemPasswordChar = true;
                }
            }
        }


        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
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


        //Eventos
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(_TextChanged != null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }
        /*
        private void textBox1_BackColorChanged(object sender, EventArgs e)
        {
            this.OnBackColorChanged(e);
        }

        private void textBox1_VisibleChanged(object sender, EventArgs e)
        {
            this.OnVisibleChanged(e);
        }
        */

        //eventos del mouse
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        //eventos del key
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.OnPreviewKeyDown(e);
        }
        

        //Eventos de accion
        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.OnMouseCaptureChanged(e);
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.OnMouseDoubleClick(e);
        }
        
        //eventos del focus
        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.OnEnter(e);
            isFocused = true;
            RemovePlaceholder();
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            this.OnLeave(e);
            isFocused = false;
            SetPlaceholder();
            this.Invalidate();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            this.OnValidated(e);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            this.OnValidating(e);
        }
        /*
        //eventos del drag drop
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            this.OnDragDrop(e);
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            this.OnDragEnter(e);
        }

        private void textBox1_DragLeave(object sender, EventArgs e)
        {
            this.OnDragLeave(e);
        }

        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            this.OnDragOver(e);
        }

        private void textBox1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            this.OnGiveFeedback(e);
        }

        private void textBox1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            this.OnQueryContinueDrag(e);
        }
        
        //eventos del layout
        private void textBox1_Layout(object sender, LayoutEventArgs e)
        {
            this.OnLayout(e);
        }

        private void textBox1_MarginChanged(object sender, EventArgs e)
        {
            this.OnMarginChanged(e);
        }

        private void textBox1_Move(object sender, EventArgs e)
        {
            this.OnMove(e);
        }

        private void textBox1_Resize(object sender, EventArgs e)
        {
            this.OnResize(e);
        }

        private void textBox1_SizeChanged(object sender, EventArgs e)
        {
            this.OnSizeChanged(e);
        }

        private void textBox1_RegionChanged(object sender, EventArgs e)
        {
            this.OnRegionChanged(e);
        }

        private void textBox1_LocationChanged(object sender, EventArgs e)
        {
            this.OnLocationChanged(e);
        }

        private void textBox1_ForeColorChanged(object sender, EventArgs e)
        {
            this.OnForeColorChanged(e);
        }

        private void textBox1_FontChanged(object sender, EventArgs e)
        {
            this.OnFontChanged(e);
        }

        private void textBox1_EnabledChanged(object sender, EventArgs e)
        {
            this.OnEnabledChanged(e);
        }

        private void textBox1_DockChanged(object sender, EventArgs e)
        {
            this.OnDockChanged(e);
        }
        */
        private void textBox1_CursorChanged(object sender, EventArgs e)
        {
            this.OnCursorChanged(e);
        }

        

    }
}
