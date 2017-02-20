using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace Employee
{

	public partial class Default : System.Web.UI.Page
	{
		private static readonly string[] columns =
			new string[] { "Фамилия", "Имя", "Дата рождения" };
		
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				var employees = Database.GetEmployees();
				FillEmployeeTable(columns, employees);
			}
		}

		public void button1Clicked(object sender, EventArgs args)
		{
			Response.Redirect("/Views/AddEmployee.aspx");
		}

		private void FillEmployeeTable(IEnumerable<string> fields, IEnumerable<Employee> employees)
		{
			TableHeaderRow thead = new TableHeaderRow { TableSection = TableRowSection.TableHeader };
			foreach (string column in fields)
			{
				thead.Cells.Add(new TableHeaderCell { Text = column });
			}
			this.table1.Rows.Add(thead);

			foreach (var item in employees)
			{
				var row = new TableRow();
				row.Attributes.Add("id", item.Id.ToString());
				foreach (string field in fields)
				{
					row.Cells.Add(new TableCell() { Text = item.Field(field) });
				}
				this.table1.Rows.Add(row);
			}
		}
	}
}
