using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.OleDb;
using System.Diagnostics;
using System.Threading;

namespace Biblioteca2
{
    public partial class frmPrincipal : Form
    {
        public bool limpiame=false;
        public int segundo = 0;
        //public Stopwatch stopWatch = new Stopwatch();

        System.Data.DataTable dataAlumnos = new System.Data.DataTable();
        System.Data.DataTable dataEmpleados = new System.Data.DataTable();
        System.Data.DataTable dataPosgrado = new System.Data.DataTable();
        System.Data.DataTable dataInvitados = new System.Data.DataTable();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-58DQ63D;Initial Catalog=Biblioteca;Integrated Security=True");

        public int tipoCuenta;
        public int getTipoCuenta()
        {
            return tipoCuenta;
        }

        public frmPrincipal()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            alternarcoloresdata(dataGridReportes);
            if (tipoCuenta == 1)
            {
                tabControl1.TabPages.Remove(dataGridReporte);
                tabControl1.TabPages.Remove(tabPage2);
            }

            string[] ports = SerialPort.GetPortNames();
 
            serialPort2.PortName = "COM4";
            

            try
            {
                serialPort2.Open();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecciones otro puerto", "Puerto no disponible");
            }
            this.ActiveControl = txtCod;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort2.Close();
        }

        private void enviarDatos(string acceso)
        {
            using (SerialPort port = new SerialPort("COM3", 19200, Parity.None, 8, StopBits.One))
            {
                if (!port.IsOpen)
                {
                    port.Open();
                    port.Write(acceso);
                    //MessageBox.Show("Reading");
                    //MessageBox.Show(port.ReadExisting());
                }
                else
                {
                    port.Write(acceso);
                }
            }
            //serialPort3.Write(acceso);
        }

        private System.Data.DataTable reporteGeneral()
        {
            string command = "SELECT usuarios.nombre,  usuarios.codigo, tipoUsuario.descripcion, usuarios.carrera, usuarios.semestre,r.fechaEntrada, r.horaEntrada, r.idUsuario FROM registro r INNER JOIN usuarios  on r.idUsuario = usuarios.idUsuarios INNER JOIN tipoUsuario on usuarios.idTipoUsuario = tipoUsuario.idTipoUsuario WHERE (r.fechaEntrada >= @dpDe AND r.fechaEntrada <= @dpHasta) ";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@dpDe", dPDe.Value);
            cmd.Parameters.AddWithValue("@dpHasta", dPHasta.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);
            return dt;
        }


        private System.Data.DataTable reporte_genero(string filtro)
        {
            string command = "SELECT id, carrera, mujer, hombre, total, anio FROM dbo.carreras_genero WHERE id > 0 " + filtro;
            var cmd = new SqlCommand(command, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            return dt;
        }

        private void repor_gen_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string anio = "" + all_years.SelectedItem;
            string hacer_filtro = "";

            if (all_years.SelectedIndex > 0)
            {
                hacer_filtro = "AND anio = " + all_years.SelectedItem;
            }

            dt = reporte_genero(hacer_filtro);
            dataGridReportes.DataSource = dt;
            exportarPDF_genero(dataGridReportes, anio);
            exportarExcel(dataGridReportes,false);
            MessageBox.Show("Reporte generado");
        }


        private void exportarPDF_genero(DataGridView tabla, string anio) 
        {
            DateTime thisDay = DateTime.Today;
            int indiceCol = 0;

            foreach (DataGridViewColumn col in tabla.Columns)
            {
                indiceCol++;
            }

            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\claua\Desktop\reportesAccesobiblioteca\Reporte_entradas_genero_" + anio + ".pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Reporte genero");
            doc.AddCreator("Biblioteca FCFM");

            // Abrimos el archivo
            doc.Open();
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Creamos la imagen y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Users\claua\Desktop\Biblioteca3_V2\Biblioteca2\Biblioteca2\Resources\fcfm_logo.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_RIGHT;

            imagen.SetAbsolutePosition(470, 710);
            float percentage = 0.0f;
            percentage = 100 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            // Insertamos la imagen en el documento
            doc.Add(imagen);

            // Creamos la imagen y le ajustamos el tamaño
            imagen = iTextSharp.text.Image.GetInstance(@"C:\Users\claua\Desktop\Biblioteca3_V2\Biblioteca2\Biblioteca2\Resources\uanl_logo.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            imagen.SetAbsolutePosition(50, 710);
            percentage = 0.0f;
            percentage = 100 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            // Insertamos la imagen en el documento
            doc.Add(imagen);
            Paragraph titulo_uni = new Paragraph("FACULTAD DE CIENCIAS FÍSICO MATEMÁTICAS");
            titulo_uni.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo_uni);

            // Escribimos el encabezamiento en el documento
            Paragraph saltoDeLinea = new Paragraph("\n");
            doc.Add(saltoDeLinea);
            doc.Add(saltoDeLinea);
            doc.Add(saltoDeLinea);
            doc.Add(new Paragraph("Reporte de entradas a Biblioteca por genero              Fecha de creación:" + thisDay.ToString("g")));
            doc.Add(new Paragraph("________________________________________________________________________________"));


            doc.Add(new Paragraph("ACCESOS DEL AÑO: " + anio));
            doc.Add(saltoDeLinea);
            doc.Add(saltoDeLinea);
            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(indiceCol);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clid = new PdfPCell(new Phrase("ID", _standardFont));
            clid.BorderWidth = 0;
            clid.BorderWidthBottom = 0.100f;

            PdfPCell clcarrera = new PdfPCell(new Phrase("CARRERA", _standardFont));
            clcarrera.BorderWidth = 0;
            clcarrera.BorderWidthBottom = 0.100f;

            PdfPCell clmujer = new PdfPCell(new Phrase("MUJERES", _standardFont));
            clmujer.BorderWidth = 0;
            clmujer.BorderWidthBottom = 0.100f;

            PdfPCell clhombre = new PdfPCell(new Phrase("HOMBRES", _standardFont));
            clhombre.BorderWidth = 0;
            clhombre.BorderWidthBottom = 0.100f;

            PdfPCell cltotal = new PdfPCell(new Phrase("TOTAL", _standardFont));
            cltotal.BorderWidth = 0;
            cltotal.BorderWidthBottom = 0.100f;

            PdfPCell clanio = new PdfPCell(new Phrase("AÑO", _standardFont));
            clanio.BorderWidth = 0;
            clanio.BorderWidthBottom = 0.100f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clid);
            tblPrueba.AddCell(clcarrera);
            tblPrueba.AddCell(clmujer);
            tblPrueba.AddCell(clhombre);
            tblPrueba.AddCell(cltotal);
            tblPrueba.AddCell(clanio);

            PdfPCell celda_vacia = new PdfPCell(new Phrase(" ", _standardFont));
            celda_vacia.BorderWidth = 0;
            PdfPCell celda_num = new PdfPCell(new Phrase(" ", _standardFont));
            celda_num.BorderWidth = 0;


