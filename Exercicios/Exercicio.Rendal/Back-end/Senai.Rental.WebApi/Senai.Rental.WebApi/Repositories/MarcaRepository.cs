using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        public void AtualizarIdCorpo(MarcaDomain marcaAtualizado)
        {
            throw new NotImplementedException();
        }

        public MarcaDomain BuscarPorId(int cod_mar)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(MarcaDomain novaMarca)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int cod_mar)
        {
            throw new NotImplementedException();
        }

        public List<MarcaDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
