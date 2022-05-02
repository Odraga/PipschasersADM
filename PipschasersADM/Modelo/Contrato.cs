using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipschasersADM.Modelo
{
    class Contrato
    {
        public int Id_Contrato { get; set; }
        public string Nombre_Completo { get; set; }
        public int Tipo_Identificacion { get; set; }
        public string Nro_Identificacion { get; set; }
        public string Nombre_Persona_Implicada { get; set; }
        public string Cedula_Persona_Implicada { get; set; }
        public string Referido_Por { get; set; }
        public string Fecha_Contratacion { get; set; }
        public float Monto_Contrato { get; set; }
        public float Porcentaje_Contrato { get; set; }
        public int Retencion_Impuesto { get; set; }
        public int Dia_Pago { get; set; }
        public float Deposito_Mensual { get; set; }
        public string Procedencia_Capital { get; set; }
        public string Correo_Electronico { get; set; }
        public string Nro_Telefono_Cliente { get; set; }
        public int Telefono_Whatsapp { get; set; }
    }
}
