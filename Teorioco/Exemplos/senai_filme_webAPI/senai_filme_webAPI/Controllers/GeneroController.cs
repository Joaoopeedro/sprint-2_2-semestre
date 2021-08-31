using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum genero encontrado");
            }

            return Ok(generoBuscado);
        }

        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {

            if (generoAtualizado.nomeGenero == null || generoAtualizado.idGenero <= 0)
            {
                return BadRequest(
                        new
                        {
                            mensagem = "Nome ou o id do genero não foi informado ! "
                        }
                    );
            }
            GeneroDomain generobuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            if (generobuscado != null)
            {
                try
                {
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);
                    return NoContent();
                }
                catch (Exception codErro)
                {
                    return BadRequest(codErro);
                }
            }
            return NotFound(
                    new
                    {
                        mensagem = "Gênero nao encontrado",
                        erroStatus = true
                    }
                );
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

        [HttpPut("{id}")]
        public IActionResult PutPorId(int id, GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscando = _generoRepository.BuscarPorId(id);

            if (generoBuscando == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Gênero nao encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);
                return NoContent();
            }
            catch (Exception erro )
            {
                return BadRequest(erro);
                
            }
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _generoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
