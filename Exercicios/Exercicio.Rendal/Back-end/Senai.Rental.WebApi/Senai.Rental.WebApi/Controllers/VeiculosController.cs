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
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculo = _VeiculoRepository.ListarTodos();
            return Ok(listaVeiculo);
        }

        [HttpGet("{cod}")]
        public IActionResult GetPorId (int cod)
        {
            try
            {
                VeiculoDomain veiculoBuscado = _VeiculoRepository.BuscarPorId(cod);
                if (veiculoBuscado == null)
                {
                    return NotFound("Nenhum veiculo encontrado");
                }
                return Ok(veiculoBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutIdBody(VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.cod_empresa <= 0||veiculoAtualizado.cod_mod <= 0||veiculoAtualizado.placa == null||veiculoAtualizado.cod_veic <= 0)
            {
                return BadRequest(
                        new
                        {
                            mensagem = "Informações não foram informados corretamente ! "
                        }
                    );
            }

            VeiculoDomain veiculoBuscado = _VeiculoRepository.BuscarPorId(veiculoAtualizado.cod_veic);

            if (veiculoBuscado != null)
            {
                try
                {
                    _VeiculoRepository.AtualizarIdCorpo(veiculoAtualizado);
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
                        mensagem = "Veiculo nao encontrado",
                        erroStatus = true
                    }
                );
        }
        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _VeiculoRepository.Cadastrar(novoVeiculo);
            return StatusCode(201);
        }

        [HttpDelete("excluir/{cod}")]
        public IActionResult Delete(int cod)
        {
            _VeiculoRepository.Deletar(cod);
            return StatusCode(204);
        }
    }
}
