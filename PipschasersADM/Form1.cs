using PipschasersADM.Modelo;
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
        public FormRegistroGeneralClientes()
        {
            InitializeComponent();
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

            if (true)
            {
                contrato.Nombre_Completo = txtNombreCompleto.Text;
                contrato.Tipo_Identificacion = rbCedula.Checked ? 1 : 2;
                contrato.Nro_Identificacion = txtNroIdentificacionCliente.Text;
                contrato.Nombre_Persona_Implicada = txtNombreCompletoSegunda.Text;
                contrato.Cedula_Persona_Implicada = txtIdentificacionSegunda.Text;
                contrato.Referido_Por = txtRerferidoPor.Text;

                dateTime = dtpFechaContratacion.Value;

                contrato.Fecha_Contratacion = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                contrato.Monto_Contrato = (float)nudMontoContratado.Value;
                contrato.Porcentaje_Contrato = (float)nudPorcentajeContratado.Value;
                contrato.Retencion_Impuesto = rbRetenImpuestosSi.Checked ? 1 : 2;
                contrato.Dia_Pago = rbDiasQuince.Checked ? 1 : 2;
                contrato.Deposito_Mensual = (float)nudDepositoMensual.Value;
                contrato.Procedencia_Capital = txtProcedenciaCapital.Text;
                contrato.Correo_Electronico = txtCorreoElectronico.Text;
                contrato.Nro_Telefono_Cliente = txtNroTelefono.Text;
                contrato.Telefono_Whatsapp = rbSiWhatsapp.Checked ? 1 : 2;


                string nombreBanco = string.Empty;

                if (rbBanreservas.Checked)
                {
                    datosBancarios.Institucion_Bancaria = rbBanreservas.Text;
                }
                else if (rbBancoPopular.Checked)
                {
                    datosBancarios.Institucion_Bancaria = rbBancoPopular.Text;
                }
                else if (rbBancoBHD.Checked)
                {
                    datosBancarios.Institucion_Bancaria = rbBancoBHD.Text;
                }
                else if (rbAPAP.Checked)
                {
                    datosBancarios.Institucion_Bancaria = rbAPAP.Text;
                }
                else if (rbScotiabank.Checked)
                {
                    datosBancarios.Institucion_Bancaria = rbScotiabank.Text;
                }
                else if (rbBancoFihogar.Checked)
                {
                    datosBancarios.Institucion_Bancaria = rbBancoFihogar.Text;
                }
                else if (rbAlaver.Checked)
                {
                    datosBancarios.Institucion_Bancaria = rbAlaver.Text;
                }
                else if (rbBancoAdemi.Checked)
                {
                    datosBancarios.Institucion_Bancaria = rbBancoAdemi.Text;
                }
                else if (rbBLH.Checked)
                {
                    datosBancarios.Institucion_Bancaria = rbBLH.Text;
                }
                else if (rbBDI.Checked)
                {
                    datosBancarios.Institucion_Bancaria = rbBDI.Text;
                }

            }



        }
    }
}
