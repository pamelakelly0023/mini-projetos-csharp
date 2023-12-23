using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ListaTarefas.Controllers;
using ListaTarefas.Models;
using ListaTarefas.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ListaTarefas.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;

        public AuthController( 
                              SignInManager<IdentityUser> signInManager, 
                              UserManager<IdentityUser> userManager, 
                              IOptions<AppSettings> appSettings,
                              ILogger<AuthController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar (RegistrarUsuarioModel registrarUser)
        {
            var user = new IdentityUser
            {
                UserName = registrarUser.Email,
                Email = registrarUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registrarUser.Password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                //return CreatedAtAction("User", new { user = user.Email }, user);
                return Ok(GerarTokenJWT());
            } 
            foreach (var error in result.Errors)
            {
                var notificacao = error.Description;
                return BadRequest(notificacao);
            }

            _logger.LogInformation("Usuario registrado:" + user);
            return CreatedAtAction("Usuario", registrarUser);
        }

        [HttpGet]
        private string GerarTokenJWT()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            
            _logger.LogInformation("Token criado:" + token);
            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }
    }

}