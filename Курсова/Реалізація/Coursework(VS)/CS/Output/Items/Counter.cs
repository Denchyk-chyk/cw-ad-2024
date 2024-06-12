using Npgsql;

namespace CS.Output.Items
{
	internal class Counter : Displayable
	{
		public Counter(NpgsqlDataReader reader, string name = "name") : base(reader)
		{
			Value = $"{ReadString(name)} - {ReadInt("count")}";
		}
	}
}