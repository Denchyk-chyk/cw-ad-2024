using CS.Authorization;
using CS.General;
using CS.General.Form.Logic;
using System.Windows;

namespace CS
{
	public partial class MainWindow : Window, IFormUser
	{
		private static Dictionary<ConnectionStatus, bool[]> _statuses = [];

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
			_statuses[ConnectionStatus.None] = [true, false, false];
			_statuses[ConnectionStatus.Connected] = [true, true, true];
		}

		private void Editing_Click(object sender, RoutedEventArgs e)
		{
			new Queries.MainWindow().Show();
			Close();
		}

		private void Creating_Click(object sender, RoutedEventArgs e)
		{
			new Form(new UserCreatorWindow()).Open(this, UserCreator.Instant());
			Hide();
		}

		private void Connection_Click(object sender, RoutedEventArgs e)
		{
			new Form(new ServerConnectorWindow()).Open(this, ServerConnector.Instant());
			Hide();
		}

		public void ReturnTo()
		{
			Show();
			SetStatus();
		}
	}

	public enum ConnectionStatus
	{
		None, Connected
	}
}