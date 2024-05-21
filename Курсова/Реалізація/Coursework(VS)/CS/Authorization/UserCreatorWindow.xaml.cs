using CS.General;
using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.Authorization
{
	/// <summary>
	/// Interaction logic for UserAddingWindow.xaml
	/// </summary>
	public partial class UserCreatorWindow : Window, IFormUi
	{
		public List<Field> Fields { get; private set; }

		public UserCreatorWindow()
		{
			InitializeComponent();
			Fields = [
				new StringField(Name, Input.Tag.Name),
				new StringField(Password, Input.Tag.Password),
				new EnumField(Type, ComboList.UserType, Input.Tag.Type)];
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

		public void Open(Action send, Action close)
		{
			Show();
			Buttons.Connect(send, close);
		}
	}
}
