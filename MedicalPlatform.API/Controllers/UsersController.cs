using MedicalPlatform.API.Contracts.Users;
using MedicalPlatform.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController: ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Register(
            [FromBody] RegisterUserRequest request,
            UserService userService)
        {
            await userService.Register(request.UserName, request.Password);
            return Results.Ok();
        }

        [HttpPost]
        public async Task<IResult> LogIn(
            [FromBody] LoginUserRequest request,
            UserService usersService)
        {
            var token = await usersService.Login(request.UserName, request.Password);
            return Results.Ok(token);
        }
        [Authorize]
        [HttpGet]
        public IResult SayHello()
        {
            return Results.Ok("Hello, World!");
        }

        [HttpGet]
        public IActionResult Connect()
        {
            return Ok("Connected");
        }
    }
}
