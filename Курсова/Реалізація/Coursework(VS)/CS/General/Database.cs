using Npgsql;

namespace CS.General
{
	internal static class Database
	{
		public static NpgsqlConnection Connection { get; set; }
		public static AuthorizationStatus Status { get; set; }
		public static Dictionary<ComboList, string[]> ComboLists { get; private set; }

		static Database()
		{
			ComboLists = new Dictionary<ComboList, string[]>();
			ComboLists[ComboList.Gender] = ["Чоловіча", "Жіноча"];
			ComboLists[ComboList.UserType] = ["Користувач", "Адміністратор"];
		}
	}

	public enum ComboList
	{
		Gender, UserType
	}

	public enum UserType
	{
		User, Admin
	}
}