using API.Services;
using Domain.DTO.Usuario;
using Domain.Models.Aurthenticated;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/authentication")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IHttpContextAccessor _context;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly JwtService _jwtService;
		public AuthController(UserManager<IdentityUser> userManager, JwtService jwtService)
		{
			_userManager = userManager;
			_jwtService = jwtService;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("regiter-user")]
		public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO userRegister)
		{
			try
			{
				if (!ModelState.IsValid) return BadRequest(ModelState);

				var user = new IdentityUser();

				user.UserName = userRegister.username;

				var result = await _userManager.CreateAsync(user, userRegister.password);

				if (!result.Succeeded) return BadRequest(result.Errors);

				return Created("RegisterUser", result.Succeeded);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("validate-user")]
		public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLogin)
		{
			try
			{
				if (!ModelState.IsValid) return BadRequest(ModelState);

				var user = await _userManager.FindByNameAsync(userLogin.username);

				if (user is null) return NotFound();

				var result = await _userManager.CheckPasswordAsync(user, userLogin.password);

				if (!result) return BadRequest("Bad credentials");

				var response = _jwtService.CreateToken(user);

				return Ok(response);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}
}
