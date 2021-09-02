using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-L3Q203S\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        //private string stringConexao = @"Data Source=NOTE0113G2\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=Senai@132";
        public void AtualizarIdCorpo(AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE ALUGUEL SET cod_cliente = @cod_cliente, cod_veic = @cod_veic,dataRetirada = @dataRet,dataDev = @dataDev	WHERE cod_aluguel = @cod_aluguel";

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@cod_cliente", aluguelAtualizado.cod_cliente);
                    cmd.Parameters.AddWithValue("@cod_veic", aluguelAtualizado.cod_veic);
                    cmd.Parameters.AddWithValue("@dataRet", aluguelAtualizado.dataRetirada);
                    cmd.Parameters.AddWithValue("@dataDev", aluguelAtualizado.dataDev);
                    cmd.Parameters.AddWithValue("@cod_aluguel", aluguelAtualizado.cod_aluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int cod_aluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = $@"SELECT A.cod_aluguel,C.nomeCliente,V.placa,M.nomemod,MA.nomeMar,A.dataRetirada,A.dataDev FROM ALUGUEL A 
                                        INNER JOIN VEICULO V ON A.cod_veic = v.cod_veic
                                        INNER JOIN CLIENTE C ON A.cod_cliente = C.cod_cliente
                                        INNER JOIN MODELO M ON V.cod_mod = M.cod_mod
                                        INNER JOIN MARCA MA ON M.cod_mar = MA.cod_mar
                                        WHERE cod_aluguel = @cod_aluguel";

                con.Open();
                SqlDataReader reader;


                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@cod_aluguel", cod_aluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain aluguelBuscar = new AluguelDomain
                        {
                            cod_aluguel = Convert.ToInt32(reader[0]),
                            dataRetirada = Convert.ToDateTime(reader[5]),
                            dataDev = Convert.ToDateTime(reader[6]),
                            VEICULO = new VeiculoDomain
                            {
                                placa = reader[2].ToString(),
                                MODELO = new ModeloDomain
                                {
                                    nomemod = reader[3].ToString(),
                                    MARCA = new MarcaDomain
                                    {
                                        nomeMar = reader[4].ToString()
                                    }
                                }

                            },
                            CLIENTE = new ClienteDomain
                            {
                                nomeCliente = reader[1].ToString()
                            }

                        };
                        return aluguelBuscar;

                    }
                    return null;
                }

            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ALUGUEL(cod_cliente,cod_veic,dataRetirada,dataDev) VALUES (@cod_cliente,@cod_veic,@dataRetirada,@dataDev)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@cod_cliente", novoAluguel.cod_cliente);
                    cmd.Parameters.AddWithValue("@cod_veic", novoAluguel.cod_veic);
                    cmd.Parameters.AddWithValue("@dataRetirada", novoAluguel.dataRetirada);
                    cmd.Parameters.AddWithValue("@dataDev", novoAluguel.dataDev);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int cod_aluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE cod_aluguel = @cod_aluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@cod_aluguel", cod_aluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAluguel = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = $@"SELECT A.cod_aluguel,C.nomeCliente,V.placa,M.nomemod,MA.nomeMar,A.dataRetirada,A.dataDev FROM ALUGUEL A 
                                        INNER JOIN VEICULO V ON A.cod_veic = v.cod_veic
                                        INNER JOIN CLIENTE C ON A.cod_cliente = C.cod_cliente
                                        INNER JOIN MODELO M ON V.cod_mod = M.cod_mod
                                        INNER JOIN MARCA MA ON M.cod_mar = MA.cod_mar";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain ALUGUEL = new AluguelDomain
                        {
                            cod_aluguel = Convert.ToInt32(rdr[0]),
                            dataRetirada = Convert.ToDateTime(rdr[5]),
                            dataDev = Convert.ToDateTime(rdr[6]),
                            VEICULO = new VeiculoDomain
                            {
                                placa = rdr[2].ToString(),
                                MODELO = new ModeloDomain
                                {
                                    nomemod = rdr[3].ToString(),
                                    MARCA = new MarcaDomain
                                    {
                                        nomeMar = rdr[4].ToString()
                                    }
                                }

                            },
                            CLIENTE = new ClienteDomain
                            {
                                nomeCliente = rdr[1].ToString()
                            }
                        };
                        listaAluguel.Add(ALUGUEL);
                    }
                }
            }
            return listaAluguel;
        }
    }
}
