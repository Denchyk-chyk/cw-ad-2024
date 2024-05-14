using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.Authorization
{
	/// <summary>
	/// Interaction logic for ServerConnectionWindow.xaml
	/// </summary>
	public partial class ServerConnectorWindow : Window, IFormUi
	{
		public List<Field> Fields { get; set; }

		public ServerConnectorWindow()
		{
			InitializeComponent();
			Fields = [
				new StringField(Host, Input.Tag.Host),
				new StringField(Database, Input.Tag.Database),
				new StringField(Name, Input.Tag.Name),
				new StringField(Password, Input.Tag.Password)];
		}

		public void Delete()
		{
			Close();
		}

		public void Disable()
		{
			Hide();
		}

		public void Enable()
		{
			Show();
		}

		public void Open(Form logic)
		{
			Show();
			Buttons.Connect(logic);
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