using Npgsql;

namespace CS.Output.Items.Product
{
	public class Product(NpgsqlDataReader reader) : Displayable(reader)
	{
		protected string GetName() => $"{ReadString("name")} ({ReadString("category")})";
	}
}