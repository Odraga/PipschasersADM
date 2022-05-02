using PipschasersADM.Controlador;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Validar validar = new Validar();

            bool validado = validar.Iniciar_Sesion(txtNombreUsuario.Text, txtContrasenia.Text);

            if (validado)
            {
                FormRegistroGeneralClientes formRegistroGeneralClientes = new FormRegistroGeneralClientes();

                formRegistroGeneralClientes.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al iniciar sesion.");
            }
        }
    }
}
