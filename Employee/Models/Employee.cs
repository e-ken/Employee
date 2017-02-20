using System;
using System.ComponentModel;

namespace Employee
{
	public class Employee
	{
		[Description("Идентификатор")]
		public int Id { get; set; }
		[Description("Фамилия")] 
		public string Surname { get; set; }
		[Description("Имя")]
		public string Name { get; set; }
		[Description("Отчество")]
		public string Patronymic { get; set; }
		[Description("Дата рождения")]
		public DateTime Birthday { get; set; }
		[Description("ИНН")]
		public string INN { get; set; }
		[Description("Номер паспорта")]
		public string Passport { get; set; }
		[Description("Должность")]
		public string JobPost { get; set; }

		[Description("Количество полных лет")]
		public int Age { 
			get { return DateTime.Today.Year - this.Birthday.Year; } 
		}
	}
}
