using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Auth;
using Ambev.GestaoFuncionarios.Domain.Services.Rsa;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ITokenService tokenService, IFuncionarioRepository funcionarioRepository, IRsaService rsaService)
        : Controller
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;
        private readonly IRsaService _rsaService = rsaService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var decryptedPassword = _rsaService.Decrypt(request.Password);
                var decryptedEmail = _rsaService.Decrypt(request.Email);
                bool correctUserPassword = await _funcionarioRepository.ValidLogin(decryptedEmail, decryptedPassword);

                if (correctUserPassword)
                {
                    var token = _tokenService.GenerateToken(decryptedEmail);
                    return Ok(new { Token = token });
                }

                return Unauthorized(new { Message = "Credenciais inválidas." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return StatusCode(500, new { Message = "Erro interno no servidor." });
            }
        }

        [HttpGet("validate-token")]
        public void ValidateToken()
        {

        }
    }
}
