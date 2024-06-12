using CS.General.Form.Field.UI;
using System.Windows.Controls;
using System.Windows.Media;

namespace CS.General.Form.Field
{
	public partial class TextField : UserControl, ITextFieldUi
	{
		public string Title
		{
			get => Header.Text;
			set => Header.Text = value;
		}

		public string Text
		{
			get => Field.Text;
			set => Field.Text = value;
		}

		public void ShowCorrectness(bool correct)
		{
			Header.Foreground = correct ? Brushes.Black : Brushes.Red;
		}

		public TextField()
		{
			InitializeComponent();
		}
	}
}