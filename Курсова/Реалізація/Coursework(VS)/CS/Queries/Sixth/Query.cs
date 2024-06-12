using CS.Output.Items.Employee;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Sixth
{
	internal class Query : Queries.Query
	{
		protected override void Read(NpgsqlDataReader reader) => Result.Add(new Laborer(reader));

		protected override string Select()
		{
			return
				"select " +
					"first_name, last_name, age, experience, " +
					"lc.name as category, speed, detect_rate, " +
					"material_saving,  accuracy, processing_level, " +
					"b.name as brigade, b.id as brigade_id " +
				"from staff s " +
					"join laborers l on s.id = l.id " +
					"left join laborer_categories lc on l.category = lc.id " +
					"left join installers i on l.id = i.id " +
					"left join welders w on l.id = w.id " +
					"left join turners t3 on l.id = t3.id " +
					"left join millers m1 on l.id = m1.id " +
					"left join grinders g on l.id = g.id " +
					"left join brigades_staff bs on l.id = bs.id " +
					"left join brigades b on l.id = b.foreman or bs.brigade = b.id " +
					"left join sites s1 on s1.id = b.site " +
				"where " +
					CheckOptional(Input.Tag.Site, "s1.id") +
					" and " +
					CheckOptional(Input.Tag.Workshop, "s1.workshop") +
				";";
			;
		}
	}
}