using Npgsql;

namespace CS.Output.Items.Employee
{
	internal abstract class Employee : Displayable
    {
        protected Employee(NpgsqlDataReader reader, (string name, string title)[] fields) : base(reader)
        {
            Console.WriteLine(Reader);
            Value = GetShort();

            foreach (var (name, title) in fields)
                if (TryReadInt(name, out int value)) Value += $"\n{title}: {value}";
        }

		protected string GetName() => $"{ReadString("first_name")} {ReadString("last_name")} ({ReadInt("age")})";

		protected virtual string GetBase() => $"{GetName()} - {ReadString("category")}";

        protected virtual string GetShort() => GetBase();
	}
}