using CS.General;
using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using CS.Output;
using CS.Output.Items;
using Npgsql;

namespace CS.Queries
{
	public abstract class Query : IFormHandler
	{
		private string _select = string.Empty;

		public FormErrorHandler[] ErrorHandlers => [
			new FormErrorHandler(typeof(PostgresException), (e) => $"Помилка роботи з PostgreSQL\n\n{_select}\n\n{e.Message}"),
			new FormErrorHandler((e) => $"Необроблена помилка ({e.Message})"),
		];

		protected List<Displayable> Result { get; } = [];
		protected Form Form { get; private set; }

		public void Get(Form form)
		{
			Form = form;
			_select = Select();
			using (var reader = new NpgsqlCommand(_select, Database.Connection).ExecuteReader())
			{
				while (reader.Read()) Read(reader);
			}
			Display.Output(Write());
		}

		protected abstract string Select();
		
		protected abstract void Read(NpgsqlDataReader reader);

		protected virtual List<Displayable> Write() => Result;

		protected string CheckOptional(Tag tag, string name, int addition = 1) => (int)Form[tag] == -1 ? "true" : $"{name} = {(int)Form[tag] + addition}";
		
		protected string CheckSwitch(Tag tag, (Tag tag, string name, int addition)[] options)
		{
			int selected = (int)Form[tag] - 1;
			return selected == -1 ? "true" : $"{options[selected].name} = {(int)Form[options[selected].tag] + options[selected].addition}";
		}
	}
}