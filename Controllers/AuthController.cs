using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using System.Threading.Tasks;
using DatingApp.API.models;
using DatingApp.API.Dtos;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
      [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IAuthRepository _repo;
        private readonly Mapper _mapper;
          private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo,IConfiguration config,Mapper mapper)
        {
            _config=config;
            _repo=repo;
            _mapper=mapper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegiserDtos _dtos)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            _dtos.Username=_dtos.Username.ToLower();
            if(await _repo.UserExists(_dtos.Username))
                return BadRequest("User Already Exist");
            var userToCreate=_mapper.Map<User>(_dtos);
            var createdUser= await _repo.Register(userToCreate,_dtos.Password);
            var userToReturn=_mapper.Map<UserForDetailedDto>(createdUser);
            return CreatedAtRoute("GetUser",new {Controller="Users",id=createdUser.Id},userToReturn);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userFromRepo=await _repo.Login(loginDto.Username.ToLower(),loginDto.Password);
            if(userFromRepo==null)
            {
                return Unauthorized();
            }
            var claims=new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.UserName)
            };
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            var tokenDiscriptor=new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(claims),
                Expires=DateTime.Now.AddDays(1),
                SigningCredentials=creds
            };
            var tokenHandler=new JwtSecurityTokenHandler();
            var token=tokenHandler.CreateToken(tokenDiscriptor);
            return Ok(new
                {
                    token=tokenHandler.WriteToken(token)
                });
        }

    }


}