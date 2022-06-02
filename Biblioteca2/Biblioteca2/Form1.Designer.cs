namespace Biblioteca2
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.img_arrow = new System.Windows.Forms.PictureBox();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.imgFCFM = new System.Windows.Forms.Panel();
            this.imgUANL = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblError = new System.Windows.Forms.Label();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecibidos = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.dataGridReporte = new System.Windows.Forms.TabPage();
            this.repor_gen = new System.Windows.Forms.Button();
            this.all_mes = new System.Windows.Forms.ComboBox();
            this.all_years = new System.Windows.Forms.ComboBox();
            this.btn_alum = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rbGeneralPosgrado = new System.Windows.Forms.RadioButton();
            this.rbCarreraPosgrado = new System.Windows.Forms.RadioButton();
            this.lblCarreraPosgrado = new System.Windows.Forms.Label();
            this.ddlCarreraPosgrado = new System.Windows.Forms.ComboBox();
            this.rbCarrera = new System.Windows.Forms.RadioButton();
            this.rbSemestre = new System.Windows.Forms.RadioButton();
            this.rbGeneral = new System.Windows.Forms.RadioButton();
            this.ddlReportes = new System.Windows.Forms.ComboBox();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.ddlSemestre = new System.Windows.Forms.ComboBox();
            this.ddlCarrera = new System.Windows.Forms.ComboBox();
            this.dataGridReportes = new System.Windows.Forms.DataGridView();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dPHasta = new System.Windows.Forms.DateTimePicker();
            this.dPDe = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCInvitados = new System.Windows.Forms.Label();
            this.txtCPosgrado = new System.Windows.Forms.Label();
            this.txtCEmpleados = new System.Windows.Forms.Label();
            this.txtCAlumnos = new System.Windows.Forms.Label();
            this.btnInvitados = new System.Windows.Forms.Button();
            this.btnCInivitados = new System.Windows.Forms.Button();
            this.btnPosgrado = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnCPosgrado = new System.Windows.Forms.Button();
            this.btnCEmpleados = new System.Windows.Forms.Button();
            this.btnAlumnos = new System.Windows.Forms.Button();
            this.btnCAlumnos = new System.Windows.Forms.Button();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort3 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_arrow)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dataGridReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportes)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.ReadTimeout = 1000;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.dataGridReporte);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(868, 855);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.img_arrow);
            this.tabPage1.Controls.Add(this.lblBienvenido);
            this.tabPage1.Controls.Add(this.imgFCFM);
            this.tabPage1.Controls.Add(this.imgUANL);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(860, 826);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Autenticación";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // img_arrow
            // 
            this.img_arrow.Image = global::Biblioteca2.Properties.Resources.f_green_minmin;
            this.img_arrow.Location = new System.Drawing.Point(405, 420);
            this.img_arrow.Name = "img_arrow";
            this.img_arrow.Size = new System.Drawing.Size(203, 190);
            this.img_arrow.TabIndex = 24;
            this.img_arrow.TabStop = false;
            this.img_arrow.Visible = false;
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.Location = new System.Drawing.Point(368, 45);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(198, 42);
            this.lblBienvenido.TabIndex = 23;
            this.lblBienvenido.Text = "Bienvenido";
            // 
            // imgFCFM
            // 
            this.imgFCFM.BackgroundImage = global::Biblioteca2.Properties.Resources.logo_FCFM;
            this.imgFCFM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgFCFM.Location = new System.Drawing.Point(726, 24);
            this.imgFCFM.Name = "imgFCFM";
            this.imgFCFM.Size = new System.Drawing.Size(113, 96);
            this.imgFCFM.TabIndex = 22;
            // 
            // imgUANL
            // 
            this.imgUANL.BackgroundImage = global::Biblioteca2.Properties.Resources.logo_UANL;
            this.imgUANL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgUANL.Location = new System.Drawing.Point(52, 24);
            this.imgUANL.Name = "imgUANL";
            this.imgUANL.Size = new System.Drawing.Size(113, 96);
            this.imgUANL.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblError);
            this.groupBox2.Controls.Add(this.txtCarrera);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFecha);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.txtCodigo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtRecibidos);
            this.groupBox2.Location = new System.Drawing.Point(250, 135);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(484, 264);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(8, 237);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(444, 23);
            this.lblError.TabIndex = 24;
            // 
            // txtCarrera
            // 
            this.txtCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarrera.Location = new System.Drawing.Point(117, 113);
            this.txtCarrera.Margin = new System.Windows.Forms.Padding(4);
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.ReadOnly = true;
            this.txtCarrera.Size = new System.Drawing.Size(335, 22);
            this.txtCarrera.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Carrera";
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(117, 171);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(4);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(335, 22);
            this.txtFecha.TabIndex = 26;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(117, 67);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(335, 22);
            this.txtNombre.TabIndex = 25;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(117, 20);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(335, 22);
            this.txtCodigo.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Fecha de Entrada";
            // 
            // txtRecibidos
            // 
            this.txtRecibidos.BackColor = System.Drawing.Color.Transparent;
            this.txtRecibidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecibidos.Location = new System.Drawing.Point(48, 23);
            this.txtRecibidos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtRecibidos.Name = "txtRecibidos";
            this.txtRecibidos.Size = new System.Drawing.Size(62, 23);
            this.txtRecibidos.TabIndex = 15;
            this.txtRecibidos.Text = "Código";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCod);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 186);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(207, 91);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Código: ";
            // 
            // txtCod
            // 
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Location = new System.Drawing.Point(85, 39);
            this.txtCod.Margin = new System.Windows.Forms.Padding(4);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(102, 22);
            this.txtCod.TabIndex = 14;
            this.txtCod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTx_KeyDown);
            // 
            // dataGridReporte
            // 
            this.dataGridReporte.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridReporte.Controls.Add(this.repor_gen);
            this.dataGridReporte.Controls.Add(this.all_mes);
            this.dataGridReporte.Controls.Add(this.all_years);
            this.dataGridReporte.Controls.Add(this.btn_alum);
            this.dataGridReporte.Controls.Add(this.btnPDF);
            this.dataGridReporte.Controls.Add(this.button1);
            this.dataGridReporte.Controls.Add(this.rbGeneralPosgrado);
            this.dataGridReporte.Controls.Add(this.rbCarreraPosgrado);
            this.dataGridReporte.Controls.Add(this.lblCarreraPosgrado);
            this.dataGridReporte.Controls.Add(this.ddlCarreraPosgrado);
            this.dataGridReporte.Controls.Add(this.rbCarrera);
            this.dataGridReporte.Controls.Add(this.rbSemestre);
            this.dataGridReporte.Controls.Add(this.rbGeneral);
            this.dataGridReporte.Controls.Add(this.ddlReportes);
            this.dataGridReporte.Controls.Add(this.lblSemestre);
            this.dataGridReporte.Controls.Add(this.lblCarrera);
            this.dataGridReporte.Controls.Add(this.ddlSemestre);
            this.dataGridReporte.Controls.Add(this.ddlCarrera);
            this.dataGridReporte.Controls.Add(this.dataGridReportes);
            this.dataGridReporte.Controls.Add(this.btnGeneral);
            this.dataGridReporte.Controls.Add(this.label10);
            this.dataGridReporte.Controls.Add(this.label6);
            this.dataGridReporte.Controls.Add(this.label4);
            this.dataGridReporte.Controls.Add(this.dPHasta);
            this.dataGridReporte.Controls.Add(this.dPDe);
            this.dataGridReporte.Controls.Add(this.panel2);
            this.dataGridReporte.Controls.Add(this.panel1);
            this.dataGridReporte.Location = new System.Drawing.Point(4, 25);
            this.dataGridReporte.Name = "dataGridReporte";
            this.dataGridReporte.Padding = new System.Windows.Forms.Padding(3);
            this.dataGridReporte.Size = new System.Drawing.Size(860, 826);
            this.dataGridReporte.TabIndex = 1;
            this.dataGridReporte.Text = "Reportes";
            // 
            // repor_gen
            // 
            this.repor_gen.Location = new System.Drawing.Point(675, 254);
            this.repor_gen.Name = "repor_gen";
            this.repor_gen.Size = new System.Drawing.Size(104, 43);
            this.repor_gen.TabIndex = 39;
            this.repor_gen.Text = "Reporte género";
            this.repor_gen.UseVisualStyleBackColor = true;
            this.repor_gen.Click += new System.EventHandler(this.repor_gen_Click);
            // 
            // all_mes
            // 
            this.all_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.all_mes.FormattingEnabled = true;
            this.all_mes.Items.AddRange(new object[] {
            "TODOS",
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.all_mes.Location = new System.Drawing.Point(675, 173);
            this.all_mes.Name = "all_mes";
            this.all_mes.Size = new System.Drawing.Size(121, 24);
            this.all_mes.TabIndex = 38;
            // 
            // all_years
            // 
            this.all_years.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.all_years.FormattingEnabled = true;
            this.all_years.Items.AddRange(new object[] {
            "Todos",
            "2019",
            "2018",
            "2017",
            "2016"});
            this.all_years.Location = new System.Drawing.Point(675, 140);
            this.all_years.Name = "all_years";
            this.all_years.Size = new System.Drawing.Size(121, 24);
            this.all_years.TabIndex = 36;
            // 
            // btn_alum
            // 
            this.btn_alum.Location = new System.Drawing.Point(675, 207);
            this.btn_alum.Name = "btn_alum";
            this.btn_alum.Size = new System.Drawing.Size(104, 40);
            this.btn_alum.TabIndex = 35;
            this.btn_alum.Text = "Reporte de entradas";
            this.btn_alum.UseVisualStyleBackColor = true;
            this.btn_alum.Click += new System.EventHandler(this.btn_alum_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Location = new System.Drawing.Point(759, 598);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(80, 59);
            this.btnPDF.TabIndex = 34;
            this.btnPDF.Text = "Exportar a PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(759, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 59);
            this.button1.TabIndex = 33;
            this.button1.Text = "Exportar a Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbGeneralPosgrado
            // 
            this.rbGeneralPosgrado.AutoSize = true;
            this.rbGeneralPosgrado.Location = new System.Drawing.Point(46, 312);
            this.rbGeneralPosgrado.Name = "rbGeneralPosgrado";
            this.rbGeneralPosgrado.Size = new System.Drawing.Size(74, 20);
            this.rbGeneralPosgrado.TabIndex = 32;
            this.rbGeneralPosgrado.TabStop = true;
            this.rbGeneralPosgrado.Text = "General";
            this.rbGeneralPosgrado.UseVisualStyleBackColor = true;
            this.rbGeneralPosgrado.Visible = false;
            // 
            // rbCarreraPosgrado
            // 
            this.rbCarreraPosgrado.AutoSize = true;
            this.rbCarreraPosgrado.Location = new System.Drawing.Point(349, 312);
            this.rbCarreraPosgrado.Name = "rbCarreraPosgrado";
            this.rbCarreraPosgrado.Size = new System.Drawing.Size(71, 20);
            this.rbCarreraPosgrado.TabIndex = 31;
            this.rbCarreraPosgrado.TabStop = true;
            this.rbCarreraPosgrado.Text = "Carrera";
            this.rbCarreraPosgrado.UseVisualStyleBackColor = true;
            this.rbCarreraPosgrado.Visible = false;
            this.rbCarreraPosgrado.CheckedChanged += new System.EventHandler(this.rbCarreraPosgrado_CheckedChanged);
            // 
            // lblCarreraPosgrado
            // 
            this.lblCarreraPosgrado.AutoSize = true;
            this.lblCarreraPosgrado.Location = new System.Drawing.Point(284, 353);
            this.lblCarreraPosgrado.Name = "lblCarreraPosgrado";
            this.lblCarreraPosgrado.Size = new System.Drawing.Size(68, 16);
            this.lblCarreraPosgrado.TabIndex = 30;
            this.lblCarreraPosgrado.Text = "Posgrado";
            this.lblCarreraPosgrado.Visible = false;
            // 
            // ddlCarreraPosgrado
            // 
            this.ddlCarreraPosgrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCarreraPosgrado.FormattingEnabled = true;
            this.ddlCarreraPosgrado.Items.AddRange(new object[] {
            "Maestría en Ciencias con Orientación en Matemáticas",
            "Maestría en Ing. Física Industrial",
            "Maestría en Ing. en Seguridad de la Información",
            "Maestría en Astrofísica Planetaria y Tencologías Afines",
            "Doctorado en Matemáticas",
            "Doctorado en Ing. Física Industrial"});
            this.ddlCarreraPosgrado.Location = new System.Drawing.Point(389, 353);
            this.ddlCarreraPosgrado.Name = "ddlCarreraPosgrado";
            this.ddlCarreraPosgrado.Size = new System.Drawing.Size(400, 24);
            this.ddlCarreraPosgrado.TabIndex = 29;
            this.ddlCarreraPosgrado.Visible = false;
            // 
            // rbCarrera
            // 
            this.rbCarrera.AutoSize = true;
            this.rbCarrera.Location = new System.Drawing.Point(349, 309);
            this.rbCarrera.Name = "rbCarrera";
            this.rbCarrera.Size = new System.Drawing.Size(71, 20);
            this.rbCarrera.TabIndex = 28;
            this.rbCarrera.TabStop = true;
            this.rbCarrera.Text = "Carrera";
            this.rbCarrera.UseVisualStyleBackColor = true;
            this.rbCarrera.Visible = false;
            this.rbCarrera.CheckedChanged += new System.EventHandler(this.rbCarrera_CheckedChanged);
            // 
            // rbSemestre
            // 
            this.rbSemestre.AutoSize = true;
            this.rbSemestre.Location = new System.Drawing.Point(663, 312);
            this.rbSemestre.Name = "rbSemestre";
            this.rbSemestre.Size = new System.Drawing.Size(84, 20);
            this.rbSemestre.TabIndex = 27;
            this.rbSemestre.TabStop = true;
            this.rbSemestre.Text = "Semestre";
            this.rbSemestre.UseVisualStyleBackColor = true;
            this.rbSemestre.Visible = false;
            this.rbSemestre.CheckedChanged += new System.EventHandler(this.rbSemestre_CheckedChanged);
            // 
            // rbGeneral
            // 
            this.rbGeneral.AutoSize = true;
            this.rbGeneral.Location = new System.Drawing.Point(46, 309);
            this.rbGeneral.Name = "rbGeneral";
            this.rbGeneral.Size = new System.Drawing.Size(74, 20);
            this.rbGeneral.TabIndex = 26;
            this.rbGeneral.TabStop = true;
            this.rbGeneral.Text = "General";
            this.rbGeneral.UseVisualStyleBackColor = true;
            this.rbGeneral.Visible = false;
            // 
            // ddlReportes
            // 
            this.ddlReportes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlReportes.FormattingEnabled = true;
            this.ddlReportes.Items.AddRange(new object[] {
            "General",
            "Alumnos",
            "Docentes",
            "Posgrado",
            "Administrativos",
            "Invitados"});
            this.ddlReportes.Location = new System.Drawing.Point(288, 169);
            this.ddlReportes.Name = "ddlReportes";
            this.ddlReportes.Size = new System.Drawing.Size(121, 24);
            this.ddlReportes.TabIndex = 25;
            this.ddlReportes.SelectedIndexChanged += new System.EventHandler(this.ddlReportes_SelectedIndexChanged_1);
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(623, 356);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(66, 16);
            this.lblSemestre.TabIndex = 24;
            this.lblSemestre.Text = "Semestre";
            this.lblSemestre.Visible = false;
            // 
            // lblCarrera
            // 
            this.lblCarrera.AutoSize = true;
            this.lblCarrera.Location = new System.Drawing.Point(284, 356);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(53, 16);
            this.lblCarrera.TabIndex = 23;
            this.lblCarrera.Text = "Carrera";
            this.lblCarrera.Visible = false;
            // 
            // ddlSemestre
            // 
            this.ddlSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSemestre.FormattingEnabled = true;
            this.ddlSemestre.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.ddlSemestre.Location = new System.Drawing.Point(709, 353);
            this.ddlSemestre.Name = "ddlSemestre";
            this.ddlSemestre.Size = new System.Drawing.Size(121, 24);
            this.ddlSemestre.TabIndex = 22;
            this.ddlSemestre.Visible = false;
            // 
            // ddlCarrera
            // 
            this.ddlCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCarrera.FormattingEnabled = true;
            this.ddlCarrera.Items.AddRange(new object[] {
            "LA",
            "LCC",
            "LF",
            "LM",
            "LMAD",
            "LSTI"});
            this.ddlCarrera.Location = new System.Drawing.Point(389, 353);
            this.ddlCarrera.Name = "ddlCarrera";
            this.ddlCarrera.Size = new System.Drawing.Size(121, 24);
            this.ddlCarrera.TabIndex = 21;
            this.ddlCarrera.Visible = false;
            // 
            // dataGridReportes
            // 
            this.dataGridReportes.AllowUserToAddRows = false;
            this.dataGridReportes.AllowUserToDeleteRows = false;
            this.dataGridReportes.AllowUserToOrderColumns = true;
            this.dataGridReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReportes.Location = new System.Drawing.Point(56, 446);
            this.dataGridReportes.MultiSelect = false;
            this.dataGridReportes.Name = "dataGridReportes";
            this.dataGridReportes.ReadOnly = true;
            this.dataGridReportes.ShowCellErrors = false;
            this.dataGridReportes.ShowCellToolTips = false;
            this.dataGridReportes.ShowEditingIcon = false;
            this.dataGridReportes.Size = new System.Drawing.Size(697, 266);
            this.dataGridReportes.TabIndex = 19;
            this.dataGridReportes.TabStop = false;
            // 
            // btnGeneral
            // 
            this.btnGeneral.Location = new System.Drawing.Point(489, 164);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(83, 31);
            this.btnGeneral.TabIndex = 12;
            this.btnGeneral.Text = "Generar";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(177, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Reporte :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "De:";
            // 
            // dPHasta
            // 
            this.dPHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dPHasta.Location = new System.Drawing.Point(387, 85);
            this.dPHasta.Name = "dPHasta";
            this.dPHasta.Size = new System.Drawing.Size(200, 22);
            this.dPHasta.TabIndex = 5;
            // 
            // dPDe
            // 
            this.dPDe.CustomFormat = "";
            this.dPDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dPDe.Location = new System.Drawing.Point(387, 21);
            this.dPDe.Name = "dPDe";
            this.dPDe.Size = new System.Drawing.Size(200, 22);
            this.dPDe.TabIndex = 4;
            this.dPDe.Value = new System.DateTime(2016, 5, 4, 15, 28, 19, 0);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Biblioteca2.Properties.Resources.logo_FCFM;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(675, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(104, 100);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Biblioteca2.Properties.Resources.logo_UANL;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(70, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 90);
            this.panel1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.txtCInvitados);
            this.tabPage2.Controls.Add(this.txtCPosgrado);
            this.tabPage2.Controls.Add(this.txtCEmpleados);
            this.tabPage2.Controls.Add(this.txtCAlumnos);
            this.tabPage2.Controls.Add(this.btnInvitados);
            this.tabPage2.Controls.Add(this.btnCInivitados);
            this.tabPage2.Controls.Add(this.btnPosgrado);
            this.tabPage2.Controls.Add(this.btnEmpleados);
            this.tabPage2.Controls.Add(this.btnCPosgrado);
            this.tabPage2.Controls.Add(this.btnCEmpleados);
            this.tabPage2.Controls.Add(this.btnAlumnos);
            this.tabPage2.Controls.Add(this.btnCAlumnos);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(860, 826);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "carga de datos";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // txtCInvitados
            // 
            this.txtCInvitados.AutoSize = true;
            this.txtCInvitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCInvitados.Location = new System.Drawing.Point(315, 264);
            this.txtCInvitados.Name = "txtCInvitados";
            this.txtCInvitados.Size = new System.Drawing.Size(0, 16);
            this.txtCInvitados.TabIndex = 13;
            // 
            // txtCPosgrado
            // 
            this.txtCPosgrado.AutoSize = true;
            this.txtCPosgrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPosgrado.Location = new System.Drawing.Point(315, 218);
            this.txtCPosgrado.Name = "txtCPosgrado";
            this.txtCPosgrado.Size = new System.Drawing.Size(0, 16);
            this.txtCPosgrado.TabIndex = 13;
            // 
            // txtCEmpleados
            // 
            this.txtCEmpleados.AutoSize = true;
            this.txtCEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCEmpleados.Location = new System.Drawing.Point(315, 168);
            this.txtCEmpleados.Name = "txtCEmpleados";
            this.txtCEmpleados.Size = new System.Drawing.Size(0, 16);
            this.txtCEmpleados.TabIndex = 13;
            // 
            // txtCAlumnos
            // 
            this.txtCAlumnos.AutoSize = true;
            this.txtCAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCAlumnos.Location = new System.Drawing.Point(315, 118);
            this.txtCAlumnos.Name = "txtCAlumnos";
            this.txtCAlumnos.Size = new System.Drawing.Size(0, 16);
            this.txtCAlumnos.TabIndex = 12;
            // 
            // btnInvitados
            // 
            this.btnInvitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvitados.Location = new System.Drawing.Point(682, 259);
            this.btnInvitados.Name = "btnInvitados";
            this.btnInvitados.Size = new System.Drawing.Size(129, 28);
            this.btnInvitados.TabIndex = 11;
            this.btnInvitados.Text = "Importar";
            this.btnInvitados.UseVisualStyleBackColor = true;
            this.btnInvitados.Click += new System.EventHandler(this.btnInvitados_Click);
            // 
            // btnCInivitados
            // 
            this.btnCInivitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCInivitados.Location = new System.Drawing.Point(47, 259);
            this.btnCInivitados.Name = "btnCInivitados";
            this.btnCInivitados.Size = new System.Drawing.Size(234, 28);
            this.btnCInivitados.TabIndex = 10;
            this.btnCInivitados.Text = "Cargar archivo invitados";
            this.btnCInivitados.UseVisualStyleBackColor = true;
            this.btnCInivitados.Click += new System.EventHandler(this.btnCInivitados_Click);
            // 
            // btnPosgrado
            // 
            this.btnPosgrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosgrado.Location = new System.Drawing.Point(682, 213);
            this.btnPosgrado.Name = "btnPosgrado";
            this.btnPosgrado.Size = new System.Drawing.Size(129, 28);
            this.btnPosgrado.TabIndex = 9;
            this.btnPosgrado.Text = "Importar";
            this.btnPosgrado.UseVisualStyleBackColor = true;
            this.btnPosgrado.Click += new System.EventHandler(this.btnPosgrado_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleados.Location = new System.Drawing.Point(682, 163);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(129, 28);
            this.btnEmpleados.TabIndex = 7;
            this.btnEmpleados.Text = "Importar";
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnCPosgrado
            // 
            this.btnCPosgrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCPosgrado.Location = new System.Drawing.Point(47, 213);
            this.btnCPosgrado.Name = "btnCPosgrado";
            this.btnCPosgrado.Size = new System.Drawing.Size(234, 28);
            this.btnCPosgrado.TabIndex = 6;
            this.btnCPosgrado.Text = "Cargar archivo posgrado";
            this.btnCPosgrado.UseVisualStyleBackColor = true;
            this.btnCPosgrado.Click += new System.EventHandler(this.btnCPosgrado_Click);
            // 
            // btnCEmpleados
            // 
            this.btnCEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCEmpleados.Location = new System.Drawing.Point(47, 163);
            this.btnCEmpleados.Name = "btnCEmpleados";
            this.btnCEmpleados.Size = new System.Drawing.Size(234, 28);
            this.btnCEmpleados.TabIndex = 4;
            this.btnCEmpleados.Text = "Cargar archivo empleados";
            this.btnCEmpleados.UseVisualStyleBackColor = true;
            this.btnCEmpleados.Click += new System.EventHandler(this.btnCEmpleados_Click);
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnos.Location = new System.Drawing.Point(682, 113);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Size = new System.Drawing.Size(129, 28);
            this.btnAlumnos.TabIndex = 2;
            this.btnAlumnos.Text = "Importar";
            this.btnAlumnos.UseVisualStyleBackColor = true;
            this.btnAlumnos.Click += new System.EventHandler(this.btnAlumnos_Click_1);
            // 
            // btnCAlumnos
            // 
            this.btnCAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCAlumnos.Location = new System.Drawing.Point(47, 113);
            this.btnCAlumnos.Name = "btnCAlumnos";
            this.btnCAlumnos.Size = new System.Drawing.Size(234, 28);
            this.btnCAlumnos.TabIndex = 0;
            this.btnCAlumnos.Text = "Cargar archivo alumnos";
            this.btnCAlumnos.UseVisualStyleBackColor = true;
            this.btnCAlumnos.Click += new System.EventHandler(this.btnCAlumnos_Click);
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM3";
            this.serialPort2.ReadTimeout = 1000;
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived);
            // 
            // serialPort3
            // 
            this.serialPort3.BaudRate = 19200;
            this.serialPort3.PortName = "COM4";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(866, 750);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Sistema de Biblioteca";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_arrow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dataGridReporte.ResumeLayout(false);
            this.dataGridReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Panel imgFCFM;
        private System.Windows.Forms.Panel imgUANL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label txtRecibidos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.TabPage dataGridReporte;
        private System.IO.Ports.SerialPort serialPort2;
        private System.IO.Ports.SerialPort serialPort3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtCarrera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dPHasta;
        private System.Windows.Forms.DateTimePicker dPDe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridReportes;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.ComboBox ddlSemestre;
        private System.Windows.Forms.ComboBox ddlCarrera;
        private System.Windows.Forms.RadioButton rbCarrera;
        private System.Windows.Forms.RadioButton rbSemestre;
        private System.Windows.Forms.RadioButton rbGeneral;
        private System.Windows.Forms.ComboBox ddlReportes;
        private System.Windows.Forms.RadioButton rbCarreraPosgrado;
        private System.Windows.Forms.Label lblCarreraPosgrado;
        private System.Windows.Forms.ComboBox ddlCarreraPosgrado;
        private System.Windows.Forms.RadioButton rbGeneralPosgrado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCAlumnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAlumnos;
        private System.Windows.Forms.Button btnCEmpleados;
        private System.Windows.Forms.Button btnCInivitados;
        private System.Windows.Forms.Button btnPosgrado;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnCPosgrado;
        private System.Windows.Forms.Button btnInvitados;
        private System.Windows.Forms.Label txtCInvitados;
        private System.Windows.Forms.Label txtCPosgrado;
        private System.Windows.Forms.Label txtCEmpleados;
        private System.Windows.Forms.Label txtCAlumnos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_alum;
        private System.Windows.Forms.ComboBox all_years;
        private System.Windows.Forms.ComboBox all_mes;
        private System.Windows.Forms.PictureBox img_arrow;
        private System.Windows.Forms.Button repor_gen;
    }
}

