using Npgsql;

namespace CS.Output.Items.Product
{
	internal class Production : Product
	{
		protected int Summ { get; set; }
		protected int Counter { get; set; }
		protected string Entries { get; set; }

		private int _id;
		private string _name;

		protected Production(NpgsqlDataReader reader) : base(reader)
		{
			_id = ReadInt("id");
			_name = GetName();
		}

		public override string Display() => $"{_name} — {Summ}{Entries}";
		
		protected virtual void Add()
		{
			Counter++;
			int count = ReadInt("count");
			Summ += count;
			Entries += $"\n{Counter,4}) {ReadDate("time")} + {count,2} ({Summ})";
		}

		public static void Add(List<Production> production, NpgsqlDataReader reader) => Add(production, new Production(reader));

		public static void Add(List<Production> production, Production newProduct)
		{
			Production? selected = production.FirstOrDefault(p => p.ReadInt("id") == p._id);
			if (selected == null) production.Add(selected = newProduct);
			selected.Add();
		}
	}
}