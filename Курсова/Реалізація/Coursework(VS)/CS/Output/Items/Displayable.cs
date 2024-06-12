using Npgsql;

namespace CS.Output.Items
{
    public abstract class Displayable(NpgsqlDataReader reader) 
    {
		protected string Value { get; set; }

        protected NpgsqlDataReader Reader { get; private set; } = reader;

		public virtual string Display() => Value;

		protected string ReadString(string field) => reader.GetString(reader.GetOrdinal(field));

		protected string ReadDate(string field) => reader.GetDateTime(reader.GetOrdinal(field)).ToString("dd.MM.yyyy");
		
		protected int ReadInt(string field) => reader.GetInt32(reader.GetOrdinal(field));

		protected bool TryReadInt(string field, out int value)
		{
			bool success = !reader.IsDBNull(reader.GetOrdinal(field));
			value = success ? ReadInt(field) : -1;
			return success;
		}
    }
}