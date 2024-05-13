namespace CS.General.Form.Field.Logic
{
	internal class EnumField : Field
	{
		protected ListField Ui { get; private set; }

		public EnumField(ListField ui, ComboList type, Tag tag) : base(tag)
		{
			Ui = ui;
			Ui.List = type;
		}

		public override bool TryRead(out object value)
		{
			value = Ui.Selected;
			bool result = Ui.Selected > -1;
			ShowCorrectness(result);
			return result;
		}
  
		public override void Write(object value)
		{
			Ui.Selected = (int)value;
		}

		protected override void ShowCorrectness(bool correct)
		{
			Ui.ShowCorrectness(correct);
		}
	}
}