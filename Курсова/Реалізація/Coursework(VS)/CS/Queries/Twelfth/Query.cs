using CS.Output.Items;
using CS.Output.Items.Employee;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Twelfth
{
	internal class Query : Queries.Query
	{
		protected override string Select()
		{
			return
				"select first_name, last_name, age, experience, quality, ts.name as specialization from testers t " +
					"join staff s on t.id = s.id " +
					"join tester_specialization ts on t.specialization = ts.id " +
					"join testing t1 on t.id = t1.tester " +
					"join products p on t1.product = p.category " +
				$"where " +
					CheckSwitch(Input.Tag.ProductsPart, [(Input.Tag.ProductCategory, "p.category", 1), (Input.Tag.Product, "p.id", 1)]) +
					" and " +
					CheckOptional(Input.Tag.Laboratory, "t1.laboratory") +
			";";
		}

		protected override void Read(NpgsqlDataReader reader) => Result.Add(new Tester(reader));
	}
}