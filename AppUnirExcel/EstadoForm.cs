﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUnirExcel
{
    public static class EstadoForm
    {
        public static Boolean procesarDatos = false;

        public static Boolean cancelado = false;

        public static String accion = "";

        public static int totalRegistros = 0;

        public static int cantidadRegistrosProcesado = 0;

        public static Boolean formEstaAbierto = true;

        public static void resetearValoresCantidades()
        {
            totalRegistros = 0;
            cantidadRegistrosProcesado = 0;
        }

    }
}
