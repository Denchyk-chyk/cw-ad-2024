using Input = CS.General.Form.Logic;
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

		public void Connect(Input.Form form)
		{
			Submit.Click += (object sender, RoutedEventArgs e) => form.Send();
			Cancel.Click += (object sender, RoutedEventArgs e) => form.Close();
		}
	}
}