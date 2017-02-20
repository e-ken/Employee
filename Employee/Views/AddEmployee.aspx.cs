using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee
{

	public partial class AddEmployee : System.Web.UI.Page
	{
		private static readonly string[] fields =
			new string[] { "Фамилия", "Имя", "Отчество", "ИНН", "Номер паспорта",
				"Дата рождения", "Должность" };

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				foreach (var item in Support.GetJobPosts())
					field7.Items.Add(new ListItem(item, item));
			}
		}

		public void button1Clicked(object sender, EventArgs args)
		{
			var employee = GetEmployeeFromRequest();

			string error;
			if (!Database.CheckEmployee(employee, out error))
			{
				this.field8.Text = error;
				this.field8.Visible = true;
				return;
			}

			// Добавляем сотрудника
			Database.AddEmployee(employee);

			// К списку сотрудников
			Response.Redirect("/Default.aspx");
		}

		public void button2Clicked(object sender, EventArgs args)
		{
			// К списку сотрудников
			Response.Redirect("/Default.aspx");
		}



		private Employee GetEmployeeFromRequest()
		{
			Employee employee = new Employee();

			employee.Surname = Request.Form["field1"];
			employee.Name = Request.Form["field2"];
			employee.Patronymic = Request.Form["field3"];
			employee.INN = Request.Form["field4"];
			employee.Passport = Request.Form["field5"];
            string date = Request.Form["field6"];

            employee.Birthday = new DateTime(int.Parse(date.Substring(6)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2)));
			employee.JobPost = Request.Form["field7"];
			return employee;
		}
	}
}
