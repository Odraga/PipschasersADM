using SistemaDeInventarioOD.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipschasersADM.Controlador
{
    class Validar
    {
        public bool Iniciar_Sesion(string usuario, string clave)
        {
            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                return false;
            }
            else
            {
                DBDatos dBDatos = new DBDatos();

                bool existe = dBDatos.BuscarUsuario(usuario, clave);

                if (existe)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
