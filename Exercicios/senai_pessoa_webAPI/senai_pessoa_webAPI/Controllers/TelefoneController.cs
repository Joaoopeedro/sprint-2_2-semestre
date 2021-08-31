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
    public class TelefoneController : ControllerBase
    {
        private ITelefoneRepository _TelefoneRepository { get; set; }

        public TelefoneController()
        {
            _TelefoneRepository = new TelefoneRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<TelefoneDomain> listaTelefone = _TelefoneRepository.ListarTodos();

            return Ok(listaTelefone);
        }
        [HttpPost]
        public IActionResult Post(TelefoneDomain novoTelefone)
        {
            _TelefoneRepository.Cadastrar(novoTelefone);
            return StatusCode(201);
        }
    }
}
