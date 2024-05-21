using System.Windows;
using System.Windows.Controls;

namespace CS.General.Form
{
	/// <summary>
	/// Interaction logic for FormButtons.xaml
	/// </summary>
	public partial class FormButtons : UserControl
	{
		public FormButtons()
		{
			InitializeComponent();
		}

		public void Connect(Action send, Action close)
		{
			Submit.Click += (object sender, RoutedEventArgs e) => send();
			Cancel.Click += (object sender, RoutedEventArgs e) => close();
		}
	}
}