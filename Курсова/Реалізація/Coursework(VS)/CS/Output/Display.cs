using CS.Output.Items;
using System.Windows;

namespace CS.Output
{
    public static class Display
	{
		private static DisplayUi? _ui;

		public static void Output(List<Displayable> data)
		{
			if (_ui == null)
			{
				_ui = new DisplayUi();
				_ui.Closed += (s, e) => _ui = null;
				_ui.Show();
			}
			else
			{
				if (_ui.WindowState == WindowState.Minimized) 
					_ui.WindowState = WindowState.Normal;
			}

			_ui.GetData([.. data.Select(e => e.Display())]);
		}
	}
}