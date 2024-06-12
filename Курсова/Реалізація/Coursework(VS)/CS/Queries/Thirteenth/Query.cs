using CS.Output.Items;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Thirteenth
{
	internal class Query : Queries.Query
	{
		protected override string Select()
		{
			return
				"select distinct tt.name from testing_tools tt " +
					"join testing t on tt.id = t.tool " +
					"join products p on t.product = p.category " +
				$"where " +
					CheckSwitch(Input.Tag.ProductsPart, [(Input.Tag.ProductCategory, "p.category", 1), (Input.Tag.Product, "p.id", 1)]) +
					" and " +
					CheckOptional(Input.Tag.Laboratory, "t.laboratory") +
			";";
		}

		protected override void Read(NpgsqlDataReader reader) => Result.Add(new Line(reader));
	}
}