using PipschasersADM.Controlador;
using PipschasersADM.Modelo;
using SistemaDeInventarioOD.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipschasersADM
{
    public partial class FormRegistroGeneralClientes : Form
    {
        private List<Contrato> contratos = new List<Contrato>();

        public FormRegistroGeneralClientes()
        {
            InitializeComponent();

            
        }
        
        private void CargarDatosContratos()
        {
            DBDatos dBDatos = new DBDatos();

            contratos.Clear();

            contratos = dBDatos.TraerContratos();

            dgvContratos.Rows.Clear();

            foreach (var item in contratos)
            {
                dgvContratos.Rows.Add(item.Id_Contrato,
                    item.Nombre_Completo,
                    item.Tipo_Identificacion == 0 ? "Cedula" : "Pasaporte",
                    item.Nro_Identificacion,
                    item.Nombre_Persona_Implicada,
                    item.Cedula_Persona_Implicada,
                    item.Referido_Por,
                    item.Fecha_Contratacion,
                    item.Monto_Contrato,
                    item.Porcentaje_Contrato,
                    item.Retencion_Impuesto == 0 ? "Si" : "No",
                    item.Dia_Pago == 0 ? "Dias: 15":"Dias: 30",
                    item.Deposito_Mensual,
                    item.Procedencia_Capital,
                    item.Correo_Electronico,
                    item.Nro_Telefono_Cliente,
                    item.Telefono_Whatsapp == 0 ? "Si" : "No"); 
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime();

            Contrato contrato = new Contrato();
            DatosBancarios datosBancarios = new DatosBancarios();
            Validar validar = new Validar();

            if (string.IsNullOrEmpty(txtNombreCompleto.Text) || string.IsNullOrEmpty(txtNroIdentificacionCliente.Text) || string.IsNullOrEmpty(txtNombreCompletoSegunda.Text) || 
                string.IsNullOrEmpty(txtNombreCompletoSegunda.Text) || string.IsNullOrEmpty(txtIdentificacionSegunda.Text) || string.IsNullOrEmpty(txtNroCuentaBancaria.Text) ||
                string.IsNullOrEmpty(txtProcedenciaCapital.Text) || string.IsNullOrEmpty(txtRerferidoPor.Text) || string.IsNullOrEmpty(txtCorreoElectronico.Text) || 
                string.IsNullOrEmpty(txtIdentificacionTitular.Text) || string.IsNullOrEmpty(txtNombreTitularCuenta.Text))
            {
                MessageBox.Show("No puede haber campos vacios.");
            }
            else {
                try
                {

                    contrato.Nombre_Completo = txtNombreCompleto.Text;
                    contrato.Tipo_Identificacion = rbCedula.Checked ? 0 : 1;
                    contrato.Nro_Identificacion = txtNroIdentificacionCliente.Text;
                    contrato.Nombre_Persona_Implicada = txtNombreCompletoSegunda.Text;
                    contrato.Cedula_Persona_Implicada = txtIdentificacionSegunda.Text;
                    contrato.Referido_Por = txtRerferidoPor.Text;

                    dateTime = dtpFechaContratacion.Value;

                    contrato.Fecha_Contratacion = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    contrato.Monto_Contrato = (float)nudMontoContratado.Value;
                    contrato.Porcentaje_Contrato = (float)nudPorcentajeContratado.Value;
                    contrato.Retencion_Impuesto = rbRetenImpuestosSi.Checked ? 0 : 1;
                    contrato.Dia_Pago = rbDiasQuince.Checked ? 0 : 1;
                    contrato.Deposito_Mensual = (float)nudDepositoMensual.Value;
                    contrato.Procedencia_Capital = txtProcedenciaCapital.Text;
                    contrato.Correo_Electronico = txtCorreoElectronico.Text;
                    contrato.Nro_Telefono_Cliente = txtNroTelefono.Text;
                    contrato.Telefono_Whatsapp = rbSiWhatsapp.Checked ? 0 : 1;


                    string nombreBanco = string.Empty;

                    if (rbBanreservas.Checked)
                    {
                        nombreBanco = rbBanreservas.Text;
                    }
                    else if (rbBancoPopular.Checked)
                    {
                        nombreBanco = rbBancoPopular.Text;
                    }
                    else if (rbBancoBHD.Checked)
                    {
                        nombreBanco = rbBancoBHD.Text;
                    }
                    else if (rbAPAP.Checked)
                    {
                        nombreBanco = rbAPAP.Text;
                    }
                    else if (rbScotiabank.Checked)
                    {
                        nombreBanco = rbScotiabank.Text;
                    }
                    else if (rbBancoFihogar.Checked)
                    {
                        nombreBanco = rbBancoFihogar.Text;
                    }
                    else if (rbAlaver.Checked)
                    {
                        nombreBanco = rbAlaver.Text;
                    }
                    else if (rbBancoAdemi.Checked)
                    {
                        nombreBanco = rbBancoAdemi.Text;
                    }
                    else if (rbBLH.Checked)
                    {
                        nombreBanco = rbBLH.Text;
                    }
                    else if (rbBDI.Checked)
                    {
                        nombreBanco = rbBDI.Text;
                    }

                    datosBancarios.Institucion_Bancaria = nombreBanco;

                    datosBancarios.Nro_Cuenta_Bancaria = txtNroCuentaBancaria.Text;
                    datosBancarios.Nombre_Titular = txtNombreTitularCuenta.Text;
                    datosBancarios.Cedula_Titular = txtIdentificacionTitular.Text;

                    if (rbAhorro.Checked)
                    {
                        datosBancarios.Naturaleza_Cuenta = rbAhorro.Text;
                    }
                    else if (rbCorriente.Checked)
                    {
                        datosBancarios.Naturaleza_Cuenta = rbCorriente.Text;
                    }
                    else if (rbOtro.Checked)
                    {
                        datosBancarios.Naturaleza_Cuenta = txtOtraNaturaleza.Text;
                    }

                    bool resultado = validar.AgregarContratoCuentaBancaria(contrato, datosBancarios);

                    if (resultado)
                    {
                        MessageBox.Show("EXITOSO!");

                        txtNombreCompleto.Clear();
                        txtNroIdentificacionCliente.Clear();
                        txtNombreCompletoSegunda.Clear();
                        txtIdentificacionSegunda.Clear();
                        txtRerferidoPor.Clear();
                        txtNombreTitularCuenta.Clear();
                        txtIdentificacionTitular.Clear();
                        txtNroCuentaBancaria.Clear();
                        txtProcedenciaCapital.Clear();
                        txtCorreoElectronico.Clear();
                        txtNroTelefono.Clear();

                        nudDepositoMensual.Value = 0;
                        nudMontoContratado.Value = 0;
                        nudPorcentajeContratado.Value = 0;

                    }
                    else
                    {
                        MessageBox.Show("FRACAZO EL PROCESO!");
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("Ocurrio una Excepcion!"+ex.Message);
                }
            }
        }

        private void rbOtro_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOtro.Checked)
            {
                txtOtraNaturaleza.ReadOnly = false;
            }
            else
            {
                txtOtraNaturaleza.Text = string.Empty;
                txtOtraNaturaleza.ReadOnly = true;
            }
        }

        private void tabConRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosContratos();
        }
    }
}
