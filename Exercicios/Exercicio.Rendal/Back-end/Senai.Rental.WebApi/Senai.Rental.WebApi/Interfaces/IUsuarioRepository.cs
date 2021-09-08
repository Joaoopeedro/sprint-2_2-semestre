using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> ListarTodos();


        UsuarioDomain BuscarPorId(int idUsuario);

        void Cadastrar(UsuarioDomain novoUsuario);


        void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado);



        void Deletar(int idUsuario);
    }
}
