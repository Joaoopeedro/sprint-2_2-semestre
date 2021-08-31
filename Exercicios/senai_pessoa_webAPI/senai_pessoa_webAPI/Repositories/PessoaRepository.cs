using senai_pessoa_webAPI.Domains;
using senai_pessoa_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoa_webAPI.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {

        private string stringConexao = @"Data Source=DESKTOP-L3Q203S\SQLEXPRESS;  initial catalog=EMPRESA_JOAO; user Id=sa; pwd=senai@132 ";
        public void AtualizarIdurl(int idPessoa, PessoaDomain pessoa)
        {
            throw new NotImplementedException();
        }

        public PessoaDomain BuscarPorId(int idPessoa)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(PessoaDomain novaPessoa)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO PESSOA (nomePessoa,cnh) VALUES (@novaPessoa,@novoCnh)";

                con.Open();


                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@novaPessoa", novaPessoa.nomePessoa);
                    cmd.Parameters.AddWithValue("@novoCnh", novaPessoa.cnh);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idPessoa)
        {
            throw new NotImplementedException();
        }

        public List<PessoaDomain> ListarTodos()
        {
            List<PessoaDomain> listaPessoa = new List<PessoaDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idPessoa, nomePessoa,cnh FROM PESSOA";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        PessoaDomain PESSOA = new PessoaDomain()
                        {
                            idPessoa = Convert.ToInt32(rdr[0]),
                            nomePessoa = rdr[1].ToString(),
                            cnh = rdr[2].ToString()
                        };

                        listaPessoa.Add(PESSOA);
                    }
                }
            }
            return listaPessoa;
        }
    }
}
