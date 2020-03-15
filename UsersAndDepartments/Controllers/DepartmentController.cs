using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using UsersAndDepartments.Contexts;
using UsersAndDepartments.Entities;

namespace DepartmentsAndDepartments.Controllers
{
	/// <summary>
	/// Контроллер отделов
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class DepartmentController : ControllerBase
	{
		private readonly ILogger<DepartmentController> _logger;

		public DepartmentController(ILogger<DepartmentController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Получение списка отделов
		/// </summary>
		[HttpGet]
		public IEnumerable<Department> Get()
		{
			using (var context = new UserContext())
			{
				return context.Departments.ToArray();
			}
		}

		/// <summary>
		/// Получение инфо об отделе
		/// </summary>
		[HttpGet("{id}")]
		public ActionResult<Department> Get(long id)
		{
			using (var context = new UserContext())
			{
				var Department = context.Departments.SingleOrDefault(d => d.Id == id);

				if (Department == null)
				{
					return NotFound();
				}

				return Department;
			}
		}

		/// <summary>
		/// Создание отдела
		/// </summary>
		[HttpPost]
		public ActionResult Create(Department Department)
		{
			using (var context = new UserContext())
			{
				context.Departments.Add(Department);
				context.SaveChanges();
				return CreatedAtAction(nameof(Get), new { id = Department.Id }, Department);
			}
		}

		/// <summary>
		/// Обновление отдела
		/// </summary>
		[HttpPut("{id}")]
		public IActionResult Update(long id, Department Department)
		{
			using (var context = new UserContext())
			{
				if (id != Department.Id)
				{
					return BadRequest();
				}

				context.Entry(Department).State = EntityState.Modified;

				try
				{
					context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!context.Departments.Any(d => d.Id == id))
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
		/// Удаление отдела
		/// </summary>
		[HttpDelete("{id}")]
		public ActionResult<Department> Delete(int id)
		{
			using (var context = new UserContext())
			{
				var Department = context.Departments.SingleOrDefault(d => d.Id == id);

				if (Department==null)
				{
					return NotFound();
				}

				context.Departments.Remove(Department);
				context.SaveChanges();
				return Department;
			}
		}
	}
}
