using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.Test.Ui
{
	/// <summary>
	/// Interaction logic for Authorization.xaml
	/// </summary>
	public partial class Authorization : Window, IFormUi
	{
		public Form Form { get; set; }
		public List<Field> Fields { get; }

		public Authorization()
		{
			InitializeComponent();
			Fields = [];
			Fields.Add(new StringField(Name, Input.Tag.Name));
			Fields.Add(new StringField(Surname, Input.Tag.Surname));
			Fields.Add(new IntegerField(Age, Input.Tag.Age));
			Fields.Add(new EnumField(Gender, General.ComboList.Gender, Input.Tag.Gender));
		}

		public void Open(Form form)
		{
			Show();
			Buttons.Connect(form);
		}

		public void Enable()
		{
			Show();
		}

		public void Disable()
		{
			Hide();
		}

		public void Delete()
		{
			Close();
		}
	}
}