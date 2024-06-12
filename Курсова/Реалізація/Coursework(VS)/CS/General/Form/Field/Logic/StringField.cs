using CS.General.Form.Field.UI;

namespace CS.General.Form.Field.Logic
{
	public class StringField(ITextFieldUi ui, Tag tag) : Field(tag)
    {
		public override IFieldUi UiPart => Ui;

		protected ITextFieldUi Ui { get; private set; } = ui;

		public override bool TryRead(out object value)
        {
            value = Ui.Text;
			bool result = Ui.Text.Length > 0;
			ShowCorrectness(result);
			return result;
        }

		public override void Write(object value)
		{
			Ui.Text = value.ToString();
			ShowCorrectness(false);
		}

		protected override void ShowCorrectness(bool correct)
		{
			Ui.ShowCorrectness(correct);
		}
	}
}