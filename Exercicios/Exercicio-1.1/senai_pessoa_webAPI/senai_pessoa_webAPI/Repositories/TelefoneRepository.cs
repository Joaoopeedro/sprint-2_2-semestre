using senai_pessoa_webAPI.Domains;
using senai_pessoa_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoa_webAPI.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private string stringConexao = @"Data Source= DESKTOP-L3Q203S\SQLEXPRESS;  initial catalog = EMPRESA_JOAO; user Id= sa; pwd=senai@132 ";

        public void AtualizarIdUrl(int idTelefone, TelefoneDomain telefone)
        {
            throw new NotImplementedException();
        }

        public TelefoneDomain BuscarPorId(int idTelefone)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TelefoneDomain novoTelefone)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TELEFONE (idPessoa, numeroTelefone) VALUES (@idPessoa, @numTel)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@idPessoa", novoTelefone.idPessoa);
                    cmd.Parameters.AddWithValue("@numTel", novoTelefone.numeroTelefone);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idTelefone)
        {
            throw new NotImplementedException();
        }

        public List<TelefoneDomain> ListarTodos()
        {
            List<TelefoneDomain> listaTelefone = new List<TelefoneDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idTelefone, idPessoa, numeroTelefone FROM  TELEFONE";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con ))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TelefoneDomain TELEFONE = new TelefoneDomain()
                        {
                            idTelefone = Convert.ToInt32(rdr[0]),
                            idPessoa = Convert.ToInt32(rdr[1]),
                            numeroTelefone = rdr[2].ToString()
                        };
                        listaTelefone.Add(TELEFONE);

                    }
                }
            }
            return listaTelefone;
        }
    }
}
