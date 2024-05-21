using CS.General;
using CS.General.Form.Logic;
using Npgsql;
using System.Net.Sockets;
using Input = CS.General.Form.Field.Logic;

namespace CS.Authorization
{
	public class ServerConnector : IFormHandler
	{
		public FormErrorHandler[] ErrorHandlers => _errorHandlers;
		
		private static ServerConnector _singletone;
		private static FormErrorHandler[] _errorHandlers;

		public static ServerConnector Instant()
		{
			if (_singletone == null) _singletone = new ServerConnector();
			return _singletone;
		}

		private ServerConnector() { }

		static ServerConnector()
		{
			_errorHandlers = [
				new FormErrorHandler(typeof(SocketException), ex => $"Не вдалося під'єднатися до сервера", (Input.Tag.Host, "...")),
				new FormErrorHandler(typeof(PostgresException), ex => ((PostgresException)ex).SqlState == "28P01", ex => $"Неправильне ім'я користувача або пароль", (Input.Tag.Password, string.Empty)),
				new FormErrorHandler(typeof(PostgresException), ex => ((PostgresException)ex).SqlState == "3D000", ex => $"Базу даних не знайдено", (Input.Tag.Database, string.Empty)),
				new FormErrorHandler(typeof(PostgresException), ex => ((PostgresException)ex).SqlState == "28000", ex => $"Помилка авторизації"),
				new FormErrorHandler(typeof(PostgresException), ex => $"Помилка при під'єднанні до сервера:\n {((PostgresException)ex).ErrorCode}"),
				new FormErrorHandler(typeof(Exception), ex => true, ex => $"Помилка:\n {ex.Message}")];
		}

		public void Get(Form form)
		{
			Database.Connection = new NpgsqlConnection(
				$"Host={form[Input.Tag.Host]};" +
				$"Username={form[Input.Tag.Name]};" +
				$"Password={form[Input.Tag.Password]};" +
				$"Database={form[Input.Tag.Database]}");
			Database.Connection.Open();

			string query = $"SELECT rolname FROM pg_roles WHERE rolname = '{form[Input.Tag.Name]}' AND rolsuper = true";
			using (var reader = new NpgsqlCommand(query, Database.Connection).ExecuteReader()) Database.Status = reader.Read() ? AuthorizationStatus.Admin : AuthorizationStatus.User;
		}
	}
}