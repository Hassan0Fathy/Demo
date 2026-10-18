using AutoMapper;
using Demo.Dtos;
using Demo.Models;
using Demo.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Demo.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUOW _uow;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthController(IUOW uow , IConfiguration configuration , IMapper mapper)
        {
            _uow = uow;
            _configuration = configuration;
            _mapper = mapper;
        }
        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credss = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claimss = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier , user.UserId.ToString()),
                 new Claim(ClaimTypes.Email , user.Email),
                 new Claim(ClaimTypes.Name , user.FullName),
                 new Claim(ClaimTypes.Role , user.Role),
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                signingCredentials: credss,
                claims:claimss,
                expires:DateTime.Now.AddHours(2)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var search = await _uow.User.GetByEmail(dto.Email);
            if(search != null)
            {
                return Unauthorized();
            }
            var res = _mapper.Map<User>(dto);
            await _uow.User.Create(res);
            await _uow.Save();
            return Created(string.Empty , new {message = $"Welcome, {dto.FullName}!"});
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var search = await _uow.User.GetByEmail(dto.Email);
            if(search.Email != dto.Email && search.PasswordHash != dto.PasswordHash)
            {
                return Unauthorized();
            }
            return Ok(GenerateToken(search));

        }
    }
}
