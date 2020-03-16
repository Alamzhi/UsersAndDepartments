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

		public DepartmentController() { }

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
				var department = context.Departments.SingleOrDefault(d => d.Id == id);

				if (department == null)
				{
					return NotFound();
				}

				return department;
			}
		}

		/// <summary>
		/// Создание отдела
		/// </summary>
		[HttpPost]
		public CreatedAtActionResult Create(Department department)
		{
			using (var context = new UserContext())
			{
				context.Departments.Add(department);
				context.SaveChanges();
				return CreatedAtAction(nameof(Get), new { id = department.Id }, department);
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
		public ActionResult<Department> Delete(long id)
		{
			using (var context = new UserContext())
			{
				var department = context.Departments.SingleOrDefault(d => d.Id == id);

				if (department==null)
				{
					return NotFound();
				}

				context.Departments.Remove(department);
				context.SaveChanges();
				return department;
			}
		}
	}
}
