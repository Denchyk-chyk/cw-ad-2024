using Npgsql;

namespace CS.General
{
	internal static class Database
	{
		public static NpgsqlConnection Connection { get; private set; }
		public static ConnectionStatus Status { get; set; }
		public static Dictionary<ComboList, List<string>> ComboLists { get; private set; }

		public static void Load(NpgsqlConnection connection)
		{
			Connection = connection;
			Connection.Open();

			Load("select name from workshops order by id;", ComboList.Workshop);
			Load("select name || ' ('|| id::text || ')' from sites order by id;", ComboList.Site);
			Load("select name from product_categories order by id;", ComboList.ProductCategory);
			Load("select name from products order by id;", ComboList.Product);
			Load("select name from engineer_categories order by id;", ComboList.Engineer);
			Load("select name from laborer_categories order by id;", ComboList.Laborer);
			Load("select name from laboratories order by id;", ComboList.Laboratory);
		}

		private static void Load(string query, ComboList list)
		{
			ComboLists[list] = [];
			using (var command = new NpgsqlCommand(query, Connection))
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					ComboLists[list].Add(reader.GetString(0));
				}
			}
		}

		static Database()
		{
			ComboLists = new Dictionary<ComboList, List<string>>
			{
				[ComboList.Unit] = ["Підприємство", "Цех", "Ділянка"],
				[ComboList.EmployeeCategory] = ["Весь", "Інженерно-технічний", "Робітники"],
				[ComboList.ProductsPart] = ["Всі", "Певної категорії", "Конкретний виріб"]
			};
		}
	}

	public enum ComboList
	{
		Unit, Workshop, Site, ProductCategory, Product, EmployeeCategory, Engineer, Laborer, Laboratory, ProductsPart
	}
}