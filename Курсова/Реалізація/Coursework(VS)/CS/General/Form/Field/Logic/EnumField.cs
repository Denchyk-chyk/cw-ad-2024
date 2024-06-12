using CS.General.Form.Field.UI;

namespace CS.General.Form.Field.Logic
{
	internal class EnumField : Field
	{
		public override IFieldUi UiPart => Ui;

		protected ListField Ui { get; private set; }

		public EnumField(ListField ui, ComboList type, Tag tag) : base(tag)
		{
			Ui = ui;
			Ui.List = type;
		}

		protected virtual bool Check() => Ui.Selected > -1;

		public override bool TryRead(out object value)
		{
			value = Ui.Selected;
			bool result = Check();
			ShowCorrectness(result);
			return result;
		}
  
		public override void Write(object value)
		{
			Ui.Selected = (int)value;
			ShowCorrectness(false);
		}

		protected override void ShowCorrectness(bool correct)
		{
			Ui.ShowCorrectness(correct);
		}
	}
}