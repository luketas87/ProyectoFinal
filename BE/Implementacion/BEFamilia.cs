﻿using BE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BE.Implementacion
{
    public class BEFamilia 
    {
        public int IdFamilia { get; set; }

        public string Descripcion { get; set; }

        public List<BEPatente> Patentes { get; set; }
     
    }
}
