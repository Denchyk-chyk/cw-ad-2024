using CS.General.Form.Container;
using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.Authorization
{
	public partial class ServerConnectorWindow : Window, IFormUi
	{
		public Container Container { get => _container; }

		private Container _container;

		public ServerConnectorWindow()
		{
			InitializeComponent();
			_container = new Container([
				new StringField(Host, Input.Tag.Host),
				new StringField(Database, Input.Tag.Database),
				new StringField(Name, Input.Tag.Name),
				new StringField(Password, Input.Tag.Password)]);
		}

		public void Open(Action send, Action close)
		{
			base.Show();
			Buttons.Connect(send, close);
		}

		private void FillCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
		{
			Host.Text = "127.0.0.1";
			Database.Text = "factory";
			Name.Text = "postgres";
			Password.Text = "ip-22-1-28";
        }
	}
}