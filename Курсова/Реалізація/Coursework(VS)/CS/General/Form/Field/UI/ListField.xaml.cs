using CS.General.Form.Field.UI;
using System.Windows.Controls;
using System.Windows.Media;

namespace CS.General.Form.Field
{
	public partial class ListField : UserControl, IFieldUi
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

		private int _previousSelected = -1;

		public ComboList List { set => Combo.ItemsSource = Database.ComboLists[value]; }

		public void SetEvent(Action<int> action)
		{
			Combo.SelectionChanged += (s, e) => action(Selected);
		}

		public ListField()
		{
			InitializeComponent();
		}

		public void ShowCorrectness(bool correct)
		{
			Header.Foreground = correct ? Brushes.Black : Brushes.Red;
		}

		private void Combo_DropDownClosed(object sender, EventArgs e)
		{
			if (_previousSelected == Selected) Selected = -1;
			else _previousSelected = Selected;
		}
	}
}