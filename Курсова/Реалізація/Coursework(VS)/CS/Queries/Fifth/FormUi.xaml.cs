using CS.General;
using CS.General.Form.Container;
using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Fifth
{
	public partial class FormUi : Window, IFormUi
	{
		public Container Container { get; private set; }

		public FormUi()
		{
			InitializeComponent();
			Container = new Container([new EnumField(Product, ComboList.Product, Input.Tag.Product)]);
		}

		public void Open(Action send, Action close)
		{
			Show();
			Buttons.Connect(send, close);
		}
	}
}
