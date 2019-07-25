using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRTP
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #region constructores
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Valida que los caracteres ingresados sean numericos
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>double
        private double ValidarNumero(string strNumero)
        {

            bool VN;
            double R = 0;
            VN = double.TryParse(strNumero, out R);
            if (VN == true)
                return R;
            else
            {
                R = 0;
                return R;
            }
        }

        /// <summary>
        /// pasa de binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>string
        public string BinarioDecimal(string binario)
        {


            char[] array = binario.ToCharArray();
            bool valorInvalido = false;


            Array.Reverse(array);
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {

                    sum += (int)Math.Pow(2, i);
                }
                else if (array[i] != '0')
                {
                    valorInvalido = true;
                    break;
                }
            }

            if (valorInvalido == false)
                return sum.ToString();
            else
                return "Valor inválido";
        }

        /// <summary>
        /// pasa de decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            double num = 0;
            string Binar = "";
            bool B;



            B = double.TryParse(numero, out num);

            Binar = DecimalBinario(num);
            B = double.TryParse(Binar, out double B1);

            if (B == true && Binar.Length<20)
                return Binar;
            else return "Valor invalido";


        }


        /// <summary>
        /// pasa de decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string Binar = "";
            string Fin = "";
            double dos = 1;

            double j = 1;
            int RB = 0;
            double nb = numero;
            int potDos = 1;


            //saca qué potencia es la que corresponde al numero ingresado
            do
            {
                if (Math.Pow(2, j) <= numero)
                    potDos++;
                else break;
            } while ((Math.Pow(2, potDos) <= numero));

            potDos = potDos - 1;
            Console.WriteLine("potDos= {0}", potDos);

            //define numero final segun si es par o no
            if ((numero % 2) == 0)
                Fin = "0";
            else
            {
                Fin = "1";
                RB = 1;
                nb = nb - 1;
            }

            //define la cadena con excepcion del ultimo numero
            do
            {
                dos = Math.Pow(2, potDos);
                if (dos <= nb)
                {
                    Binar = Binar + 1;
                    RB = RB + (int)Math.Pow(2, potDos);
                    nb = nb - (int)Math.Pow(2, potDos);
                }
                else Binar = Binar + 0;
                potDos--;



            } while (potDos != 0);

            if ((Binar + Fin).Length < 20)//No se me ocurrió en qué otro caso poner valor invalido, por lo que para cumplir con la consigna decidí usar este que se excede en la cantidad de caracteres que entran en el form.
                return Binar + Fin;
            else
                return "Valor inválido";

        }

        public static double operator -(Numero n1, Numero n2)
        {

            return n1.numero - n2.numero;

        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;

        }

        public static double operator /(Numero n1, Numero n2)
        {

            return n1.numero / n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        #endregion
    }
}
