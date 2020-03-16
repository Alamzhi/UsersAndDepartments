using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UsersAndDepartments.Contexts;
using UsersAndDepartments.Entities;

namespace UsersAndDepartments.Controllers
{
	/// <summary>
	/// Контроллер пользователей
	/// </summary>
	[ApiController]
	[System.Web.Http.Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> _logger;

		public UserController()
		{
		}

		public UserController(ILogger<UserController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Получение списка пользователей
		/// </summary>
		[HttpGet]
		public IEnumerable<User> Get()
		{
			using (var context = new UserContext())
			{
				return context.Users.ToArray();
			}
		}

		/// <summary>
		/// Получение инфо о пользователе
		/// </summary>
		[HttpGet("{id}")]
		public ActionResult<User> Get(long id)
		{
			using (var context = new UserContext())
			{
				var user = context.Users.SingleOrDefault(u => u.Id == id);

				if (user == null)
				{
					return NotFound();
				}

				return user;
			}
		}

		/// <summary>
		/// Создание пользователя
		/// </summary>
		[HttpPost]
		public CreatedAtActionResult Create(User user)
		{
			using (var context = new UserContext())
			{
				context.Users.Add(user);
				context.SaveChanges();
				return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
			}
		}

		/// <summary>
		/// Обновление пользователя
		/// </summary>
		[HttpPut("{id}")]
		public IActionResult Update(long id, User user)
		{
			using (var context = new UserContext())
			{
				if (id != user.Id)
				{
					return BadRequest();
				}

				context.Entry(user).State = EntityState.Modified;

				try
				{
					context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!context.Users.Any(u => u.Id == id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}

				return NoContent();
			}
		}

		/// <summary>
		/// Удаление пользователя
		/// </summary>
		[HttpDelete("{id}")]
		public ActionResult<User> Delete(long id)
		{
			using (var context = new UserContext())
			{
				var user = context.Users.SingleOrDefault(u => u.Id == id);

				if (user==null)
				{
					return NotFound();
				}

				context.Users.Remove(user);
				context.SaveChanges();
				return user;
			}
		}
	}
}
