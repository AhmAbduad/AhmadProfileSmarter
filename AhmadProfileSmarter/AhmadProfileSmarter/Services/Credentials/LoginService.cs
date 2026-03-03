using AhmadDAL.DataAccessLayer.Credentials;
using AhmadDAL.Models.Credentials;
using AhmadProfileSmarter.Interfaces;
using AhmadService.dto.Credentials;
using AhmadService.dto.LoginResponse;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AhmadService.Services.Credentials
{
    public class LoginService
    {
        private readonly ILogin _loginRepository;
        private readonly IConfiguration _configuration;

        public LoginService(ILogin loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto?> ValidateUserCredential(LoginDto login)
        {
            //return await _loginRepository.ValidateUserCredentials(login.Email,login.Password);


            var user = await _loginRepository
                 .ValidateUserCredentials(login.Email, login.Password);

            if (user == null)
                return null;

            var token = GenerateJwtToken(user);

            return new LoginResponseDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Token = token
            };
        }

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName)
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])
                ),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
