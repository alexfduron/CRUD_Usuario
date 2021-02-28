namespace CRUD_BIS.PRESENTACION
{
    partial class FORM_USUARIO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_USUARIO));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnl_Buscar = new System.Windows.Forms.Panel();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnl_Nombre = new System.Windows.Forms.Panel();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnl_Pass = new System.Windows.Forms.Panel();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.lbl_Pass = new System.Windows.Forms.Label();
            this.pnl_Menu1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Volver = new System.Windows.Forms.Button();
            this.btn_GuardarCambio = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.pnl_Menu2 = new System.Windows.Forms.Panel();
            this.pic_Foto = new System.Windows.Forms.PictureBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Borrar = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnl_Menu1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnl_Menu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Foto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1183, 152);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnl_Buscar);
            this.panel3.Controls.Add(this.txt_Buscar);
            this.panel3.Controls.Add(this.btn_Buscar);
            this.panel3.Controls.Add(this.btn_Borrar);
            this.panel3.Controls.Add(this.btn_Agregar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(783, 45);
            this.panel3.TabIndex = 4;
            // 
            // pnl_Buscar
            // 
            this.pnl_Buscar.BackColor = System.Drawing.Color.White;
            this.pnl_Buscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Buscar.Location = new System.Drawing.Point(0, 40);
            this.pnl_Buscar.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Buscar.Name = "pnl_Buscar";
            this.pnl_Buscar.Size = new System.Drawing.Size(609, 5);
            this.pnl_Buscar.TabIndex = 3;
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.BackColor = System.Drawing.Color.Black;
            this.txt_Buscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Buscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_Buscar.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscar.ForeColor = System.Drawing.Color.White;
            this.txt_Buscar.Location = new System.Drawing.Point(0, 0);
            this.txt_Buscar.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(609, 40);
            this.txt_Buscar.TabIndex = 4;
            this.txt_Buscar.TextChanged += new System.EventHandler(this.txt_Buscar_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Consolas", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(783, 107);
            this.label1.TabIndex = 1;
            this.label1.Text = "USUARIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(983, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 152);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 190);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(188, 239);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pic_Foto);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(860, 273);
            this.panel5.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pnl_Nombre);
            this.panel6.Controls.Add(this.txt_Nombre);
            this.panel6.Controls.Add(this.lbl_Nombre);
            this.panel6.Location = new System.Drawing.Point(17, 44);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(613, 50);
            this.panel6.TabIndex = 5;
            // 
            // pnl_Nombre
            // 
            this.pnl_Nombre.BackColor = System.Drawing.Color.White;
            this.pnl_Nombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Nombre.Location = new System.Drawing.Point(190, 47);
            this.pnl_Nombre.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Nombre.Name = "pnl_Nombre";
            this.pnl_Nombre.Size = new System.Drawing.Size(423, 3);
            this.pnl_Nombre.TabIndex = 3;
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.BackColor = System.Drawing.Color.Black;
            this.txt_Nombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_Nombre.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Nombre.ForeColor = System.Drawing.Color.White;
            this.txt_Nombre.Location = new System.Drawing.Point(190, 0);
            this.txt_Nombre.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(423, 47);
            this.txt_Nombre.TabIndex = 4;
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Nombre.Location = new System.Drawing.Point(0, 0);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(190, 50);
            this.lbl_Nombre.TabIndex = 5;
            this.lbl_Nombre.Text = "Nombre:";
            this.lbl_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pnl_Pass);
            this.panel8.Controls.Add(this.txt_Pass);
            this.panel8.Controls.Add(this.lbl_Pass);
            this.panel8.Location = new System.Drawing.Point(17, 137);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(613, 50);
            this.panel8.TabIndex = 6;
            // 
            // pnl_Pass
            // 
            this.pnl_Pass.BackColor = System.Drawing.Color.White;
            this.pnl_Pass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Pass.Location = new System.Drawing.Point(190, 47);
            this.pnl_Pass.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Pass.Name = "pnl_Pass";
            this.pnl_Pass.Size = new System.Drawing.Size(423, 3);
            this.pnl_Pass.TabIndex = 3;
            // 
            // txt_Pass
            // 
            this.txt_Pass.BackColor = System.Drawing.Color.Black;
            this.txt_Pass.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_Pass.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Pass.ForeColor = System.Drawing.Color.White;
            this.txt_Pass.Location = new System.Drawing.Point(190, 0);
            this.txt_Pass.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.Size = new System.Drawing.Size(423, 47);
            this.txt_Pass.TabIndex = 4;
            // 
            // lbl_Pass
            // 
            this.lbl_Pass.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Pass.Location = new System.Drawing.Point(0, 0);
            this.lbl_Pass.Name = "lbl_Pass";
            this.lbl_Pass.Size = new System.Drawing.Size(190, 50);
            this.lbl_Pass.TabIndex = 5;
            this.lbl_Pass.Text = "Contraseña:";
            this.lbl_Pass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_Menu1
            // 
            this.pnl_Menu1.Controls.Add(this.tableLayoutPanel1);
            this.pnl_Menu1.Controls.Add(this.panel5);
            this.pnl_Menu1.Location = new System.Drawing.Point(30, 43);
            this.pnl_Menu1.Name = "pnl_Menu1";
            this.pnl_Menu1.Size = new System.Drawing.Size(860, 335);
            this.pnl_Menu1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Guardar, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_GuardarCambio, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Volver, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 273);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(860, 62);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btn_Volver
            // 
            this.btn_Volver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Volver.FlatAppearance.BorderSize = 4;
            this.btn_Volver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btn_Volver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Volver.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Volver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Volver.Location = new System.Drawing.Point(3, 3);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(244, 56);
            this.btn_Volver.TabIndex = 0;
            this.btn_Volver.Text = "Volver";
            this.btn_Volver.UseVisualStyleBackColor = true;
            // 
            // btn_GuardarCambio
            // 
            this.btn_GuardarCambio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_GuardarCambio.FlatAppearance.BorderSize = 4;
            this.btn_GuardarCambio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btn_GuardarCambio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_GuardarCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuardarCambio.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_GuardarCambio.Location = new System.Drawing.Point(308, 3);
            this.btn_GuardarCambio.Name = "btn_GuardarCambio";
            this.btn_GuardarCambio.Size = new System.Drawing.Size(244, 56);
            this.btn_GuardarCambio.TabIndex = 2;
            this.btn_GuardarCambio.Text = "Guardar Cambios";
            this.btn_GuardarCambio.UseVisualStyleBackColor = true;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Guardar.FlatAppearance.BorderSize = 4;
            this.btn_Guardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btn_Guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Guardar.Location = new System.Drawing.Point(613, 3);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(244, 56);
            this.btn_Guardar.TabIndex = 5;
            this.btn_Guardar.Text = "Guardar Nuevo";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            // 
            // pnl_Menu2
            // 
            this.pnl_Menu2.Controls.Add(this.pnl_Menu1);
            this.pnl_Menu2.Location = new System.Drawing.Point(228, 180);
            this.pnl_Menu2.Name = "pnl_Menu2";
            this.pnl_Menu2.Size = new System.Drawing.Size(932, 473);
            this.pnl_Menu2.TabIndex = 4;
            // 
            // pic_Foto
            // 
            this.pic_Foto.BackColor = System.Drawing.Color.Transparent;
            this.pic_Foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Foto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Foto.Image = global::CRUD_BIS.Properties.Resources.Foto_Aqui_2;
            this.pic_Foto.Location = new System.Drawing.Point(672, 43);
            this.pic_Foto.Name = "pic_Foto";
            this.pic_Foto.Size = new System.Drawing.Size(149, 144);
            this.pic_Foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Foto.TabIndex = 7;
            this.pic_Foto.TabStop = false;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Buscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Buscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Buscar.Image = global::CRUD_BIS.Properties.Resources.buscar_2;
            this.btn_Buscar.Location = new System.Drawing.Point(609, 0);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(58, 45);
            this.btn_Buscar.TabIndex = 5;
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Borrar
            // 
            this.btn_Borrar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Borrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Borrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Borrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Borrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Borrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btn_Borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Borrar.Image = global::CRUD_BIS.Properties.Resources.borrador;
            this.btn_Borrar.Location = new System.Drawing.Point(667, 0);
            this.btn_Borrar.Name = "btn_Borrar";
            this.btn_Borrar.Size = new System.Drawing.Size(58, 45);
            this.btn_Borrar.TabIndex = 6;
            this.btn_Borrar.UseVisualStyleBackColor = false;
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Agregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Agregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Agregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Agregar.Image = global::CRUD_BIS.Properties.Resources.mas_2;
            this.btn_Agregar.Location = new System.Drawing.Point(725, 0);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(58, 45);
            this.btn_Agregar.TabIndex = 7;
            this.btn_Agregar.UseVisualStyleBackColor = false;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::CRUD_BIS.Properties.Resources.cancelar;
            this.button1.Location = new System.Drawing.Point(100, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::CRUD_BIS.Properties.Resources.Logo_BIS___Copy11;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FORM_USUARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1183, 734);
            this.Controls.Add(this.pnl_Menu2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FORM_USUARIO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FORM_USUARIO_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.pnl_Menu1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnl_Menu2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Foto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnl_Buscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Button btn_Borrar;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel pnl_Nombre;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pnl_Pass;
        private System.Windows.Forms.TextBox txt_Pass;
        private System.Windows.Forms.Label lbl_Pass;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.PictureBox pic_Foto;
        private System.Windows.Forms.Panel pnl_Menu1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_GuardarCambio;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.Panel pnl_Menu2;
    }
}