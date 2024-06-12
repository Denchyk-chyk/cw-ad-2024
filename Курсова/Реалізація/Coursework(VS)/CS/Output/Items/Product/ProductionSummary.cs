using Npgsql;

namespace CS.Output.Items.Product
{
	internal class ProductionSummary : Product
	{
		public ProductionSummary(NpgsqlDataReader reader) : base(reader)
		{
			Value = $"{GetName()} - {ReadInt("count")}";
		}
	}
}