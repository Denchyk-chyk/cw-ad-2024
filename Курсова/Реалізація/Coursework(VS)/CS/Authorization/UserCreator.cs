using CS.General;
using CS.General.Form.Logic;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Authorization
{
	public class UserCreator : IFormHandler
	{
		private static UserCreator _singleton;

		private UserCreator() { }

		public static UserCreator Instant()
		{
			if (_singleton == null) _singleton = new UserCreator();
			return _singleton;
		}

		private static void Create(FormData data)
		{
			bool admin = int.Parse(data[Input.Tag.Type].ToString()) == (int)UserType.Admin;

			string createUserQuery = admin ?
				$"CREATE ROLE {data[Input.Tag.Name]} SUPERUSER LOGIN PASSWORD '{data[Input.Tag.Password]}'"
				:
				$"CREATE ROLE {data[Input.Tag.Name]} LOGIN PASSWORD '{data[Input.Tag.Password]}'" ;
			string grantPrivilegesQuery = admin ?
				$"GRANT ALL PRIVILEGES ON DATABASE {Database.Connection.Database} TO {data[Input.Tag.Name]};"
				:
				$"GRANT SELECT ON ALL TABLES IN SCHEMA public TO {data[Input.Tag.Name]};";

			new NpgsqlCommand(createUserQuery, Database.Connection).ExecuteNonQuery();
			new NpgsqlCommand(grantPrivilegesQuery, Database.Connection).ExecuteNonQuery();
		}

		public bool Get(FormData data)
		{
			try
			{
				Create(data);
			}
			catch (Exception exception)
			{
				FormFeedback feedback = data.CreateFeedback($"Помилка:\n {exception.Message}");

				if (exception is PostgresException postgresException && postgresException.SqlState == "42710") 
					feedback = data.CreateFeedback($"Користувач з таким ім'ям вже існує", (Input.Tag.Name, string.Empty));

				data.Form.Reopen(feedback);
				return false;
			}

			return true;
		}
	}
}