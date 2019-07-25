using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesRTP;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text is null || lblResultado.Text == "Resultado" || lblResultado.Text == "No hay resultado que convertir" || lblResultado.Text == "Valor invalido")
            {
                lblResultado.Text = "No hay resultado que convertir";
            }
            else
            {
                Numero n1 = new Numero();
                string z;
                string a = lblResultado.Text;

                z = n1.DecimalBinario(a);
                lblResultado.Text = z;
            }
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text is null || lblResultado.Text == "Resultado" || lblResultado.Text == "No hay resultado que convertir" || lblResultado.Text == "Valor invalido")
            {
                lblResultado.Text = "No hay resultado que convertir";
            }
            else
            {
                Numero n1 = new Numero();
                string z;
                string a = lblResultado.Text;

                z = n1.BinarioDecimal(a);
                lblResultado.Text = z;
            }
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string a = txtNumero1.Text;
            string b = txtNumero2.Text;
            string c = cmbOperador.Text;

            this.lblResultado.Text = (Operar(a, b, c)).ToString();
        }

        /// <summary>
        /// llama a operar de calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>double
        private static double Operar(string numero1, string numero2, string operador)
        {
            Calculadora calculadora = new Calculadora();
            double res = 0;


            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);


            res = calculadora.Operar(n1, n2, operador);
            return res;
        }

        /// <summary>
        /// restablece todos los valores de la calculadora
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();
            lblResultado.Text = "0";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    
}
