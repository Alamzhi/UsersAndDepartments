using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UsersAndDepartments.Entities;

namespace UsersAndDepartments.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DepartmentController : ControllerBase
	{
		private readonly ILogger<DepartmentController> _logger;

		public DepartmentController(ILogger<DepartmentController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<Department> Get()
		{
			throw new NotImplementedException();
		}
	}
}
