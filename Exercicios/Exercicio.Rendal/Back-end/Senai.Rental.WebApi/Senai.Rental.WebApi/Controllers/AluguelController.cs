﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AluguelController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAluguel = _AluguelRepository.ListarTodos();

            return Ok(listaAluguel);
         }

        [HttpGet("{cod}")]
        public IActionResult GetPorId(int cod)
        {
            try
            {
                AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(cod);
                if (aluguelBuscado == null)
                {
                    return NotFound("Nenhum aluguel encontrado");
                }

                return Ok(aluguelBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutIdBody(AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.cod_cliente == null || aluguelAtualizado.cod_veic == null || aluguelAtualizado.dataRetirada == null||aluguelAtualizado.dataDev == null||aluguelAtualizado.cod_aluguel == null)
            {
                return BadRequest(
                        new
                        {
                            mensagem = "Informações não foram informados corretamente ! "
                        }
                    );
            }

            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(aluguelAtualizado.cod_aluguel);

            if (aluguelBuscado != null)
            {
                try
                {
                    _AluguelRepository.AtualizarIdCorpo(aluguelAtualizado);
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
                        mensagem = "Aluguel nao encontrado",
                        erroStatus = true
                    }
                );
        }
        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _AluguelRepository.Cadastrar(novoAluguel);
            return StatusCode(201);
        }
        [HttpDelete("excluir/{cod}")]
        public IActionResult Delete(int cod)
        {
            _AluguelRepository.Deletar(cod);
            return StatusCode(204);
        }

    }
}
