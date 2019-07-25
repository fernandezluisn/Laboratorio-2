using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{

    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }



        public static Correo operator +(Correo c, Paquete p)
        {
            bool b = false;
            Thread thread;

            foreach (Paquete paquete in c.paquetes)
            {
                if (paquete == p)
                {
                    b = true;
                    break;
                }
            }
            if (b == true)
                throw new TrackingIDRepetidoException("El paquete ya se encuentra en la lista.");
            else
            {
                c.paquetes.Add(p);
                thread = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(thread);
                
                try
                {
                    thread.Start();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return c;
        }

        /// <summary>
        /// devuelve los datos de una lista de paquetes
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder s = new StringBuilder();
            foreach (Paquete paquete in ((Correo)elemento).Paquetes)
            {
                s.AppendLine(string.Format("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString()));
            }

            return s.ToString();
        }

        /// <summary>
        /// cierra los hilos abiertos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
                if (hilo.IsAlive)
                    hilo.Abort();

        }
    }
}

