﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DniInvalidoException:Exception
    {
        private string mensajeBase;

        public DniInvalidoException()
        {

        }
        public DniInvalidoException(Exception e):base("",e)
        {

        }
        public DniInvalidoException(string message):base(message)
        {

        }
        public DniInvalidoException(string message, Exception e):base(message, e)
        {

        }
    }
}
