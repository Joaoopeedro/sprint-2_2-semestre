using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculoRepository
    {

        /// <summary>
        /// Listar todos os veiculos 
        /// </summary>
        /// <returns> Uma lista de clientes </returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// Busca um veiculo atraves do seu id 
        /// </summary>
        /// <param name="cod_veic"> id do veiculo que sera buscado</param>
        /// <returns> Um veiculo</returns>
        VeiculoDomain BuscarPorId(int cod_veic);

        /// <summary>
        /// Cadastrar um novo veiculo
        /// </summary>
        /// <param name="novoVeiculo"> Objeto novoVeiculo com os novos dados</param>
        void Cadastrar(VeiculoDomain novoVeiculo);


        /// <summary>
        /// Atualizar um veiculo existente
        /// </summary>
        /// <param name="veiculoAtualizado">Objeto veiculoAtualizado co os novos dados atualizados</param>
        void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado);

        /// <summary>
        /// Deletar um veiculo existente 
        /// </summary>
        /// <param name="cod_veic">id do veiculo que sera deletado</param>
        void Deletar(int cod_veic);
    }
}
