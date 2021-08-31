using senai_pessoa_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoa_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório EmailRepository
    /// </summary>
    interface IEmailRepository
    {
        List<EmailDomain> ListarTodos();

        EmailDomain BuscarPorId(int idEmail);

        void Cadastrar(EmailDomain novoEmail);

        void AtualizarIdUrl(int idEmail, EmailDomain email);

        void Deletar(int idEmail);
    }
}
