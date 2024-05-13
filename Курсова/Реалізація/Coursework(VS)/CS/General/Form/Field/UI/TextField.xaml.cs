using System.Windows.Controls;
using System.Windows.Media;

namespace CS.General.Form.Field
{
	public partial class TextField : UserControl
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

		public void ShowCorrectness(bool corrct)
		{
			Header.Foreground = corrct ? Brushes.Black : Brushes.Red;
		}

		public TextField()
		{
			InitializeComponent();
		}
	}
}