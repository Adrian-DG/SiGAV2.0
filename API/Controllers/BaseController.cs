using Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : ControllerBase
	{
		protected readonly IUnitOfWork _uow;
        public BaseController(IUnitOfWork unitOfWork)
        {
			_uow = unitOfWork;
        }
    }
}
