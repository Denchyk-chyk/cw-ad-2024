using CS.Output.Items.Product;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Fourteenth
{
	internal class Query : Queries.Query
	{
		protected override void Read(NpgsqlDataReader reader) => Result.Add(new FullProductionSummary(reader));

		protected override string Select()
		{
			return
				"select * from (select id, name as category from product_categories) pc " +
					"join products p on pc.id = p.category " +
					"join lateral ( " +
						"select distinct p1.id as main_id, pc1.id, count(pr.product) from production pr " +
						"left join products p1 on pr.product = p1.id " +
						"left join product_categories pc1 on p1.category = pc1.id " +
						"left join brigades_specialization bs on p.id = bs.product " +
						"left join brigades b on b.id = bs.id " +
						"left join sites s on s.id = b.site " +
						"left join workshops w on w.id = s.workshop " +
						"where " +
							"pr.time > now() " +
							" and " +
							CheckOptional(Input.Tag.ProductCategory, "p1.category") +
							" and " +
							CheckSwitch(Input.Tag.Unit, [(Input.Tag.Workshop, "w.id", 1), (Input.Tag.Site, "s.id", 1)]) +
						" group by p1.id, pc1.id " +
						"order by p1.id) as info " +
						"on p.id = info.main_id " +
					"left join cars c on p.id = c.id " +
					"left join bikes on p.id = bikes.id " +
					"left join buses on p.id = buses.id " +
					"left join trucks tk on p.id = tk.id " +
					"left join tractors tr on p.id = tr.id " +
					"left join excavator e on p.id = e.id"
			;
		}
	}
}