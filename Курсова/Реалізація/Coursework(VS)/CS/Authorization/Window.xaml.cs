using CS.Authorization;
using CS.General;
using CS.General.Form.Logic;
using System.Windows;

namespace CS
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, IFormUser
	{
		public static Dictionary<AuthorizationStatus, bool[]> _statuses = [];
		public void SetStatus()
		{
			Connection.IsEnabled = _statuses[Database.Status][0];
			Creating.IsEnabled = _statuses[Database.Status][1];
			Editing.IsEnabled = _statuses[Database.Status][2];
		}

		public MainWindow()
		{
			InitializeComponent();
			SetStatus();
		}

		static MainWindow()
		{
			_statuses[AuthorizationStatus.None] = [true, false, false];
			_statuses[AuthorizationStatus.User] = [true, false, true];
			_statuses[AuthorizationStatus.Admin] = [true, true, true];
		}

		private void Editing_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Creating_Click(object sender, RoutedEventArgs e)
		{
			new Form(new UserCreatorWindow()).Open(UserCreator.Instant(), this);
			Hide();
		}

		private void Connection_Click(object sender, RoutedEventArgs e)
		{
			new Form(new ServerConnectorWindow()).Open(ServerConnector.Instant(), this);
			Hide();
		}

		public void ReturnTo()
		{
			Show();
			SetStatus();
		}
	}

	public enum AuthorizationStatus
	{
		None, User, Admin
	}
}