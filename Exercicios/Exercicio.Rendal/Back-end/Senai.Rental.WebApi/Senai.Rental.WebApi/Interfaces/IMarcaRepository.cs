using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IMarcaRepository
    {
        /// <summary>
        /// Listar todas as marcas
        /// </summary>
        /// <returns> Uma lista de marca</returns>
        List<MarcaDomain> ListarTodos();

        /// <summary>
        /// Busca uma marca através do seu id
        /// </summary>
        /// <param name="cod_mar"> id da marca que será buscado</param>
        /// <returns> Uma marca</returns>
        MarcaDomain BuscarPorId(int cod_mar);
        /// <summary>
        /// cadatrar uma nova marca
        /// </summary>
        /// <param name="novaMarca"> Objeto novaMarca com os novos dados</param>
        void Cadastrar(MarcaDomain novaMarca);

        /// <summary>
        /// Atualiza uma marca existente
        /// </summary>
        /// <param name="marcaAtualizado">Objeto marcaAtualizado com os novos dados atualizados</param>
        void AtualizarIdCorpo(MarcaDomain marcaAtualizado);


        /// <summary>
        /// Deletar uma marca existente 
        /// </summary>
        /// <param name="cod_mar"> id da marca que sera deletado</param>
        void Deletar(int cod_mar);
    }
}
