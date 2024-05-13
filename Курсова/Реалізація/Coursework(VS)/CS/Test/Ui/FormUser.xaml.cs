using CS.General.Form.Logic;
using System.Windows;

namespace CS.Test.Ui
{
	/// <summary>
	/// Interaction logic for FormUser.xaml
	/// </summary>
	public partial class FormUser : Window, IFormUser
	{
		public FormUser()
		{
			InitializeComponent();
		}

		public void ReturnTo()
		{
			Show();
		}

		private void Authorize_Click(object sender, RoutedEventArgs e)
		{
			new Form(new Authorization()).Open(new FormHAndler(), this);
        }
    }
}