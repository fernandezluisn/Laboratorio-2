﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ArchivosException:Exception
    {
        public ArchivosException(Exception innerException):base("archivos exception",innerException)
        {

        }
    }
}
