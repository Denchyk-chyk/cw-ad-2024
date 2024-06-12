using CS.Output.Items.Employee;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Ninth
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
					"material_saving, accuracy, processing_level, " +
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
					"left join brigades_specialization bs2 on b.id = bs2.id " +
					"left join products p on bs2.product = p.id " +
				"where " +
					$"p.id = {(int)Form[Input.Tag.Product] + 1};"
			;
		}
	}
}