using System.Collections.Generic;

namespace UsersAndDepartments.Entities
{
	/// <summary>
	/// Отдел
	/// </summary>
	public class Department
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Пользователи
		/// </summary>
		public List<User> Users { get; } = new List<User>();
	}
}