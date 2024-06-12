using CS.Output.Items;
using Npgsql;

namespace CS.Queries.Tenth
{
	internal class Query : Queries.Query
	{
		protected override void Read(NpgsqlDataReader reader) => Result.Add(new Line(reader, "name"));

		protected override string Select()
		{
			return
				"select distinct l.name from laboratories l " +
					"left join testing t on l.id = t.laboratory " +
					"left join products p on t.product = p.category " +
				$"where p.id = {Form[General.Form.Field.Logic.Tag.Product]};"
			;
		}
	}
}