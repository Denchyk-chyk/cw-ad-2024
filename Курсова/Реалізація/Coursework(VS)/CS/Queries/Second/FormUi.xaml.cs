using CS.General;
using CS.General.Form.Container;
using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Second
{
	public partial class FormUi : Window, IFormUi
	{
		public Container Container { get; private set; }

		public FormUi()
		{
			InitializeComponent();

			Container = new Container([
				new OptionalEnumField(Category, ComboList.ProductCategory, Input.Tag.ProductCategory),
				new EnumField(Unit, ComboList.Unit, Input.Tag.Unit),
				new EnumField(Workshop, ComboList.Workshop, Input.Tag.Workshop),
				new EnumField(Site, ComboList.Site, Input.Tag.Site),
				new StringField(FirstDate, Input.Tag.FirstDate),
				new StringField(LastDate, Input.Tag.LastDate),
				], [[2, 3], [3], [2]]);

			Unit.SetEvent((n) => Container.Activate(n));
		}

		public void Open(Action send, Action close)
		{
			Show();
			Buttons.Connect(send, close);
		}

		private void FillCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
		{
			Unit.Selected = 0;
			FirstDate.Text = "2022-02-22";
			LastDate.Text = "2024-04-24";
		}
	}
}