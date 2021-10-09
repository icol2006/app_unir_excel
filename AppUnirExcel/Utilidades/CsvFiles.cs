using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUnirExcel.Utilidades
{
    public static class CsvFiles
    {
        public static Boolean JoinCsv(String pathOrigin)
        {
            var pathArchivoFinal = pathOrigin + "//res.csv";

            File.Delete(pathArchivoFinal);

            var files = Directory.EnumerateFiles(pathOrigin, "*.csv");

            if (files.Count() == 0)
                return false;

            var archivos = FilesUtils.GetFilesDirectoryByExtension(pathOrigin, "csv");
            string[] header = { File.ReadLines(archivos.First().FullName).First(l => !string.IsNullOrWhiteSpace(l)) };

            // Get CSV Data
            var mergedData = archivos.SelectMany(csv => File.ReadLines(csv.FullName).SkipWhile(l => string.IsNullOrWhiteSpace(l)).Skip(1));

            // skip header of each file
            File.WriteAllLines(pathArchivoFinal, header.Concat(mergedData), Encoding.UTF8);

            return true;

        }
    }
}
