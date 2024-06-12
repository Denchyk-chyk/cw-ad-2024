using Npgsql;

namespace CS.Output.Items
{
	internal class Empty : Displayable
	{
		public Empty(NpgsqlDataReader reader) : base(reader)
		{
			Value = $"Тест ({GetHashCode()})";
		}
	}
}
