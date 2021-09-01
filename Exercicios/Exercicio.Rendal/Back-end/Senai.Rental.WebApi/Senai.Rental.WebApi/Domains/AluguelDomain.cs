using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomain
    {
        public int cod_aluguel { get; set; }
        public int cod_cliente { get; set; }
        public int cod_veic { get; set; }
        public DateTime dataRetirada { get; set; }
        public DateTime dataDev { get; set; }

    }
}
