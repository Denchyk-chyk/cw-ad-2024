using Npgsql;

namespace CS.Output.Items.Employee
{
	internal class Engineer(NpgsqlDataReader reader) : Employee(reader, [
		("experience", "Досвід роботи"),
		("service_efficiency", "Ефективність обслуговування"),
		("emergency_response_speed", "Швидкість надання допомоги при аваріях"),
		("optimization_level", "Рівень оптимізації виробництва"),
		("productivity", "Продуктивність")
	])
	{
		protected override string GetShort() => $"{GetBase()}. {ReadString("site")} ділянка ({ReadInt("site_id")})";
	}
}