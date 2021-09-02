using Microsoft.AspNetCore.Http;
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
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _clienteRepository { get; set; }

        public ClientesController()
        {
            _clienteRepository = new ClienteRepository();

        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaCliente = _clienteRepository.ListarTodos();

            return Ok(listaCliente);
        }

        [HttpGet("{cod}")]
        public IActionResult GetById(int cod)
        {
            ClienteDomain clienteBuscado = _clienteRepository.BuscarPorId(cod);

            if (clienteBuscado == null)
            {
                return NotFound("Nenhum cliente encontrado");
            }

            return Ok(clienteBuscado);
        }

        [HttpPut]
        public IActionResult PutIdBody(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.nomeCliente == null || clienteAtualizado.sobreNome == null || clienteAtualizado.cod_cliente <=0) 
            {
                return BadRequest(
                        new
                        {
                            mensagem = "Informações não foram informados corretamente ! "
                        }
                    );
            }

            ClienteDomain clienteBuscado = _clienteRepository.BuscarPorId(clienteAtualizado.cod_cliente);

            if (clienteBuscado != null)
            {
                try
                {
                    _clienteRepository.AtualizarIdCorpo(clienteAtualizado);
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
                        mensagem = "Cliente nao encontrado",
                        erroStatus = true
                    }
                );
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _clienteRepository.Cadastrar(novoCliente);
            return StatusCode(201);
        }

        [HttpDelete("excluir/{cod}")]
        public IActionResult Delete(int cod)
        {
            _clienteRepository.Deletar(cod);
            return StatusCode(204);

        }
    }
}
