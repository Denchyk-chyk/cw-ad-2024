using CS.Output.Items.Employee;
using Npgsql;

namespace CS.Output.Items
{
	internal class Site : Displayable
	{
		public Site(NpgsqlDataReader reader) : base(reader)
		{
			Value = $"{ReadInt("id"), 2}. {ReadString("name")} ділянка ({ReadString("workshop")} цех)\n" +
				$"{new string(' ', 4)}Начальник: {new Manager(reader).Display().Replace("\n", $"\n{new string(' ', 8)}")}";
		}
	}
}