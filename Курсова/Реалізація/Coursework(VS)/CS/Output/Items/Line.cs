using Npgsql;

namespace CS.Output.Items
{
    internal class Line : Displayable
    {
        public Line(NpgsqlDataReader reader, string field = "name") : base(reader)
        {
            Value = ReadString(field);
        }
    }
}