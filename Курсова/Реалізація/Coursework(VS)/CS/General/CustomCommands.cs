using System.Windows.Input;

namespace CS.General
{
	public static class CustomCommands
	{
		public static readonly RoutedUICommand FillCommand = new(
			"Fill in with test data command",
			"FillCommand",
			typeof(CustomCommands),
			[new KeyGesture(Key.F, ModifierKeys.Control | ModifierKeys.Shift | ModifierKeys.Alt)]
		);
	}
}