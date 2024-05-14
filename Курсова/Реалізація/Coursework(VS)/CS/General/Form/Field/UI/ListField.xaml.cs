using System.Windows.Controls;
using System.Windows.Media;

namespace CS.General.Form.Field
{
	public partial class ListField : UserControl
	{
		public int Selected
		{
			get => Combo.SelectedIndex;
			set => Combo.SelectedIndex = value;
		}

		public string Title
		{
			get => Header.Text;
			set => Header.Text = value;
		}

		public ComboList List { set => Combo.ItemsSource = Database.ComboLists[value]; }

		public ListField()
		{
			InitializeComponent();
		}

		public void ShowCorrectness(bool corrct)
		{
			Header.Foreground = corrct ? Brushes.Black : Brushes.Red;
		}
	}
}