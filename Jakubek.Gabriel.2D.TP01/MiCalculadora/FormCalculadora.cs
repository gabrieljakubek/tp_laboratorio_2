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
            }
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }
    }
}
