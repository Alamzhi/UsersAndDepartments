using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using DepartmentsAndDepartments.Controllers;
using Microsoft.Extensions.Logging;
using UsersAndDepartments.Contexts;
using UsersAndDepartments.Entities;
using Xunit;

namespace UsersAndDepartments.Tests
{
	public class DepartmentsTest
	{
		/// <summary>
		///  Создаем отделы и удаляем
		/// </summary>
		[Fact]
		public void GenerateTest()
		{
			int number = 10;
			StringBuilder nameBuilder = new StringBuilder();
			nameBuilder.Append("Department");
			var controller = new DepartmentController();

			for (int i = 1; i <= number; i++)
			{
				var createResult = controller.Create(new Department
				{
					Name = nameBuilder.Append(i).ToString()
				});

				var dep = controller.Get(((Department)createResult.Value).Id);
				Assert.NotNull(dep.Value);
				Assert.Equal(nameBuilder.ToString(), dep.Value.Name);
			}

			var departments = controller.Get().ToArray();
			Assert.True(departments.Length == number);

			foreach (var department in departments)
			{
				controller.Delete(department.Id);
			}

			departments = controller.Get().ToArray();
			Assert.Empty(departments);
		}
	}
}