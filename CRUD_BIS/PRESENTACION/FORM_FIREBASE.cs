using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//hacemos referencia al archivo app.config
using System.Configuration;
using System.Xml;

//hacemos referencia al firesharp
//asegurarse que tenemos instalado el Firesharp en el proyecto
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

//hacemos referencia al web.script para leer y convertir JSON string
//habilitamos la referencia: Asemblies/Framework/System.Web.Extension
using System.Web.Script.Serialization;
//hacemos referencia al companentmodel para ordenar los datos del datagridview
using System.ComponentModel;
//hacemos refencia al IO para usarlo con ImageToBase64 y Base64ToImage
using System.IO;


namespace CRUD_BIS.PRESENTACION
{
    public partial class FORM_FIREBASE : Form
    {

        //Variables-------------------------------------------

        string IMG_FileNameInput;

        Boolean clearDGVCol = true;

        private DataTable dtTableGrd;


        //Configuramos FireSharp------------------------------

        private FirebaseConfig FCon_ = new FirebaseConfig
        {

            AuthSecret = ConfigurationManager.AppSettings.Get("AuthSecret"),

            BasePath = ConfigurationManager.AppSettings.Get("BasePath")

        };
        
        //video: 29:55 min
        private IFirebaseClient Cliente1;
        
        //Funcion para convertir imagenes-----------------------

        public string ImageToBase64(Image Image1)
        {

            using (MemoryStream Ms = new MemoryStream())
            {
                
                //convertimos la imagen a bytes
                System.Drawing.Imaging.ImageFormat Format1 = System.Drawing.Imaging.ImageFormat.Jpeg;

                Image1.Save(Ms, Format1);

                byte[] ImageByte1 = Ms.ToArray();

                //convertimos las bytes a base64
                string Base64String = Convert.ToBase64String(ImageByte1);

                return Base64String;

            }

        }

        public Image Base64ToImage(string Base64String)
        {

            //convertimos Base64 a bytes
            byte[] ImageBytes1 = Convert.FromBase64String(Base64String);

            MemoryStream Ms = new MemoryStream(ImageBytes1, 0, ImageBytes1.Length);

            //convertimos bytes a imagen
            Ms.Write(ImageBytes1, 0, ImageBytes1.Length);

            Image Image1 = System.Drawing.Image.FromStream(Ms, true);

            return Image1;

        }

        private void DisplayRegSave(Boolean Stat)
        {

            this.Txt_Name.Enabled = Stat;

            this.Txt_ID.Enabled = Stat;

            this.Cmb_Genger.Enabled = Stat;

            this.Txt_City.Enabled = Stat;

            this.Btn_Save.Enabled = Stat;

            this.Btn_ClearAll.Enabled = Stat;

        }

        private void DisplayRecLoad(Boolean Stat)
        {

            this.Txt_Search.Enabled = Stat;

            this.Cmb_SearchBy.Enabled = Stat;

            this.Btn_Edit.Enabled = Stat;

            this.Btn_Delete.Enabled = Stat;

            this.Btn_Refresh.Enabled = Stat;

            this.Btn_ClearSelection.Enabled = Stat;

            this.DGV_UserData.Enabled = Stat;

        }

