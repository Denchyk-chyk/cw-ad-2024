using CS.General;
using CS.General.Form.Logic;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Authorization
{
	public class UserCreator : IFormHandler
	{
		public FormErrorHandler[] ErrorHandlers => _errorHandlers;

		private static UserCreator _singleton;
		private static FormErrorHandler[] _errorHandlers;

		private UserCreator() { }

		static UserCreator()
		{
			_errorHandlers = [
				new FormErrorHandler(typeof(PostgresException), ex => ((PostgresException)ex).SqlState == "42710", "Користувач з таким ім'ям вже існує", (Input.Tag.Name, string.Empty)),
				new FormErrorHandler(typeof(Exception), ex => true, ex => $"Помилка:\n {ex.Message}")];
		}

		public static UserCreator Instant()
		{
			if (_singleton == null) _singleton = new UserCreator();
			return _singleton;
		}

		public void Get(Form form)
		{
			bool admin = int.Parse(form[Input.Tag.Type].ToString()) == (int)UserType.Admin;

			string createUserQuery = admin ?
				$"CREATE ROLE {form[Input.Tag.Name]} SUPERUSER LOGIN PASSWORD '{form[Input.Tag.Password]}'"
				:
				$"CREATE ROLE {form[Input.Tag.Name]} LOGIN PASSWORD '{form[Input.Tag.Password]}'";
			string grantPrivilegesQuery = admin ?
				$"GRANT ALL PRIVILEGES ON DATABASE {Database.Connection.Database} TO {form[Input.Tag.Name]};"
				:
				$"GRANT SELECT ON ALL TABLES IN SCHEMA public TO {form[Input.Tag.Name]};";

			new NpgsqlCommand(createUserQuery, Database.Connection).ExecuteNonQuery();
			new NpgsqlCommand(grantPrivilegesQuery, Database.Connection).ExecuteNonQuery();
		}
	}
}