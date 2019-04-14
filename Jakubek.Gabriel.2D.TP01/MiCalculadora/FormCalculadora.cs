using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        static bool chequeoConvercion;

        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lleva a acabo la operacion deseada
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Calculadora calculadora = new Calculadora();
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return calculadora.Operar(num1, num2, operador);
        }

        /// <summary>
        /// Limpia los textbox, label y combobox del form
        /// </summary>
        private void Limpiar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox || item is ComboBox || item is Label)
                {
                    item.Text = "";
                }
                chequeoConvercion = true;
            }
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
            chequeoConvercion = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (chequeoConvercion == false && lblResultado.Text != "Valor invalido" && lblResultado.Text != "")
            {
                lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
                chequeoConvercion = true;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (chequeoConvercion ==true&& lblResultado.Text != "Valor invalido")
            {
                lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
                chequeoConvercion = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
