using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        public void AtualizarIdCorpo(ModeloDomain modeloAtualizado)
        {
            throw new NotImplementedException();
        }

        public ModeloDomain BuscarPorId(int cod_mod)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ModeloDomain novoModelo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int cod_mod)
        {
            throw new NotImplementedException();
        }

        public List<ModeloDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
