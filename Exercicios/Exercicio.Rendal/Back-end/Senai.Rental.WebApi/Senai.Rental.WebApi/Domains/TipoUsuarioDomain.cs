﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class TipoUsuarioDomain
    {
        public int idTipoUsuario { get; set; }

        [Required (ErrorMessage = "Informe o  tipo de Usuario")]
        public string tipoUsuario  { get; set; }
        
        
    }
}
