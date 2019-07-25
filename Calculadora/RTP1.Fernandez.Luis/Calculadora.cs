using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRTP
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string ope;
            switch (operador)
            {
                case "-":
                    ope = "-";
                    break;
                case "*":
                    ope = "*";
                    break;
                case "/":
                    ope = "/";
                    break;
                default:
                    ope = "+";
                    break;
            }

            return ope;
        }

        public double Operar(Numero num1, Numero num2, string operador)
        {
            string signo = ValidarOperador(operador);
            double result;


            switch (signo)
            {
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (double.IsInfinity(num1 / num2))
                        return double.MinValue;
                    else return num1 / num2;
                default:
                    result = num1 + num2;
                    break;
            }


            return result;
        }
    }
}
