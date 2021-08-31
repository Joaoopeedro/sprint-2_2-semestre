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
    public class EmailController : ControllerBase
    {
        private IEmailRepository _EmailRepository { get; set; }

        public EmailController()
        {
            _EmailRepository = new EmailRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<EmailDomain> listaEmail = _EmailRepository.ListarTodos();

            return Ok(listaEmail);
        }

        [HttpPost]
        public IActionResult Post(EmailDomain novoEmail)
        {
            _EmailRepository.Cadastrar(novoEmail);
            return StatusCode(201);
        }
    }
}
