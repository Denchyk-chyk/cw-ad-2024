using CS.General.Form.Container;
using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.Authorization
{
	public partial class UserCreatorWindow : Window, IFormUi
	{
		public Container Container { get => _container; }

		private Container _container;

		public UserCreatorWindow()
		{
			InitializeComponent();
			_container = new Container([
				new StringField(Name, Input.Tag.Name),
				new StringField(Password, Input.Tag.Password)]);
		}

		public void Open(Action send, Action close)
		{
			Show();
			Buttons.Connect(send, close);
		}
	}
}
