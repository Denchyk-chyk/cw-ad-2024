using CS.General.Form.Container;
using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Twelfth
{
	public partial class FormUi : Window, IFormUi
	{
		public Container Container { get; private set; }

		public FormUi()
		{
			InitializeComponent();
			Container = new Container([
				new EnumField(ProductsPart, General.ComboList.ProductsPart, Input.Tag.ProductsPart),
				new EnumField(ProductCategory, General.ComboList.ProductCategory, Input.Tag.ProductCategory),
				new EnumField(Product, General.ComboList.Product, Input.Tag.Product),
				new OptionalEnumField(Laboratory, General.ComboList.Laboratory, Input.Tag.Laboratory),
				], [[1, 2], [2], [1]] );

			ProductsPart.SetEvent((n) => Container.Activate(n));
		}

		public void Open(Action send, Action close)
		{
			Show();
			Buttons.Connect(send, close);
		}
	}
}
