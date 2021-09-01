using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IModeloRepository
    {

        /// <summary>
        /// Listar todos ops modelos 
        /// </summary>
        /// <returns> uma lista de modelo</returns>
        List<ModeloDomain> ListarTodos();

        /// <summary>
        /// Busca um modelo atraves de seu id
        /// </summary>
        /// <param name="cod_mod">id de modelo que sera buscado</param>
        /// <returns> Um modelo</returns>
        ModeloDomain BuscarPorId(int cod_mod);


        /// <summary>
        /// Cadastrar um novo modelo
        /// </summary>
        /// <param name="novoModelo"> Objeto novoModelo com os novos dados </param>
        void Cadastrar(ModeloDomain novoModelo);


        /// <summary>
        /// Atualizar uma marca existente
        /// </summary>
        /// <param name="modeloAtualizado"> Objeto modeloAtualizado com os novos dados atualizados</param>
        void AtualizarIdCorpo(ModeloDomain modeloAtualizado);


        /// <summary>
        /// Deletar um modelo existente
        /// </summary>
        /// <param name="cod_mod"></param>
        void Deletar(int cod_mod);
    }
}
