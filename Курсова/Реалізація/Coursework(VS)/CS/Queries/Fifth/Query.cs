using CS.Output.Items;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Fifth
{
	internal class Query : Queries.Query
	{
		protected override string Select()
		{
			return
				"select ps.name from processing pg " +
					"join processes ps on pg.process = ps.id " +
					"join products p on pg.category = p.category " +
				$"where p.id = {Form[Input.Tag.Product]}" +
				" order by name;"
			;
		}

		protected override void Read(NpgsqlDataReader reader) => Result.Add(new Line(reader, "name"));
	}
}