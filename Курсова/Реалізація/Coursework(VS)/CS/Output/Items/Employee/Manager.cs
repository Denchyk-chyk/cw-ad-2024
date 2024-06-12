using Npgsql;

namespace CS.Output.Items.Employee
{
	internal class Manager(NpgsqlDataReader reader) : Employee(reader, [
		("experience", "Досвід роботи"),
		("staff_management", "Управління персоналом"),
		("production_efficiency", "Забезпечення ефективності виробництва"),
		("standards_compliance", "Контроль дотримання стандартів виробництва"),
	])
	{
		protected override string GetBase() => $"{GetName()}";
	}
}