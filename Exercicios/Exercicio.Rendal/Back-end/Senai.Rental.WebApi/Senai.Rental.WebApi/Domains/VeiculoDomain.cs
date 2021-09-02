using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class VeiculoDomain
    {
        public int cod_veic { get; set; }
        public int cod_empresa { get; set; }
        public int cod_mod { get; set; }
        public string placa { get; set; }
        public ModeloDomain MODELO { get; set; }
        public EmpresaDomain EMPRESA { get; set; }
    }
}