            foreach (DataGridViewRow row in tabla.Rows)
            {
                clid = new PdfPCell(new Phrase(row.Cells[0].Value.ToString(), _standardFont));
                clid.BorderWidth = 0;

                clcarrera = new PdfPCell(new Phrase(row.Cells[1].Value.ToString(), _standardFont));
                clcarrera.BorderWidth = 0;

                clmujer = new PdfPCell(new Phrase(row.Cells[2].Value.ToString(), _standardFont));
                clmujer.BorderWidth = 0;

                clhombre = new PdfPCell(new Phrase(row.Cells[3].Value.ToString(), _standardFont));
                clhombre.BorderWidth = 0;

                cltotal = new PdfPCell(new Phrase(row.Cells[4].Value.ToString(), _standardFont));
                cltotal.BorderWidth = 0;

                clanio = new PdfPCell(new Phrase(row.Cells[5].Value.ToString(), _standardFont));
                clanio.BorderWidth = 0;

                tblPrueba.AddCell(clid);
                tblPrueba.AddCell(clcarrera);
                tblPrueba.AddCell(clmujer);
                tblPrueba.AddCell(clhombre);
                tblPrueba.AddCell(cltotal);
                tblPrueba.AddCell(clanio);

            }

            doc.Add(tblPrueba);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("________________________________________________________________________________"));

            doc.Close();
            writer.Close();
        }


        private System.Data.DataTable reporteAlumnosPorSemestre()
        {
            string command = "";
            command = "SELECT usuarios.nombre, usuarios.codigo, tipoUsuario.descripcion, usuarios.carrera, usuarios.semestre,r.fechaEntrada, r.horaEntrada, r.idUsuario FROM registro r INNER JOIN usuarios  on r.idUsuario = usuarios.idUsuarios INNER JOIN tipoUsuario on usuarios.idTipoUsuario = tipoUsuario.idTipoUsuario WHERE (r.fechaEntrada >= @dpDe AND r.fechaEntrada <= @dpHasta AND tipoUsuario.idTipoUsuario = 1 AND usuarios.semestre = @semestre) ";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@dpDe", dPDe.Value);
            cmd.Parameters.AddWithValue("@dpHasta", dPHasta.Value);
            cmd.Parameters.AddWithValue("@semestre", ddlSemestre.SelectedItem);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);
            return dt;
        }

        private System.Data.DataTable reporteAlumnosPorCarrera()
        {
            string command = "";
            command = "SELECT usuarios.nombre, usuarios.codigo, tipoUsuario.descripcion, usuarios.carrera, usuarios.semestre,r.fechaEntrada, r.horaEntrada, r.idUsuario FROM registro r INNER JOIN usuarios  on r.idUsuario = usuarios.idUsuarios INNER JOIN tipoUsuario on usuarios.idTipoUsuario = tipoUsuario.idTipoUsuario WHERE (r.fechaEntrada >= @dpDe AND r.fechaEntrada <= @dpHasta AND tipoUsuario.idTipoUsuario = 1 AND usuarios.carrera = @carrera) ";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@dpDe", dPDe.Value);
            cmd.Parameters.AddWithValue("@dpHasta", dPHasta.Value);
            cmd.Parameters.AddWithValue("@carrera", ddlCarrera.SelectedItem);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);
            return dt;
        }

        private System.Data.DataTable reporteAlumnosGeneral()
        {
            string command = "";
            command = "SELECT usuarios.nombre, usuarios.codigo, tipoUsuario.descripcion, usuarios.carrera, usuarios.semestre,r.fechaEntrada, r.horaEntrada, r.idUsuario FROM registro r INNER JOIN usuarios  on r.idUsuario = usuarios.idUsuarios INNER JOIN tipoUsuario on usuarios.idTipoUsuario = tipoUsuario.idTipoUsuario WHERE (r.fechaEntrada >= @dpDe AND r.fechaEntrada <= @dpHasta AND usuarios.idTipoUsuario = 1 ) ";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@dpDe", dPDe.Value);
            cmd.Parameters.AddWithValue("@dpHasta", dPHasta.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);

            return dt;
        }

        private System.Data.DataTable reporteDocentesGeneral()
        {
            string command = "";
            command = "SELECT usuarios.nombre, usuarios.codigo, tipoUsuario.descripcion, usuarios.carrera, usuarios.semestre,r.fechaEntrada, r.horaEntrada, r.idUsuario FROM registro r INNER JOIN usuarios  on r.idUsuario = usuarios.idUsuarios INNER JOIN tipoUsuario on usuarios.idTipoUsuario = tipoUsuario.idTipoUsuario WHERE (r.fechaEntrada >= @dpDe AND r.fechaEntrada <= @dpHasta AND tipoUsuario.idTipoUsuario = 2 ) ";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@dpDe", dPDe.Value);
            cmd.Parameters.AddWithValue("@dpHasta", dPHasta.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);

            return dt;
        }

        private System.Data.DataTable reportePosgradoPorCarrera()
        {
            string command = "";
            command = "SELECT usuarios.nombre, usuarios.codigo, tipoUsuario.descripcion, usuarios.carrera, usuarios.semestre,r.fechaEntrada, r.horaEntrada, r.idUsuario FROM registro r INNER JOIN usuarios  on r.idUsuario = usuarios.idUsuarios INNER JOIN tipoUsuario on usuarios.idTipoUsuario = tipoUsuario.idTipoUsuario WHERE (r.fechaEntrada >= @dpDe AND r.fechaEntrada <= @dpHasta AND tipoUsuario.idTipoUsuario = 3  AND usuarios.carrera = @carrera) ";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@dpDe", dPDe.Value);
            cmd.Parameters.AddWithValue("@dpHasta", dPHasta.Value);
            cmd.Parameters.AddWithValue("@carrera", ddlCarreraPosgrado.SelectedItem);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);

            return dt;
        }

        private System.Data.DataTable reportePosgradoGeneral()
        {
            string command = "";
            command = "SELECT usuarios.nombre, usuarios.codigo, tipoUsuario.descripcion, usuarios.carrera, usuarios.semestre,r.fechaEntrada, r.horaEntrada, r.idUsuario FROM registro r INNER JOIN usuarios  on r.idUsuario = usuarios.idUsuarios INNER JOIN tipoUsuario on usuarios.idTipoUsuario = tipoUsuario.idTipoUsuario WHERE (r.fechaEntrada >= @dpDe AND r.fechaEntrada <= @dpHasta AND tipoUsuario.idTipoUsuario = 3 ) ";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@dpDe", dPDe.Value);
            cmd.Parameters.AddWithValue("@dpHasta", dPHasta.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);

            return dt;
        }

        private System.Data.DataTable reporteAdministrativosGeneral()
        {
            string command = "";
            command = "SELECT usuarios.nombre, usuarios.codigo, tipoUsuario.descripcion, usuarios.carrera, usuarios.semestre,r.fechaEntrada, r.horaEntrada, r.idUsuario FROM registro r INNER JOIN usuarios  on r.idUsuario = usuarios.idUsuarios INNER JOIN tipoUsuario on usuarios.idTipoUsuario = tipoUsuario.idTipoUsuario WHERE (r.fechaEntrada >= @dpDe AND r.fechaEntrada <= @dpHasta AND tipoUsuario.idTipoUsuario = 4 ) ";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@dpDe", dPDe.Value);
            cmd.Parameters.AddWithValue("@dpHasta", dPHasta.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);

            return dt;
        }

        private System.Data.DataTable reporteInvitadosGeneral()
        {
            string command = "";
            command = "SELECT usuarios.nombre, usuarios.codigo, tipoUsuario.descripcion, usuarios.carrera, usuarios.semestre,r.fechaEntrada, r.horaEntrada, r.idUsuario FROM registro r INNER JOIN usuarios  on r.idUsuario = usuarios.idUsuarios INNER JOIN tipoUsuario on usuarios.idTipoUsuario = tipoUsuario.idTipoUsuario WHERE (r.fechaEntrada >= @dpDe AND r.fechaEntrada <= @dpHasta AND tipoUsuario.idTipoUsuario = 5 ) ";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@dpDe", dPDe.Value);
            cmd.Parameters.AddWithValue("@dpHasta", dPHasta.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);

            return dt;
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            switch (ddlReportes.SelectedIndex)
            {
                case 0: dt = reporteGeneral();
                    break;
                case 1: if (rbGeneral.Checked == true)
                    {
                        dt = reporteAlumnosGeneral();
                    }
                    else if (rbCarrera.Checked == true)
                    {
                        dt = reporteAlumnosPorCarrera();
                    }
                    else if (rbSemestre.Checked == true)
                    {
                        dt = reporteAlumnosPorSemestre();
                    }
                    break;
                case 2: dt = reporteDocentesGeneral();
                    break;
                case 3: if (rbGeneralPosgrado.Checked == true)
                    {
                        dt = reportePosgradoGeneral();
                    }
                    else if (rbCarreraPosgrado.Checked == true)
                    {
                        dt = reportePosgradoPorCarrera();
                    }
                    break;
                case 4:
                    dt = reporteAdministrativosGeneral();
                    break;
                case 5: dt = reporteInvitadosGeneral();
                    break;
            }



            dataGridReportes.DataSource = dt;

        }

        /*Reporte para */
        private void btn_alum_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string anio_n = "" + all_years.SelectedItem;
            string mes = "" + all_mes.SelectedItem;
            string hacer_filtro = "";

            if(all_years.SelectedIndex > 0) {
              
                hacer_filtro = "AND anio = " + all_years.SelectedItem;
            }

            if(all_mes.SelectedIndex >= 0){
                if (all_mes.SelectedIndex == 0)
                {
                    
                }
                else {
                    hacer_filtro = hacer_filtro + " AND mes = " + all_mes.SelectedIndex;
                }
                
            }


            dt = reporte_por_carrera(hacer_filtro);

            dataGridReportes.DataSource = dt;

            exportarPDF_alumnos(dataGridReportes, anio_n, mes);
            exportarExcel(dataGridReportes,false);
            MessageBox.Show("Reporte generado");
        }

        private System.Data.DataTable reporte_por_carrera(string filtro_reporte)
        {
            string command = "";
            command = "SELECT anio AS AÑO, MES = CASE mes WHEN 1 THEN 'ENERO' WHEN 2 THEN 'FEBRERO' WHEN 3 THEN 'MARZO' WHEN 4 THEN 'ABRIL' WHEN 5 THEN 'MAYO' WHEN 6 THEN 'JUNIO' WHEN 7 THEN 'JULIO' WHEN 8 THEN 'AGOSTO' WHEN 9 THEN 'SEPTIEMBRE' WHEN 10 THEN 'OCTUBRE' WHEN 11 THEN 'NOVIEMBRE' WHEN 12 THEN 'DICIEMBRE' END, lcc AS LCC, lmad AS LMAD, la AS LA, lf AS LF, lsti AS LSTI, lm AS LM FROM entras_carrera WHERE id > 1 " + filtro_reporte;
            var cmd = new SqlCommand(command, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);
            return dt;   
        }

        private System.Data.DataTable carga(int idUsuario)
        {
            string command = "SELECT u.idUsuarios, u.semestre FROM usuarios u WHERE u.idUsuarios = @idUsuario";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            System.Data.DataTable dt = new System.Data.DataTable();


            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            conn.Open();

            adapt.Fill(dt);
            conn.Close();


            return dt;
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dtReportes = reporteAlumnosGeneral();

            int[] arraySemestres = new int[10];

            for (int i = 0; i < dtReportes.Rows.Count; i++)
            {
                System.Data.DataTable dtUsuario = carga(Convert.ToInt32(dtReportes.Rows[i]["idUsuario"]));
                if (dtUsuario.Rows[0]["semestre"].ToString() != "")
                {
                    arraySemestres[Convert.ToInt32(dtUsuario.Rows[0]["semestre"])]++;
                }

            }


        }

        public void alternarcoloresdata(DataGridView tabla) {
            tabla.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

        }

        private void ddlReportes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (ddlReportes.SelectedIndex == 1)
            {
                rbCarrera.Visible = true;
                rbGeneral.Visible = true;
                rbSemestre.Visible = true;
            }
            else if (ddlReportes.SelectedIndex == 3)
            {
                rbCarreraPosgrado.Visible = true;
                rbGeneralPosgrado.Visible = true;


                rbCarrera.Visible = false;
                rbGeneral.Visible = false;
                rbSemestre.Visible = false;
                rbCarrera.Checked = false;
                rbSemestre.Checked = false;
            }
            else
            {
                rbCarrera.Visible = false;
                rbGeneral.Visible = false;
                rbSemestre.Visible = false;
                rbCarrera.Checked = false;
                rbSemestre.Checked = false;
                rbCarreraPosgrado.Visible = false;
                rbGeneralPosgrado.Visible = false;
                rbCarreraPosgrado.Checked = false;

            }
        }

        private void rbCarrera_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCarrera.Checked == true)
            {
                lblCarrera.Visible = true;
                ddlCarrera.Visible = true;
            }
            else if (rbCarrera.Checked == false)
            {
                lblCarrera.Visible = false;
                ddlCarrera.Visible = false;
            }
        }

        private void rbSemestre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSemestre.Checked == true)
            {
                lblSemestre.Visible = true;
                ddlSemestre.Visible = true;
            }
            else if (rbSemestre.Checked == false)
            {
                lblSemestre.Visible = false;
                ddlSemestre.Visible = false;
            }
        }

        private void rbCarreraPosgrado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCarreraPosgrado.Checked == true)
            {
                lblCarreraPosgrado.Visible = true;
                ddlCarreraPosgrado.Visible = true;
            }
            else if (rbCarreraPosgrado.Checked == false)
            {
                lblCarreraPosgrado.Visible = false;
                ddlCarreraPosgrado.Visible = false;
            }
        }

        private void compararCodigo(string codigo)
        {
            lblError.Text = "";
            txtFecha.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCarrera.Text = "";
            string command = "SELECT u.codigo, u.idUsuarios, u.nombre, u.carrera FROM usuarios u where u.codigo = @codigo and u.esBaja = 'false'";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            System.Data.DataTable dt = new System.Data.DataTable();
            

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            conn.Open();

            adapt.Fill(dt);
            conn.Close();

            // Data is accessible through the DataReader object here.
            if (dt.Rows.Count == 0)
            {
                //enviarDatos("N");
                lblError.Text = "Código no válido, favor de ingresar otro.";
            }
            else
            {
                enviarDatos("Y");
                guardarRegistro((dt.Rows[0]["idUsuarios"].ToString()));
                txtCodigo.Text = dt.Rows[0]["codigo"].ToString();
                txtNombre.Text = dt.Rows[0]["nombre"].ToString();
                txtCarrera.Text = dt.Rows[0]["carrera"].ToString();
                string horaEntrada = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                DateTime fechaEntrada = DateTime.Today;
                txtFecha.Text = fechaEntrada.Day + "/" + fechaEntrada.Month + "/" + fechaEntrada.Year + "  " + horaEntrada;
                System.Threading.Thread.Sleep(3500);
                this.tabPage1.BackColor = Color.LimeGreen;
                img_arrow.Visible = true;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtCod.Text = dt.Rows[i]["codigo"].ToString();
            }

            txtCod.Text = "";
            this.ActiveControl = txtCod;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
            string datorx = serialPort1.ReadExisting();
            txtCod.Text = datorx.Trim();
            compararCodigo(txtCod.Text);
        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            string datorx = serialPort2.ReadExisting();
            txtCod.Text = datorx.Trim();
            compararCodigo(txtCod.Text);
            
        }

        private void guardarRegistro(string idUsuario)
        {

            string horaEntrada = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            DateTime fechaEntrada = DateTime.Today;
            string command = "INSERT INTO registro (idUsuario, fechaEntrada, horaEntrada) VALUES(@idUsuario, @fechaEntrada, @horaEntrada)";
            var cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@fechaEntrada", fechaEntrada);
            cmd.Parameters.AddWithValue("@horaEntrada", horaEntrada);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridReportes.Rows.Count != 0)
            {
                exportarExcel(dataGridReportes,true);
            }
            else
            {
                MessageBox.Show("No hay registro para mostrar en el Excel");
            }
        }

        private void exportarExcel(DataGridView tabla, bool veri)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);

            int indiceCol = 0;

            foreach (DataGridViewColumn col in tabla.Columns)
            {
                indiceCol++;
                excel.Cells[1, indiceCol] = col.Name;

            }

            int indiceFila = 0;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                indiceFila++;
                indiceCol = 0;
                DateTime date = new DateTime();
                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    indiceCol++;
                    if (veri)
                    {
                        if (indiceCol == 6)
                        {
                            date = Convert.ToDateTime(row.Cells[col.Name].Value);
                            excel.Cells[indiceFila + 1, indiceCol] = date.ToString("dd-MMM-yyyy");
                        }
                        else
                        {
                            excel.Cells[indiceFila + 1, indiceCol] = row.Cells[col.Name].Value.ToString();
                        }
                    }
                    else 
                        excel.Cells[indiceFila + 1, indiceCol] = row.Cells[col.Name].Value.ToString();
                    
                    
                }
            }
            excel.Cells[indiceFila + 2, indiceCol - 1] = "Total";
            excel.Cells[indiceFila + 2, indiceCol] = indiceFila;

            excel.Visible = true;
        }

        private void exportarPDF_alumnos(DataGridView tabla, string anio, string mes)
        {
            DateTime thisDay = DateTime.Today;
            int indiceCol = 0;
            int cortar_anio = 0;

            foreach (DataGridViewColumn col in tabla.Columns)
            {
                indiceCol++;
            }

            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\claua\Desktop\reportesAccesobiblioteca\Reporte_entradas_" + anio + "_"+ mes +".pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Reporte");
            doc.AddCreator("Biblioteca FCFM");

            // Abrimos el archivo
            doc.Open();
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Creamos la imagen y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Users\claua\Desktop\Biblioteca3_V2\Biblioteca2\Biblioteca2\Resources\fcfm_logo.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_RIGHT;

            imagen.SetAbsolutePosition(470, 710);
            float percentage = 0.0f;
            percentage = 100 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            // Insertamos la imagen en el documento
            doc.Add(imagen);

            // Creamos la imagen y le ajustamos el tamaño
            imagen = iTextSharp.text.Image.GetInstance(@"C:\Users\claua\Desktop\Biblioteca3_V2\Biblioteca2\Biblioteca2\Resources\uanl_logo.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            imagen.SetAbsolutePosition(50, 710);       
            percentage = 0.0f;
            percentage = 100 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            // Insertamos la imagen en el documento
            doc.Add(imagen);
            Paragraph titulo_uni = new Paragraph("FACULTAD DE CIENCIAS FÍSICO MATEMÁTICAS");
            titulo_uni.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo_uni);

            // Escribimos el encabezamiento en el documento
            Paragraph saltoDeLinea = new Paragraph("\n");
            doc.Add(saltoDeLinea);
            doc.Add(saltoDeLinea);
            doc.Add(saltoDeLinea);
            doc.Add(new Paragraph("Reporte de entradas a Biblioteca por carrera               Fecha de creación:" + thisDay.ToString("g")));
            doc.Add(new Paragraph("________________________________________________________________________________"));


            doc.Add(new Paragraph("ACCESOS DEL AÑO: " + anio + " MES: " + mes));
            doc.Add(saltoDeLinea);
            doc.Add(saltoDeLinea);
            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(indiceCol);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla

            PdfPCell clanio = new PdfPCell(new Phrase("AÑO", _standardFont));
            clanio.BorderWidth = 0;
            clanio.BorderWidthBottom = 0.100f;

            PdfPCell clmes = new PdfPCell(new Phrase("MES", _standardFont));
            clmes.BorderWidth = 0;
            clmes.BorderWidthBottom = 0.100f;

            PdfPCell cllcc = new PdfPCell(new Phrase("LCC", _standardFont));
            cllcc.BorderWidth = 0;
            cllcc.BorderWidthBottom = 0.100f;

            PdfPCell cllmad = new PdfPCell(new Phrase("LMAD", _standardFont));
            cllmad.BorderWidth = 0;
            cllmad.BorderWidthBottom = 0.100f;

            PdfPCell clla = new PdfPCell(new Phrase("LA", _standardFont));
            clla.BorderWidth = 0;
            clla.BorderWidthBottom = 0.100f;

            PdfPCell cllf = new PdfPCell(new Phrase("LF", _standardFont));
            cllf.BorderWidth = 0;
            cllf.BorderWidthBottom = 0.100f;

            PdfPCell cllsti = new PdfPCell(new Phrase("LSTI", _standardFont));
            cllsti.BorderWidth = 0;
            cllsti.BorderWidthBottom = 0.100f;

            PdfPCell cllm = new PdfPCell(new Phrase("LM", _standardFont));
            cllm.BorderWidth = 0;
            cllm.BorderWidthBottom = 0.100f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clanio);
            tblPrueba.AddCell(clmes);
            tblPrueba.AddCell(cllcc);
            tblPrueba.AddCell(cllmad);

            tblPrueba.AddCell(clla);
            tblPrueba.AddCell(cllf);
            tblPrueba.AddCell(cllsti);
            tblPrueba.AddCell(cllm);

            PdfPCell celda_vacia = new PdfPCell(new Phrase(" ", _standardFont));
            celda_vacia.BorderWidth = 0;
            PdfPCell celda_num = new PdfPCell(new Phrase(" ", _standardFont));
            celda_num.BorderWidth = 0;
            // Llenamos la tabla con información
            int total_lcc = 0, total_lmad = 0, total_la = 0, total_lf = 0, total_lm = 0, total_lsti = 0;
            int total_lcc_a = 0, total_lmad_a = 0, total_la_a = 0, total_lf_a = 0, total_lm_a = 0, total_lsti_a = 0;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                cortar_anio = cortar_anio + 1;
                clanio = new PdfPCell(new Phrase(row.Cells[0].Value.ToString(), _standardFont));
                clanio.BorderWidth = 0;

                clmes = new PdfPCell(new Phrase(row.Cells[1].Value.ToString(), _standardFont));
                clmes.BorderWidth = 0;

                cllcc = new PdfPCell(new Phrase(row.Cells[2].Value.ToString(), _standardFont));
                cllcc.BorderWidth = 0;

                cllmad = new PdfPCell(new Phrase(row.Cells[3].Value.ToString(), _standardFont));
                cllmad.BorderWidth = 0;

                clla = new PdfPCell(new Phrase(row.Cells[4].Value.ToString(), _standardFont));
                clla.BorderWidth = 0;

                cllf = new PdfPCell(new Phrase(row.Cells[5].Value.ToString(), _standardFont));
                cllf.BorderWidth = 0;

                cllsti = new PdfPCell(new Phrase(row.Cells[6].Value.ToString(), _standardFont));
                cllsti.BorderWidth = 0;

                cllm = new PdfPCell(new Phrase(row.Cells[7].Value.ToString(), _standardFont));
                cllm.BorderWidth = 0;



                total_lcc = total_lcc + (int) row.Cells[2].Value;
                total_lmad = total_lmad + (int) row.Cells[3].Value;
                total_la = total_la + (int) row.Cells[4].Value;
                total_lf = total_lf + (int) row.Cells[5].Value;
                total_lm = total_lm + (int) row.Cells[6].Value;
                total_lsti = total_lsti + (int) row.Cells[7].Value;


                total_lcc_a = total_lcc_a + (int)row.Cells[2].Value;
                total_lmad_a = total_lmad_a + (int)row.Cells[3].Value;
                total_la_a = total_la_a + (int)row.Cells[4].Value;
                total_lf_a = total_lf_a + (int)row.Cells[5].Value;
                total_lm_a = total_lm_a + (int)row.Cells[6].Value;
                total_lsti_a = total_lsti_a + (int)row.Cells[7].Value;


                tblPrueba.AddCell(clanio);
                tblPrueba.AddCell(clmes);
                tblPrueba.AddCell(cllcc);
                tblPrueba.AddCell(cllmad);
                tblPrueba.AddCell(clla);
                tblPrueba.AddCell(cllf);
                tblPrueba.AddCell(cllsti);
                tblPrueba.AddCell(cllm);

                
                if (cortar_anio >= 12)
                {
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);

                    celda_num = new PdfPCell(new Phrase("Total año:", _standardFont));
                    celda_num.BorderWidth = 0;
                    tblPrueba.AddCell(celda_num);


                    celda_num = new PdfPCell(new Phrase(row.Cells[0].Value.ToString(), _standardFont));
                    celda_num.BorderWidth = 0;
                    tblPrueba.AddCell(celda_num);

                    celda_num = new PdfPCell(new Phrase("" + total_lcc, _standardFont));
                    celda_num.BorderWidth = 0;
                    tblPrueba.AddCell(celda_num);

                    celda_num = new PdfPCell(new Phrase("" + total_lmad, _standardFont));
                    celda_num.BorderWidth = 0;
                    tblPrueba.AddCell(celda_num);


                    celda_num = new PdfPCell(new Phrase("" + total_la, _standardFont));
                    celda_num.BorderWidth = 0;
                    tblPrueba.AddCell(celda_num);


                    celda_num = new PdfPCell(new Phrase("" + total_lf, _standardFont));
                    celda_num.BorderWidth = 0;
                    tblPrueba.AddCell(celda_num);


                    celda_num = new PdfPCell(new Phrase("" + total_lm, _standardFont));
                    celda_num.BorderWidth = 0;
                    tblPrueba.AddCell(celda_num);


                    celda_num = new PdfPCell(new Phrase("" + total_lsti, _standardFont));
                    celda_num.BorderWidth = 0;
                    tblPrueba.AddCell(celda_num);

                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);
                    tblPrueba.AddCell(celda_vacia);

                    total_lcc = 0;
                    total_lmad = 0;
                    total_la = 0;
                    total_lf = 0;
                    total_lm = 0;
                    total_lsti = 0;
                    cortar_anio = 0;


                }
               

            }



            // Añadimos las celdas a la tabla

            doc.Add(tblPrueba);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("________________________________________________________________________________"));
            doc.Add(new Paragraph("Totales:                          " + total_lcc_a + "          " + total_lmad_a + "           " + total_la_a + "         " + total_lf_a + "           " + total_lm_a + "        " + total_lsti_a));

            doc.Close();
            writer.Close();


        }


        private void exportarPDF(DataGridView tabla)
        {

            int indiceCol = 0;

            foreach (DataGridViewColumn col in tabla.Columns)
            {
                indiceCol++;


            }

            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\claua\Desktop\reportesAccesobiblioteca\reporte.pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Reporte");
            doc.AddCreator("Biblioteca FCFM");

            // Abrimos el archivo
            doc.Open();
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Reporte de entradas a Biblioteca"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(indiceCol - 1);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla



            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clCodigo = new PdfPCell(new Phrase("Código", _standardFont));
            clCodigo.BorderWidth = 0;
            clCodigo.BorderWidthBottom = 0.75f;

            PdfPCell clDescripcion = new PdfPCell(new Phrase("Descripción", _standardFont));
            clDescripcion.BorderWidth = 0;
            clDescripcion.BorderWidthBottom = 0.75f;

            PdfPCell clCarrera = new PdfPCell(new Phrase("Carrera", _standardFont));
            clCarrera.BorderWidth = 0;
            clCarrera.BorderWidthBottom = 0.75f;

            PdfPCell clSemestre = new PdfPCell(new Phrase("Semestre", _standardFont));
            clSemestre.BorderWidth = 0;
            clSemestre.BorderWidthBottom = 0.75f;

            PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", _standardFont));
            clFecha.BorderWidth = 0;
            clFecha.BorderWidthBottom = 0.75f;

            PdfPCell clHora = new PdfPCell(new Phrase("Hora", _standardFont));
            clHora.BorderWidth = 0;
            clHora.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clCodigo);
            tblPrueba.AddCell(clDescripcion);
            tblPrueba.AddCell(clCarrera);
            tblPrueba.AddCell(clSemestre);
            tblPrueba.AddCell(clFecha);
            tblPrueba.AddCell(clHora);

            // Llenamos la tabla con información
            string nombre;
            int total = 0;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                nombre = row.Cells[0].Value.ToString();
                clNombre = new PdfPCell(new Phrase(nombre, _standardFont));
                clNombre.BorderWidth = 0;

                clCodigo = new PdfPCell(new Phrase(row.Cells[1].Value.ToString(), _standardFont));
                clCodigo.BorderWidth = 0;

                clDescripcion = new PdfPCell(new Phrase(row.Cells[2].Value.ToString(), _standardFont));
                clDescripcion.BorderWidth = 0;

                clCarrera = new PdfPCell(new Phrase(row.Cells[3].Value.ToString(), _standardFont));
                clCarrera.BorderWidth = 0;

                clSemestre = new PdfPCell(new Phrase(row.Cells[4].Value.ToString(), _standardFont));
                clSemestre.BorderWidth = 0;

                clHora = new PdfPCell(new Phrase(row.Cells[6].Value.ToString(), _standardFont));
                clHora.BorderWidth = 0;


                DateTime fecha = Convert.ToDateTime(row.Cells[5].Value);
                clFecha = new PdfPCell(new Phrase(fecha.ToShortDateString(), _standardFont));
                clFecha.BorderWidth = 0;



                tblPrueba.AddCell(clNombre);
                tblPrueba.AddCell(clCodigo);
                tblPrueba.AddCell(clDescripcion);
                tblPrueba.AddCell(clCarrera);
                tblPrueba.AddCell(clSemestre);
                tblPrueba.AddCell(clFecha);
                tblPrueba.AddCell(clHora);
                total = total + 1;

            }



            // Añadimos las celdas a la tabla

            doc.Add(tblPrueba);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("Total: " + total));

            doc.Close();
            writer.Close();


        }

        private void btnPDF_Click_1(object sender, EventArgs e)
        {
            if (dataGridReportes.Rows.Count != 0)
            {
                exportarPDF(dataGridReportes);
                MessageBox.Show("PDF Creado Exitosamente");
            }
            else
            {
                MessageBox.Show("No hay registro para mostrar en el PDF");
            }

        }

        public System.Data.DataTable consultaAlumnos()
        {
            string command = "";
            command = "SELECT * FROM usuarios u WHERE u.idTipoUsuario = 1 ";
            var cmd = new SqlCommand(command, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);
            return dt;
        }

        public System.Data.DataTable consultaEmpleados()
        {
            string command = "";
            command = "SELECT * FROM usuarios u WHERE u.idTipoUsuario = 2 AND u.idTipoUsuario = 4 ";
            var cmd = new SqlCommand(command, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);
            return dt;
        }

        public System.Data.DataTable consultaPosgrado()
        {
            string command = "";
            command = "SELECT * FROM usuarios u WHERE u.idTipoUsuario = 3 ";
            var cmd = new SqlCommand(command, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);
            return dt;
        }

        public System.Data.DataTable consultaInvitado()
        {
            string command = "";
            command = "SELECT * FROM usuarios u WHERE u.idTipoUsuario = 5 ";
            var cmd = new SqlCommand(command, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);
            return dt;
        }

        public void actualizarEmpleados()
        {
            System.Data.DataTable dtExcel = dataEmpleados;
            System.Data.DataTable dtBD = consultaEmpleados();

            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {
                bool encontrado = false;
                for (int j = 0; j < dtBD.Rows.Count; j++)
                {
                    if (dtExcel.Rows[i]["NUMEMPLEADO"].ToString() == dtBD.Rows[j]["codigo"].ToString())
                    {
                        //Ejecutamos un Update por matricula en la BD
                        actualizarEmpleado(dtExcel, i);
                        encontrado = true;
                        j = dtBD.Rows.Count;

                    }

                }
                if (encontrado == false)
                {
                    //Ejecutamos un Insert del registro en la BD
                    insertarEmpleado(dtExcel, i);
                }
            }

            for (int i = 0; i < dtBD.Rows.Count; i++)
            {
                bool encontrado = false;
                for (int j = 0; j < dtExcel.Rows.Count; j++)
                {
                    if (dtBD.Rows[i]["codigo"].ToString() == dtExcel.Rows[j]["NUMEMPLEADO"].ToString())
                    {
                        encontrado = true;

                    }
                }
                if (encontrado == false)
                {
                    //Ejecutamos un Update que cambie el estado del usuario a de baja 
                    borrarEmpleado(dtBD, i);
                }
            }

        }

        public void actualizarPosgrados(){

            System.Data.DataTable dtExcel = dataPosgrado;
            System.Data.DataTable dtBD = consultaPosgrado();

            for (int i = 0; i < dtExcel.Rows.Count; i++){
                bool encontrado = false;
                for (int j = 0; j < dtBD.Rows.Count; j++){
                    if (dtExcel.Rows[i]["MATRICULA"].ToString() == dtBD.Rows[j]["codigo"].ToString()){
                        //Ejecutamos un Update por matricula en la BD
                        actualizarPosgrado(dtExcel, i);
                        encontrado = true;
                        j = dtBD.Rows.Count;
                    }
                }
                if (encontrado == false){
                    //Ejecutamos un Insert del registro en la BD
                    insertarPosgrado(dtExcel, i);
                }
            }
            
            for (int i = 0; i < dtBD.Rows.Count; i++){
                bool encontrado = false;
                for (int j = 0; j < dtExcel.Rows.Count; j++){
                    if (dtExcel.Rows[j]["NUMEMPLEADO"].ToString() == dtBD.Rows[i]["codigo"].ToString()){
                        encontrado = true;
                    }
                }
                if (encontrado == false){
                    //Ejecutamos un Update que cambie el estado del usuario a de baja 
                    borrarPosgrado(dtBD, i);
                }
            }
        }

        public void actualizarAlumnos(){
            System.Data.DataTable dtExcel = dataAlumnos;
            System.Data.DataTable dtBD = consultaAlumnos();

            for (int i = 0; i < dtExcel.Rows.Count; i++){
                bool encontrado = false;
                for (int j = 0; j < dtBD.Rows.Count; j++){
                    if (dtExcel.Rows[i]["MATRICULA"].ToString() == dtBD.Rows[j]["codigo"].ToString()){
                        //Ejecutamos un Update por matricula en la BD
                        actualizarAlumno(dtExcel, i);
                        encontrado = true;
                        j = dtBD.Rows.Count;

                    }

                }
                if (encontrado == false)
                {
                    //Ejecutamos un Insert del registro en la BD
                    insertarAlunmno(dtExcel, i);
                }
            }

            for (int i = 0; i < dtBD.Rows.Count; i++)
            {
                bool encontrado = false;
                for (int j = 0; j < dtExcel.Rows.Count; j++)
                {
                    if (dtBD.Rows[i]["codigo"].ToString() == dtExcel.Rows[j]["MATRICULA"].ToString())
                    {
                        encontrado = true;

                    }
                }
                if (encontrado == false)
                {
                    //Ejecutamos un Update que cambie el estado del usuario a de baja 
                    borrarAlumno(dtBD, i);
                }
            }

        }

        public void actualizarAlumno(System.Data.DataTable dtExcel, int aux)
        {
            string command = "UPDATE  usuarios SET nombre = @nombre, codigo = @matricula, idTipoUsuario = @tipoUsuario, carrera = @carrera, semestre = @semestre, sexo = @genero  WHERE codigo = @matricula";
            var cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@matricula", dtExcel.Rows[aux]["MATRICULA"].ToString());
            cmd.Parameters.AddWithValue("@nombre", dtExcel.Rows[aux]["NOMBRE"].ToString());
            cmd.Parameters.AddWithValue("@carrera", dtExcel.Rows[aux]["CARR"].ToString());
            cmd.Parameters.AddWithValue("@semestre", dtExcel.Rows[aux]["SEMESTRE"].ToString());
            //cmd.Parameters.AddWithValue("@genero", dtExcel.Rows[aux]["GENERO"].ToString());
            cmd.Parameters.AddWithValue("@tipoUsuario", 1);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void actualizarPosgrado(System.Data.DataTable dtExcel, int aux)
        {
            string command = "UPDATE  usuarios SET nombre = @nombre, codigo = @matricula, idTipoUsuario = @tipoUsuario, carrera = @carrera WHERE codigo = @matricula";
            var cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@matricula", dtExcel.Rows[aux]["MATRICULA"].ToString());
            cmd.Parameters.AddWithValue("@nombre", dtExcel.Rows[aux]["NOMBRE"].ToString());
            cmd.Parameters.AddWithValue("@carrera", dtExcel.Rows[aux]["CARR"].ToString());
            cmd.Parameters.AddWithValue("@tipoUsuario", 3);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void actualizarEmpleado(System.Data.DataTable dtExcel, int aux)
        {
            string command = "UPDATE  usuarios SET nombre = @nombre, codigo = @numEmpleado, idTipoUsuario = @tipoUsuario WHERE codigo = @numEmpleado";
            var cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@numEmpleado", dtExcel.Rows[aux]["NUMEMPLEADO"].ToString());
            cmd.Parameters.AddWithValue("@nombre", dtExcel.Rows[aux]["NOMBRE"].ToString());
            cmd.Parameters.AddWithValue("@tipoUsuario", dtExcel.Rows[aux]["TIPOUSUARIO"].ToString());
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void borrarAlumno(System.Data.DataTable dtBD, int aux)
        {
            string command = "UPDATE  usuarios SET esBaja = 1 WHERE codigo = @matricula";
            var cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@matricula", dtBD.Rows[aux]["codigo"].ToString());
            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();


        }

        public void borrarPosgrado(System.Data.DataTable dtBD, int aux)
        {
            string command = "UPDATE  usuarios SET esBaja = true WHERE codigo = @matricula";
            var cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@matricula", dtBD.Rows[aux]["MATRICULA"].ToString());
            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();


        }

        public void borrarEmpleado(System.Data.DataTable dtBD, int aux)
        {
            string command = "UPDATE  usuarios SET esBaja = true WHERE codigo = @numEmpleado";
            var cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@numEmpleado", dtBD.Rows[aux]["NUMEMPLEADO"].ToString());
            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();


        }

        public void insertarAlunmno(System.Data.DataTable dtExcel, int aux)
        {

            string command = "INSERT INTO usuarios (nombre, codigo, carrera, semestre, idTipoUsuario, esBaja, sexo) VALUES(@nombre, @codigo, @carrera, @semestre,@idTipoUsuario, @esBaja, @genero)";
            var cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@nombre", dtExcel.Rows[aux]["NOMBRE"].ToString());
            cmd.Parameters.AddWithValue("@codigo", dtExcel.Rows[aux]["MATRICULA"].ToString());
            cmd.Parameters.AddWithValue("@semestre", dtExcel.Rows[aux]["SEMESTRE"].ToString());
            cmd.Parameters.AddWithValue("@carrera", dtExcel.Rows[aux]["CARR"].ToString());
            cmd.Parameters.AddWithValue("@esBaja", false);
            cmd.Parameters.AddWithValue("@genero", dtExcel.Rows[aux]["GENERO"].ToString());
            cmd.Parameters.AddWithValue("@idTipoUsuario", 1);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void insertarPosgrado(System.Data.DataTable dtExcel, int aux){

            string command = "INSERT INTO usuarios (nombre, codigo, carrera,  idTipoUsuario, esBaja ) VALUES(@nombre, @codigo, @carrera, @idTipoUsuario, @esBaja)";
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@nombre", dtExcel.Rows[aux]["NOMBRE"].ToString());
            cmd.Parameters.AddWithValue("@codigo", dtExcel.Rows[aux]["MATRICULA"].ToString());
            cmd.Parameters.AddWithValue("@carrera", dtExcel.Rows[aux]["CARR"].ToString());
            cmd.Parameters.AddWithValue("@esBaja", false);
            cmd.Parameters.AddWithValue("@idTipoUsuario", 3);
            //Console.WriteLine(valueInt);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void insertarEmpleado(System.Data.DataTable dtExcel, int aux)
        {

            string command = "INSERT INTO usuarios (nombre, codigo, idTipoUsuario, esBaja ) VALUES(@nombre, @codigo, @idTipoUsuario, @esBaja)";
            var cmd = new SqlCommand(command, conn);


            cmd.Parameters.AddWithValue("@nombre", dtExcel.Rows[aux]["NOMBRE"].ToString());
            cmd.Parameters.AddWithValue("@codigo", dtExcel.Rows[aux]["NUMEMPLEADO"].ToString());
            cmd.Parameters.AddWithValue("@esBaja", false);
            cmd.Parameters.AddWithValue("@idTipoUsuario", dtExcel.Rows[aux]["TIPOUSUARIO"].ToString());

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void insertarInvitado()
        {
            for (int i = 0; i < dataInvitados.Rows.Count; i++)
            {
                string command = "INSERT INTO usuarios (nombre, codigo, idTipoUsuario, carrera, esBaja ) VALUES(@nombre, @codigo, @idTipoUsuario, @carrera, @esBaja)";
                var cmd = new SqlCommand(command, conn);


                cmd.Parameters.AddWithValue("@nombre", dataInvitados.Rows[i]["NOMBRE"].ToString());
                cmd.Parameters.AddWithValue("@codigo", dataInvitados.Rows[i]["CODIGO"].ToString());
                cmd.Parameters.AddWithValue("@carrera", dataInvitados.Rows[i]["CARR"].ToString());
                cmd.Parameters.AddWithValue("@esBaja", false);
                cmd.Parameters.AddWithValue("@idTipoUsuario", 5);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        private void txtTx_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                //stopWatch.Start();
                if (txtCod.Text != "")
                {
                    compararCodigo(txtCod.Text);
                    limpiame = true;
                }else {
                    limpiarPantalla();
                }
            }
        }

        private void btnCEmpleados_Click(object sender, EventArgs e)
        {
            OleDbConnection conn;
            OleDbDataAdapter MyDataAdapter;
            System.Data.DataTable dt = new System.Data.DataTable();
            String ruta = "";

            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.Filter = "Excel Files |*.xlsx";
            openfile1.Title = "Seleccione el archivo de Excel";
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openfile1.FileName.Equals("") == false)
                {
                    ruta = openfile1.FileName;
                   
                }
                
                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + ruta + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'");
                //try
                //{
                    MyDataAdapter = new OleDbDataAdapter("Select * from [Hoja1$]", conn);
                    dt = new System.Data.DataTable();
                    MyDataAdapter.Fill(dt);
                    dataEmpleados = dt;
                    txtCEmpleados.Text = openfile1.SafeFileName;
                //}
                //catch (Exception ex)
                //{
                   // MessageBox.Show("Este archivo no tiene el formaro especificado");
                //}
            }
        }

        private void btnCAlumnos_Click(object sender, EventArgs e)
        {
            OleDbConnection conn;
            OleDbDataAdapter MyDataAdapter;
            System.Data.DataTable dt = new System.Data.DataTable();
            String ruta = "";

            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.Filter = "Excel Files |*.xlsx";
            openfile1.Title = "Seleccione el archivo de Excel";
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openfile1.FileName.Equals("") == false)
                {
                    ruta = openfile1.FileName;
                    
                }

                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; data source=" + ruta + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'");
                try
                {
                    MyDataAdapter = new OleDbDataAdapter("Select * from [Hoja1$]", conn);
                    dt = new System.Data.DataTable();
                    MyDataAdapter.Fill(dt);
                    dataAlumnos = dt;
                    txtCAlumnos.Text = openfile1.SafeFileName;
                }
                catch (Exception ex) {
                    MessageBox.Show("Este archivo no tiene el formato especificado");
                }
            }

        }

        private void btnCPosgrado_Click(object sender, EventArgs e)
        {
            OleDbConnection conn;
            OleDbDataAdapter MyDataAdapter;
            System.Data.DataTable dt = new System.Data.DataTable();
            String ruta = "";

            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.Filter = "Excel Files |*.xlsx";
            openfile1.Title = "Seleccione el archivo de Excel";
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openfile1.FileName.Equals("") == false)
                {
                    ruta = openfile1.FileName;
                    
                }

                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + ruta + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'");
                try
                {
                    MyDataAdapter = new OleDbDataAdapter("Select * from [Hoja1$]", conn);
                    dt = new System.Data.DataTable();
                    MyDataAdapter.Fill(dt);
                    dataPosgrado = dt;
                    txtCPosgrado.Text = openfile1.SafeFileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Este archivo no tiene el formaro especificado");
                }
            }

        }

        private void btnCInivitados_Click(object sender, EventArgs e)
        {
            OleDbConnection conn;
            OleDbDataAdapter MyDataAdapter;
            System.Data.DataTable dt = new System.Data.DataTable();
            String ruta = "";

            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.Filter = "Excel Files |*.xlsx";
            openfile1.Title = "Seleccione el archivo de Excel";
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openfile1.FileName.Equals("") == false)
                {
                    ruta = openfile1.FileName;
                   
                }

                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + ruta + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'");
                try
                {
                    MyDataAdapter = new OleDbDataAdapter("Select * from [Hoja1$]", conn);
                    dt = new System.Data.DataTable();
                    MyDataAdapter.Fill(dt);
                    dataInvitados = dt;
                    txtCInvitados.Text = openfile1.SafeFileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Este archivo no tiene el formaro especificado");
                }
            }
        }

        private void btnAlumnos_Click_1(object sender, EventArgs e)
        {
            if (dataAlumnos.Rows.Count != 0)
            {
                actualizarAlumnos();
                MessageBox.Show("Archivo importado exitosamente");
            }
            else {
                MessageBox.Show("No hay archivo seleccionado");
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            if (dataEmpleados.Rows.Count != 0)
            {
                actualizarEmpleados();
                MessageBox.Show("Archivo importado exitosamente");
            }
            else
            {
                MessageBox.Show("No hay archivo seleccionado");
            }
        }

        private void btnPosgrado_Click(object sender, EventArgs e)
        {
            if (dataPosgrado.Rows.Count != 0)
            {
                actualizarPosgrados();
                MessageBox.Show("Archivo importado exitosamente");
            }
            else
            {
                MessageBox.Show("No hay archivo seleccionado");
            }
        }

        private void btnInvitados_Click(object sender, EventArgs e)
        {
            if (dataInvitados.Rows.Count != 0)
            {
                insertarInvitado();
                MessageBox.Show("Archivo importado exitosamente");
            }
            else
            {
                MessageBox.Show("No hay archivo seleccionado");
            }
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (limpiame == true && segundo == 3)
            {
                limpiarPantalla();
                limpiame = false;
                segundo = 0;
                this.tabPage1.BackColor = Color.Gainsboro;
                img_arrow.Visible = false;
            }
            else if (limpiame == true && segundo < 3)
            {
                segundo++;
            }
        }

        private void limpiarPantalla(){
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCarrera.Text = "";
            txtFecha.Text = "";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

       
    }
}

