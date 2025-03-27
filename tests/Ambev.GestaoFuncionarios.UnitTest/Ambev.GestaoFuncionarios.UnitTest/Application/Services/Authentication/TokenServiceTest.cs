using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace Ambev.GestaoFuncionarios.UnitTest.Application.Services.Authentication
{
    public class TokenServiceTest
    {
        IConfiguration _configuration;
        TokenService _tokenService;

        public TokenServiceTest()
        { 
            _configuration = Substitute.For<IConfiguration>();
            _configuration["JWT_KEY"].Returns("+uV7pC9xG2DQm/L3R4t5N9kz8eTQ7vYmZ8R5Fj3Ko0c=");
            _tokenService = new TokenService(_configuration);
        }

        [Fact]
        public void GenerateToken_Success()
        {
            string token = _tokenService.GenerateToken("teste.unitarios@teste.com");
            Assert.NotNull(token);
        }

        [Fact]
        public void ValidateToken_Success()
        {
            string token = _tokenService.GenerateToken("teste.unitarios@teste.com");
            bool isValid = _tokenService.ValidateToken(token);
            Assert.True(isValid);
        }

        [Fact]
        public void ValidateToken_Error()
        {
            string token = _tokenService.GenerateToken("teste.unitarios@teste.com").Replace(".","?");
            bool isValid = _tokenService.ValidateToken(token);
            Assert.False(isValid);
        }
    }
}
