using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoa_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) TELEFONE
    /// </summary>
    public class TelefoneDomain
    {
        public int idTelefone  { get; set; }
        public int  idPessoa { get; set; }
        public string numeroTelefone { get; set; }


    }
}
