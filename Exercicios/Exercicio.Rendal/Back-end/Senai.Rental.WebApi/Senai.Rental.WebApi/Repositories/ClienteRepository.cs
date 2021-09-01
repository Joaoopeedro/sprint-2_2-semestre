using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-L3Q203S\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        public void AtualizarIdCorpo(ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE CLIENTE SET nomeCliente = @nomeCliente, sobreNome = @sobreNome,dataNascimento = @dataNasc	WHERE cod_cliente = @cod_cliente";

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody,con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobreNome", clienteAtualizado.sobreNome);
                    cmd.Parameters.AddWithValue("@dataNasc", clienteAtualizado.dataNascimento);
                    cmd.Parameters.AddWithValue("@codCliente", clienteAtualizado.cod_cliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int cod_cliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT cod_cliente, nomecliente,sobreNome,dataNascimento FROM CLIENTE WHERE cod_cliente = @cod_cliente";

                con.Open();
                SqlDataReader reader;


                using (SqlCommand cmd = new SqlCommand(querySelectById,con))
                {
                    cmd.Parameters.AddWithValue("@cod_cliente", cod_cliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscar = new ClienteDomain
                        {
                            cod_cliente = Convert.ToInt32(reader[0]),
                            nomeCliente = reader[1].ToString(),
                            sobreNome = reader[2].ToString(),
                            dataNascimento = Convert.ToDateTime(reader[3])
                        };
                        return clienteBuscar;

                    }
                    return null;
                }

            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO CLIENTE (nomeCliente,sobreNome,dataNascimento) VALUES (@nomeCliente,@sobreNome,@dataNasci)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobreNome", novoCliente.sobreNome);
                    cmd.Parameters.AddWithValue("@dataNasci", novoCliente.dataNascimento);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int cod_cliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE cod_cliente = @cod_cliente";

                using (SqlCommand cmd = new SqlCommand (queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@cod_cliente", cod_cliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaCliente = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT cod_cliente,nomeCliente, sobreNome,dataNascimento FROM CLIENTE";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ClienteDomain CLIENTE = new ClienteDomain()
                        {
                            cod_cliente = Convert.ToInt32(reader[0]),
                            nomeCliente = reader[1].ToString(),
                            sobreNome = reader[2].ToString(),
                            dataNascimento = Convert.ToDateTime(reader[3])
                        };
                        listaCliente.Add(CLIENTE);

                    }
                }
            }
            return listaCliente;
        }
    }
}
