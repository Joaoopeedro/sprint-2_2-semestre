﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filme_webAPI.Domains;
using senai_filme_webAPI.Interfaces;
using senai_filme_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Controllers
{
    //Define que o tipo de resposta de API sera no formato Json
    [Produces("application/json")]

    //Define que a rota de requisicao será no formato domino/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private IGeneroRepository _generoRepository { get; set; }

        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GeneroDomain> listaGenero = _generoRepository.ListarTodos();

            return Ok(listaGenero);
        }

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <returns> um status code 201 - Cread</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            //Faz a chamada para o metodo .cadastrar
            _generoRepository.Cadastrar(novoGenero);

            //Retornar o Status code 201 - Created
            return StatusCode(201);
        }
    }
}
