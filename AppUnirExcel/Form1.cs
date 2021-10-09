using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppUnirExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //textBox1.Text= Utilidades.FilesUtils.AbrirDialogoDirectorio();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //unirArchivosCsv();

            // var files= Utilidades.FilesUtils.GetFilesDirectoryByExtension(textBox1.Text,"xlsx");
            //Utilidades.ExcelDoc.GetColumsNames(files[0].FullName, 8);
            //  Utilidades.ExcelDoc.convertExceltoCsv(files[0].FullName);
            pctProcesamiento.Visible = true;
            togleButtons();
            Thread thread = new Thread(async () =>
            {
                try
                {
                    var archivoCsv = Utilidades.FilesUtils.AbrirDialogoArchivo();
                    var res = Procesamiento.GetDataTabletFromCSVFile(archivoCsv);
                    Procesamiento.InsertDataIntoSQLServerUsingSQLBulkCopy(res);
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Datos procesados");
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(ex.Message);
                    }));
                }
                finally
                {
                    this.Invoke(new Action(() =>
                    {
                        pctProcesamiento.Visible = false;
                        togleButtons();
                    }));
                }

            });
            try
            {
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                thread.IsBackground = true;
                thread.Start();

            }
            catch (Exception ex)
            {

            }



        }

        private void unirArchivosCsv()
        {
            try
            {
                var path = Utilidades.FilesUtils.AbrirDialogoDirectorio();
                Procesamiento.unirArchivosCsv(path);
                MessageBox.Show("Accion realizada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void verificarArchivosExcel()
        {
            //try
            //{
            //    var res = Procesamiento.verificarDocumentosExcel(textBox1.Text);
            //    if (res.resultado == false)
            //    {
            //        MessageBox.Show(res.imprimirMensaje());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var path = Utilidades.FilesUtils.AbrirDialogoDirectorio();
            Utilidades.CsvFiles.JoinCsv(path);
            MessageBox.Show("Accion realizada correctamente");
        }

        public List<String[]> ReadArrayFromFile(string fileName)
        {
            List<String[]> lista = new List<string[]>();

            //using (var reader = new StreamReader(fileName))
            //{
            //    var size = Convert.ToInt32(reader.ReadLine());
            //    result = reader.ReadLine()
            //            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //}

            using (var reader = new StreamReader(fileName, Encoding.GetEncoding(28591)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    lista.Add(values);
                }
            }
            return lista;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Esta seguron que desea eliminar los datos??",
                                     "Confirmacion!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                pctProcesamiento.Visible = true;
                togleButtons();
                Thread thread = new Thread(async () =>
                {
                    try
                    {
                        Procesamiento.eliminarInformacion_dbDatos();

                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show("Datos procesados");
                        }));
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show(ex.Message);
                        }));
                    }
                    finally
                    {
                        this.Invoke(new Action(() =>
                        {
                            pctProcesamiento.Visible = false;
                            togleButtons();
                        }));
                    }

                });
                try
                {
                    thread.IsBackground = true;
                    thread.Start();

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Procesamiento.exportSqlToCsv();
            MessageBox.Show("Datos procesados");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show("Datos procesados");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pctProcesamiento.Visible = true;
            togleButtons();
            Thread thread = new Thread(async () =>
            {
                try
                {
                    Procesamiento.procesarRepetidos();
                    Procesamiento.procesarResultados();

                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Datos procesados");
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(ex.Message);
                    }));
                }
                finally
                {
                    this.Invoke(new Action(() =>
                    {
                        pctProcesamiento.Visible = false;
                        togleButtons();
                    }));
                }

            });
            try
            {
                thread.IsBackground = true;
                thread.Start();

            }
            catch (Exception ex)
            {

            }


        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exprotarSqltoCsv();
        }

        private void exprotarSqltoCsv()
        {
            List<string> filtro = new List<string>();
            var directory = Utilidades.FilesUtils.AbrirDialogoDirectorio();

            if (chCIFIN.Checked)
            {
                filtro.Add("CIFIN");
            }
            if (chDATACREDITO.Checked)
            {
                filtro.Add("DATACREDITO");
            }
            if (chLICENCIAS.Checked)
            {
                filtro.Add("LICENCIAS");
            }
            if (chPICO_PLACA.Checked)
            {
                filtro.Add("PICO_PLACA");
            }
            if (chREGISTRO_BICI.Checked)
            {
                filtro.Add("REGISTRO_BICI");
            }
            if (chRUES.Checked)
            {
                filtro.Add("RUES");
            }
            if (chRUNT.Checked)
            {
                filtro.Add("RUNT");
            }
            if (chSHD.Checked)
            {
                filtro.Add("SHD");
            }
            if (chTIGLOBAL.Checked)
            {
                filtro.Add("TIGLOBAL");
            }


            pctProcesamiento.Visible = true;
            EstadoForm.procesarDatos = true;
            togleButtons();
            Thread thread = new Thread(async () =>
            {
                try
                {
                    Procesamiento.exportSqlToCsv(filtro, directory);

                    this.Invoke(new Action(() =>
                    {
                        if (EstadoForm.cancelado == false)
                        {
                            MessageBox.Show("Datos procesados");
                        }

                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(ex.Message);
                    }));
                }
                finally
                {
                    this.Invoke(new Action(() =>
                    {
                        if (EstadoForm.cancelado == false)
                        {
                            togleButtons();
                        }

                        pctProcesamiento.Visible = false;
                        EstadoForm.procesarDatos = false;
                        EstadoForm.cancelado = false;
                    }));
                }

            });
            try
            {
                thread.IsBackground = true;
                thread.Start();

            }
            catch (Exception ex)
            {

            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Procesamiento.SqlComando.Cancel();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Procesamiento.SqlComando.Cancel();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Procesamiento.SqlComando.Cancel();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            EstadoForm.procesarDatos = false;
            EstadoForm.cancelado = true;
            pctProcesamiento.Visible = false;
            togleButtons();
        }

        private void button2_Click_3(object sender, EventArgs e)
        {

        }

        private void togleButtons()
        {
            this.btnExportar.Enabled = !this.btnExportar.Enabled;
            this.btnExportarCsvSql.Enabled = !this.btnExportarCsvSql.Enabled;
            this.btnProcesarResultados.Enabled = !this.btnProcesarResultados.Enabled;
            this.btnEliminarRegistrosSql.Enabled = !this.btnEliminarRegistrosSql.Enabled;


        }

        private void button2_Click_4(object sender, EventArgs e)
        {
            this.togleButtons();
        }
    }

}
