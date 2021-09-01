using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        /// <summary>
        /// Listar todos os alugueis
        /// </summary>
        /// <returns> Uma lista de alugueis </returns>
        List<AluguelDomain> ListarTodos();

        /// <summary>
        /// Busca um aluguel através do seu id
        /// </summary>
        /// <param name="cod_aluguel"> id do aluguelque será buscado</param>
        /// <returns> Um aluguel </returns>
        AluguelDomain BuscarPorId(int cod_aluguel);
        /// <summary>
        /// cadatrar um novo aluguel
        /// </summary>
        /// <param name="novoAluguel"> Objeto novoAluguel com os novos dados</param>
        void Cadastrar(AluguelDomain novoAluguel);

        /// <summary>
        /// Atualiza um aluguel existente
        /// </summary>
        /// <param name="aluguelAtualizado">Objeto aluguelAtualizado com os novos dados atualizados</param>
        void AtualizarIdCorpo(AluguelDomain aluguelAtualizado);


        /// <summary>
        /// Deletar um aluguel existente 
        /// </summary>
        /// <param name="cod_aluguel"> id do aluguel que sera deletado</param>
        void Deletar(int cod_aluguel);
    }
}
