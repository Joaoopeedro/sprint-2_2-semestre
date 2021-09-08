using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-L3Q203S\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        public void AtualizarIdCorpo(TipoUsuarioDomain TipoAtualizado)
        {
            throw new NotImplementedException();
        }

        public TipoUsuarioDomain BuscarPorId(int idTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoUsuarioDomain novoTipo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuarioDomain> ListarTodos()
        {
            List<TipoUsuarioDomain> listaTipo = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM TIPOUSUARIO";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoUsuarioDomain TIPO = new TipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(reader[0]),
                            tipoUsuario = reader[1].ToString()
                        };
                        listaTipo.Add(TIPO);

                    }
                }
            }
            return listaTipo;
        }
    }
    }
}
