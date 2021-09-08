using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_filme_webAPI.Domains;
using senai_filme_webAPI.Interfaces;
using senai_filme_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);
            if (usuarioBuscado == null)
                return NotFound("E-mail ou senha inválidos!");

            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.permissao),
                new Claim("Claim personalizada", "Valor Teste")
            };

            // return Ok(usuarioBuscado);

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

            // Define as credenciais do token - signature
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Composição do token
            var meuToken = new JwtSecurityToken(
                    issuer: "Filmes.webAPI",                // emissor do token
                    audience: "Filmes.webAPI",              // destinatário do token
                    claims: minhasClaims,                   // dados definidos acima (linha 39)
                    expires: DateTime.Now.AddMinutes(30),   // tempo de expiração do token
                    signingCredentials: creds               // credenciais do token
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(meuToken)
            });
        }
    }
}
