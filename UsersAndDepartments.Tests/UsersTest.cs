using System;
using System.Linq;
using System.Text;
using DepartmentsAndDepartments.Controllers;
using UsersAndDepartments.Contexts;
using UsersAndDepartments.Controllers;
using UsersAndDepartments.Entities;
using Xunit;

namespace UsersAndDepartments.Tests
{
	public class UsersTest
	{
		/// <summary>
		///  Создаем пользователей и удаляем
		/// </summary>
		[Fact]
		public void GenerateTest()
		{
			int number = 10;
			StringBuilder nameBuilder = new StringBuilder();
			nameBuilder.Append("User");
			var controller = new UserController();

			for (int i = 1; i <= number; i++)
			{
				var createResult = controller.Create(new User
				{
					Name = nameBuilder.Append(i).ToString()
				});

				var dep = controller.Get(((User)createResult.Value).Id);
				Assert.NotNull(dep.Value);
				Assert.Equal(nameBuilder.ToString(), dep.Value.Name);
			}

			var users = controller.Get().ToArray();
			Assert.True(users.Length == number);

			foreach (var user in users)
			{
				controller.Delete(user.Id);
			}

			users = controller.Get().ToArray();
			Assert.Empty(users);
		}
	}
}
