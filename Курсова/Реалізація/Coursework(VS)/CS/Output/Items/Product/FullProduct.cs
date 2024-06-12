using Npgsql;

namespace CS.Output.Items.Product
{
	internal class FullProduct : Product
    {
		private static (string name, string title)[] _fields = [
			("safety", "Безпека"),
			("reliability", "Надійність"),
			("engine_power", "Потужність двигуна"),
			("cost_effectiveness", "Економія пального"),
			("prime_cost", "Собівартість виробництва"),
			("convenience", "Зручність"),
			("capacity", "Місткість"),
			("carrying_capacity", "Вантажопідйомність"),
			("speed", "Швидкість"),
			("ease_of_driving", "Простота керування"),
			("spaciousness", "Просторість"),
			("traction_force", "Тяга"),
			("maneuverability", "Маневреність"),
			("productivity", "Продуктивність"),
		];

		public FullProduct(NpgsqlDataReader reader) : base(reader)
		{
			Console.WriteLine(Reader);
			Value = GetName();

			foreach (var (name, title) in _fields)
				if (TryReadInt(name, out int value)) Value += $"\n{title}: {value}";
		}
	}
}