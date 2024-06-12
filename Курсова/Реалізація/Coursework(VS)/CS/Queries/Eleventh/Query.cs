using CS.Output.Items;
using CS.Output.Items.Product;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Eleventh
{
	internal class Query : Queries.Query
	{
		private List<Production> _products = [];

		protected override void Read(NpgsqlDataReader reader) => Production.Add(_products, new ProductTesting(reader));

		protected override List<Displayable> Write() => _products.Select(e => (Displayable)e).ToList();

		protected override string Select()
		{
			return
				"select distinct p.id, pr.time, p.name, pc.name as category, count(pr.product) / count(pr.product) as count from production pr " +
					"join products p on pr.product = p.id " +
					"join product_categories pc on p.category = pc.id " +
					"join brigades_specialization bs on p.id = bs.product " +
					"join brigades b on b.id = bs.id " +
					"join sites s on s.id = b.site " +
					"join public.testing t on p.category = t.product " +
					"join laboratories l on t.laboratory = l.id " +
				$"where " +
					$"pr.time > '{Form[Input.Tag.FirstDate]}'::date and pr.time < '{Form[Input.Tag.LastDate]}'::date " +
					" and " +
					CheckOptional(Input.Tag.ProductCategory, "pr.product") +
					" and " +
					$"l.id = {(int)Form[Input.Tag.Laboratory] + 1} " +
				"group by p.id, p.name, pc.name, pr.time " +
				"order by pr.time;"
			;
		}
	}
}