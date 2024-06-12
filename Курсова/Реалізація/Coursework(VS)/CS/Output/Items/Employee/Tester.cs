using Npgsql;

namespace CS.Output.Items.Employee
{
	internal class Tester(NpgsqlDataReader reader) : Employee(reader, [
		("experience", "Досвід роботи"),
		("quality", "Якість випробувань"),
	])
	{
		protected override string GetBase() => $"{GetName()} - {ReadString("specialization")}";
	}
}