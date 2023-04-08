using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webtesting.Dtos.User;

namespace webtesting.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRespository _authRepo;

        public AuthController(IAuthRespository authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegistrationDto request){
            var response = await _authRepo.Register(
                new Users{Username = request.Username}, request.password
            );
            if(!response.status){
                return BadRequest(response);
            }
            response.Mymessage = "Succesfully Logged In";
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request){
            var response = await _authRepo.Login(
                request.Username, request.password
            );
            if(!response.status){
                return BadRequest(response);
            }
            
            return Ok(response);
        }
    }
}