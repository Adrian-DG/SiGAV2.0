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

				if (user is null) return NotFound("Error: El nombre de usuario no es valido");

				var result = await _userManager.CheckPasswordAsync(user, userLogin.password);

				if (!result) return BadRequest("Error: la contraseña no es valida");

				var response = _jwtService.CreateToken(user);

				return Ok(response);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		[Authorize]
		[Route("change-password")]
		public async Task<IActionResult> ChangePassword([FromBody] UserChangePasswordDTO userChangePassword)
		{
			try
			{
				if (!ModelState.IsValid) return BadRequest(ModelState);

				var user = await _userManager.FindByNameAsync(userChangePassword.username);

				if (user is null) return NotFound("Error: El nombre de usuario no es valido");

				var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

				var result = await _userManager.ResetPasswordAsync(user, resetToken, userChangePassword.newPassword);

				if (!result.Succeeded) BadRequest(result);

				return Ok(result.Succeeded);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}
