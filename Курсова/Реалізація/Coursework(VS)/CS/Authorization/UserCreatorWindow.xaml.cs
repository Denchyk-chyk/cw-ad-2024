using CS.General.Form.Field.Logic;
using Input = CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CS.General;

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

		public void Open(Form logic)
		{
			Show();
			Buttons.Connect(logic);
		}
	}
}
