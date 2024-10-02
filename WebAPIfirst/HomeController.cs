using Microsoft.AspNetCore.Mvc;
using WebAPIfirst.Models;

namespace WebAPIfirst.Controllers
{
	[ApiController]
	[Route("home")]
	public class HomeController: ControllerBase
	{
		[HttpGet]
		
			public ResponseModel GetMessage() 
			{
			return new ResponseModel()
			{
				HttpStatus = 200,
				Message = "Hello ASP.Net Core Web API"
			};

            }
        
	}
}

