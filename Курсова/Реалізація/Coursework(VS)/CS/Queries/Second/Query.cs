using CS.Output.Items;
using CS.Output.Items.Product;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Second
{
	internal class Query : Queries.Query
	{
		private List<Production> _products = [];
		
		protected override void Read(NpgsqlDataReader reader) => Production.Add(_products, reader);

		protected override List<Displayable> Write() => _products.Select(e => (Displayable)e).ToList();

		protected override string Select()
		{
			return
				"select distinct p.id, p.name, pr.time, pc.name as category, count(pr.product) from production pr " +
					"left join products p on pr.product = p.id " + 
					"left join product_categories pc on p.category = pc.id " +
					"left join brigades_specialization bs on p.id = bs.product " +
					"left join brigades b on b.id = bs.id " +
					"left join sites s on s.id = b.site " +
					"left join workshops w on w.id = s.workshop " +
				$"where " +
				$"pr.time > '{Form[Input.Tag.FirstDate]}'::date and pr.time < '{Form[Input.Tag.LastDate]}'::date" +
					" and " +
					CheckOptional(Input.Tag.ProductCategory, "category") +
					" and " +
					CheckSwitch(Input.Tag.Unit, [(Input.Tag.Workshop, "workshop", 1), (Input.Tag.Site, "site", 1)]) +
				" group by p.id, p.name, pc.name, pr.time" +
				" order by pr.time;"
			;
		}
	}
}