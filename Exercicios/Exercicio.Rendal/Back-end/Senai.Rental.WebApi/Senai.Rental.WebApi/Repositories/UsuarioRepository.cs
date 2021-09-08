using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-L3Q203S\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        public void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public UsuarioDomain BuscarPorId(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> listaUsuario = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT idUsuario,email,senha,tipoUsuario FROM USUARIOS U
                                        inner join TIPOUSUARIO TI ON U.idTipoUsuario = TI.idTipoUsuario";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioDomain CLIENTE = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),
                            email = reader["email"].ToString(),
                            senha = reader["senha"].ToString(),
                            TIPOUsuario = new TipoUsuarioDomain
                            {
                                tipoUsuario = reader["tipoUsuario"].ToString()
                            }
                        };
                        listaUsuario.Add(CLIENTE);

                    }
                }
            }
            return listaUsuario;
        }
    }
    }
}
