using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IEmpresaRepository
    {

        /// <summary>
        /// Listar todas as empresas
        /// </summary>
        /// <returns> Uma lista de empresa</returns>
        List<EmpresaDomain> ListarTodos();

        /// <summary>
        /// Busca uma empresa através do seu id
        /// </summary>
        /// <param name="cod_empresa"> id da empresa que será buscado</param>
        /// <returns> Uma empresa</returns>
        EmpresaDomain BuscarPorId(int cod_empresa);
        /// <summary>
        /// cadatrar uma nova empresa
        /// </summary>
        /// <param name="novaEmpresa"> Objeto novaEmpresa com os novos dados</param>
        void Cadastrar(EmpresaDomain novaEmpresa);

        /// <summary>
        /// Atualiza uma empresa existente
        /// </summary>
        /// <param name="empresaAtualizado">Objeto empresaAtualizado com os novos dados atualizados</param>
        void AtualizarIdCorpo(EmpresaDomain empresaAtualizado);


        /// <summary>
        /// Deletar uma empresa existente 
        /// </summary>
        /// <param name="cod_empresa"> id da empresa que sera deletado</param>
        void Deletar(int cod_empresa);

    }
}
