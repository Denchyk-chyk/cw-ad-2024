using CS.Output.Items.Product;
using Npgsql;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.First
{
	public class Query : Queries.Query
	{
		protected override void Read(NpgsqlDataReader reader) => Result.Add(new FullProduct(reader));

		protected override string Select()
		{
			return 
				"select * from (select id, name as category from product_categories) pc " +
					"join products op on pc.id = op.category " +
					"left join cars c on op.id = c.id " +
					"left join bikes on op.id = bikes.id " +
					"left join buses on op.id = buses.id " +
					"left join trucks tk on op.id = tk.id " +
					"left join tractors tr on op.id = tr.id " +
					"left join excavator e on op.id = e.id " +
				"where op.id in ( " +
					"select distinct p.id from products p " +
						"join brigades_specialization bs on p.id = bs.product " +
						"join brigades b on b.id = bs.id " +
						"join sites s on s.id = b.site " +
						"join workshops w on w.id = s.workshop " +
					$"where " +
						CheckOptional(Input.Tag.ProductCategory, "category") +
						" and " +
						CheckOptional(Input.Tag.Workshop, "workshop") +
					");"
			;
		}
	}
}