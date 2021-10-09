using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUnirExcel
{
    public static class Parametros
    {
        public static List<String> nombresColumnasExcel =new List<string> { "tipo_documento", "numero_documento", "direccion", "departamento", "email", "celular", "telefono", "archivo" };
        public static String extesionExcel= "xlsx";
        public static String ConexxionBD = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static String tb_dataos = "tb_datos";
        public static String tbresultado = "tbresultado";

    }
}
