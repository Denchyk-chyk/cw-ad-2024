using CS.General;
using System.Windows;
using System.Windows.Controls;

namespace CS.Queries
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private static (string Name, string Tooltip)[] _reportingText;
		private static (string Name, string Tooltip)[] _recordingText;

		public MainWindow()
		{
			InitializeComponent();
			CreateButtons(Reporting, 2, _reportingText);
			CreateButtons(Recording, 1, _recordingText);
			FinishInit();
		}

		static MainWindow()
		{
			_reportingText =
			[
				("1", "A"),
				("2", "B"),
				("3", "C"),
				("4", "D"),
				("5", "E"),
				("6", "F"),
				("7", "G"),
				("8", "H"),
				("9", "J"),
				("10", "I"),
				("11", "K"),
				("12", "L"),
				("13", "M"),
				("14", "N")
			];

			_recordingText =
			[
				("1", "A"),
				("2", "B"),
				("3", "C"),
				("4", "D")
			];
		}

		private void FinishInit()
		{
			Recording.IsEnabled = Database.Status == AuthorizationStatus.Admin;
			User.Content = Database.Connection.UserName;
		}

		private void CreateButtons(Grid grid, int width, (string Name, string Tooltip)[] text)
		{

			for (int i = 0; i < width; i++) grid.ColumnDefinitions.Add(new ColumnDefinition());
			for (int i = 0; i <= text.Length / width; i++) grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

			grid.RowDefinitions[^1].Height = new GridLength(1, GridUnitType.Star);
			var buttons = new Button[text.Length];

			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i] = new()
				{
					Content = text[i].Name,
					ToolTip = text[i].Tooltip,
					Style = (Style)FindResource("DefaultButton")
				};

				grid.Children.Add(buttons[i]);
				Grid.SetRow(buttons[i], i / width);
				Grid.SetColumn(buttons[i], i % width);
			}
		}

		private void User_Click(object sender, RoutedEventArgs e)
		{
			new CS.MainWindow().Show();
			Close();
		}
	}
}