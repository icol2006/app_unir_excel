using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUnirExcel.Modelos
{
    public class ValorRetornado
    {
        public Boolean resultado { get; set; }
        public List<String> mensaje { get; set; }

        public ValorRetornado()
        {
            mensaje = new List<string>();
        }

        public String imprimirMensaje()
        {
            String res = "";

            foreach (var item in this.mensaje)
            {
                res += item + Environment.NewLine;
            }
            return res;
        }
    }
}
