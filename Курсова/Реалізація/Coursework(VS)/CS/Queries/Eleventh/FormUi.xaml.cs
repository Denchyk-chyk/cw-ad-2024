using CS.General;
using CS.General.Form.Container;
using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Eleventh
{
	public partial class FormUi : Window, IFormUi
	{
		public Container Container { get; private set; }

		public FormUi()
		{
			InitializeComponent();

			Container = new Container([
				new OptionalEnumField(ProductCategory, ComboList.ProductCategory, Input.Tag.ProductCategory),
				new EnumField(Laboratory, ComboList.Laboratory, Input.Tag.Laboratory),
				new StringField(FirstDate, Input.Tag.FirstDate),
				new StringField(LastDate, Input.Tag.LastDate)
				]);
		}

		public void Open(Action send, Action close)
		{
			Show();
			Buttons.Connect(send, close);
		}

		private void FillCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
		{
			FirstDate.Text = "2022-02-22";
			LastDate.Text = "2024-04-24";
		}
	}
}