using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAndDepartments.Entities
{
	/// <summary>
	/// Пользователь
	/// </summary>
	public class User
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Имя
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Идентификатор Отдела
		/// </summary>
		public long DepId { get; set; }

		/// <summary>
		/// Отдел
		/// </summary>
		public Department Department { get; set; }
	}
}
