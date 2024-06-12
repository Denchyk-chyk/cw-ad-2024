using CS.Output.Items;
using CS.Output.Items.Product;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Eighth
{
	internal class Query : Queries.Query
	{
		private List<Displayable> _products = [];

		protected override string Select()
		{
			return
				"select distinct p.id, p.name, pc.name as category, count(pr.product) from production pr " +
					"left join products p on pr.product = p.id " +
					"left join product_categories pc on p.category = pc.id " +
					"left join brigades_specialization bs on p.id = bs.product " +
					"left join brigades b on b.id = bs.id " +
					"left join sites s on s.id = b.site " +
					"left join workshops w on w.id = s.workshop " +
				"where " +
					"pr.time > now()" +
					" and " +
					CheckOptional(Input.Tag.ProductCategory, "category") +
					" and " +
					CheckSwitch(Input.Tag.Unit, [(Input.Tag.Workshop, "workshop", 1), (Input.Tag.Site, "site", 1)]) +
				" group by p.id, p.id, p.name, pc.name" +
				" order by p.id;"
			;
		}

		protected override void Read(NpgsqlDataReader reader)
		{
			_products.Add(new ProductionSummary(reader));
		}

		protected override List<Displayable> Write() => _products;
	}
}