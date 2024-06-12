using System.Windows;

namespace CS.Output
{
	public partial class DisplayUi : Window
	{
		private string[] _text;

		public DisplayUi()
		{
			InitializeComponent();
			Topmost = true;
		}

		public void GetData(string[] text)
		{
			_text = text;
			Output.Text = string.Empty;
			Output.Text += string.Join("\n\n", _text);
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			Saver.SaveText(Output.Text);
		}
	}
}