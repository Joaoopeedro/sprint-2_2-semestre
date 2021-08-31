using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_pessoa_webAPI.Domains;
using senai_pessoa_webAPI.Interfaces;
using senai_pessoa_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoa_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaRepository _PessoaRepository { get; set; }

        public PessoaController()
        {
            _PessoaRepository = new PessoaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<PessoaDomain> listaPessoa = _PessoaRepository.ListarTodos();
            return Ok(listaPessoa);
        }

        [HttpPost]
        public IActionResult Post(PessoaDomain novaPessoa)
        {
            _PessoaRepository.Cadastrar(novaPessoa);
            return StatusCode(201);
        }
    }
}
