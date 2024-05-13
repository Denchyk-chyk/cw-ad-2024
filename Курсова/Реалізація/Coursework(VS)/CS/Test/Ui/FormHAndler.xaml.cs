using CS.General;
using CS.General.Form.Logic;
using System.Windows;
using System.Windows.Documents;
using Input = CS.General.Form.Field.Logic;

namespace CS.Test.Ui
{
	/// <summary>
	/// Interaction logic for FormHAndler.xaml
	/// </summary>
	public partial class FormHAndler : Window, IFormHandler
	{
		public FormHAndler()
		{
			InitializeComponent();
		}

		public bool Get(FormData data)
		{
			if ((int)data[Input.Tag.Age] < 18)
			{
				data.Form.Reopen(data.CreateFeedback("Замалий вік", (Input.Tag.Age, 18)));
				return false;
			}

			Show();

			Block.Text =
				$"Ім'я {data[Input.Tag.Name]}\n" +
				$"Прізвище {data[Input.Tag.Surname]}\n" +
				$"Вік {data[Input.Tag.Age]}\n" +
				$"Стать {Storage.ComboLists[ComboList.Gender][(int)data[Input.Tag.Gender]]}";

			return true;
		}
	}
}