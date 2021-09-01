using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ClienteDomain
    {
        public int cod_cliente { get; set; }
        public string nomeCliente { get; set; }
        public string sobreNome { get; set; }
        public DateTime dataNascimento { get; set; } 

    }
}
