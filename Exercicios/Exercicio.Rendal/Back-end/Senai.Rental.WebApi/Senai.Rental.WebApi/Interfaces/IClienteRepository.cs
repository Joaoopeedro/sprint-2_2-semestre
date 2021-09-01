using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IClienteRepository
    {

        /// <summary>
        /// Listar todos os clientes
        /// </summary>
        /// <returns> Uma lista de cliente </returns>
        List<ClienteDomain> ListarTodos();


        /// <summary>
        /// Busca um cliente atraves do seu id
        /// </summary>
        /// <param name="cod_cliente"> id do cliente que sera buscado</param>
        /// <returns> Um cliente</returns>
        ClienteDomain BuscarPorId(int cod_cliente);

        /// <summary>
        /// Cadastrar um novo cliente
        /// </summary>
        /// <param name="novoCliente"> Objeto novoCliente com os novos dados</param>
        void Cadastrar(ClienteDomain novoCliente);

        /// <summary>
        /// Atualizar uma empresa Existente
        /// </summary>
        /// <param name="clienteAtualizado"> Objeto ClienteAtualizado com os novos dados atualizados</param>
        void AtualizarIdCorpo(ClienteDomain clienteAtualizado);

        /// <summary>
        /// Deletar um cliente existente
        /// </summary>
        /// <param name="cod_cliente">id do cliente que sera deletado</param>
        void Deletar(int cod_cliente);
    }
}
