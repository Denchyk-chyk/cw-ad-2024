namespace CS.General.Form.Field.UI
{
	public interface IFieldUi
	{
		public string Title { get; set; }
		public bool IsEnabled { get; set; }

		public void ShowCorrectness(bool correct);
	}
}