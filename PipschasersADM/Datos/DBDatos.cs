using MySql.Data.MySqlClient;
using PipschasersADM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInventarioOD.Datos
{
    class DBDatos
    {
        private const string conexion = "datasource = 127.0.0.1; port = 3306; username = root; password = root; database = pipschasersadm; Allow User Variables=True;";

        public bool BuscarUsuario(string nombreUsuario, string clave)
        {
            try
            {
                MySqlDataReader reader;

                MySqlConnection conn = new MySqlConnection(conexion);

                conn.Open();

                string query = "SELECT * FROM usuario WHERE nombre_usuario = @nombreUsuario AND clave = @clave";

                MySqlCommand comando = new MySqlCommand(query, conn);
                comando.Parameters.AddWithValue("@nombreusuario", nombreUsuario);
                comando.Parameters.AddWithValue("@clave", clave);

                reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Contrato> TraerContratos()
        {
            try
            {
                MySqlDataReader reader;

                MySqlConnection conn = new MySqlConnection(conexion);

                conn.Open();

                string query = "SELECT * FROM contratos";

                MySqlCommand comando = new MySqlCommand(query, conn);

                reader = comando.ExecuteReader();

                List<Contrato> contratos = new List<Contrato>();

                while (reader.Read())
                {
                    contratos.Add(new Contrato
                    {
                        Id_Contrato = reader.GetInt32(0),
                        Nombre_Completo = reader.GetString(1),
                        Tipo_Identificacion = reader.GetInt32(2),
                        Nro_Identificacion = reader.GetString(3),
                        Nombre_Persona_Implicada = reader.GetString(4),
                        Cedula_Persona_Implicada = reader.GetString(5),
                        Referido_Por = reader.GetString(6),
                        Fecha_Contratacion = reader.GetString(7),
                        Monto_Contrato = reader.GetFloat(8),
                        Porcentaje_Contrato = reader.GetFloat(9),
                        Retencion_Impuesto = reader.GetInt32(10),
                        Dia_Pago = reader.GetInt32(11),
                        Deposito_Mensual = reader.GetFloat(12),
                        Procedencia_Capital = reader.GetString(13),
                        Correo_Electronico = reader.GetString(14),
                        Nro_Telefono_Cliente = reader.GetString(15),
                        Telefono_Whatsapp = reader.GetInt32(16),

                    });
                }

                return contratos;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int AgregarContratoCuentaBancaria(Contrato contrato)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(conexion);

                conn.Open();

                string query = "INSERT INTO contratos(NOMBRE_COMPLETO,TIPO_IDENTIFICACION,NRO_IDENTIFICACION,NOMBRE_PERSONA_IMPLICADA," +
                    "CEDULA_PERSONA_IMPLICADA,REFERIDO_POR,FECHA_CONTRATACION,MONTO_CONTRATADO,PORCENTAJE_CONTRATO,RETENCION_IMPUESTO," +
                    "DIA_PAGO,DEPOSITO_MENSUAL,PROCEDENCIA_CAPITAL,CORREO_ELECTRONICO,NRO_TELEFONO_CLIENTE,TELEFONO_WHATSAPP)VALUES" +

                    "(@nombre_completo, @tipo_identificacion, @nro_identificacion, @nombre_persona_implicada," +
                    "@cedula_persona_implicada, @referido_por, @fecha_contratacion, @monto_contratado, @porcentaje_contrato, @retencion_impuesto," +
                    "@dia_pago, @deposito_mensual, @procedencia_capital, @correo_electronico, @nro_telefono_cliente,@telefono_whatsapp);";

                MySqlCommand comando = new MySqlCommand(query, conn);

                comando.Parameters.AddWithValue("@nombre_completo", contrato.Nombre_Completo);
                comando.Parameters.AddWithValue("@tipo_identificacion", contrato.Tipo_Identificacion);
                comando.Parameters.AddWithValue("@nro_identificacion", contrato.Nro_Identificacion);
                comando.Parameters.AddWithValue("@nombre_persona_implicada", contrato.Nombre_Persona_Implicada);
                comando.Parameters.AddWithValue("@cedula_persona_implicada", contrato.Cedula_Persona_Implicada);
                comando.Parameters.AddWithValue("@referido_por", contrato.Referido_Por);
                comando.Parameters.AddWithValue("@fecha_contratacion", contrato.Fecha_Contratacion);
                comando.Parameters.AddWithValue("@monto_contratado", contrato.Monto_Contrato);
                comando.Parameters.AddWithValue("@porcentaje_contrato", contrato.Porcentaje_Contrato);
                comando.Parameters.AddWithValue("@retencion_impuesto", contrato.Retencion_Impuesto);
                comando.Parameters.AddWithValue("@dia_pago", contrato.Dia_Pago);
                comando.Parameters.AddWithValue("@deposito_mensual", contrato.Deposito_Mensual);
                comando.Parameters.AddWithValue("@procedencia_capital", contrato.Procedencia_Capital);
                comando.Parameters.AddWithValue("@correo_electronico", contrato.Correo_Electronico);
                comando.Parameters.AddWithValue("@nro_telefono_cliente", contrato.Nro_Telefono_Cliente);
                comando.Parameters.AddWithValue("@telefono_whatsapp", contrato.Telefono_Whatsapp);

                int resultado = comando.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }catch(Exception ex)
            {
                return 0;
            }
        }

        public int AgregaraDatosBancarios (DatosBancarios datosBancarios)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(conexion);

                string query = "INSERT INTO datos_bancarios (id_contrato, institucion_bancaria, nro_cuenta_bancaria, nombre_titular, cedula_titular, naturaleza_cuenta) VALUES" +
                    //"((SELECT id_contratos FROM contratos ORDER BY id_contratos DESC LIMIT 1), \"Banreservas\", \"18491827491827\", \"Gabriel Vargas\", \"28058200\", \"Ahorro\");";
                    "((SELECT id_contratos FROM contratos ORDER BY id_contratos DESC LIMIT 1), @institucionBancaria, @nroCuentaBancaria, @nombreTitular, @cedulaTitular, @naturalezaTitular);";

                conn.Open();

                MySqlCommand comando = new MySqlCommand(query, conn);

                comando.Parameters.AddWithValue("@institucionBancaria", datosBancarios.Institucion_Bancaria);
                comando.Parameters.AddWithValue("@nroCuentaBancaria", datosBancarios.Nro_Cuenta_Bancaria);
                comando.Parameters.AddWithValue("@nombreTitular", datosBancarios.Nombre_Titular);
                comando.Parameters.AddWithValue("@cedulaTitular", datosBancarios.Cedula_Titular);
                comando.Parameters.AddWithValue("@naturalezaTitular", datosBancarios.Naturaleza_Cuenta);

                int resultado = comando.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
