using MySql.Data.MySqlClient;
using PipschasersADM.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInventarioOD.Datos
{
    class DBDatos
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["stringConnection"].ConnectionString;

        public bool BuscarUsuario(string nombreUsuario, string clave)
        {
            try
            {
                bool estado = false;

                SQLiteConnection conn = new SQLiteConnection(conexion);

                conn.Open();

                string query = "SELECT * FROM usuarios WHERE NOMBRE_USUARIO = @nombreusuario AND CLAVE = @clave LIMIT 1;";

                SQLiteCommand comando = new SQLiteCommand(query, conn);
                comando.Parameters.AddWithValue("@nombreusuario", nombreUsuario);
                comando.Parameters.AddWithValue("@clave", clave);

                SQLiteDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    estado = true;
                }

                conn.Close();

                return estado;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /*public List<Contrato> TraerContratos()
        {
            try
            {
                SQLiteDataReader reader;

                SQLiteConnection conn = new SQLiteConnection(conexion);

                conn.Open();

                string query = "SELECT * FROM contratos";

                SQLiteCommand comando = new SQLiteCommand(query, conn);

                reader = comando.ExecuteReader();

                List<Contrato> contratos = new List<Contrato>();

                while (reader.Read())
                {
                    contratos.Add(new Contrato
                    {
                        Id_Contrato = reader.GetInt32("id_contrato"),
                        Nombre_Completo = reader.GetString("nombre_completo"),
                        Tipo_Identificacion = reader.GetInt32("tipo_identificacion"),
                        Nro_Identificacion = reader.GetString("nro_identificacion"),
                        Nombre_Persona_Implicada = reader.GetString("nombre_persona_implicada"),
                        Cedula_Persona_Implicada = reader.GetString("cedula_persona_implicada"),
                        Referido_Por = reader.GetString("referido_por"),
                        Fecha_Contratacion = reader.GetString("fecha_contratacion"),
                        Monto_Contrato = reader.GetFloat("monto_contrato"),
                        Porcentaje_Contrato = reader.GetFloat("porcentaje_contrato"),
                        Retencion_Impuesto = reader.GetInt32("retencion_impuesto"),
                        Dia_Pago = reader.GetInt32("dia_pago"),
                        Deposito_Mensual = reader.GetFloat("deposito_mensual"),
                        Procedencia_Capital = reader.GetString("procedencia_capital"),
                        Correo_Electronico = reader.GetString("correo_electronico"),
                        Nro_Telefono_Cliente = reader.GetString("nro_telefono_cliente"),
                        Telefono_Whatsapp = reader.GetInt32("telefono_whatsapp"),

                    });
                }

                return contratos;
            }
            catch (Exception)
            {
                return null;
            }
        }*/
        public int AgregarContratoCuentaBancaria(Contrato contrato)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(conexion);

                conn.Open();

                string query = "INSERT INTO contratos(NOMBRE_COMPLETO,TIPO_IDENTIFICACION,NRO_IDENTIFICACION,NOMBRE_PERSONA_IMPLICADA," +
                    "CEDULA_PERSONA_IMPLICADA,REFERIDO_POR,FECHA_CONTRATACION,MONTO_CONTRATO,PORCENTAJE_CONTRATO,RETENCION_IMPUESTO," +
                    "DIA_PAGO,DEPOSITO_MENSUAL,PROCEDENCIA_CAPITAL,CORREO_ELECTRONICO,NRO_TELEFONO_CLIENTE,TELEFONO_WHATSAPP)VALUES" +

                    "(@nombre_completo, @tipo_identificacion, @nro_identificacion, @nombre_persona_implicada," +
                    "@cedula_persona_implicada, @referido_por, @fecha_contratacion, @monto_contratado, @porcentaje_contrato, @retencion_impuesto," +
                    "@dia_pago, @deposito_mensual, @procedencia_capital, @correo_electronico, @nro_telefono_cliente,@telefono_whatsapp);";

                SQLiteCommand comando = new SQLiteCommand(query, conn);

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
            }catch(Exception)
            {
                return 0;
            }
        }

        public int AgregaraDatosBancarios (DatosBancarios datosBancarios)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(conexion);

                string query = "INSERT INTO dt_bk (id_contrato, institucion_bk, cuenta_bk, nombre_titular, cedula_titular, naturaleza_cuenta) VALUES" +
                    "((SELECT id_contrato FROM contratos ORDER BY id_contrato DESC LIMIT 1), @institucionBancaria, @nroCuentaBancaria, @nombreTitular, @cedulaTitular, @naturalezaTitular);";

                conn.Open();

                SQLiteCommand comando = new SQLiteCommand(query, conn);

                comando.Parameters.AddWithValue("@institucionBancaria", datosBancarios.Institucion_Bancaria);
                comando.Parameters.AddWithValue("@nroCuentaBancaria", datosBancarios.Nro_Cuenta_Bancaria);
                comando.Parameters.AddWithValue("@nombreTitular", datosBancarios.Nombre_Titular);
                comando.Parameters.AddWithValue("@cedulaTitular", datosBancarios.Cedula_Titular);
                comando.Parameters.AddWithValue("@naturalezaTitular", datosBancarios.Naturaleza_Cuenta);

                int resultado = comando.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
