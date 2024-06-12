using CS.Output.Items.Employee;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Seventh
{
	internal class Query : Queries.Query
	{
		protected override void Read(NpgsqlDataReader reader) => Result.Add(new Engineer(reader));

		protected override string Select()
		{
			return
				"select " +
					"sm.id, s.first_name, s.last_name, s.age,s.experience, " +
					"ec.name as category, ts.service_efficiency, ts.emergency_response_speed, " +
					"t.optimization_level, ps.productivity, " +
					"ps2.name as specialization, s1.name as site, s1.id as site_id " +
				"from sites_masters sm " +
					"left join staff s on sm.id = s.id " +
					"left join engineers e on s.id = e.id " +
					"left join engineer_categories ec on e.category = ec.id " +
					"left join technical_support ts on e.id = ts.id " +
					"left join technologists t on e.id = t.id " +
					"left join production_specialists ps on e.id = ps.id " +
					"left join production_specialization ps2 on t.specialization = ps2.id or ps.specialization = ps2.id " +
					"left join sites s1 on sm.site = s1.id " +
				"where " +
					CheckOptional(Input.Tag.Site, "s1.id") +
					" and " +
					CheckOptional(Input.Tag.Workshop, "s1.workshop") +
			";";
		}
	}
}