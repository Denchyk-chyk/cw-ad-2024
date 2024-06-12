using Npgsql;

namespace CS.Output.Items.Product
{
	internal class ProductTesting(NpgsqlDataReader reader) : Production(reader)
	{
		protected override void Add()
		{
			Counter++;
			Summ = Counter;
			Entries += $"\n{Counter,4}) {ReadDate("time")}";
		}
	}
}