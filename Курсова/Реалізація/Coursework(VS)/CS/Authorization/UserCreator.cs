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

			string createUserQuery = $"create role {form[Input.Tag.Name]} superuser login password '{form[Input.Tag.Password]}'";
			string grantPrivilegesQuery = $"grant all privileges on database {Database.Connection.Database} to {form[Input.Tag.Name]};";

			new NpgsqlCommand(createUserQuery, Database.Connection).ExecuteNonQuery();
			new NpgsqlCommand(grantPrivilegesQuery, Database.Connection).ExecuteNonQuery();
		}
	}
}