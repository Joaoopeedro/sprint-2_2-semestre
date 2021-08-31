using senai_pessoa_webAPI.Domains;
using senai_pessoa_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoa_webAPI.Repositories
{
    public class EmailRepository : IEmailRepository
    {

        private string stringConexao = @"Data Source= DESKTOP-L3Q203S\SQLEXPRESS;  initial catalog = EMPRESA_JOAO; user Id= sa; pwd=senai@132 ";

        public void AtualizarIdUrl(int idEmail, EmailDomain email)
        {
            throw new NotImplementedException();
        }

        public EmailDomain BuscarPorId(int idEmail)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(EmailDomain novoEmail)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO EMAIL (idPessoa,end_email) VALUES (@idPessoa,@novoEmail)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@idPessoa", novoEmail.idPessoa);
                    cmd.Parameters.AddWithValue("@novoEmail", novoEmail.end_email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idEmail)
        {
            throw new NotImplementedException();
        }

        public List<EmailDomain> ListarTodos()
        {
            List<EmailDomain> listaEmail = new List<EmailDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idEmail,idPessoa,end_email FROM EMAIL";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EmailDomain EMAIL = new EmailDomain()
                        {
                            idEmail = Convert.ToInt32(rdr[0]),
                            idPessoa = Convert.ToInt32(rdr[1]),
                            end_email = rdr[2].ToString()

                        };
                        listaEmail.Add(EMAIL);

                    }
                }
            }
            return listaEmail;
        }
    }
}
