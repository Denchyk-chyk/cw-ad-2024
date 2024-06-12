using Npgsql;

namespace CS.Output.Items.Product
{
	internal class FullProductionSummary : Product
	{
		public FullProductionSummary(NpgsqlDataReader reader) : base(reader)
		{
			string text = new FullProduct(reader).Display();
			Value = text.Insert(text.IndexOf('\n'), $" - {ReadInt("count")}") ;
		}
	}
}