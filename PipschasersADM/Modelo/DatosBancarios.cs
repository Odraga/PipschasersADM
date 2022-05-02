using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipschasersADM.Modelo
{
    class DatosBancarios
    {
        public int Id_Datos_Bancarios { get; set; }
        public int Id_Contrato { get; set; }
        public string Institucion_Bancaria { get; set; }
        public string Nro_Cuenta_Bancaria { get; set; }
        public string Nombre_Titular { get; set; }
        public string Cedular_Titular { get; set; }
        public string Naturaleza_Cuenta { get; set; }
    }
}
