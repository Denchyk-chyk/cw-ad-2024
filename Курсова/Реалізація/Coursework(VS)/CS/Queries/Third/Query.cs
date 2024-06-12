using CS.Output.Items;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Third
{
	internal class Query : Queries.Query
	{
		private string SelectEngineers()
		{
			return
				"select ec.name, count(e.id) from engineers e " +
					"left join engineer_categories ec on e.category = ec.id " +
					"left join sites_masters sm on e.id = sm.id " +
					"left join sites s on sm.site = s.id or e.id = s.chief " +
				"where " +
					CheckSwitch(Input.Tag.EmployeeCategory, [(Input.Tag.Engineer, "ec.id", 1), (Input.Tag.Laborer, "lc.id", 1)]) +
					" and " +
					CheckSwitch(Input.Tag.Unit, [(Input.Tag.Workshop, "s.workshop", 1), (Input.Tag.Site, "s.id", 1)]) +
				" group by ec.name"
			;
		}	
		private string SelectLaborers()
		{
			return
				"select lc.name, count(l.id) from laborers l " +
					"left join laborer_categories lc on l.category = lc.id " +
					"left join brigades_staff bs on l.id = bs.id " +
					"left join brigades b on bs.brigade = b.id or l.id = b.foreman " +
					"left join sites s on b.site = s.id " +
				"where " +
					CheckSwitch(Input.Tag.EmployeeCategory, [(Input.Tag.Engineer, "ec.id", 1), (Input.Tag.Laborer, "lc.id", 1)]) +
					" and " +
					CheckSwitch(Input.Tag.Unit, [(Input.Tag.Workshop, "s.workshop", 1), (Input.Tag.Site, "s.id", 1)]) +
				" group by lc.name"
			;
		}

		protected override string Select()
		{
			switch ((int)Form[Input.Tag.EmployeeCategory])
			{
				case 1:
					return $"{SelectEngineers()};";
				case 2:
					return $"{SelectLaborers()};";
				default:
					return $"{SelectEngineers()} union all {SelectLaborers()}";
			}
		}

		protected override void Read(NpgsqlDataReader reader)
		{
			Result.Add(new Counter(reader));
		}
	}
}