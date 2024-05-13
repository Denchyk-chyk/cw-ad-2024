namespace CS.General
{
	internal static class Storage
	{
		public static Dictionary<ComboList, string[]> ComboLists { get; private set; }

		static Storage()
		{
			ComboLists = new Dictionary<ComboList, string[]>();
			ComboLists[ComboList.Gender] = ["Чоловіча", "Жіноча"];
		}
	}

	public enum ComboList
	{
		Gender
	}
}