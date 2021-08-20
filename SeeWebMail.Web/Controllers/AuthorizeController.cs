using Microsoft.AspNetCore.Mvc;
using SeeWebMail.Contracts.Abstract;
using SeeWebMail.Contracts.Common;
using SeeWebMail.Contracts.Contracts;
using SeeWebMail.Contracts.Contracts.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeWebMail.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthorizeController : ControllerBase
	{
		private readonly IAuthorizationService authorizationService;
		public AuthorizeController(IAuthorizationService authorizationService)
		{
			this.authorizationService = authorizationService;
		}

		[HttpPost]
		[Route("login")]
		public async Task<OperationResult<UserContract>> Login(LoginContract contract) 
			=> await authorizationService.Login(contract.EmailAddress, contract.Password);
	}
}
