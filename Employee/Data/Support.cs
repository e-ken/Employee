using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Employee
{
	internal static class Support
	{
		private static readonly string[] jobPosts =
			new string[] { "Бухгалтер", "Водитель", "Программист" };

		public static string[] GetJobPosts()
		{
			return jobPosts;
		}
	
		public static System.Reflection.PropertyInfo FindProperty(this Employee employee, string name)
		{
			if (employee == null) throw new ArgumentNullException(nameof(employee));

			foreach (var item in employee.GetType().GetProperties())
			{
				DescriptionAttribute description = (DescriptionAttribute)item.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
				if (description.Description == name) return item;
			}
			throw new KeyNotFoundException($"Поле '{name}' не найдено в описании объекта '{nameof(employee)}'");
		}

		public static string Field(this Employee employee, string name)
		{
			var property = employee.FindProperty(name);
			var value = property.GetValue(employee);
			if (value == null) return string.Empty;
			if (value is DateTime) return ((DateTime)value).ToString("dd.MM.yyyy");
			return value.ToString();
		}

		public static void Field(this Employee employee, string name, object value)
		{
			var property = employee.FindProperty(name);
			if (property.PropertyType == typeof(DateTime)) value = Convert.ToDateTime(value);
			property.SetValue(employee, value);
		}
	}
}
