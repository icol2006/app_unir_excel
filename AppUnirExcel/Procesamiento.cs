using AppUnirExcel.Modelos;
using AppUnirExcel.Utilidades;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AppUnirExcel
{
    public static class Procesamiento
    {
        public static SqlCommand SqlComando = new SqlCommand();

        public static ValorRetornado verificarDocumentosExcel(String pathFiles)
        {
            ValorRetornado valorRetornado = new ValorRetornado();
            valorRetornado.resultado = true;

            List<String> nombresColumnasExcel = new List<string>();
            var listadoArchivos = Utilidades.FilesUtils
                                      .GetFilesDirectoryByExtension(pathFiles, Parametros.extesionExcel);

            foreach (var item in listadoArchivos)
            {
                nombresColumnasExcel = ExcelDoc.GetColumsNames(item.FullName, 8);
                nombresColumnasExcel = nombresColumnasExcel.ConvertAll(d => d.ToLower());

                var archivoNombre = Path.GetFileNameWithoutExtension(item.FullName);

                foreach (var item2 in Parametros.nombresColumnasExcel)
                {
                    var res = nombresColumnasExcel.Where(x => x.Equals(item2.ToLower())).Count();

                    if (res == 0)
                    {
                        valorRetornado.mensaje.Add(item2 + " no existe en archivo " + item.Name);
                        valorRetornado.resultado = false;
                        return valorRetornado;
                    }
                }
            }

            return valorRetornado;
        }

        public static void procesarExcelToCsv(String path)
        {
            var xlsxFiles = Utilidades.FilesUtils.GetFilesDirectoryByExtension(path, "xlsx");
            foreach (var item in xlsxFiles)
            {
                Utilidades.ExcelDoc.convertExceltoCsv(item.FullName);
            }
        }

        public static void unirArchivosCsv(String path)
        {
            var archivos = Utilidades.FilesUtils.GetFilesDirectoryByExtension(path, "xlsx");
            foreach (var item in archivos)
            {
                Utilidades.ExcelDoc.convertExceltoCsv(item.FullName);
            }
            CsvFiles.JoinCsv(path + @"/csv");
        }

        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();


            using (TextFieldParser csvReader = new TextFieldParser(csv_file_path, Encoding.GetEncoding(28591)))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                string[] colFields = csvReader.ReadFields();
                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }
                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }

            return csvData;
        }

        public static void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable csvFileData)
        {
            using (SqlConnection dbConnection = new SqlConnection(Parametros.ConexxionBD))
            {
                dbConnection.Open();

                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    s.BulkCopyTimeout = 100000000;
                    s.DestinationTableName = Parametros.tb_dataos;
                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(csvFileData);                    
                }
            }
        }

        public static void eliminarInformacion_dbDatos()
        {
            using (SqlConnection dbConnection = new SqlConnection(Parametros.ConexxionBD))
            {
                dbConnection.Open();

                SqlComando = new SqlCommand();
                SqlComando.CommandTimeout = 11111112;
                SqlComando.Connection = dbConnection;
                SqlComando.CommandText = "delete from " + Parametros.tb_dataos;
                SqlComando.ExecuteNonQuery();
                SqlComando.CommandText = "delete from " + Parametros.tbresultado;
                SqlComando.ExecuteNonQuery();
            }
        }

        public static void exportSqlToCsv(List<string> filtro, String directory)
        {
            string archivoDestino = directory + @"\resultado.csv";
            string query = "select * from " + Parametros.tbresultado + " WHERE 1 = 1 ";
            using (SqlConnection dbConnection = new SqlConnection(Parametros.ConexxionBD))
            {
                dbConnection.Open();
                SqlComando = new SqlCommand();
                SqlComando.CommandTimeout = 11111112;
                SqlComando.Connection = dbConnection;

                if(filtro.Count()>0)
                {
                    query += " and (";
                }

                if (filtro.Where(x => x.Equals("CIFIN")).Count() > 0)
                {
                    query += " or archivo='CIFIN' ";
                }
                if (filtro.Where(x => x.Equals("DATACREDITO")).Count() > 0)
                {
                    query += " or archivo='DATACREDITO' ";
                }
                if (filtro.Where(x => x.Equals("LICENCIAS")).Count() > 0)
                {
                    query += " or archivo='LICENCIAS' ";
                }
                if (filtro.Where(x => x.Equals("PICO_PLACA")).Count() > 0)
                {
                    query += " or archivo='PICO_PLACA' ";
                }
                if (filtro.Where(x => x.Equals("REGISTRO_BICI")).Count() > 0)
                {
                    query += " or archivo='REGISTRO_BICI' ";
                }
                if (filtro.Where(x => x.Equals("RUES")).Count() > 0)
                {
                    query += " or archivo='RUES' ";
                }
                if (filtro.Where(x => x.Equals("RUNT")).Count() > 0)
                {
                    query += " or archivo='RUNT' ";
                }
                if (filtro.Where(x => x.Equals("SHD")).Count() > 0)
                {
                    query += " or archivo='SHD' ";
                }
                if (filtro.Where(x => x.Equals("TIGLOBAL")).Count() > 0)
                {
                    query += " or archivo='TIGLOBAL' ";
                }

                if (filtro.Count() > 0)
                {
                    query += ")";
                }

                query = query.Replace("( or", "(");


                SqlComando.CommandText = query;

                var reader = SqlComando.ExecuteReader();

                File.Delete(archivoDestino);
                File.Create(archivoDestino).Dispose();
                Thread.Sleep(500);
                string csvDetails = "numero_documento" + "," + "tipo_documento" + "," + "direccion_datacredito" + "," + "departamento_datacredito" + "," + "email_datacredito" + "," + "celular_datacredito" + "," + "telefono_datacredito" + "," + "direccion_pico_placa" + "," + "departamento_pico_placa" + "," + "email_pico_placa" + "," + "celular_pico_placa" + "," + "telefono_pico_placa" + "," + "direccion_registro_bici" + "," + "departamento_registro_bici" + "," + "email_registro_bici" + "," + "celular_registro_bici" + "," + "telefono_registro_bici" + "," + "direccion_rues" + "," + "departamento_rues" + "," + "email_rues" + "," + "celular_rues" + "," + "telefono_rues" + "," + "direccion_runt" + "," + "departamento_runt" + "," + "email_runt" + "," + "celular_runt" + "," + "telefono_runt" + "," + "direccion_shd" + "," + "departamento_shd" + "," + "email_shd" + "," + "celular_shd" + "," + "telefono_shd" + "," + "direccion_tiglobal" + "," + "departamento_tiglobal" + "," + "email_tiglobal" + "," + "celular_tiglobal" + "," + "telefono_tiglobal" + "," + "direccion_licencias" + "," + "departamento_licencias" + "," + "email_licencias" + "," + "celular_licencias" + "," + "telefono_licencias" + "," + "direccion_cifin" + "," + "departamento_cifin" + "," + "email_cifin" + "," + "celular_cifin" + "," + "telefono_cifin" + "," + "id" + "," + "archivo";
                writeCsv(archivoDestino, csvDetails);
                csvDetails = "";
                int cont = 0;

                while (reader.Read() && EstadoForm.procesarDatos == true)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //grab relevant tag data and set the csv line for the current row.
                        //  csvDetails = reader.GetValue(0).ToString().Replace(",", " ") + "," + reader.GetValue(1).ToString().Replace(",", " ") + "," + reader.GetValue(2).ToString().Replace(",", " ") + "," + reader.GetValue(3).ToString().Replace(",", " ") + "," + reader.GetValue(4).ToString().Replace(",", " ") + "," + reader.GetValue(5).ToString().Replace(",", " ") + "," + reader.GetValue(6).ToString().Replace(",", " ") + "," + reader.GetValue(7).ToString().Replace(",", " ");

                        csvDetails += reader.GetValue(i).ToString().Replace(",", " ") + ",";                        
                        //csvDetails = resultado;
                      
                        if(EstadoForm.procesarDatos==false)
                        {
                            i = reader.FieldCount + 100;
                        }
                    }
                    csvDetails += Environment.NewLine;

                    cont++;
                    if (cont == 300)
                    {
                        writeCsv(archivoDestino, csvDetails);
                        csvDetails = "";
                        cont = 0;
                    }
             
                }
            }

        }
        public static void writeCsv(String fileName, string csvDetails)
        {
            FileInfo fileInfo = new FileInfo(fileName);
           
            while (IsFileLocked(fileInfo))
            {

            }
            using (FileStream fsWDT = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            using (StreamWriter swDT = new StreamWriter(fsWDT, Encoding.UTF8))
            {
                //write csv line to file.
                swDT.WriteLine(csvDetails.ToString());
                //Thread.Sleep(1);
            }
        }

        public static bool IsFileReady(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException ex)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public static void procesarRepetidos()
        {
            using (SqlConnection dbConnection = new SqlConnection(Parametros.ConexxionBD))
            {
                dbConnection.Open();

                SqlComando = new SqlCommand();
                SqlComando.CommandTimeout = 11111112;
                SqlComando.Connection = dbConnection;
                SqlComando.CommandText = "procesa_repetidos";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlComando.ExecuteNonQuery();
            }
        }

        public static void procesarResultados()
        {
            using (SqlConnection dbConnection = new SqlConnection(Parametros.ConexxionBD))
            {
                dbConnection.Open();

                SqlComando = new SqlCommand();
                SqlComando.CommandTimeout = 11111112;
                SqlComando.Connection = dbConnection;
                SqlComando.CommandText = "procesa_resultados";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlComando.ExecuteNonQuery();
            }
        }
    }
}