using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        //private string stringConexao = @"Data Source=DESKTOP-L3Q203S\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        private string stringConexao = @"Data Source=NOTE0113A1\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=Senai@132";
        public void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE VEICULO SET cod_empresa = @cod_empresa, cod_mod = @cod_mod,placa = @placa	WHERE cod_veic = @cod_veic";

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@cod_empresa", veiculoAtualizado.cod_empresa);
                    cmd.Parameters.AddWithValue("@cod_mod", veiculoAtualizado.cod_mod);
                    cmd.Parameters.AddWithValue("@placa", veiculoAtualizado.placa);
                    cmd.Parameters.AddWithValue("@cod_veic", veiculoAtualizado.cod_veic);
                    

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    

        public VeiculoDomain BuscarPorId(int cod_veic)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = $@"SELECT V.cod_veic, V.placa,M.nomemod, MA.nomeMar,E.nomeEmpresa FROM VEICULO V
                                            INNER JOIN EMPRESA E ON V.cod_empresa = E.cod_empresa
                                            INNER JOIN MODELO M ON V.cod_mod = M.cod_mod
                                            INNER JOIN MARCA MA ON M.cod_mar = MA.cod_mar
                                            WHERE cod_veic = @cod_veic";

                con.Open();
                SqlDataReader reader;


                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@cod_veic", cod_veic);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain veiculoBuscar = new VeiculoDomain
                        {
                            cod_veic = Convert.ToInt32(reader[0]),
                            placa = reader[1].ToString(),
                            MODELO = new ModeloDomain
                            {
                                nomemod = reader[2].ToString(),
                                MARCA = new MarcaDomain
                                {
                                    nomeMar = reader[3].ToString()
                                }
                            },
                            EMPRESA = new EmpresaDomain
                            {
                                nomeEmpresa = reader[4].ToString()
                            }
                            

                        };
                        return veiculoBuscar;

                    }
                    return null;
                }

            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO VEICULO(cod_empresa,cod_mod,placa) VALUES (@cod_empresa,@cod_mod,@placa)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@cod_empresa", novoVeiculo.cod_empresa);
                    cmd.Parameters.AddWithValue("@cod_mod", novoVeiculo.cod_mod);
                    cmd.Parameters.AddWithValue("@placa", novoVeiculo.placa);
                    

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int cod_veic)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE cod_veic = @cod_veic";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@cod_veic", cod_veic);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculo = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = $@"SELECT V.cod_veic, V.placa,M.nomemod, MA.nomeMar,E.nomeEmpresa FROM VEICULO V
                                            INNER JOIN EMPRESA E ON V.cod_empresa = E.cod_empresa
                                            INNER JOIN MODELO M ON V.cod_mod = M.cod_mod
                                            INNER JOIN MARCA MA ON M.cod_mar = MA.cod_mar";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain VEICULO = new VeiculoDomain()
                        {
                            cod_veic = Convert.ToInt32(rdr[0]),
                            placa = rdr[1].ToString(),
                            MODELO = new ModeloDomain
                            {
                                nomemod = rdr[2].ToString(),
                                MARCA = new MarcaDomain
                                {
                                    nomeMar = rdr[3].ToString()
                                }
                            },
                            EMPRESA = new EmpresaDomain
                            {
                                nomeEmpresa = rdr[4].ToString()
                            }
                        };
                        listaVeiculo.Add(VEICULO);

                    }
                }
            }
            return listaVeiculo;
        }
    }
}
