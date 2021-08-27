﻿using senai_filme_webAPI.Domains;
using senai_filme_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Repositories
{

    /// <summary>
    /// Classe reponsavel pelo repositorio dos GENEROS
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// 
        /// </summary>

        private string stringConexao = @"Data Source=DESKTOP-L3Q203S\SQLEXPRESS; initial catalog=CATALOGO_JOAO; user Id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto novoGenero com com as informacoes que seram cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO GENERO (nomegenero) VALUES ('" + novoGenero.nomeGenero + "')";

                con.Open();

                using (SqlCommand cmd  = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int idGenero)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listar todos os generos
        /// </summary>
        /// <returns>Uma Lista de Generos</returns>

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            //
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idGenero,nomeGenero FROM GENERO";

                //ABRE A CONEXAO COM O BANCO DE DADOS
                con.Open();

                SqlDataReader rdr;

                //Declara o SqlCommand passando da query que será executada e a conexao com parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        //

                        GeneroDomain GENERO = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                            nomeGenero = rdr[1].ToString()
                        };

                        listaGenero.Add(GENERO);

                    }
                       
                }
            }
            return listaGenero;
        }
    }
}
