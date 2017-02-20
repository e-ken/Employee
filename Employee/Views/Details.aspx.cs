using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee
{
	public partial class Details : System.Web.UI.Page
	{
		private static readonly string[] fields =
			new string[] { "Фамилия", "Имя", "Отчество", "ИНН", "Номер паспорта", 
				"Дата рождения", "Должность", "Количество полных лет" };
		
		protected void Page_Load(object sender, EventArgs e)
		{
			int userId;
			int.TryParse(Request["id"], out userId);
			var employee = Database.GetEmployee(userId);
			FillDetailsTable(employee);
		}

		public void button1Clicked(object sender, EventArgs args)
		{
			// К списку сотрудников
			Response.Redirect("/Default.aspx");
		}

		private void FillDetailsTable(Employee employee)
		{
			foreach (var item in fields)
			{
				var row = new TableRow();

				row.Cells.Add(new TableCell() { Text = item });
				row.Cells.Add(new TableCell() { Text = employee.Field(item) });

				this.table1.Rows.Add(row);
			}
		}
	}
}
