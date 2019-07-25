using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace EntidadesAbstractas

{
    abstract public class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {

                this.dni = ValidarDNI(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {



                this.nacionalidad = value;

            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {

                this.nombre = ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                int e;
                if (int.TryParse(value, out e) == false || value.Length > 8 || int.Parse(value) < 1)
                    throw new DniInvalidoException("DNI incorrecto");
                else
                    this.DNI = ValidarDNI(this.nacionalidad, value);
            }
        }
        #endregion

        #region metodos
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        
        public Persona(string nombre, string apellido, int dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.DNI = dni;
        }
        
        public Persona(string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;

        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(string.Format("Nombre completo: {0}, {1}", this.Apellido, this.Nombre));

            s.AppendLine(string.Format("Nacionalidad: {0}", this.Nacionalidad.ToString()));


            return s.ToString();
        }

        /// <summary>
        /// Valida que el número de dni y la nacionalidad sean correctos
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>int dato
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 90000000 && nacionalidad == Persona.ENacionalidad.Extranjero)
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            else if (dato > 89999999 && nacionalidad == Persona.ENacionalidad.Argentino)
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            else
                return dato;
        }
        /// <summary>
        /// Sobrecarga el metodo anterior, permitiendo ingresar una cadena con el dni, en lugar de un entero.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            int.TryParse(dato, out dni);
            return this.ValidarDNI(nacionalidad, dni);
        }

        /// <summary>
        /// Valida el Apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>string 
        private string ValidarNombreApellido(string dato)
        {
            if (dato.All(char.IsLetter))
                return dato;
            else
                return "nombre mal ingresado";

        }
        #endregion


    }
}
