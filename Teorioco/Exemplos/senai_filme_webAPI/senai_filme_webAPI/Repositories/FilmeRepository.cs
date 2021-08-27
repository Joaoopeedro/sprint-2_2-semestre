using senai_filme_webAPI.Domains;
using senai_filme_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-L3Q203S\SQLEXPRESS; initial catalog=CATALOGO_JOAO; user Id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(FilmeDomain filmeAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idFilme, FilmeDomain filmeAtualizado)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int idFilme)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Cadastrar um novo filme
        /// </summary>
        /// <param name="novoFilme"></param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert;

                if (novoFilme.idGenero > 0)
                {
                    queryInsert = "INSERT INTO FILME (idGenero,tituloFilme) VALUES ("+novoFilme.idGenero +",'" + novoFilme.tituloFilme + "')";

                }
                else
                {
                    queryInsert = "INSERT INTO FILME (tituloFilme) VALUES ('" + novoFilme.tituloFilme + "')";
                }

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idFilme)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listarFilme = new List<FilmeDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idFilme,ISNULL(G.idGenero,0)AS idGenero  , tituloFilme,ISNULL(nomeGenero,'NAO CADASTRADO')AS nomegenero  FROM FILME F LEFT JOIN GENERO G ON F.idGenero = G.idGenero";
                    


                con.Open();

                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain FILME = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),
                            idGenero = Convert.ToInt32(rdr[1]),
                            tituloFilme = rdr[2].ToString(),
                            genero = new GeneroDomain()
                            {
                                idGenero = Convert.ToInt32(rdr[1]),
                                nomeGenero = rdr[3].ToString()
                            }
                    };

                        listarFilme.Add(FILME);

                    }
                }
            }
            return listarFilme;
        }
    }
}
