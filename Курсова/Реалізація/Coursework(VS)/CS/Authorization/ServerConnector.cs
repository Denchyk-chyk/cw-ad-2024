using CS.General;
using CS.General.Form.Logic;
using Npgsql;
using System.Net.Sockets;
using Input = CS.General.Form.Field.Logic;

namespace CS.Authorization
{
	public class ServerConnector : IFormHandler
	{
		private static ServerConnector _singletone;

		public static ServerConnector Instant()
		{
			if (_singletone == null) _singletone = new ServerConnector();
			return _singletone;
		}

		private ServerConnector() { }

		private static void Connect(FormData data)
		{
			Database.Connection = new NpgsqlConnection(
				$"Host={data[Input.Tag.Host]};" +
				$"Username={data[Input.Tag.Name]};" +
				$"Password={data[Input.Tag.Password]};" +
				$"Database={data[Input.Tag.Database]}");
			Database.Connection.Open();

			string query = $"SELECT rolname FROM pg_roles WHERE rolname = '{data[Input.Tag.Name]}' AND rolsuper = true";
			using (var reader = new NpgsqlCommand(query, Database.Connection).ExecuteReader()) Database.Status = reader.Read() ? AuthorizationStatus.Admin : AuthorizationStatus.User;
		}

		public bool Get(FormData data)
		{
			try
			{ 
				Connect(data); 
			}
			catch (SocketException exception)
			{
				data.Form.Reopen(data.CreateFeedback($"Помилка при підключенні до сервера ({exception.ErrorCode})", [(Input.Tag.Host, "...")]));
				return false;
			}
			catch (PostgresException exception)
			{
				var feedback = data.CreateFeedback($"Помилка при підключенні до сервера:\n {exception.ErrorCode}");

				if (exception.SqlState == "28000") feedback = data.CreateFeedback("Помилка авторизації");
				if (exception.SqlState == "28P01") feedback = data.CreateFeedback("Неправильне ім'я користувача або пароль", [(Input.Tag.Password, string.Empty)]);
				if (exception.SqlState == "3D000") feedback = data.CreateFeedback("Базу даних не знайдено", [(Input.Tag.Database, string.Empty)]);

				data.Form.Reopen(feedback);
				return false; 
			}
			catch
			{
				data.Form.Reopen(data.CreateFeedback("Невідома помилка", []));
				return false;
			}

			data.Form.Close();
			return true;
		}
	}
}