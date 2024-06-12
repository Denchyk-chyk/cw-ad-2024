using CS.Output.Items;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Fourth
{
	internal class Query : Queries.Query
	{
		protected override void Read(NpgsqlDataReader reader)
		{
			Result.Add(new Site(reader));
		}

		protected override string Select()
		{
			return
				"select " +
					"s.id, s.name, w.name as workshop, " +
					"s1.first_name, s1.last_name, s1.age, s1.experience, " +
					"m.staff_management, m.production_efficiency, m.standards_compliance " +
				"from sites s " +
					"left join staff s1 on s.chief = s1.id " +
					"left join management m on s1.id = m.id " +
					"left join workshops w on s.workshop = w.id " +
				"where " +
					CheckOptional(Input.Tag.Workshop, "w.id") +
					";"
			;
		}
	}
}