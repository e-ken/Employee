using System.Web;

namespace Employee
{
	public class Global : HttpApplication
	{
		protected void Application_Start()
		{
            Database.Prepare();
		}
	}
}
