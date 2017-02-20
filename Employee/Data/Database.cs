using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;

namespace Employee
{
	public static class Database
	{
        private static readonly string filename = "EmployeeDB.sdf";

        private static string GetConnectionString()
        {
            return $"Data Source=|DataDirectory|{filename}";
        }
        public static void Prepare()
        {
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            path = Path.Combine(path, filename);
            if (File.Exists(path)) return;
            
            SqlCeEngine engine = new SqlCeEngine(GetConnectionString());
            engine.CreateDatabase();

            CreateTable();
        }

        internal static void CreateTable()
        {
            string commandText =
                "CREATE TABLE Employee(" +
                    "ID int not NULL identity(1,1) PRIMARY KEY," +
                    "SURNAME nchar(20) not NULL," +
                    "NAME nchar(20) not NULL," +
                    "PATRONYMIC nchar(20) NULL," +
                    "INN nchar(12) NULL," +
                    "PASSPORT nchar(10) NULL," +
                    "BIRTHDAY datetime not NULL," +
                    "JOB_POST nchar(255) NULL)";

            using (SqlCeConnection connection = new SqlCeConnection(GetConnectionString()))
            {
                connection.Open();
                using(SqlCeCommand command = new SqlCeCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static IEnumerable<Employee> GetEmployees()
		{
            string commandText =
                "select ID, SURNAME, NAME, PATRONYMIC" +
                ", INN, PASSPORT, BIRTHDAY, JOB_POST from Employee";
            using (SqlCeConnection connection = new SqlCeConnection(GetConnectionString()))
            {
                connection.Open(); 
                using (SqlCeCommand command = new SqlCeCommand(commandText, connection))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return new Employee()
                            {
                                Id = reader.GetInt32(0),
                                Surname = reader.GetString(1),
                                Name = reader.GetString(2),
                                Patronymic = reader.GetString(3),
                                INN = reader.GetString(4),
                                Passport = reader.GetString(5),
                                Birthday = reader.GetDateTime(6),
                                JobPost = reader.GetString(7)
                            };
                        }
                    }
                }
            }
		}

		public static Employee GetEmployee(int id)
		{
            string commandText =
               "select ID, SURNAME, NAME, PATRONYMIC" +
                ", INN, PASSPORT, BIRTHDAY, JOB_POST" +
               " from Employee where ID = @ID";
            using (SqlCeConnection connection = new SqlCeConnection(GetConnectionString()))
            {
                connection.Open();
                using (SqlCeCommand command = new SqlCeCommand(commandText, connection))
                {
                    command.Parameters.Add("ID", System.Data.SqlDbType.Int).Value = id;
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Employee()
                            {
                                Id = reader.GetInt32(0),
                                Surname = reader.GetString(1),
                                Name = reader.GetString(2),
                                Patronymic = reader.GetString(3),
                                INN = reader.GetString(4),
                                Passport = reader.GetString(5),
                                Birthday = reader.GetDateTime(6),
                                JobPost = reader.GetString(7)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static void AddEmployee(Employee employee)
        {
            string commandText =
               "insert into Employee(SURNAME, NAME, PATRONYMIC, INN, PASSPORT, BIRTHDAY, JOB_POST)" +
                " values (@SURNAME, @NAME, @PATRONYMIC, @INN, @PASSPORT, @BIRTHDAY, @JOB_POST)";
            using (SqlCeConnection connection = new SqlCeConnection(GetConnectionString()))
            {
                connection.Open();
                using (SqlCeCommand command = new SqlCeCommand(commandText, connection))
                {
                    command.Parameters.Add("SURNAME", System.Data.SqlDbType.NChar).Value = employee.Surname;
                    command.Parameters.Add("NAME", System.Data.SqlDbType.NChar).Value = employee.Name;
                    command.Parameters.Add("PATRONYMIC", System.Data.SqlDbType.NChar).Value = employee.Patronymic;
                    command.Parameters.Add("INN", System.Data.SqlDbType.NChar).Value = employee.INN;
                    command.Parameters.Add("PASSPORT", System.Data.SqlDbType.NChar).Value = employee.Passport;
                    command.Parameters.Add("BIRTHDAY", System.Data.SqlDbType.DateTime).Value = employee.Birthday;
                    command.Parameters.Add("JOB_POST", System.Data.SqlDbType.NChar).Value = employee.JobPost;

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT @@IDENTITY";
                    employee.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

		public static bool CheckEmployee(Employee employee, out string error)
		{
			error = null;

            if (string.IsNullOrEmpty(employee.INN) && string.IsNullOrEmpty(employee.Passport)) return true;

            using (SqlCeConnection connection = new SqlCeConnection(GetConnectionString()))
            {
                connection.Open();
                using (SqlCeCommand command = new SqlCeCommand("select count(1) from Employee where INN = @INN", connection))
                {
                    if (!string.IsNullOrEmpty(employee.INN))
                    {
                        command.Parameters.Add("INN", System.Data.SqlDbType.NChar).Value = employee.INN;

                        if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                        {
                            error = $"Ошибка ИНН '{employee.INN}' принадлежит другому сотруднику";
                            return false;
                        }
                    }

                    if (!string.IsNullOrEmpty(employee.Passport))
                    {
                        command.Parameters.Clear();
                        command.CommandText = "select count(1) from Employee where PASSPORT = @PASSPORT";
                        command.Parameters.Add("PASSPORT", System.Data.SqlDbType.NChar).Value = employee.Passport;

                        if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                        {
                            error = $"Ошибка номер паспорта '{employee.Passport}' принадлежит другому сотруднику";
                            return false;
                        }
                    }

                }
            }
              
			return true;
		}
	}
}
