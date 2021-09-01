using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public void AtualizarIdCorpo(EmpresaDomain empresaAtualizado)
        {
            throw new NotImplementedException();
        }

        public EmpresaDomain BuscarPorId(int cod_empresa)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(EmpresaDomain novaEmpresa)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int cod_empresa)
        {
            throw new NotImplementedException();
        }

        public List<EmpresaDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
