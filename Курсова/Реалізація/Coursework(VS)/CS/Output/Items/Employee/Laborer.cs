using Npgsql;

namespace CS.Output.Items.Employee
{
	internal class Laborer(NpgsqlDataReader reader) : Employee(reader, [
		("experience", "Досвід роботи"),
		("speed", "Швидкість роботи"),
		("detect_rate", "Частка браку"),
		("material_saving", "Економія матеріалів"),
		("accuracy", "Точність"),
		("processing_level", "Рівень обробки")
	])
	{
		protected override string GetShort() => $"{GetBase()}. {ReadString("brigade")} бригада ({ReadInt("brigade_id")})";
	}
}