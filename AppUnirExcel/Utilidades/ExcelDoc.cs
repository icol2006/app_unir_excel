using Spire.Xls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUnirExcel.Utilidades
{
    public static class ExcelDoc
    {
        public static List<String> GetColumsNames(String filePath, int numColumns)
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            List<String> res = new List<string>();

            Workbook workbook = new Workbook();
            workbook.LoadFromFile(filePath);

            Worksheet sheet = workbook.Worksheets[0];

            for (int i = 0; i < numColumns; i++)
            {
                String column = alpha[i].ToString() + (1);
                res.Add(sheet.Range[column].Value);
            }

            return res;
        }

        public static void convertExceltoCsv(String path)
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            var pathDestination = Path.GetDirectoryName(path)+@"/csv/";

            Workbook workbook = new Workbook();
            workbook.LoadFromFile(path);
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToFile(pathDestination+fileName + ".csv", ",", Encoding.UTF8);
        }

    }
}
