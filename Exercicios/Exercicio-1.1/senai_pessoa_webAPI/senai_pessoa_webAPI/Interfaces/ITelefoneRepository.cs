using senai_pessoa_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoa_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório TelefoneRepository
    /// </summary>
    interface ITelefoneRepository
    {
        List<TelefoneDomain> ListarTodos();

        TelefoneDomain BuscarPorId(int idTelefone);

        void Cadastrar(TelefoneDomain novoTelefone);

        void AtualizarIdUrl(int idTelefone, TelefoneDomain telefone);

        void Deletar(int idTelefone);
    }
}
