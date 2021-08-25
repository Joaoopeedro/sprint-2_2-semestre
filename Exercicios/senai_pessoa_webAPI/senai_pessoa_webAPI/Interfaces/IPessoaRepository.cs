using senai_pessoa_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoa_webAPI.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório PessoaRepository
    /// </summary>
    interface IPessoaRepository
    {
        List<PessoaDomain> ListarTodos();

        PessoaDomain BuscarPorId(int idPessoa);

        void Cadastrar(PessoaDomain novaPessoa);

        void AtualizarIdurl(int idPessoa, PessoaDomain pessoa);

        void Deletar(int idPessoa);
    }
}
