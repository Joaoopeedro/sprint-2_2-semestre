using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{

    /// <summary>
    /// Classe representa a entidade (tabela) EMPRESA
    /// </summary>
    public class EmpresaDomain
    {
        public int cod_empresa { get; set; }
        public string nomeEmpresa { get; set; }
    }
}