        //Subrutina para cargar la base de datos y mostrarlo en el DataGridView-------
        //video VB Net with Firebase using FireSharp 32:43 min
        public void ShowRecord()
        {

            try
            {

                DataTable DtTable = new DataTable();

                DtTable.Columns.Add("Nombre");
                DtTable.Columns.Add("ID");
                DtTable.Columns.Add("Genero");
                DtTable.Columns.Add("Ciudad");
                DtTable.Columns.Add("Imagen", typeof(Image));

                //Condicion para borrar columnas-------------------
                if (clearDGVCol == true)
                {

                    this.DGV_UserData.Columns.Clear();

                    clearDGVCol = false;

                }

                var SRRecord = Cliente1.Get("PersonDB/"); //32:43

                //convertimos JSON a un tipo Objeto----------------------
                JavaScriptSerializer myJsonTool = new JavaScriptSerializer();

                var myDeserializedItems = myJsonTool.Deserialize<Dictionary<String, PersonalData>>(SRRecord.Body);

                foreach (KeyValuePair<String, PersonalData> dicItem in myDeserializedItems)
                {

                    DtTable.Rows.Add(dicItem.Value.Name, dicItem.Value.ID, dicItem.Value.Genger, dicItem.Value.City, Base64ToImage(dicItem.Value.Image));

                }

                this.DGV_UserData.DataSource = DtTable;

                dtTableGrd = DtTable;

                var ImageColumn = (DataGridViewImageColumn)this.DGV_UserData.Columns["Imagen"];
                
                ImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                this.DGV_UserData.Sort(this.DGV_UserData.Columns[0], ListSortDirection.Ascending);

                this.Lbl_TotalUser.Text = "Total Usuarios: " + this.DGV_UserData.RowCount.ToString();

                this.Text = "VB Net FIREBASE RealTime";

                this.Lbl_RecordView.Text = "Vista de Registros: ";

                DisplayRecLoad(true);

                this.DGV_UserData.ClearSelection();

            }
            catch (Exception ex)
            {

                if (ex.Message == "One or more error occurred")
                {

                    MessageBox.Show("Cannot connect to FireBase, check your network", "Error message...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (ex.Message == "Object reference not set to an instance of an object")
                {

                    DataTable DtTable = new DataTable();

                    DtTable.Columns.Add("Nombre");
                    DtTable.Columns.Add("ID");
                    DtTable.Columns.Add("Genero");
                    DtTable.Columns.Add("Ciudad");
                    DtTable.Columns.Add("Imagen", typeof(Image));

                    this.DGV_UserData.DataSource = DtTable;

                    MessageBox.Show("Database not found or Database is empty", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    MessageBox.Show(ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                this.Text = "VB Net FIREBASE RealTime";

                this.Lbl_RecordView.Text = "Vista de Registros: ";

                DisplayRecLoad(true);

            }

        }

        //video 35:21 min








        public FORM_FIREBASE()
        {
            InitializeComponent();
        }




        private void FORM_FIREBASE_Load(object sender, EventArgs e)
        {

            CRUD_BIS.LOGICA.TAM_DT Formato1 = new CRUD_BIS.LOGICA.TAM_DT();

            Formato1.CentrarControl(this.Pnl_Header3);

            Formato1.CentrarControl(this.panel4);


            try
            {

                Cliente1 = new FireSharp.FirebaseClient(FCon_);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            this.Cmb_SearchBy.SelectedIndex = 0;

        }



        private void Btn_CreateID_Click(object sender, EventArgs e)
        {

            try
            {

                this.Txt_ID.Text = "Por favor espere...";

                //aqui generamos el ID del registro----------------
                Random R = new Random();

                int Num;

                Num = (R.Next(1, 99999));
                            
                string IDResultado;

                IDResultado = "00000" + Num.ToString();
                            
                IDResultado = IDResultado.Substring(IDResultado.Length - 5);

                //video 35:42 min
                var CheckID = Cliente1.Get("PersonDB/" + IDResultado);
                //var CheckID = await Cliente1.PushAsync("f", "f");
                            
                //aqui validamos que no se repita el ID--------------
                if (CheckID.Body != "null")
                {

                    MessageBox.Show("El mismo ID fue encontrado, crea otro ID", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    this.Txt_ID.Text = IDResultado;

                }

            }
            catch(Exception ex)
            {

                if (ex.Message == "One or more error occurred")
                {

                    MessageBox.Show("Cannot connect to FireBase, check your network", "Error message...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            
            if (this.Btn_Save.Text == "Guardar")
            {
                
                if (this.Txt_Name.Text == "")
                {
                    
                    MessageBox.Show("El campo Nombre esta vacio" + System.Environment.NewLine + "Ingrese un Nombre", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.Txt_ID.Text == "")
                {

                    MessageBox.Show("El campo ID esta vacio" + System.Environment.NewLine + "Genere un ID", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.Cmb_Genger.Text == "")
                {

                    MessageBox.Show("El campo Genero esta vacio" + System.Environment.NewLine + "Seleccione un Genero", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.Txt_City.Text == "")
                {

                    MessageBox.Show("El campo Ciudad esta vacio" + System.Environment.NewLine + "Ingrese una Ciudad", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.IMG_FileNameInput == "")
                {

                    MessageBox.Show("La Imagen esta vacia" + System.Environment.NewLine + "Busque una Imagen", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {

                    this.Text = "VB Net FIREBASE RealTime (Guardando...)";

                    this.Lbl_Registration.Text = "Registrando (Guardando...)";

                    DisplayRegSave(false);

                    string ImgData;

                    ImgData = ImageToBase64(this.PB_UserReg.Image);

                    PersonalData PD = new PersonalData();

                    PD.Name = this.Txt_Name.Text;
                    PD.ID = this.Txt_ID.Text;
                    PD.Genger = this.Cmb_Genger.Text;
                    PD.City = this.Txt_City.Text;
                    PD.Image = ImgData;

                    var Save = Cliente1.Set("PersonDB/" + this.Txt_ID.Text, PD);

                    DisplayRegSave(true);

                    this.Lbl_Registration.Text = "Registro nuevo:";

                    this.Text = "VB Net FIREBASE RealTime";

                    MessageBox.Show("Datos guardados exitosamente", "Informacion...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Btn_ClearAll_Click(sender, e);

                    this.Btn_Refresh_Click(sender, e);

                }
                catch (Exception ex)
                {

                    if (ex.Message == "One or more error occurred")
                    {

                        MessageBox.Show("Cannot connect to FireBase, check your network", "Error message...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {

                        MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    DisplayRegSave(true);

                    this.Lbl_Registration.Text = "Registro nuevo:";

                    this.Text = "VB Net FIREBASE RealTime";

                }

            }
            else
            {

                if (this.Txt_Name.Text == "")
                {

                    MessageBox.Show("El campo Nombre esta vacio" + System.Environment.NewLine + "Ingrese un Nombre", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.Txt_City.Text == "")
                {

                    MessageBox.Show("El campo Ciudad esta vacio" + System.Environment.NewLine + "Ingrese una Ciudad", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {

                    this.Text = "VB Net FIREBASE RealTime (Actualizando...)";

                    this.Lbl_Registration.Text = "Registrando (Actualizando...)";

                    DisplayRegSave(false);

                    string ImgData;

                    ImgData = ImageToBase64(this.PB_UserReg.Image);

                    PersonalData PD = new PersonalData();

                    PD.Name = this.Txt_Name.Text;
                    PD.ID = this.Txt_ID.Text;
                    PD.Genger = this.Cmb_Genger.Text;
                    PD.City = this.Txt_City.Text;
                    PD.Image = ImgData;

                    var Update = Cliente1.Update("PersonDB/" + this.Txt_ID.Text, PD);

                    DisplayRegSave(true);

                    this.Lbl_Registration.Text = "Registro nuevo:";

                    this.Text = "VB Net FIREBASE RealTime";

                    MessageBox.Show("Datos actualizados exitosamente", "Informacion...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Btn_ClearAll_Click(sender, e);

                    this.Btn_Refresh_Click(sender, e);

                }
                catch (Exception ex)
                {

                    if (ex.Message == "One or more error occurred")
                    {

                        MessageBox.Show("Cannot connect to FireBase, check your network", "Error message...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {

                        MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    DisplayRegSave(true);

                    this.Lbl_Registration.Text = "Registro nuevo:";

                    this.Text = "VB Net FIREBASE RealTime";

                }

            }

        }



        private void Btn_ClearAll_Click(object sender, EventArgs e)
        {

            this.Txt_Name.Clear();

            this.Txt_ID.Clear();

            this.Cmb_Genger.Text = "";

            this.Txt_City.Clear();

            this.PB_UserReg.Image = CRUD_BIS.Properties.Resources.Foto_Aqui_2;

            this.IMG_FileNameInput = "";

            this.Btn_Save.Text = "Guardar";

            this.Btn_CreateID.Enabled = true;

        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {

            this.Text = "VB Net FIREBASE RealTime (Cargando...)";

            this.Lbl_RecordView.Text = "Vista de Registros: (Cargando...)";

            DisplayRecLoad(false);

            ShowRecord();

        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {

            //validar si tenemos una fila seleccionada------------------
            if (this.DGV_UserData.SelectedRows.Count == 0)
            {

                MessageBox.Show("Seleccione una fila de la tabla para Editar", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            //validar si hemos seleccionado una fila seleccionada------------------
            if (this.DGV_UserData.SelectedRows.Count >= 2)
            {

                MessageBox.Show("Usted a seleccionado " + this.DGV_UserData.SelectedRows.Count + " filas de la tabla." + System.Environment.NewLine + "Solo puedes Editar una fila a la vez", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            if (this.DGV_UserData.SelectedRows.Count == 1)
            {

                this.Txt_Name.Text = this.DGV_UserData.SelectedRows[0].Cells["Nombre"].Value.ToString();

                this.Txt_ID.Text = this.DGV_UserData.SelectedRows[0].Cells["ID"].Value.ToString();

                this.Cmb_Genger.Text = this.DGV_UserData.SelectedRows[0].Cells["Genero"].Value.ToString();

                this.Txt_City.Text = this.DGV_UserData.SelectedRows[0].Cells["Ciudad"].Value.ToString();

                this.PB_UserReg.Image = (System.Drawing.Image)this.DGV_UserData.Rows[this.DGV_UserData.SelectedRows[0].Index].Cells["Imagen"].Value;

                this.Btn_Save.Text = "Subir";

            }

        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {

            //Validadmos si queremos borrar todos los datos-----------------
            if (AllCellsSelected(this.DGV_UserData) == true)
            {

                try
                {

                    DialogResult Respuesta = MessageBox.Show("¿Quieres borrar todos los datos?", "Confirmar...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Respuesta == DialogResult.Cancel)
                    {
                        return;
                    }

                    this.Text = "VB Net FIREBASE RealTime (Borrando...)";

                    this.Lbl_RecordView.Text = "Vista de Registros: (Borrando...)";

                    DisplayRecLoad(false);

                    var BorrarTodo = Cliente1.Delete("PersonDB");

                    MessageBox.Show("Datos Borrados exitosamente", "Informacion...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Text = "VB Net FIREBASE RealTime";

                    this.Lbl_RecordView.Text = "Vista de Registros:";

                    DisplayRecLoad(true);

                    this.Btn_Refresh_Click(sender, e);

                    return;

                }
                catch(Exception ex)
                {

                    if (ex.Message == "One or more error occurred")
                    {

                        MessageBox.Show("Cannot connect to FireBase, check your network", "Error message...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {

                        MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    this.Text = "VB Net FIREBASE RealTime";

                    this.Lbl_RecordView.Text = "Vista de Registros:";

                    DisplayRecLoad(true);

                }

            }

            //--------------------------------

            try
            {

                if(this.DGV_UserData.SelectedRows.Count == 0)
                {

                    MessageBox.Show("Seleccione una fila de la tabla para Borrar", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }

                DialogResult Respuesta = MessageBox.Show("¿Quieres borrar estos datos?", "Confirmar...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Respuesta == DialogResult.Cancel)
                {
                    return;
                }

                this.Text = "VB Net FIREBASE RealTime (Borrando...)";

                this.Lbl_RecordView.Text = "Vista de Registros: (Borrando...)";

                DisplayRecLoad(false);

                foreach (DataGridViewRow Fila in this.DGV_UserData.SelectedRows)
                {

                    if (Fila.Selected == true)
                    {

                        DataGridViewRow DataRow1 = this.DGV_UserData.Rows[Fila.Index];

                        string Codigo = DataRow1.Cells["ID"].Value.ToString();

                        var BorrarFila = Cliente1.Delete("PersonDB/" + Codigo);

                    }

                }

                MessageBox.Show("Datos Borrados exitosamente", "Informacion...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Text = "VB Net FIREBASE RealTime";

                this.Lbl_RecordView.Text = "Vista de Registros:";

                DisplayRecLoad(true);

                this.Btn_Refresh_Click(sender, e);

            }
            catch(Exception ex)
            {

                if (ex.Message == "One or more error occurred")
                {

                    MessageBox.Show("Cannot connect to FireBase, check your network", "Error message...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                this.Text = "VB Net FIREBASE RealTime";

                this.Lbl_RecordView.Text = "Vista de Registros:";

                DisplayRecLoad(true);

            }

        }

        private Boolean AllCellsSelected(DataGridView DGV)
        {

            if (DGV.RowCount == 0)
            {

                return false;

            }

            if (DGV.RowCount == 1)
            {

                return false;

            }

            return (DGV.SelectedCells.Count == (DGV.RowCount * DGV.Columns.GetColumnCount(DataGridViewElementStates.Visible)));

        }

        //video 49:19
        private void Btn_ClearSelection_Click(object sender, EventArgs e)
        {

            this.DGV_UserData.ClearSelection();

        }

        private void Txt_Search_TextChanged(object sender, EventArgs e)
        {

            this.dtTableGrd.DefaultView.RowFilter = this.Cmb_SearchBy.Text + " Like '%" + this.Txt_Search.Text + "%'";

            this.DGV_UserData.ClearSelection();

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Btn_Edit_Click(sender, e);

        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Btn_Delete_Click(sender, e);

        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.DGV_UserData.SelectAll();

        }

        private void limpiarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Btn_ClearSelection_Click(sender, e);

        }

        private void ModificarValor(string xTexto, string xCampo)
        {
            /*aqui obtenemos el valor
            string Valor1 = ConfigurationManager.AppSettings.Get("TABLA");

            MessageBox.Show(Valor1);
            */

            //aqui modificamos el valor
            XmlDocument XmlDoc = new XmlDocument();

            //string xDir = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Substring(0, AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.ToString().IndexOf("bin")) + "app.config";
            string xDir = Application.ExecutablePath.Substring(0, Application.ExecutablePath.ToString().IndexOf("bin")) + "app.config";

            if (System.IO.File.Exists(xDir) == false)
            {
                
                cfgSetValue("configuration/appSettings", "AuthSecret", "Unknow");
                cfgSetValue("configuration/appSettings", "BasePath", "Unknow");
                cfgSetValue("configuration/appSettings", "TABLA", "Unknow");

                XmlDoc.Save(xDir);

            }

            XmlDoc.Load(xDir);

            foreach (XmlElement Elemento in XmlDoc.DocumentElement)
            {

                if (Elemento.Name.Equals("appSettings"))
                {

                    foreach (XmlNode Nodo in Elemento.ChildNodes)
                    {

                        //Attributes[0] es igual al Key
                        //Attributes[1] es igual al value
                        if (Nodo.Attributes[0].Value == xCampo)
                        {

                            Nodo.Attributes[1].Value = xTexto;

                        }

                    }

                }

            }

            XmlDoc.Save(xDir);

            ConfigurationManager.RefreshSection("appSettings");

        }

        //  El método para guardar los valores
        private void cfgSetValue(string seccion, string clave, string valor)
        {
            //
            XmlDocument configXml = new XmlDocument();
            //

            XmlNode n;
            n = configXml.SelectSingleNode(seccion + "/add[@key=\"" + clave + "\"]");
            if (n != null)
            {
                n.Attributes["value"].InnerText = valor;
            }
        }

        private void PB_UserReg_Click(object sender, EventArgs e)
        {

            this.OFD_UserImage.InitialDirectory = "";

            this.OFD_UserImage.Filter = "Imagenes|*.jpg;*.png;*.bmp";

            this.OFD_UserImage.FilterIndex = 3;

            this.OFD_UserImage.Title = "Cargador de Imagenes...";

            if (this.OFD_UserImage.ShowDialog() == DialogResult.OK)
            {

                this.PB_UserReg.BackgroundImage = null;

                this.PB_UserReg.Image = new Bitmap(this.OFD_UserImage.FileName);

            }

        }
    }
}
